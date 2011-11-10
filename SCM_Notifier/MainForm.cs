//
// SCM Notifier
// Copyright Sung-Ho Lee
// SCM Notifier is forked from SVN Notifier. Part of this program is copyrighted by SVN Notifier authors
//
//
// SVN Notifier
// Copyright 2007 SIA Computer Hardware Design (www.chd.lv)
//
// This file is part of SVN Notifier.
//
// SVN Notifier is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
//
// SVN Notifier is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>
//

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using DragNDrop;


namespace pocorall.SCM_Notifier
{
	public partial class MainForm : Form
	{
		[DllImport("psapi")]
		private static extern int EmptyWorkingSet(IntPtr handle);

		private readonly Hashtable errorLog = new Hashtable();
		private bool reupdateStatus;
		private readonly ManualResetEvent updateNotInProgress = new ManualResetEvent (true);
		private readonly Queue forcedFolders = Queue.Synchronized (new Queue());
		private bool timerEnabledWhenSuspended = true;


		public MainForm()
		{
			InitializeComponent();

			if (Config.HideOnStartup)
			{
				WindowState = FormWindowState.Minimized;
				ShowInTaskbar = false;
			}
			else
				ShowInTaskbar = Config.ShowInTaskbar;

            ScmRepository.ErrorAdded += OnErrorAdded;
			
			AddPowerEventListener();

			FormInit();
		}

		private void AddPowerEventListener()
		{
			Microsoft.Win32.SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
		}

		private void RemovePowerEventListener()
		{
			// Static events must be removed when application closes to avoid memory leaks
			Microsoft.Win32.SystemEvents.PowerModeChanged -= SystemEvents_PowerModeChanged;
		}

		void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
		{
			switch (e.Mode )
			{
				case Microsoft.Win32.PowerModes.Suspend:
					timerEnabledWhenSuspended = statusUpdateTimer.Enabled;
					statusUpdateTimer.Stop();
					break;
				case Microsoft.Win32.PowerModes.Resume:
					pauseTimer.Stop();
					if (timerEnabledWhenSuspended)
					{
						pauseTimer.Interval = 1000 * Config.PauseAfterWindowsResumeInterval;
						pauseTimer.Start();
					}
					break;
			}
		}

		private void FormInit()
		{
			listViewFolders.Clear();

			folders = Config.ReadSvnFolders();

			foreach (ScmRepository folder in folders)
			{
                ListViewItem item = new ListViewItem(folder.Path, folder.ImageIndex());

				if (folder.Disable)
				{
					item.Font = new Font (listViewFolders.Font, FontStyle.Strikeout);
					item.ForeColor = Color.LightGray;
				}

				listViewFolders.Items.Add (item);
			}

			UpdateFormSize();

			UpdateListViewFolderNames();

			if (Config.PauseAfterApplicationStartupInterval > 0)
			{
				pauseTimer.Interval = 1000 * Config.PauseAfterApplicationStartupInterval;
			}
			pauseTimer.Enabled = Config.DoPauseAfterApplicationStartup && Config.PauseAfterApplicationStartupInterval > 0;
		}


		private void UpdateFormSize()
		{
			int[] size = Config.ReadMainFormSize();

			if ((size[0] == 0) || (size[1] == 0))
			{
				Config.SaveMainFormSize (Width, Height);
			}
			else
			{
				Width = size[0];
				Height = size[1];
			}
		}

		//////////////////////////////////////////////////////////////////////////////

		#region Main menu handlers


		private void menuItemExportConfig_Click (object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog
			{
				FileName = "SCM_Notifier.ini",
				Filter = "Ini files (*.ini)|*.ini|All files (*.*)|*.*",
				RestoreDirectory = true
			};

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					File.Copy (Config.iniFileName, sfd.FileName, true);
				}
				catch (Exception ex)
				{
					ShowError (ex.Message);
				}
			}
		}


		private void menuItemImportConfig_Click (object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog
			{
				Filter = "Ini files (*.ini)|*.ini|All files (*.*)|*.*",
				RestoreDirectory = true
			};

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				if ((folders.Count > 0) && MessageBox.Show ("All current settings will be lost.\n\nDo you really want to change the settings?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
					return;
				
				try
				{
					File.Copy (ofd.FileName, Config.iniFileName, true);
					Config.Init();

					// Check for correct import configs
					if (!Config.IsSettingsOK())
					{
						Hide();
						statusUpdateTimer.Stop();
						notifyIcon.Icon = trayIcon_Unknown;

						if (new SettingsForm().ShowDialog() != DialogResult.OK)
						{
							Application.Exit();
							return;
						}
						ShowInTaskbar = Config.ShowInTaskbar;
						Show();
					}

					FormInit();
				}
				catch (Exception ex)
				{
					ShowError (ex.Message);
				}
			}
		}


		private void menuItemSettings_Click (object sender, EventArgs e)
		{
			new SettingsForm().ShowDialog (this);
			ShowInTaskbar = Config.ShowInTaskbar;
			UpdateTray (false);						// To enable/disable "Update All" command
		}


		private void menuItemExit_Click (object sender, EventArgs e)
		{
			Application.Exit();
		}


		private void menuItemAbout_Click (object sender, EventArgs e)
		{
			new AboutForm().ShowDialog (this);
		}


		private void menuItemUpdateAll_Click (object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
			UpdateAll();
		}

        private void AddFolder(string path)
        {
            if (!folders.ContainsPath(path))
            {
                ScmRepository repo = ScmRepository.create(path);

                if(repo !=null) 
                {
                    folders.Add(repo);
                    listViewFolders.Items.Add(new ListViewItem(path, repo.ImageIndex()));
                    UpdateListViewFolderNames();

                    Config.SaveSvnFolders(folders);

                    UpdateTray(false);
                    BeginUpdateFolderStatuses();
                }
                else
                {
                    MessageBox.Show("This folder is not under SVN", "SCM Notifier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                SelectFolder(path);
        }

		private void menuItemAddFolder_Click (object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				string path = folderBrowserDialog.SelectedPath;

                AddFolder(path);
			}
		}

        private void AddFile(string fileName)
        {
            string path = Path.GetDirectoryName(fileName);

            if (!folders.ContainsPath(fileName))
            {
                if (Directory.Exists(path + @"\.svn") || Directory.Exists(path + @"\_svn"))
                {
                    SvnRepository repo = new SvnRepository(fileName, ScmRepository.PathType.File);
                    folders.Add(repo);

                    listViewFolders.Items.Add(new ListViewItem(fileName, repo.ImageIndex()));
                    UpdateListViewFolderNames();

                    Config.SaveSvnFolders(folders);

                    UpdateTray(false);
                    BeginUpdateFolderStatuses();
                }
                else
                {
                    MessageBox.Show("This file is not under SCM", "SCM Notifier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                SelectFolder(fileName);
        }

		private void menuItemAddFile_Click (object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string fileName = openFileDialog.FileName;			

                AddFile(fileName);
			}
		}


		private void menuItemDelete_Click (object sender, EventArgs e)
		{
			if (listViewFolders.SelectedIndices.Count > 0)
			{
				int selectedIndex = listViewFolders.SelectedIndices[0];
				string path = folders[listViewFolders.SelectedIndices[0]].Path;

				if (MessageBox.Show ("Are you sure to remove " + path + " from list?", "SCM Notifier", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
					return;

				folders.RemoveAt (selectedIndex);

				listViewFolders.Items.RemoveAt (selectedIndex);
				UpdateListViewFolderNames();
				newNonUpdatedFolders.Clear();

				Config.SaveSvnFolders (folders);

				UpdateTray (true);
				BeginUpdateFolderStatuses();
			}
		}


		private void menuItemCheckNewVersion_Click (object sender, EventArgs e)
		{
			forcedCheckForNewVersion = true;
			BeginUpdateFolderStatuses();
		}

		#endregion

		//////////////////////////////////////////////////////////////////////////////

		#region Toolbar button handlers

		private void btnUpdate_Click (object sender, EventArgs e)
		{
			UpdateFolder();
		}


		private void btnCommit_Click (object sender, EventArgs e)
		{
			CommitFolder();
		}


		private void btnOpenFolder_Click (object sender, EventArgs e)
		{
			OpenFolder();
		}


		private void btnChangeLog_Click (object sender, EventArgs e)
		{
			ShowChangeLog();
		}


		private void btnLog_Click (object sender, EventArgs e)
		{
			ShowFullLog();
		}


		#endregion

		//////////////////////////////////////////////////////////////////////////////

		#region Context menu handlers

		private void checkNowToolStripMenuItem_Click (object sender, EventArgs e)
		{
			if (listViewFolders.SelectedIndices.Count == 0)
				return;

			int selectedIndex = listViewFolders.SelectedIndices[0];
			forcedFolders.Enqueue (folders[selectedIndex]);
			BeginUpdateFolderStatuses();
		}


		private void updateToolStripMenuItem_Click (object sender, EventArgs e)
		{
			UpdateFolder();
		}


		private void commitToolStripMenuItem_Click (object sender, EventArgs e)
		{
			CommitFolder();
		}


		private void openToolStripMenuItem_Click (object sender, EventArgs e)
		{
			OpenFolder();
		}


		private void changeLogToolStripMenuItem_Click (object sender, EventArgs e)
		{
			ShowChangeLog();
		}


		private void contextMenuItemLog_Click (object sender, EventArgs e)
		{
			ShowFullLog();
		}


		private void propertiesToolStripMenuItem_Click (object sender, EventArgs e)
		{
			int selectedIndex = listViewFolders.SelectedIndices[0];
			ScmRepository folder = folders[selectedIndex];

			if (new SettingsProjectForm (folder).ShowDialog (this) == DialogResult.OK)
			{
				listViewFolders.Items[selectedIndex].Text = folder.Path;
				if (folder.Disable)
				{
					folder.Status = ScmRepositoryStatus.Unknown;
					listViewFolders.Items[selectedIndex].Font = new Font (listViewFolders.Font, FontStyle.Strikeout);
					listViewFolders.Items[selectedIndex].ForeColor = Color.LightGray;
                    listViewFolders.Items[selectedIndex].ImageIndex = folder.ImageIndex();
				}
				else
				{
					listViewFolders.Items[selectedIndex].Font = listViewFolders.Font;
					listViewFolders.Items[selectedIndex].ForeColor = SystemColors.WindowText;
				}

				newNonUpdatedFolders.Clear();

				UpdateListViewFolderNames();

				Config.SaveSvnFolders (folders);

				UpdateTray (true);
				BeginUpdateFolderStatuses();
			}
		}


		private void contextMenuStrip_Opening (object sender, CancelEventArgs e)
		{
			UpdateContextMenuItem();
		}


		private void UpdateContextMenuItem()
		{
			checkNowToolStripMenuItem.Enabled =
				commitToolStripMenuItem.Enabled =
				updateToolStripMenuItem.Enabled =
				openToolStripMenuItem.Enabled =
				changeLogToolStripMenuItem.Enabled =
				logToolStripMenuItem.Enabled =
				propertiesToolStripMenuItem.Enabled = false;

			if (listViewFolders.SelectedIndices.Count == 0) return;

			int selectedIndex = listViewFolders.SelectedIndices[0];

			switch (folders[selectedIndex].Status)
			{
				case ScmRepositoryStatus.NeedUpdate:
					checkNowToolStripMenuItem.Enabled =
						updateToolStripMenuItem.Enabled =
						openToolStripMenuItem.Enabled =
						changeLogToolStripMenuItem.Enabled =
						logToolStripMenuItem.Enabled =
						propertiesToolStripMenuItem.Enabled = true;
					break;

				case ScmRepositoryStatus.NeedUpdate_Modified:
					checkNowToolStripMenuItem.Enabled =
						commitToolStripMenuItem.Enabled =
						updateToolStripMenuItem.Enabled =
						openToolStripMenuItem.Enabled =
						changeLogToolStripMenuItem.Enabled =
						logToolStripMenuItem.Enabled =
						propertiesToolStripMenuItem.Enabled = true;
					break;

				case ScmRepositoryStatus.UpToDate_Modified:
					checkNowToolStripMenuItem.Enabled =
						commitToolStripMenuItem.Enabled =
						openToolStripMenuItem.Enabled =
						logToolStripMenuItem.Enabled =
						propertiesToolStripMenuItem.Enabled = true;
					break;

				case ScmRepositoryStatus.UpToDate:
					checkNowToolStripMenuItem.Enabled =
						openToolStripMenuItem.Enabled =
						logToolStripMenuItem.Enabled =
						propertiesToolStripMenuItem.Enabled = true;
					break;

				case ScmRepositoryStatus.Unknown:
					checkNowToolStripMenuItem.Enabled =
						openToolStripMenuItem.Enabled =
						propertiesToolStripMenuItem.Enabled = true;
					break;

				case ScmRepositoryStatus.Error:
					checkNowToolStripMenuItem.Enabled =
						openToolStripMenuItem.Enabled =
						propertiesToolStripMenuItem.Enabled = true;
					break;
			}
		}

		#endregion

		//////////////////////////////////////////////////////////////////////////////

		#region Tray menu handlers

		private void menuItem_ShowList_Click (object sender, EventArgs e)
		{
			ShowFolderList();
		}


		private void menuItem_Exit_Click (object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void menuItem_UpdateAll_Click (object sender, EventArgs e)
		{
			UpdateAll();
		}

		#endregion

		////////////////////////////////////////////////////////////////////////////////////

		#region listViewFolders handlers

		private void listViewFolders_SelectedIndexChanged (object sender, EventArgs e)
		{
			if (listViewFolders.SelectedIndices.Count > 0)
			{
				ScmRepository folder = folders[listViewFolders.SelectedIndices[0]];

				btnChangeLog.Enabled = btnUpdate.Enabled = btnLog.Enabled = false;

				if ((folder.Status == ScmRepositoryStatus.NeedUpdate) || (folder.Status == ScmRepositoryStatus.NeedUpdate_Modified))
					btnChangeLog.Enabled = btnUpdate.Enabled = btnLog.Enabled = true;
				else if ((folder.Status == ScmRepositoryStatus.UpToDate) || (folder.Status == ScmRepositoryStatus.UpToDate_Modified))
					btnLog.Enabled = true;

				if ((folder.Status == ScmRepositoryStatus.NeedUpdate_Modified) || (folder.Status == ScmRepositoryStatus.UpToDate_Modified))
					btnCommit.Enabled = true;

				deleteToolStripMenuItem.Enabled = true;
				btnDelete.Enabled = true;
				btnOpenFolder.Enabled = Directory.Exists (folder.Path) || File.Exists (folder.Path);

				Text = Application.ProductName + " - " + folder.Path;
			}
			else
			{
				btnChangeLog.Enabled = false;
				btnUpdate.Enabled = false;
				btnCommit.Enabled = false;
				deleteToolStripMenuItem.Enabled = false;
				btnDelete.Enabled = false;
				btnOpenFolder.Enabled = false;
				btnLog.Enabled = false;

				Text = Application.ProductName;
			}
		}


		private void listViewFolders_KeyDown (object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					menuItemDelete_Click (sender, null);
					break;

				case Keys.Insert:
					menuItemAddFolder_Click (sender, null);
					break;

				case Keys.Enter:
					listViewFolders_DoubleClick (sender, null);
					break;
			}
		}


		private void listViewFolders_DoubleClick(object sender, EventArgs e)
		{
			switch (Config.ItemDoubleClickAction)
			{
				case Config.Action.openAction:
					if (btnOpenFolder.Enabled)
						OpenFolder();
					break;

				case Config.Action.logAction:
					if (btnChangeLog.Enabled)
						ShowChangeLog();
					else if (btnLog.Enabled)
						ShowFullLog();
					break;

				case Config.Action.updateAction:
					if (btnUpdate.Enabled)
						UpdateFolder();
					break;

				case Config.Action.commitAction:
					if (btnCommit.Enabled)
						CommitFolder();
					break;

				case Config.Action.checkNow:
					int selectedIndex = listViewFolders.SelectedIndices[0];
					forcedFolders.Enqueue (folders[selectedIndex]);
					BeginUpdateFolderStatuses();
					break;
			}
		}


		private void listViewFolders_DragDrop(object sender, DragEventArgs e)
		{
            // Determine whether dropped object is a file or folder.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePath = ((string[])e.Data.GetData(DataFormats.FileDrop));
                foreach (string p in filePath)
                {
                    if(File.Exists(p))
                        AddFile(p);
                    else if(Directory.Exists(p))
                        AddFolder(p);
                }                
            }
            else // otherwise assume it is a DragAndDropListView.DragItem
            {
                try
                {
                    DragAndDropListView.DragItemData data = (DragAndDropListView.DragItemData)e.Data.GetData(typeof(DragAndDropListView.DragItemData));
                    ListViewItem item = (ListViewItem)data.DragItems[0];

                    folders.Remove((ScmRepository)item.Tag);
                    folders.Insert(item.Index, (ScmRepository)item.Tag);

                    Config.SaveSvnFolders(folders);
                }
                catch (Exception ex)
                {
                    OnThreadException(this, new ThreadExceptionEventArgs(ex));
                }
            }
		}


		#endregion

		////////////////////////////////////////////////////////////////////////////////////

		#region NotifyIcon handlers

		private void notifyIcon_MouseClick (object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				ShowFolderList();
				ShowInTaskbar = Config.ShowInTaskbar;
			}
		}


		private void notifyIcon_BalloonTipClicked (object sender, EventArgs e)
		{
			ShowFolderList();
			ShowInTaskbar = Config.ShowInTaskbar;

			if (firstBalloonPath != null)
				SelectFolder (firstBalloonPath);
		}
		#endregion

		////////////////////////////////////////////////////////////////////////////////////

		#region MainForm handlers

		private void MainForm_KeyDown (object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				Hide();

			e.Handled = false;
		}


		private void MainForm_Closing (object sender, CancelEventArgs e)
		{
			if (!sessionEndInProgress)
			{
				e.Cancel = true;
				Hide();
			}
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			RemovePowerEventListener();
		}

		private void MainForm_Activated (object sender, EventArgs e)
		{
			FormStateChanged (true);
			BeginUpdateFolderStatuses();
		}


		private void MainForm_Deactivate (object sender, EventArgs e)
		{
			FormStateChanged (false);
		}


		private void MainForm_ResizeEnd (object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Normal)
				Config.SaveMainFormSize (Width, Height);
		}


		#endregion

		////////////////////////////////////////////////////////////////////////////////////

		private void ShowFolderList()
		{
			Show();
			if (WindowState == FormWindowState.Minimized)
				WindowState = FormWindowState.Normal;
			Activate();
		}

		////////////////////////////////////////////////////////////////////////////////////

		private readonly SvnFolderCollection newNonUpdatedFolders = new SvnFolderCollection();
		private delegate void UpdateListViewMethod (ScmRepository folder, ScmRepositoryStatus folderStatus, DateTime statusTime);
		private delegate void SetStatusBarTextMethod (string text);
		private delegate void UpdateErrorLogMethod (string path, string error);
		private delegate void CheckedInvokeMethod (Delegate method, object[] args);
		private delegate void ShowUpdateErrorsMethod (ScmRepositoryProcess sfp);

		internal static Thread statusThread;
		string firstBalloonPath;
		private bool formIsActive;
		private readonly IntPtr currentProcessHandle = Process.GetCurrentProcess().Handle;
		private bool repeatInvoke;

		////////////////////////////////////////////////////////////////////////////////////

		#region Checking for new version

		private bool forcedCheckForNewVersion;							// Means manually called from main menu
		private DateTime lastTimeOfCheckForNewVersion = DateTime.MinValue;		// Force to check at startup
		private Version lastStableVersion;


		/// <summary>
		/// Executed on working thread
		/// </summary>
		private void CheckForNewVersion (bool forceShowResult)
		{
			string lastStableVersionInfo = ReadFromWeb ("http://svnnotifier.tigris.org/LastStableVersion.txt");

			if (lastStableVersionInfo != null)
			{
				lastStableVersion = new Version (lastStableVersionInfo.Split ('\n')[0]);

				if ((lastStableVersion > AboutForm.Version) ||
					((lastStableVersion == AboutForm.Version) && (AboutForm.VersionStatus != "")))	// if alpha/beta version
				{
					SafeInvoke (new MethodInvoker (ShowNewVersion), null, Int32.MaxValue);
				}
				else if (forceShowResult)
				{
					SafeInvoke (new MethodInvoker (ShowNoNewVersion), null, Int32.MaxValue);
				}
			}
			else if (forceShowResult)
			{
				SafeInvoke (new MethodInvoker (ErrorCheckingForNewVersion), null, Int32.MaxValue);
			}
		}


		private static string ReadFromWeb (string url)
		{
			try
			{
				WebClient web = new WebClient();
				Stream s = web.OpenRead (url);
				string content = new StreamReader (s).ReadToEnd();

				if ((content.Length < 5) || (content.Length > 15))
					return null;	// Bad content

				return content;
			}
			catch
			{
				return null;		// Problem with web connection
			}
		}


		private void ShowNewVersion()
		{
			if (MessageBox.Show (
				"New stable version of SCM Notifier is available - v" + lastStableVersion + "\n" +
				"Do you want to go to the project home page?",
				"SCM Notifier",
				MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
				new AboutForm().ShowDialog();
		}


		private static void ShowNoNewVersion()
		{
			MessageBox.Show ("You are using latest version of SCM Notifier.",
				"SCM Notifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}


		private static void ErrorCheckingForNewVersion()
		{
			MessageBox.Show ("Can't check for new version!",
				"SCM Notifier", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		#endregion

		////////////////////////////////////////////////////////////////////////////////////

		private void FormStateChanged (bool _formIsActive)
		{
			formIsActive = _formIsActive;

			bool startTimer = statusUpdateTimer.Enabled;
			statusUpdateTimer.Stop();

			if (startTimer) StartTimer();
		}


		private void StartTimer()
		{
			pauseTimer.Stop(); // Could be running if Form is activated shortly after startup

			int intervalMs = folders.FindNextStatusUpdateTimeMs (formIsActive);

			if ((intervalMs > 333) && (ScmRepository.svnFolderProcesses.Count > 0))
				intervalMs = 333;	// Wait commit process(es) finish at least 3 times per second

			statusUpdateTimer.Interval = intervalMs == 0 ? 1 : intervalMs;
			statusUpdateTimer.Start();
		}


		private void statusUpdateTimer_Elapsed (object sender, ElapsedEventArgs e)
		{
			BeginUpdateFolderStatuses();
		}

		private void pauseTimer_Tick(object sender, EventArgs e)
		{
			pauseTimer.Stop();
			StartTimer();
		}

		private void BeginUpdateFolderStatuses()
		{
			if ((folders.Count > 0) || forcedCheckForNewVersion)
			{
				statusUpdateTimer.Stop();

				lock (this)
				{
					if (statusThread == null)
					{
						reupdateStatus = false;

						statusThread = new Thread (StatusUpdateThread_Run);
						statusThread.Start();
					}
					else
						reupdateStatus = true;
				}
			}
		}


		/// <summary>
		/// Executed on working thread
		/// </summary>
		private void StatusUpdateThread_Run()
		{
			try
			{
				while (!Created) Thread.Sleep (10);

				while (true)
				{
					SafeInvoke (new MethodInvoker (BeginUpdateListView));

					foreach (ScmRepository folder in (SvnFolderCollection) folders.Clone())
					{
						if (folder.Disable) continue;

						updateNotInProgress.WaitOne();

						if (forcedCheckForNewVersion)
						{
							forcedCheckForNewVersion = false;
							lastTimeOfCheckForNewVersion = DateTime.Now;
							SafeInvoke (new SetStatusBarTextMethod (SetStatusBarText), new object[] {"Checking for new version..."});
							CheckForNewVersion (true);
						}

						bool skipUpdateStatus = false;

						// Check commit and update processes for finishing
						for (int i = 0; i < ScmRepository.svnFolderProcesses.Count; i++)
						{
                            var sfp = (ScmRepositoryProcess)ScmRepository.svnFolderProcesses[i];

							if (sfp.process.HasExited)
							{
								if (sfp.isUpdateCommand && sfp.updateError)
									SafeInvoke (new ShowUpdateErrorsMethod (ShowUpdateErrors), new object[] {sfp}, Int32.MaxValue);

								UpdateFolderStatus (sfp.folder);
                                ScmRepository.svnFolderProcesses.RemoveAt(i--);
							}
							else if ((folder.Path == sfp.folder.Path) && sfp.isUpdateCommand)
							{
								skipUpdateStatus = true;		// Because updating is still in progress
								ScmRepository.ReadProcessOutput (sfp);
							}
						}

						while (forcedFolders.Count > 0)
							UpdateFolderStatus ((ScmRepository) forcedFolders.Dequeue());

						if ((folder.StatusUpdateTime + new TimeSpan (0, 0, folder.GetInterval (formIsActive)) <= DateTime.Now) && !skipUpdateStatus)
							UpdateFolderStatus (folder);
					}

					if (forcedCheckForNewVersion)
					{
                        forcedCheckForNewVersion = false;
                        lastTimeOfCheckForNewVersion = DateTime.Now;
                        SafeInvoke(new SetStatusBarTextMethod(SetStatusBarText), new object[] { "Checking for new version..." });
                        CheckForNewVersion(true);
                    }

					if (Config.CheckForNewVersion && (lastTimeOfCheckForNewVersion + new TimeSpan(3, 0, 0) < DateTime.Now))
					{
						lastTimeOfCheckForNewVersion = DateTime.Now;
						SafeInvoke (new SetStatusBarTextMethod (SetStatusBarText), new object[] {"Checking for new version..."});
						CheckForNewVersion (false);
					}

					lock (this)
					{
						if (!reupdateStatus)
						{
							statusThread = null;
							break;
						}
						else
							reupdateStatus = false;
					}
				}

				SafeInvoke (new MethodInvoker (EndUpdateListView));
			}
			catch (ThreadAbortException)
			{
				ScmRepository.KillBackgroundProcess();
			}
			catch (Exception e)		// Otherwise it will just lost
			{
				ShowError ("Error on status thread: " + e);
				Application.Exit();
			}
		}


		/// <summary>
		/// Executed on working thread
		/// </summary>
		private void SafeInvoke (Delegate method)
		{
			SafeInvoke (method, null);
		}


		/// <summary>
		/// Executed on working thread
		/// </summary>
		private void SafeInvoke (Delegate method, object[] args)
		{
			SafeInvoke (method, args, 10000);
		}


		/// <summary>
		/// Executed on working thread
		/// </summary>
		private void SafeInvoke (Delegate method, object[] args, int timeoutMs)
		{
			// Begin/EndInvoke usage is workaround for "form.Invoke hungs sometimes" problem
			repeatInvoke = true;
			do
			{
				IAsyncResult ar;
				try
				{
					ar = BeginInvoke (new CheckedInvokeMethod (CheckedInvoke), new object[] {method, args});
				}
				catch	// Avoid exceptions for not yet created or disposed form
				{
					return;
				}

				if (ar.AsyncWaitHandle.WaitOne (timeoutMs, false))		// This timeout should be increased when debugging
				{
					try
					{
						EndInvoke(ar);
					}
					catch	// Avoid exceptions for not yet created or disposed form
					{
						return;
					}
				}
//				else
//					MessageBox.Show ("form.Invoke timeout!!! Repeat = " + repeatInvoke);		// Note: both "True" and "False" where observed
			}
			while (repeatInvoke);
		}


		private void CheckedInvoke (Delegate method, object[] args)
		{
			method.DynamicInvoke (args);
			repeatInvoke = false;
		}


		/// <summary>
		/// Executed on working thread
		/// </summary>
		private void UpdateFolderStatus (ScmRepository folder)
		{
			SafeInvoke (new SetStatusBarTextMethod (SetStatusBarText), new object[] {"Checking '" + folder.Path + "'..."});
			DateTime statusTime = DateTime.Now;
			if (sessionEndInProgress) return;		// Need to avoid error on svn.exe invoking
            ScmRepositoryStatus status = folder.GetStatus();
			SafeInvoke (new UpdateListViewMethod (UpdateListView), new object[] {folder, status, statusTime});
		}


		private void BeginUpdateListView()
		{
			newNonUpdatedFolders.Clear();
		}


		private void SetStatusBarText (string text)
		{
			statusStrip.Items[0].Text = text;
		}


		private void UpdateListView (ScmRepository folder, ScmRepositoryStatus folderStatus, DateTime statusTime)
		{
			int i = folders.IndexOf (folder);
			if (i < 0) return;

			if (statusTime < folder.StatusUpdateTime)
				return;

			if (folder.Status != folderStatus)
			{
                folder.Status = folderStatus;
                listViewFolders.Items[i].ImageIndex = folder.ImageIndex();

				if ((folderStatus == ScmRepositoryStatus.NeedUpdate) ||
					(folderStatus == ScmRepositoryStatus.NeedUpdate_Modified))
				{
					newNonUpdatedFolders.Add (folder);
					UpdateTray (true);
				}
				else
					UpdateTray (false);

				// Refresh buttons
				listViewFolders_SelectedIndexChanged (null, null);
			}
			else
				folder.Status = folderStatus;		// Update status time only
		}


		private void EndUpdateListView()
		{
			statusStrip.Items[0].Text = null;

			// Reduce used memory
			GC.Collect();
			EmptyWorkingSet (currentProcessHandle);

			if (!pauseTimer.Enabled)
			{
				// If the pauseTimer is running it will start up 
				// the statusUpdateTimer once the pause is done.
				StartTimer();
			}
		}


		private void UpdateTray (bool newNonUpdatedFoldersChanged)
		{
			// Update tray ToolTip

			const int MaxTrayTextLen = 63 - 4;			// "\n...".Length == 4
			string updateTrayText = "";
			string errorTrayText = "";

			foreach (ScmRepository folder in folders)
			{
				if (!folder.Disable && (folder.Status == ScmRepositoryStatus.Error))
				{
					if (errorTrayText == "")
						errorTrayText = "Failed:";

					if ((MaxTrayTextLen - errorTrayText.Length) > (1 + folder.VisiblePath.Length))
					{
						errorTrayText += "\n" + folder.VisiblePath;
					}
					else if (errorTrayText != "")
					{
						errorTrayText += "\n...";
						break;
					}
				}
			}

			foreach (ScmRepository folder in folders)
			{
				if ((folder.Status == ScmRepositoryStatus.NeedUpdate) || (folder.Status == ScmRepositoryStatus.NeedUpdate_Modified))
				{
					if (updateTrayText == "")
					{
						if ((MaxTrayTextLen - errorTrayText.Length) > 15)	// "\nUpdate needed:".Length == 15
							updateTrayText = (errorTrayText != "" ? "\n" : "") + "Update needed:";
						else
							break;
					}

					if ((MaxTrayTextLen - (updateTrayText.Length + errorTrayText.Length)) > (1 + folder.VisiblePath.Length))
					{
						updateTrayText += "\n" + folder.VisiblePath;
					}
					else if (updateTrayText != "")
					{
						updateTrayText += "\n...";
						break;
					}
				}
			}

			notifyIcon.Text = errorTrayText + updateTrayText;

			if (notifyIcon.Text == "")
				notifyIcon.Text = Application.ProductName;

			// Update tray icon

			Icon icon;
			if (folders.ContainsStatus (ScmRepositoryStatus.Error))
			{
				icon = trayIcon_Error;
			}
			else if ((folders.ContainsStatus (ScmRepositoryStatus.NeedUpdate)) ||
				(folders.ContainsStatus (ScmRepositoryStatus.NeedUpdate_Modified)))
			{
				icon = trayIcon_NeedUpdate;
			}
			else if (folders.ContainsStatus (ScmRepositoryStatus.Unknown))
			{
				icon = trayIcon_Unknown;
			}
			else if ((folders.ContainsStatus (ScmRepositoryStatus.UpToDate)) ||
				(folders.ContainsStatus (ScmRepositoryStatus.UpToDate_Modified)))
			{
				icon = trayIcon_UpToDate;
			}
			else
				icon = trayIcon_Unknown;

			if (icon != Icon)
				Icon = notifyIcon.Icon = icon;


			// Update menu

			if ((folders.ContainsStatus (ScmRepositoryStatus.NeedUpdate)
				|| folders.ContainsStatus (ScmRepositoryStatus.NeedUpdate_Modified))
				&& !Config.ChangeLogBeforeUpdate)
			{
				updateAllToolStripMenuItem.Enabled = true;
				menuItem_UpdateAll.Enabled = true;
			}
			else
			{
				updateAllToolStripMenuItem.Enabled = false;
				menuItem_UpdateAll.Enabled = false;
			}

			if (newNonUpdatedFoldersChanged)
			{
				// Update tray balloon

				if (newNonUpdatedFolders.Count > 0)
				{
					string[] nonUpdatedFolders = new string[newNonUpdatedFolders.Count];
					for (int i = 0; i < newNonUpdatedFolders.Count; i++)
						nonUpdatedFolders[i] = listViewFolders.Items[folders.IndexOf (newNonUpdatedFolders[i])].Text;

					firstBalloonPath = nonUpdatedFolders[0];

					string balloonMessage = String.Join (Environment.NewLine, nonUpdatedFolders);
					notifyIcon.ShowBalloonTip (Config.ShowBalloonInterval, "Update needed", balloonMessage, ToolTipIcon.Info);
				}
			}
		}


		private void ShowUpdateErrors (ScmRepositoryProcess sfp)
		{
			new UpdateLogsForm (sfp).ShowDialog (this);
		}


		private void OnErrorAdded (string path, string error)
		{
			SafeInvoke (new UpdateErrorLogMethod (UpdateErrorLog), new object[] {path, error});
		}


		public void UpdateErrorLog (string path, string error)
		{
			statusStrip.Items[1].DisplayStyle = ToolStripItemDisplayStyle.Image;

			if (path == null)
				path = "Checking for new version";							// TODO: Strange realization

			string s = "[" + DateTime.Now + "] " + Environment.NewLine +
				path + ":" + Environment.NewLine +
				error.Replace ("\n", Environment.NewLine) +
				Environment.NewLine + Environment.NewLine;

			errorLog[path] = s;
		}


		private void toolStripStatusLabel2_Click(object sender, EventArgs e)
		{
			if ((errorLog.Count > 0) && (new ErrorLogForm (errorLog).ShowDialog (this) == DialogResult.Abort))
			{
				statusStrip.Items[1].DisplayStyle = ToolStripItemDisplayStyle.None;
				errorLog.Clear();
			}
		}


		//////////////////////////////////////////////////////////////////////////////

		private const int WM_QUERYENDSESSION = 0x11;
		private const int WM_ENDSESSION = 0x16;

		private static bool sessionEndInProgress;


		protected override void WndProc (ref Message m)
		{
			if (m.Msg == WM_QUERYENDSESSION)
				sessionEndInProgress = true;

			if ((m.Msg == WM_ENDSESSION) && ((int) m.WParam == 0))	// if "session end" was canceled (by some other reasons)
				sessionEndInProgress = false;

			base.WndProc (ref m);
		}

		//////////////////////////////////////////////////////////////////////////////

		[STAThread]
		private static void Main (string[] args)
		{
			try
			{
				if ((args.Length == 1) && (args[0] == "start"))		// Used to start application during install
				{
					ProcessStartInfo psi = new ProcessStartInfo
					{
						FileName = Application.ExecutablePath,
						UseShellExecute = false,
						WorkingDirectory = Path.GetDirectoryName (Application.ExecutablePath)
					};
					Process.Start (psi);
					return;
				}

				const string iniFileName = "SCM_Notifier.ini";
				if (File.Exists (iniFileName))
					Config.Init (iniFileName);
				else
					Config.Init (Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData), iniFileName));

				if (!Config.IsSettingsOK())
					if (new SettingsForm().ShowDialog() != DialogResult.OK)
						return;

				MainForm form = new MainForm();

				Thread.CurrentThread.Name = "Main";
				Application.ThreadException += OnThreadException;
				Application.Run (form);

				lock (form)
				{
					if (statusThread != null)
						statusThread.Abort();
				}
			}
			catch (Exception e)
			{
				FatalError (e);
			}
		}


		private static void OnThreadException (object sender, ThreadExceptionEventArgs t)
		{
			FatalError (t.Exception);
			Application.Exit();
		}


		private static void FatalError (Exception e)
		{
			ShowError (e.ToString ());
			Config.WriteLog ("Error", e.ToString ());
		}


		private static void ShowError (string s)
		{
			MessageBox.Show (s, "SCM Notifier", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

        private void listViewFolders_DragEnter(object sender, DragEventArgs e)
        {
            //only inforce accepting dropped files, rest is handled by parent class.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void listViewFolders_DragOver(object sender, DragEventArgs e)
        {
            //only inforce accepting dropped files, rest is handled by parent class.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;                       
        }
	}
}
