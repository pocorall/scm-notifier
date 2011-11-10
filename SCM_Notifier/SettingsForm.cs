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

using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace pocorall.SCM_Notifier
{
	public class SettingsForm : Form
	{
		#region Windows Form Designer generated code

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_SVNpath;
		private System.Windows.Forms.TextBox textBox_TortoiseSVNpath;
		private System.Windows.Forms.Button button_OK;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Button button_BrowseSvn;
		private System.Windows.Forms.Button button_BrowseTortoise;
		private System.Windows.Forms.OpenFileDialog openFileDialog_svn;
		private System.Windows.Forms.OpenFileDialog openFileDialog_Tortoise;
		private System.Windows.Forms.ComboBox comboBox_ItemActions;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox checkBox_HideOnStartup;
		private System.Windows.Forms.CheckBox checkBox_CheckForNewVersion;
		private System.Windows.Forms.NumericUpDown numericUpDown_ShowBalloonInterval;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox checkBox_ChangeLogBeforeUpdate;
		private System.Windows.Forms.CheckBox checkBox_UpdateAllSilently;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox comboBox_UpdateWindowAction;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown numericUpDown_DefaultIdleStatusUpdateIntervalHour;
		private System.Windows.Forms.NumericUpDown numericUpDown_DefaultActiveStatusUpdateIntervalHour;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown numericUpDown_DefaultIdleStatusUpdateIntervalMin;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numericUpDown_DefaultActiveStatusUpdateIntervalMin;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericUpDown_DefaultIdleStatusUpdateIntervalSec;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numericUpDown_DefaultActiveStatusUpdateIntervalSec;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label15;
		private CheckBox checkBox_ShowInTaskbar;
		private GroupBox groupBox2;
		private Label label16;
		private Label label17;
		private Label label18;
		private NumericUpDown numericUpDown_PauseWindowsResumeHour;
		private NumericUpDown numericUpDown_PauseApplicationStartupHour;
		private Label label19;
		private NumericUpDown numericUpDown_PauseWindowsResumeMin;
		private Label label20;
		private Label label21;
		private NumericUpDown numericUpDown_PauseApplicationStartupMin;
		private Label label22;
		private NumericUpDown numericUpDown_PauseWindowsResumeSec;
		private NumericUpDown numericUpDown_PauseApplicationStartupSec;
		private CheckBox checkBox_PauseWindowsResume;
		private CheckBox checkBox_PauseApplicationStartup;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
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


		public SettingsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_SVNpath = new System.Windows.Forms.TextBox();
            this.textBox_TortoiseSVNpath = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_BrowseSvn = new System.Windows.Forms.Button();
            this.button_BrowseTortoise = new System.Windows.Forms.Button();
            this.openFileDialog_svn = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog_Tortoise = new System.Windows.Forms.OpenFileDialog();
            this.comboBox_ItemActions = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox_HideOnStartup = new System.Windows.Forms.CheckBox();
            this.checkBox_CheckForNewVersion = new System.Windows.Forms.CheckBox();
            this.numericUpDown_ShowBalloonInterval = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox_ChangeLogBeforeUpdate = new System.Windows.Forms.CheckBox();
            this.checkBox_UpdateAllSilently = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox_UpdateWindowAction = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox_ShowInTaskbar = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_PauseWindowsResume = new System.Windows.Forms.CheckBox();
            this.checkBox_PauseApplicationStartup = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDown_PauseWindowsResumeHour = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_PauseApplicationStartupHour = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.numericUpDown_PauseWindowsResumeMin = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.numericUpDown_PauseApplicationStartupMin = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.numericUpDown_PauseWindowsResumeSec = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_PauseApplicationStartupSec = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown_DefaultIdleStatusUpdateIntervalHour = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_DefaultActiveStatusUpdateIntervalHour = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown_DefaultIdleStatusUpdateIntervalMin = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_DefaultActiveStatusUpdateIntervalMin = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_DefaultIdleStatusUpdateIntervalSec = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_DefaultActiveStatusUpdateIntervalSec = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ShowBalloonInterval)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PauseWindowsResumeHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PauseApplicationStartupHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PauseWindowsResumeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PauseApplicationStartupMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PauseWindowsResumeSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PauseApplicationStartupSec)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DefaultIdleStatusUpdateIntervalHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DefaultActiveStatusUpdateIntervalHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DefaultIdleStatusUpdateIntervalMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DefaultActiveStatusUpdateIntervalMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DefaultIdleStatusUpdateIntervalSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DefaultActiveStatusUpdateIntervalSec)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path to svn.exe:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Path to TortoiseProc.exe:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_SVNpath
            // 
            this.textBox_SVNpath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_SVNpath.Location = new System.Drawing.Point(8, 32);
            this.textBox_SVNpath.Name = "textBox_SVNpath";
            this.textBox_SVNpath.Size = new System.Drawing.Size(318, 20);
            this.textBox_SVNpath.TabIndex = 1;
            this.textBox_SVNpath.TextChanged += new System.EventHandler(this.CheckPathes);
            // 
            // textBox_TortoiseSVNpath
            // 
            this.textBox_TortoiseSVNpath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_TortoiseSVNpath.Location = new System.Drawing.Point(8, 80);
            this.textBox_TortoiseSVNpath.Name = "textBox_TortoiseSVNpath";
            this.textBox_TortoiseSVNpath.Size = new System.Drawing.Size(318, 20);
            this.textBox_TortoiseSVNpath.TabIndex = 3;
            this.textBox_TortoiseSVNpath.TextChanged += new System.EventHandler(this.CheckPathes);
            // 
            // button_OK
            // 
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_OK.Location = new System.Drawing.Point(224, 303);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(72, 23);
            this.button_OK.TabIndex = 7;
            this.button_OK.Text = "&OK";
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Cancel.Location = new System.Drawing.Point(304, 303);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(72, 23);
            this.button_Cancel.TabIndex = 8;
            this.button_Cancel.Text = "Cancel";
            // 
            // button_BrowseSvn
            // 
            this.button_BrowseSvn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_BrowseSvn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_BrowseSvn.Location = new System.Drawing.Point(328, 32);
            this.button_BrowseSvn.Name = "button_BrowseSvn";
            this.button_BrowseSvn.Size = new System.Drawing.Size(24, 20);
            this.button_BrowseSvn.TabIndex = 2;
            this.button_BrowseSvn.Text = "...";
            this.button_BrowseSvn.Click += new System.EventHandler(this.button_BrowseSvn_Click);
            // 
            // button_BrowseTortoise
            // 
            this.button_BrowseTortoise.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_BrowseTortoise.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_BrowseTortoise.Location = new System.Drawing.Point(328, 80);
            this.button_BrowseTortoise.Name = "button_BrowseTortoise";
            this.button_BrowseTortoise.Size = new System.Drawing.Size(24, 20);
            this.button_BrowseTortoise.TabIndex = 4;
            this.button_BrowseTortoise.Text = "...";
            this.button_BrowseTortoise.Click += new System.EventHandler(this.button_BrowseTortoise_Click);
            // 
            // openFileDialog_svn
            // 
            this.openFileDialog_svn.DefaultExt = "exe";
            this.openFileDialog_svn.Filter = "svn.exe|svn.exe";
            // 
            // openFileDialog_Tortoise
            // 
            this.openFileDialog_Tortoise.DefaultExt = "exe";
            this.openFileDialog_Tortoise.Filter = "TortoiseProc.exe|TortoiseProc.exe";
            // 
            // comboBox_ItemActions
            // 
            this.comboBox_ItemActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ItemActions.Items.AddRange(new object[] {
            "Open folder",
            "Show change/full log",
            "Update",
            "Commit",
            "CheckNow"});
            this.comboBox_ItemActions.Location = new System.Drawing.Point(104, 132);
            this.comboBox_ItemActions.Name = "comboBox_ItemActions";
            this.comboBox_ItemActions.Size = new System.Drawing.Size(136, 21);
            this.comboBox_ItemActions.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "On double click:";
            // 
            // checkBox_HideOnStartup
            // 
            this.checkBox_HideOnStartup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_HideOnStartup.Location = new System.Drawing.Point(16, 184);
            this.checkBox_HideOnStartup.Name = "checkBox_HideOnStartup";
            this.checkBox_HideOnStartup.Size = new System.Drawing.Size(216, 16);
            this.checkBox_HideOnStartup.TabIndex = 15;
            this.checkBox_HideOnStartup.Text = "Hide program to system tray on startup";
            // 
            // checkBox_CheckForNewVersion
            // 
            this.checkBox_CheckForNewVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_CheckForNewVersion.Location = new System.Drawing.Point(16, 228);
            this.checkBox_CheckForNewVersion.Name = "checkBox_CheckForNewVersion";
            this.checkBox_CheckForNewVersion.Size = new System.Drawing.Size(144, 16);
            this.checkBox_CheckForNewVersion.TabIndex = 16;
            this.checkBox_CheckForNewVersion.Text = "Check for new version";
            // 
            // numericUpDown_ShowBalloonInterval
            // 
            this.numericUpDown_ShowBalloonInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_ShowBalloonInterval.Location = new System.Drawing.Point(168, 158);
            this.numericUpDown_ShowBalloonInterval.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDown_ShowBalloonInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_ShowBalloonInterval.Name = "numericUpDown_ShowBalloonInterval";
            this.numericUpDown_ShowBalloonInterval.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_ShowBalloonInterval.TabIndex = 17;
            this.numericUpDown_ShowBalloonInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_ShowBalloonInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(16, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(256, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "Hide system tray balloon after                 seconds";
            // 
            // checkBox_ChangeLogBeforeUpdate
            // 
            this.checkBox_ChangeLogBeforeUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_ChangeLogBeforeUpdate.Location = new System.Drawing.Point(16, 72);
            this.checkBox_ChangeLogBeforeUpdate.Name = "checkBox_ChangeLogBeforeUpdate";
            this.checkBox_ChangeLogBeforeUpdate.Size = new System.Drawing.Size(240, 16);
            this.checkBox_ChangeLogBeforeUpdate.TabIndex = 19;
            this.checkBox_ChangeLogBeforeUpdate.Text = "Force to see \"Change Log\" before Update";
            this.checkBox_ChangeLogBeforeUpdate.CheckedChanged += new System.EventHandler(this.checkBox_ChangeLogBeforeUpdate_CheckedChanged);
            // 
            // checkBox_UpdateAllSilently
            // 
            this.checkBox_UpdateAllSilently.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_UpdateAllSilently.Location = new System.Drawing.Point(16, 112);
            this.checkBox_UpdateAllSilently.Name = "checkBox_UpdateAllSilently";
            this.checkBox_UpdateAllSilently.Size = new System.Drawing.Size(136, 24);
            this.checkBox_UpdateAllSilently.TabIndex = 22;
            this.checkBox_UpdateAllSilently.Text = "\"Silent\" Update All";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(208, 16);
            this.label14.TabIndex = 25;
            this.label14.Text = "TortoiseSVN dialog acton after update:";
            // 
            // comboBox_UpdateWindowAction
            // 
            this.comboBox_UpdateWindowAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_UpdateWindowAction.Items.AddRange(new object[] {
            "don\'t close the dialog automatically",
            "auto close if no errors",
            "auto close if no errors and conflicts",
            "auto close if no errors, conflicts and merges",
            "auto close if no errors, conflicts and merges for local operations"});
            this.comboBox_UpdateWindowAction.Location = new System.Drawing.Point(8, 32);
            this.comboBox_UpdateWindowAction.Name = "comboBox_UpdateWindowAction";
            this.comboBox_UpdateWindowAction.Size = new System.Drawing.Size(328, 21);
            this.comboBox_UpdateWindowAction.TabIndex = 27;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(370, 287);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.checkBox_ShowInTaskbar);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.textBox_TortoiseSVNpath);
            this.tabPage1.Controls.Add(this.textBox_SVNpath);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button_BrowseSvn);
            this.tabPage1.Controls.Add(this.button_BrowseTortoise);
            this.tabPage1.Controls.Add(this.comboBox_ItemActions);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.numericUpDown_ShowBalloonInterval);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.checkBox_HideOnStartup);
            this.tabPage1.Controls.Add(this.checkBox_CheckForNewVersion);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(362, 261);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // checkBox_ShowInTaskbar
            // 
            this.checkBox_ShowInTaskbar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_ShowInTaskbar.Location = new System.Drawing.Point(16, 206);
            this.checkBox_ShowInTaskbar.Name = "checkBox_ShowInTaskbar";
            this.checkBox_ShowInTaskbar.Size = new System.Drawing.Size(144, 16);
            this.checkBox_ShowInTaskbar.TabIndex = 20;
            this.checkBox_ShowInTaskbar.Text = "Show in taskbar";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(8, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 1);
            this.panel1.TabIndex = 19;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(362, 261);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_PauseWindowsResume);
            this.groupBox2.Controls.Add(this.checkBox_PauseApplicationStartup);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.numericUpDown_PauseWindowsResumeHour);
            this.groupBox2.Controls.Add(this.numericUpDown_PauseApplicationStartupHour);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.numericUpDown_PauseWindowsResumeMin);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.numericUpDown_PauseApplicationStartupMin);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.numericUpDown_PauseWindowsResumeSec);
            this.groupBox2.Controls.Add(this.numericUpDown_PauseApplicationStartupSec);
            this.groupBox2.Location = new System.Drawing.Point(9, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 88);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pause update after...";
            // 
            // checkBox_PauseWindowsResume
            // 
            this.checkBox_PauseWindowsResume.AutoSize = true;
            this.checkBox_PauseWindowsResume.Checked = true;
            this.checkBox_PauseWindowsResume.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_PauseWindowsResume.Location = new System.Drawing.Point(11, 55);
            this.checkBox_PauseWindowsResume.Name = "checkBox_PauseWindowsResume";
            this.checkBox_PauseWindowsResume.Size = new System.Drawing.Size(119, 17);
            this.checkBox_PauseWindowsResume.TabIndex = 6;
            this.checkBox_PauseWindowsResume.Text = "... Windows resume";
            this.checkBox_PauseWindowsResume.UseVisualStyleBackColor = true;
            // 
            // checkBox_PauseApplicationStartup
            // 
            this.checkBox_PauseApplicationStartup.AutoSize = true;
            this.checkBox_PauseApplicationStartup.Checked = true;
            this.checkBox_PauseApplicationStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_PauseApplicationStartup.Location = new System.Drawing.Point(11, 31);
            this.checkBox_PauseApplicationStartup.Name = "checkBox_PauseApplicationStartup";
            this.checkBox_PauseApplicationStartup.Size = new System.Drawing.Size(131, 17);
            this.checkBox_PauseApplicationStartup.TabIndex = 0;
            this.checkBox_PauseApplicationStartup.Text = "... SCM Notifier startup";
            this.checkBox_PauseApplicationStartup.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(236, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(8, 16);
            this.label16.TabIndex = 2;
            this.label16.Text = ":";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(236, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(8, 16);
            this.label17.TabIndex = 8;
            this.label17.Text = ":";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(200, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 16);
            this.label18.TabIndex = 17;
            this.label18.Text = "Hours";
            // 
            // numericUpDown_PauseWindowsResumeHour
            // 
            this.numericUpDown_PauseWindowsResumeHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_PauseWindowsResumeHour.Location = new System.Drawing.Point(197, 56);
            this.numericUpDown_PauseWindowsResumeHour.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_PauseWindowsResumeHour.Name = "numericUpDown_PauseWindowsResumeHour";
            this.numericUpDown_PauseWindowsResumeHour.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_PauseWindowsResumeHour.TabIndex = 7;
            this.numericUpDown_PauseWindowsResumeHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_PauseWindowsResumeHour.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // numericUpDown_PauseApplicationStartupHour
            // 
            this.numericUpDown_PauseApplicationStartupHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_PauseApplicationStartupHour.Location = new System.Drawing.Point(197, 32);
            this.numericUpDown_PauseApplicationStartupHour.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_PauseApplicationStartupHour.Name = "numericUpDown_PauseApplicationStartupHour";
            this.numericUpDown_PauseApplicationStartupHour.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_PauseApplicationStartupHour.TabIndex = 1;
            this.numericUpDown_PauseApplicationStartupHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_PauseApplicationStartupHour.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(285, 56);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(8, 16);
            this.label19.TabIndex = 9;
            this.label19.Text = ":";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_PauseWindowsResumeMin
            // 
            this.numericUpDown_PauseWindowsResumeMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_PauseWindowsResumeMin.Location = new System.Drawing.Point(245, 56);
            this.numericUpDown_PauseWindowsResumeMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_PauseWindowsResumeMin.Name = "numericUpDown_PauseWindowsResumeMin";
            this.numericUpDown_PauseWindowsResumeMin.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_PauseWindowsResumeMin.TabIndex = 10;
            this.numericUpDown_PauseWindowsResumeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_PauseWindowsResumeMin.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(288, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 16);
            this.label20.TabIndex = 12;
            this.label20.Text = "Seconds";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(241, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 16);
            this.label21.TabIndex = 11;
            this.label21.Text = "Minutes";
            // 
            // numericUpDown_PauseApplicationStartupMin
            // 
            this.numericUpDown_PauseApplicationStartupMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_PauseApplicationStartupMin.Location = new System.Drawing.Point(245, 32);
            this.numericUpDown_PauseApplicationStartupMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_PauseApplicationStartupMin.Name = "numericUpDown_PauseApplicationStartupMin";
            this.numericUpDown_PauseApplicationStartupMin.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_PauseApplicationStartupMin.TabIndex = 3;
            this.numericUpDown_PauseApplicationStartupMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_PauseApplicationStartupMin.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(285, 32);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(8, 16);
            this.label22.TabIndex = 4;
            this.label22.Text = ":";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_PauseWindowsResumeSec
            // 
            this.numericUpDown_PauseWindowsResumeSec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_PauseWindowsResumeSec.Location = new System.Drawing.Point(293, 56);
            this.numericUpDown_PauseWindowsResumeSec.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_PauseWindowsResumeSec.Name = "numericUpDown_PauseWindowsResumeSec";
            this.numericUpDown_PauseWindowsResumeSec.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_PauseWindowsResumeSec.TabIndex = 13;
            this.numericUpDown_PauseWindowsResumeSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_PauseWindowsResumeSec.Value = new decimal(new int[] {
            34,
            0,
            0,
            0});
            // 
            // numericUpDown_PauseApplicationStartupSec
            // 
            this.numericUpDown_PauseApplicationStartupSec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_PauseApplicationStartupSec.Location = new System.Drawing.Point(293, 32);
            this.numericUpDown_PauseApplicationStartupSec.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_PauseApplicationStartupSec.Name = "numericUpDown_PauseApplicationStartupSec";
            this.numericUpDown_PauseApplicationStartupSec.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_PauseApplicationStartupSec.TabIndex = 5;
            this.numericUpDown_PauseApplicationStartupSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_PauseApplicationStartupSec.Value = new decimal(new int[] {
            34,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.numericUpDown_DefaultIdleStatusUpdateIntervalHour);
            this.groupBox1.Controls.Add(this.numericUpDown_DefaultActiveStatusUpdateIntervalHour);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numericUpDown_DefaultIdleStatusUpdateIntervalMin);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDown_DefaultActiveStatusUpdateIntervalMin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDown_DefaultIdleStatusUpdateIntervalSec);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDown_DefaultActiveStatusUpdateIntervalSec);
            this.groupBox1.Location = new System.Drawing.Point(9, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default status checking interval when...";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(236, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(8, 16);
            this.label13.TabIndex = 2;
            this.label13.Text = ":";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(236, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(8, 16);
            this.label12.TabIndex = 8;
            this.label12.Text = ":";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(200, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 16);
            this.label11.TabIndex = 17;
            this.label11.Text = "Hours";
            // 
            // numericUpDown_DefaultIdleStatusUpdateIntervalHour
            // 
            this.numericUpDown_DefaultIdleStatusUpdateIntervalHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_DefaultIdleStatusUpdateIntervalHour.Location = new System.Drawing.Point(197, 56);
            this.numericUpDown_DefaultIdleStatusUpdateIntervalHour.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_DefaultIdleStatusUpdateIntervalHour.Name = "numericUpDown_DefaultIdleStatusUpdateIntervalHour";
            this.numericUpDown_DefaultIdleStatusUpdateIntervalHour.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_DefaultIdleStatusUpdateIntervalHour.TabIndex = 7;
            this.numericUpDown_DefaultIdleStatusUpdateIntervalHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_DefaultIdleStatusUpdateIntervalHour.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // numericUpDown_DefaultActiveStatusUpdateIntervalHour
            // 
            this.numericUpDown_DefaultActiveStatusUpdateIntervalHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_DefaultActiveStatusUpdateIntervalHour.Location = new System.Drawing.Point(197, 32);
            this.numericUpDown_DefaultActiveStatusUpdateIntervalHour.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_DefaultActiveStatusUpdateIntervalHour.Name = "numericUpDown_DefaultActiveStatusUpdateIntervalHour";
            this.numericUpDown_DefaultActiveStatusUpdateIntervalHour.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_DefaultActiveStatusUpdateIntervalHour.TabIndex = 1;
            this.numericUpDown_DefaultActiveStatusUpdateIntervalHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_DefaultActiveStatusUpdateIntervalHour.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(285, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(8, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = ":";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_DefaultIdleStatusUpdateIntervalMin
            // 
            this.numericUpDown_DefaultIdleStatusUpdateIntervalMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_DefaultIdleStatusUpdateIntervalMin.Location = new System.Drawing.Point(245, 56);
            this.numericUpDown_DefaultIdleStatusUpdateIntervalMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_DefaultIdleStatusUpdateIntervalMin.Name = "numericUpDown_DefaultIdleStatusUpdateIntervalMin";
            this.numericUpDown_DefaultIdleStatusUpdateIntervalMin.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_DefaultIdleStatusUpdateIntervalMin.TabIndex = 10;
            this.numericUpDown_DefaultIdleStatusUpdateIntervalMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_DefaultIdleStatusUpdateIntervalMin.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(288, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Seconds";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(241, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Minutes";
            // 
            // numericUpDown_DefaultActiveStatusUpdateIntervalMin
            // 
            this.numericUpDown_DefaultActiveStatusUpdateIntervalMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_DefaultActiveStatusUpdateIntervalMin.Location = new System.Drawing.Point(245, 32);
            this.numericUpDown_DefaultActiveStatusUpdateIntervalMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_DefaultActiveStatusUpdateIntervalMin.Name = "numericUpDown_DefaultActiveStatusUpdateIntervalMin";
            this.numericUpDown_DefaultActiveStatusUpdateIntervalMin.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_DefaultActiveStatusUpdateIntervalMin.TabIndex = 3;
            this.numericUpDown_DefaultActiveStatusUpdateIntervalMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_DefaultActiveStatusUpdateIntervalMin.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(285, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(8, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = ":";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "... form is active:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_DefaultIdleStatusUpdateIntervalSec
            // 
            this.numericUpDown_DefaultIdleStatusUpdateIntervalSec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_DefaultIdleStatusUpdateIntervalSec.Location = new System.Drawing.Point(293, 56);
            this.numericUpDown_DefaultIdleStatusUpdateIntervalSec.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_DefaultIdleStatusUpdateIntervalSec.Name = "numericUpDown_DefaultIdleStatusUpdateIntervalSec";
            this.numericUpDown_DefaultIdleStatusUpdateIntervalSec.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_DefaultIdleStatusUpdateIntervalSec.TabIndex = 13;
            this.numericUpDown_DefaultIdleStatusUpdateIntervalSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_DefaultIdleStatusUpdateIntervalSec.Value = new decimal(new int[] {
            34,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "... form is not active:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_DefaultActiveStatusUpdateIntervalSec
            // 
            this.numericUpDown_DefaultActiveStatusUpdateIntervalSec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_DefaultActiveStatusUpdateIntervalSec.Location = new System.Drawing.Point(293, 32);
            this.numericUpDown_DefaultActiveStatusUpdateIntervalSec.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_DefaultActiveStatusUpdateIntervalSec.Name = "numericUpDown_DefaultActiveStatusUpdateIntervalSec";
            this.numericUpDown_DefaultActiveStatusUpdateIntervalSec.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_DefaultActiveStatusUpdateIntervalSec.TabIndex = 5;
            this.numericUpDown_DefaultActiveStatusUpdateIntervalSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_DefaultActiveStatusUpdateIntervalSec.Value = new decimal(new int[] {
            34,
            0,
            0,
            0});
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.checkBox_ChangeLogBeforeUpdate);
            this.tabPage2.Controls.Add(this.checkBox_UpdateAllSilently);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.comboBox_UpdateWindowAction);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(362, 261);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Update";
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label15.Location = new System.Drawing.Point(48, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(208, 16);
            this.label15.TabIndex = 28;
            this.label15.Text = "(Requires TortoiseSVN v1.5 or higher)";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(386, 334);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ShowBalloonInterval)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PauseWindowsResumeHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PauseApplicationStartupHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PauseWindowsResumeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PauseApplicationStartupMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PauseWindowsResumeSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PauseApplicationStartupSec)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DefaultIdleStatusUpdateIntervalHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DefaultActiveStatusUpdateIntervalHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DefaultIdleStatusUpdateIntervalMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DefaultActiveStatusUpdateIntervalMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DefaultIdleStatusUpdateIntervalSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DefaultActiveStatusUpdateIntervalSec)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		
		private void SettingsForm_Load(object sender, System.EventArgs e)
		{
			textBox_SVNpath.Text = Config.SvnPath;
			textBox_TortoiseSVNpath.Text = Config.TortoiseSvnPath;
			
			numericUpDown_DefaultActiveStatusUpdateIntervalHour.Value = Config.DefaultActiveStatusUpdateInterval / 3600;
			numericUpDown_DefaultActiveStatusUpdateIntervalMin.Value = (Config.DefaultActiveStatusUpdateInterval % 3600) / 60;
			numericUpDown_DefaultActiveStatusUpdateIntervalSec.Value = Config.DefaultActiveStatusUpdateInterval % 60;

			numericUpDown_DefaultIdleStatusUpdateIntervalHour.Value = Config.DefaultIdleStatusUpdateInterval / 3600;
			numericUpDown_DefaultIdleStatusUpdateIntervalMin.Value = (Config.DefaultIdleStatusUpdateInterval % 3600) / 60;
			numericUpDown_DefaultIdleStatusUpdateIntervalSec.Value = Config.DefaultIdleStatusUpdateInterval % 60;

			numericUpDown_PauseApplicationStartupHour.Value = Config.PauseAfterApplicationStartupInterval / 3600;
			numericUpDown_PauseApplicationStartupMin.Value = (Config.PauseAfterApplicationStartupInterval % 3600) / 60;
			numericUpDown_PauseApplicationStartupSec.Value = Config.PauseAfterApplicationStartupInterval % 60;
			checkBox_PauseApplicationStartup.Checked = Config.DoPauseAfterApplicationStartup;

			numericUpDown_PauseWindowsResumeHour.Value = Config.PauseAfterWindowsResumeInterval / 3600;
			numericUpDown_PauseWindowsResumeMin.Value = (Config.PauseAfterWindowsResumeInterval % 3600) / 60;
			numericUpDown_PauseWindowsResumeSec.Value = Config.PauseAfterWindowsResumeInterval % 60;
			checkBox_PauseWindowsResume.Checked = Config.DoPauseAfterWindowsResume;

			if (Config.IsTortoiseVersion_1_5_orHigher())
			{
				checkBox_ChangeLogBeforeUpdate.Checked = Config.ChangeLogBeforeUpdate;
				checkBox_ChangeLogBeforeUpdate.Enabled = true;
			}
			else
			{
				checkBox_ChangeLogBeforeUpdate.Checked = false;
				checkBox_ChangeLogBeforeUpdate.Enabled = false;
			}

			comboBox_ItemActions.SelectedIndex = (int) Config.ItemDoubleClickAction;
			numericUpDown_ShowBalloonInterval.Value = Config.ShowBalloonInterval / 1000;
			checkBox_HideOnStartup.Checked = Config.HideOnStartup;
			checkBox_ShowInTaskbar.Checked = Config.ShowInTaskbar;
			checkBox_CheckForNewVersion.Checked = Config.CheckForNewVersion;
			checkBox_UpdateAllSilently.Checked = Config.UpdateAllSilently;
			comboBox_UpdateWindowAction.SelectedIndex = Config.UpdateWindowAction;
		}


		private void button_OK_Click(object sender, System.EventArgs e)
		{
			Config.SvnPath = textBox_SVNpath.Text;
			Config.TortoiseSvnPath = textBox_TortoiseSVNpath.Text;

			Config.DefaultActiveStatusUpdateInterval = 
				(int)numericUpDown_DefaultActiveStatusUpdateIntervalHour.Value * 3600
				+ (int)numericUpDown_DefaultActiveStatusUpdateIntervalMin.Value * 60 
				+ (int)numericUpDown_DefaultActiveStatusUpdateIntervalSec.Value;

			Config.DefaultIdleStatusUpdateInterval = 
				(int)numericUpDown_DefaultIdleStatusUpdateIntervalHour.Value * 3600
				+ (int)numericUpDown_DefaultIdleStatusUpdateIntervalMin.Value * 60
				+ (int)numericUpDown_DefaultIdleStatusUpdateIntervalSec.Value;

			Config.PauseAfterApplicationStartupInterval =
				(int)numericUpDown_PauseApplicationStartupHour.Value * 3600
				+ (int)numericUpDown_PauseApplicationStartupMin.Value * 60
				+ (int)numericUpDown_PauseApplicationStartupSec.Value;
			Config.DoPauseAfterApplicationStartup = checkBox_PauseApplicationStartup.Checked;

			Config.PauseAfterWindowsResumeInterval =
				(int)numericUpDown_PauseWindowsResumeHour.Value * 3600
				+ (int)numericUpDown_PauseWindowsResumeMin.Value * 60
				+ (int)numericUpDown_PauseWindowsResumeSec.Value;
			Config.DoPauseAfterWindowsResume = checkBox_PauseWindowsResume.Checked;

			Config.ChangeLogBeforeUpdate = checkBox_ChangeLogBeforeUpdate.Checked;
			Config.ItemDoubleClickAction = (Config.Action) comboBox_ItemActions.SelectedIndex;
			Config.ShowBalloonInterval = (int)numericUpDown_ShowBalloonInterval.Value * 1000;
			Config.HideOnStartup = checkBox_HideOnStartup.Checked;
			Config.ShowInTaskbar = checkBox_ShowInTaskbar.Checked;
			Config.CheckForNewVersion = checkBox_CheckForNewVersion.Checked;
			Config.UpdateAllSilently = checkBox_UpdateAllSilently.Checked;
			Config.UpdateWindowAction = comboBox_UpdateWindowAction.SelectedIndex;

			Config.SaveSettings();
			Close();
		}


		private void button_BrowseSvn_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog_svn.ShowDialog (this) == DialogResult.OK)
			{
				textBox_SVNpath.Text = openFileDialog_svn.FileName;
				CheckPathes (sender, e);
			}
		}

		
		private void button_BrowseTortoise_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog_Tortoise.ShowDialog (this) == DialogResult.OK)
			{
				textBox_TortoiseSVNpath.Text = openFileDialog_Tortoise.FileName;
				CheckPathes (sender, e);
			}
		}


		private void CheckPathes (object sender, System.EventArgs e)
		{
			button_OK.Enabled = true;
			textBox_SVNpath.BackColor = textBox_TortoiseSVNpath.BackColor = Color.White;

			if (!File.Exists (textBox_SVNpath.Text))
			{
				textBox_SVNpath.BackColor = Color.Yellow;
				button_OK.Enabled = false;

			}
				
			if (!File.Exists (textBox_TortoiseSVNpath.Text))
			{
				textBox_TortoiseSVNpath.BackColor = Color.Yellow;
				button_OK.Enabled = false;
			}
		}

		private void checkBox_ChangeLogBeforeUpdate_CheckedChanged(object sender, System.EventArgs e)
		{
			checkBox_UpdateAllSilently.Enabled = !checkBox_ChangeLogBeforeUpdate.Checked;

			if (! checkBox_UpdateAllSilently.Enabled)
				checkBox_UpdateAllSilently.Checked = false;
		}
	}
}
