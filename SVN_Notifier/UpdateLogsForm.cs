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
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CHD.SVN_Notifier
{
	public class UpdateLogsForm : Form
	{
		#region Windows Form Designer generated variables

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Button btnLog;
		private Button btnOk;
		private Button btnCancel;
		private Label labelResult;
		private ListView listViewLog;
		private ColumnHeader columnAction;
		private ColumnHeader columnPath;
		private Container components;

		#endregion

		#region Windows Form Designer generated code

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose (bool disposing)
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnLog = new System.Windows.Forms.Button ();
			this.btnOk = new System.Windows.Forms.Button ();
			this.btnCancel = new System.Windows.Forms.Button ();
			this.labelResult = new System.Windows.Forms.Label ();
			this.listViewLog = new System.Windows.Forms.ListView ();
			this.columnAction = new System.Windows.Forms.ColumnHeader ();
			this.columnPath = new System.Windows.Forms.ColumnHeader ();
			this.SuspendLayout ();
			// 
			// btnLog
			// 
			this.btnLog.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLog.Enabled = false;
			this.btnLog.Location = new System.Drawing.Point (280, 352);
			this.btnLog.Name = "btnLog";
			this.btnLog.Size = new System.Drawing.Size (104, 23);
			this.btnLog.TabIndex = 0;
			this.btnLog.Text = "Show log...";
			this.btnLog.Click += new System.EventHandler (this.btnLog_Click);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point (400, 352);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size (75, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Ok";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Enabled = false;
			this.btnCancel.Location = new System.Drawing.Point (488, 352);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size (75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			// 
			// labelResult
			// 
			this.labelResult.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelResult.AutoSize = true;
			this.labelResult.Location = new System.Drawing.Point (16, 336);
			this.labelResult.Name = "labelResult";
			this.labelResult.Size = new System.Drawing.Size (0, 13);
			this.labelResult.TabIndex = 3;
			// 
			// listViewLog
			// 
			this.listViewLog.AllowColumnReorder = true;
			this.listViewLog.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listViewLog.Columns.AddRange (new System.Windows.Forms.ColumnHeader[] {
            this.columnAction,
            this.columnPath});
			this.listViewLog.FullRowSelect = true;
			this.listViewLog.LabelWrap = false;
			this.listViewLog.Location = new System.Drawing.Point (16, 8);
			this.listViewLog.Name = "listViewLog";
			this.listViewLog.Size = new System.Drawing.Size (544, 304);
			this.listViewLog.TabIndex = 5;
			this.listViewLog.UseCompatibleStateImageBehavior = false;
			this.listViewLog.View = System.Windows.Forms.View.Details;
			// 
			// columnAction
			// 
			this.columnAction.Text = "Action";
			this.columnAction.Width = 42;
			// 
			// columnPath
			// 
			this.columnPath.Text = "Path";
			this.columnPath.Width = 498;
			// 
			// UpdateLogsForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size (5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size (576, 389);
			this.Controls.Add (this.btnCancel);
			this.Controls.Add (this.btnOk);
			this.Controls.Add (this.btnLog);
			this.Controls.Add (this.labelResult);
			this.Controls.Add (this.listViewLog);
			this.MinimumSize = new System.Drawing.Size (472, 272);
			this.Name = "UpdateLogsForm";
			this.Text = "UpdateLogsForm";
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		[DllImport("winmm.dll", EntryPoint="PlaySound", CharSet=CharSet.Auto)]
		private static extern int PlaySound (String pszSound, int hmod, int falgs);


		/// <summary>
		/// API Parameter Flags for PlaySound method
		/// </summary>
		[Flags]
		public enum SND
		{
			SND_SYNC            = 0x0000  ,/* play synchronously (default) */
			SND_ASYNC           = 0x0001 , /* play asynchronously */
			SND_NODEFAULT       = 0x0002 , /* silence (!default) if sound not found */
			SND_MEMORY          = 0x0004 , /* pszSound points to a memory file */
			SND_LOOP            = 0x0008 , /* loop the sound until next sndPlaySound */
			SND_NOSTOP          = 0x0010 , /* don't stop any currently playing sound */
			SND_NOWAIT			= 0x00002000, /* don't wait if the driver is busy */
			SND_ALIAS			= 0x00010000 ,/* name is a registry alias */
			SND_ALIAS_ID		= 0x00110000, /* alias is a pre d ID */
			SND_FILENAME		= 0x00020000, /* name is file name */
			SND_RESOURCE		= 0x00040004, /* name is resource name or atom */
			SND_PURGE           = 0x0040,  /* purge non-static events for task */
			SND_APPLICATION     = 0x0080  /* look for application specific association */
		}

		private readonly Hashtable ht = new Hashtable ();
		private readonly SvnFolderProcess folderProcess;


		public UpdateLogsForm (SvnFolderProcess sfp)
		{
			if (!sfp.isUpdateCommand) throw new ApplicationException();
			folderProcess = sfp;

			InitializeComponent();

			FillList ();
			PlaySound ();
		}


		private void FillList ()
		{
			Text = folderProcess.folder.Path + " - Update... Finished!";
			bool conflict = false;

			foreach (string line in folderProcess.processOutput)
			{
				string action;
				string path;
				Color color = Color.Black;
				
				switch (line.Substring (0, Math.Min (line.Length, 2)))
				{
					case "A ":
						action = "Added";
						path = line.Substring (5);
						color = Color.Purple;
						AddAction (action);
						break;

					case "D ":
						action = "Deleted";
						path = line.Substring (5);
						color = Color.Brown;
						AddAction (action);
						break;

					case "U ":
						action = "Updated";
						path = line.Substring (5);
						AddAction (action);
						break;

					case "C ":
						action = "Conflicted";
						path = line.Substring (5);
						color = Color.Red;
						conflict = true;
						AddAction (action);
						break;

					case "G ":
						action = "Merged";
						path = line.Substring (5);
						color = Color.DarkGreen;
						AddAction (action);
						break;

					default:
						if (line.StartsWith ("Updated to revision"))
						{
							action = "Completed";
							path = "At revision: " + line.Substring (20);
						}
						else
						{
							action = "Error";
							path = line;
							color = Color.Red;
						}
						break;
				}

				ListViewItem lvi = new ListViewItem (new[] {action, path}) {ForeColor = color};
				listViewLog.Items.Add (lvi);
			}

			if (conflict)
			{
				ListViewItem lvi = new ListViewItem (new[] {"Warning!", "One or more files are in a conflicted state."});
				lvi.ForeColor = Color.Red;
				listViewLog.Items.Add (lvi);
			}

			if (ht.Count > 0)
			{
				labelResult.Text = "";
				foreach (DictionaryEntry de in ht)
				{
					labelResult.Text += de.Key + ":" + de.Value + " ";
				}
				btnLog.Enabled = true;
			}
			else
				btnLog.Visible = false;
		}


		private void AddAction (string action)
		{
			try
			{
				ht[action] = (int) ht[action] + 1;
			}
			catch
			{
				ht[action] = 1;
			}
		}


		private static void PlaySound()
		{
			string wavFile = Path.Combine (Path.GetDirectoryName (Config.TortoiseSVNpath), "TortoiseSVN_error.wav");
			if (File.Exists (wavFile))
			{
				PlaySound (wavFile, 0,(int) (SND.SND_ASYNC | SND.SND_FILENAME | SND.SND_NOWAIT));
			}
		}


		private void btnLog_Click (object sender, EventArgs e)
		{
			SvnTools.OpenChangeLogWindow (folderProcess.folder, false);
		}
	}
}
