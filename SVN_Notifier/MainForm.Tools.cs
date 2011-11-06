using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CHD.SVN_Notifier
{
	partial class MainForm
	{
		private readonly Icon trayIcon_NeedUpdate = Properties.Resources.TrayIcon_NeedUpdate;
		private readonly Icon trayIcon_UpToDate = Properties.Resources.TrayIcon_UpToDate;
		private readonly Icon trayIcon_Unknown = Properties.Resources.TrayIcon_Unknown;
		private readonly Icon trayIcon_Error = Properties.Resources.TrayIcon_Error;

		private SvnFolderCollection folders = new SvnFolderCollection ();


		private int GetFoldersCommonPartLength ()
		{
			if (folders.Count < 2) return 0;

			string path0 = folders[0].Path;

			int len = 0;
			for (int i = 0; i < path0.Length; i++)
				for (int f = 1; f < folders.Count; f++)
				{
					string path = folders[f].Path;
					if (i == path.Length - 1) return len;
					if (path0[i] != path[i]) return len;
					if (path0[i] == '\\') len = i + 1;
				}
			return len;
		}


		private void UpdateListViewFolderNames ()
		{
			int i = GetFoldersCommonPartLength ();

			for (int f = 0; f < folders.Count; f++)
			{
				folders[f].VisiblePath = (i > 0 ? "\u2026" : "") + folders[f].Path.Substring (i);
				listViewFolders.Items[f].Tag = folders[f];
				listViewFolders.Items[f].Text = folders[f].VisiblePath;
			}
		}

		//////////////////////////////////////////////////////////////////////////////

		private const int imageIndex_UpToDate = 0;
		private const int imageIndex_NeedUpdate = 1;
		private const int imageIndex_Bad = 2;
		private const int imageIndex_Unknown = 3;
		private const int imageIndex_UpToDate_Modified = 4;
		private const int imageIndex_NeedUpdate_Modified = 5;

		private static int GetFolderStatusImageIndex (SvnFolderStatus folderStatus)
		{
			switch (folderStatus)
			{
				case SvnFolderStatus.NeedUpdate_Modified:
					return imageIndex_NeedUpdate_Modified;

				case SvnFolderStatus.UpToDate_Modified:
					return imageIndex_UpToDate_Modified;

				case SvnFolderStatus.UpToDate:
					return imageIndex_UpToDate;

				case SvnFolderStatus.NeedUpdate:
					return imageIndex_NeedUpdate;

				case SvnFolderStatus.Error:
					return imageIndex_Bad;

				default:
					return imageIndex_Unknown;
			}
		}

		//////////////////////////////////////////////////////////////////////////////

		private void UpdateFolder ()
		{
			if (listViewFolders.SelectedIndices.Count == 0)
				return;

			int selectedIndex = listViewFolders.SelectedIndices[0];
			SvnFolder folder = folders[selectedIndex];

			if (Config.ChangeLogBeforeUpdate && (folder.reviewedRevision < SvnTools.GetRepositoryHeadRevision (folder)))
			{
				MessageBox.Show ("You need to see ChangeLog first!", "SVN Notifier", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			btnUpdate.Enabled = updateToolStripMenuItem.Enabled = checkNowToolStripMenuItem.Enabled = false;
			folder.Status = SvnFolderStatus.Unknown;
			listViewFolders.Items[selectedIndex].ImageIndex = imageIndex_Unknown;
			newNonUpdatedFolders.Clear ();

			statusStrip.Items[0].Text = "Updating '" + folder.Path + "'...";
			UpdateTray (true);
			Refresh ();				// Show "Unknown" folder status during updating

			updateNotInProgress.Reset ();
			BeginUpdateFolderStatuses ();

			SvnTools.Update (folder, false);

			forcedFolders.Enqueue (folder);

			updateNotInProgress.Set ();
		}


		private void CommitFolder ()
		{
			if (listViewFolders.SelectedIndices.Count == 0)
				return;

			int selectedIndex = listViewFolders.SelectedIndices[0];
			SvnTools.Commit (folders[selectedIndex]);
		}


		private void UpdateAll ()
		{
			newNonUpdatedFolders.Clear ();
			statusStrip.Items[0].Text = "Updating all...";
			UpdateTray (true);

			BeginUpdateFolderStatuses ();

			btnUpdate.Enabled = updateToolStripMenuItem.Enabled = checkNowToolStripMenuItem.Enabled = menuItem_UpdateAll.Enabled = false;

			foreach (SvnFolder folder in folders)
				if ((folder.Status == SvnFolderStatus.NeedUpdate) || (folder.Status == SvnFolderStatus.NeedUpdate_Modified))
				{
					folder.Status = SvnFolderStatus.Unknown;
					listViewFolders.Items[folders.IndexOf (folder)].ImageIndex = imageIndex_Unknown;

					if (Config.UpdateAllSilently)
						SvnTools.BeginUpdateSilently (folder);
					else
					{
						updateNotInProgress.Reset ();
						SvnTools.Update (folder, true);
						forcedFolders.Enqueue (folder);
						updateNotInProgress.Set ();
					}
				}
			UpdateTray (true);
		}


		private void OpenFolder ()
		{
			var selectedIndex = listViewFolders.SelectedIndices[0];
			var folder = folders[selectedIndex].Path;

			if (File.Exists (folders[selectedIndex].Path))
				folder = Path.GetDirectoryName (folder);

			Process.Start (folder + @"\");					// Open folder or folder of the file
		}


		private void ShowChangeLog ()
		{
			int selectedIndex = listViewFolders.SelectedIndices[0];
			SvnTools.OpenChangeLogWindow (folders[selectedIndex], true);
		}


		private void ShowFullLog ()
		{
			int selectedIndex = listViewFolders.SelectedIndices[0];
			SvnTools.OpenLogWindow (folders[selectedIndex].Path);
		}


		private void SelectFolder (string path)
		{
			foreach (ListViewItem item in listViewFolders.Items)
				if (item.Text == path)
				{
					item.Selected = true;
					break;
				}
		}
	}
}