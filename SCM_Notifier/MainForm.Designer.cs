using System.Windows.Forms;
using DragNDrop;
using FolderSelect;
using pocorall.SCM_Notifier.Properties;

namespace pocorall.SCM_Notifier
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( )
		{
			this.components = new System.ComponentModel.Container ();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (MainForm));
			this.folderBrowserDialog = new FolderSelectDialog();
			this.statusUpdateTimer = new System.Timers.Timer ();
			this.imageListFolderStatus = new System.Windows.Forms.ImageList (this.components);
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog ();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon (this.components);
			this.trayContextMenuStrip = new System.Windows.Forms.ContextMenuStrip (this.components);
			this.menuItem_ShowList = new System.Windows.Forms.ToolStripMenuItem ();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator ();
			this.menuItem_UpdateAll = new System.Windows.Forms.ToolStripMenuItem ();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator ();
			this.menuItem_Exit = new System.Windows.Forms.ToolStripMenuItem ();
			this.menuStrip = new System.Windows.Forms.MenuStrip ();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.importConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.exportConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator ();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.updateAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator ();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator ();
			this.aboutSVNNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip (this.components);
			this.checkNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator ();
			this.changeLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator ();
			this.commitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator ();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.fetchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
			this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator ();
			this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.sortListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel ();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel ();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel ();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip ();
			this.btnChangeLog = new System.Windows.Forms.ToolStripButton ();
			this.btnUpdate = new System.Windows.Forms.ToolStripButton ();
			this.btnCommit = new System.Windows.Forms.ToolStripButton ();
			this.btnOpenFolder = new System.Windows.Forms.ToolStripButton ();
			this.btnLog = new System.Windows.Forms.ToolStripButton ();
			this.btnFetch = new System.Windows.Forms.ToolStripButton ();
			this.btnDelete = new System.Windows.Forms.ToolStripButton ();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator ();
			this.btnAddFile = new System.Windows.Forms.ToolStripButton ();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator ();
			this.btnAddFolder = new System.Windows.Forms.ToolStripButton ();
			this.pauseTimer = new System.Windows.Forms.Timer(this.components);
			this.listViewFolders = new DragNDrop.DragAndDropListView ();
			((System.ComponentModel.ISupportInitialize) (this.statusUpdateTimer)).BeginInit ();
			this.trayContextMenuStrip.SuspendLayout ();
			this.menuStrip.SuspendLayout ();
			this.contextMenuStrip.SuspendLayout ();
			this.statusStrip.SuspendLayout ();
			this.toolStrip1.SuspendLayout ();
			this.SuspendLayout ();
			//
			// folderBrowserDialog
			//
		    this.folderBrowserDialog.Title = Resources.selectFolder;
			//
			// statusUpdateTimer
			//
			this.statusUpdateTimer.AutoReset = false;
			this.statusUpdateTimer.SynchronizingObject = this;
			this.statusUpdateTimer.Elapsed += new System.Timers.ElapsedEventHandler (this.statusUpdateTimer_Elapsed);
			//
			// imageListFolderStatus
			//
            global::pocorall.SCM_Notifier.Properties.Resources.getBitmap(imageListFolderStatus.Images, "Svn_FolderStatus_UpToDate");
            global::pocorall.SCM_Notifier.Properties.Resources.getBitmap(imageListFolderStatus.Images, "Svn_FolderStatus_Error");
            global::pocorall.SCM_Notifier.Properties.Resources.getBitmap(imageListFolderStatus.Images, "Svn_FolderStatus_Unknown");
            global::pocorall.SCM_Notifier.Properties.Resources.getBitmap(imageListFolderStatus.Images, "Svn_FolderStatus_UpToDate_Modified");
            global::pocorall.SCM_Notifier.Properties.Resources.getBitmap(imageListFolderStatus.Images, "Svn_FolderStatus_NeedUpdate_Modified");
            global::pocorall.SCM_Notifier.Properties.Resources.getBitmap(imageListFolderStatus.Images, "Svn_FolderStatus_NeedUpdate");
            global::pocorall.SCM_Notifier.Properties.Resources.getBitmap(imageListFolderStatus.Images, "Git_FolderStatus_UpToDate");
            global::pocorall.SCM_Notifier.Properties.Resources.getBitmap(imageListFolderStatus.Images, "Git_FolderStatus_NeedUpdate");
            global::pocorall.SCM_Notifier.Properties.Resources.getBitmap(imageListFolderStatus.Images, "Git_FolderStatus_Error");
            global::pocorall.SCM_Notifier.Properties.Resources.getBitmap(imageListFolderStatus.Images, "Git_FolderStatus_Unknown");
            global::pocorall.SCM_Notifier.Properties.Resources.getBitmap(imageListFolderStatus.Images, "Git_FolderStatus_UpToDate_Modified");
            global::pocorall.SCM_Notifier.Properties.Resources.getBitmap(imageListFolderStatus.Images, "Git_FolderStatus_NeedUpdate_Modified");
            //
			// openFileDialog
			//
            this.openFileDialog.Title = Resources.selectFolder;
			//
			// notifyIcon
			//
			this.notifyIcon.ContextMenuStrip = this.trayContextMenuStrip;
			this.notifyIcon.Icon = ((System.Drawing.Icon) (resources.GetObject ("notifyIcon.Icon")));
			this.notifyIcon.Text = "SCM Notifier";
			this.notifyIcon.Visible = true;
			this.notifyIcon.BalloonTipClicked += new System.EventHandler (this.notifyIcon_BalloonTipClicked);
			this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler (this.notifyIcon_MouseClick);
			//
			// trayContextMenuStrip
			//
			this.trayContextMenuStrip.Items.AddRange (new System.Windows.Forms.ToolStripItem [] {
            this.menuItem_ShowList,
            this.toolStripMenuItem1,
            this.menuItem_UpdateAll,
            this.toolStripMenuItem2,
            this.menuItem_Exit});
			this.trayContextMenuStrip.Name = "contextMenuStrip";
			this.trayContextMenuStrip.Size = new System.Drawing.Size (187, 82);
			//
			// menuItem_ShowList
			//
			this.menuItem_ShowList.Name = "menuItem_ShowList";
			this.menuItem_ShowList.Size = new System.Drawing.Size (186, 22);
			this.menuItem_ShowList.Text = "Show Status Window";
			this.menuItem_ShowList.Click += new System.EventHandler (this.menuItem_ShowList_Click);
			//
			// toolStripMenuItem1
			//
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size (183, 6);
			//
			// menuItem_UpdateAll
			//
			this.menuItem_UpdateAll.Name = "menuItem_UpdateAll";
			this.menuItem_UpdateAll.Size = new System.Drawing.Size (186, 22);
			this.menuItem_UpdateAll.Text = "Update All";
			this.menuItem_UpdateAll.Click += new System.EventHandler (this.menuItem_UpdateAll_Click);
			//
			// toolStripMenuItem2
			//
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size (183, 6);
			//
			// menuItem_Exit
			//
			this.menuItem_Exit.Name = "menuItem_Exit";
			this.menuItem_Exit.Size = new System.Drawing.Size (186, 22);
			this.menuItem_Exit.Text = "Exit";
			this.menuItem_Exit.Click += new System.EventHandler (this.menuItem_Exit_Click);
			//
			// menuStrip
			//
			this.menuStrip.Items.AddRange (new System.Windows.Forms.ToolStripItem [] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point (0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size (504, 24);
			this.menuStrip.TabIndex = 9;
			this.menuStrip.Text = "menuStrip";
			//
			// fileToolStripMenuItem
			//
			this.fileToolStripMenuItem.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem [] {
            this.importConfigurationToolStripMenuItem,
            this.exportConfigurationToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size (35, 20);
			this.fileToolStripMenuItem.Text = "&File";
			//
			// importConfigurationToolStripMenuItem
			//
			this.importConfigurationToolStripMenuItem.Name = "importConfigurationToolStripMenuItem";
			this.importConfigurationToolStripMenuItem.Size = new System.Drawing.Size (197, 22);
			this.importConfigurationToolStripMenuItem.Text = "&Import Configuration...";
			this.importConfigurationToolStripMenuItem.Click += new System.EventHandler (this.menuItemImportConfig_Click);
			//
			// exportConfigurationToolStripMenuItem
			//
			this.exportConfigurationToolStripMenuItem.Name = "exportConfigurationToolStripMenuItem";
			this.exportConfigurationToolStripMenuItem.Size = new System.Drawing.Size (197, 22);
			this.exportConfigurationToolStripMenuItem.Text = "&Export Configuration...";
			this.exportConfigurationToolStripMenuItem.Click += new System.EventHandler (this.menuItemExportConfig_Click);
			//
			// toolStripMenuItem3
			//
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size (194, 6);
			//
			// exitToolStripMenuItem
			//
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size (197, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler (this.menuItemExit_Click);
			//
			// editToolStripMenuItem
			//
			this.editToolStripMenuItem.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem [] {
            this.addFolderToolStripMenuItem,
            this.addFileToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size (37, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			//
			// addFolderToolStripMenuItem
			//
			this.addFolderToolStripMenuItem.Image = global::pocorall.SCM_Notifier.Properties.Resources.Toolbar_AddFolder;
			this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
			this.addFolderToolStripMenuItem.Size = new System.Drawing.Size (152, 22);
			this.addFolderToolStripMenuItem.Text = "&Add Folder...";
			this.addFolderToolStripMenuItem.Click += new System.EventHandler (this.menuItemAddFolder_Click);
			//
			// addFileToolStripMenuItem
			//
			this.addFileToolStripMenuItem.Image = global::pocorall.SCM_Notifier.Properties.Resources.Toolbar_AddFile;
			this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
			this.addFileToolStripMenuItem.Size = new System.Drawing.Size (152, 22);
			this.addFileToolStripMenuItem.Text = "Add F&ile...";
			this.addFileToolStripMenuItem.Click += new System.EventHandler (this.menuItemAddFile_Click);
			//
			// deleteToolStripMenuItem
			//
			this.deleteToolStripMenuItem.Enabled = false;
			this.deleteToolStripMenuItem.Image = global::pocorall.SCM_Notifier.Properties.Resources.Toolbar_Remove;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size (152, 22);
			this.deleteToolStripMenuItem.Text = "&Delete...";
			this.deleteToolStripMenuItem.Click += new System.EventHandler (this.menuItemDelete_Click);
			//
			// toolsToolStripMenuItem
			//
			this.toolsToolStripMenuItem.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem [] {
            this.updateAllToolStripMenuItem,
            this.toolStripMenuItem4,
            this.settingsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size (44, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			//
			// updateAllToolStripMenuItem
			//
			this.updateAllToolStripMenuItem.Enabled = false;
			this.updateAllToolStripMenuItem.Name = "updateAllToolStripMenuItem";
			this.updateAllToolStripMenuItem.Size = new System.Drawing.Size (152, 22);
			this.updateAllToolStripMenuItem.Text = "&Update All";
			this.updateAllToolStripMenuItem.Click += new System.EventHandler (this.menuItemUpdateAll_Click);
			//
			// toolStripMenuItem4
			//
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size (149, 6);
			//
			// settingsToolStripMenuItem
			//
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size (152, 22);
			this.settingsToolStripMenuItem.Text = "&Settings...";
			this.settingsToolStripMenuItem.Click += new System.EventHandler (this.menuItemSettings_Click);
			//
			// helpToolStripMenuItem
			//
			this.helpToolStripMenuItem.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem [] {
            this.checkForUpdatesToolStripMenuItem,
            this.toolStripMenuItem5,
            this.aboutSVNNotifierToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size (40, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			//
			// checkForUpdatesToolStripMenuItem
			//
			this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
			this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size (174, 22);
			this.checkForUpdatesToolStripMenuItem.Text = "&Check for Updates";
			this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler (this.menuItemCheckNewVersion_Click);
			//
			// toolStripMenuItem5
			//
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size (171, 6);
			//
			// aboutSVNNotifierToolStripMenuItem
			//
			this.aboutSVNNotifierToolStripMenuItem.Name = "aboutSVNNotifierToolStripMenuItem";
			this.aboutSVNNotifierToolStripMenuItem.Size = new System.Drawing.Size (174, 22);
			this.aboutSVNNotifierToolStripMenuItem.Text = "&About SCM Notifier";
			this.aboutSVNNotifierToolStripMenuItem.Click += new System.EventHandler (this.menuItemAbout_Click);
			//
			// contextMenuStrip
			//
			this.contextMenuStrip.Items.AddRange (new System.Windows.Forms.ToolStripItem [] {
            this.checkNowToolStripMenuItem,
            this.toolStripMenuItem6,
            this.changeLogToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.toolStripMenuItem7,
            this.commitToolStripMenuItem,
            this.toolStripMenuItem8,
            this.openToolStripMenuItem,
            this.logToolStripMenuItem,
            this.fetchToolStripMenuItem,
            this.toolStripMenuItem9,
            this.propertiesToolStripMenuItem,
            this.toolStripSeparator3, 
            this.sortListToolStripMenuItem});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size (155, 182);
			this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler (this.contextMenuStrip_Opening);
			//
			// checkNowToolStripMenuItem
			//
			this.checkNowToolStripMenuItem.Name = "checkNowToolStripMenuItem";
			this.checkNowToolStripMenuItem.Size = new System.Drawing.Size (154, 22);
			this.checkNowToolStripMenuItem.Text = "Check Now...";
			this.checkNowToolStripMenuItem.Click += new System.EventHandler (this.checkNowToolStripMenuItem_Click);
			//
			// toolStripMenuItem6
			//
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size (151, 6);
			//
			// changeLogToolStripMenuItem
			//
			this.changeLogToolStripMenuItem.Name = "changeLogToolStripMenuItem";
			this.changeLogToolStripMenuItem.Size = new System.Drawing.Size (154, 22);
			this.changeLogToolStripMenuItem.Text = "Change Log...";
			this.changeLogToolStripMenuItem.Click += new System.EventHandler (this.changeLogToolStripMenuItem_Click);
			//
			// updateToolStripMenuItem
			//
			this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
			this.updateToolStripMenuItem.Size = new System.Drawing.Size (154, 22);
			this.updateToolStripMenuItem.Text = "Update";
			this.updateToolStripMenuItem.Click += new System.EventHandler (this.updateToolStripMenuItem_Click);
			//
			// toolStripMenuItem7
			//
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size (151, 6);
			//
			// commitToolStripMenuItem
			//
			this.commitToolStripMenuItem.Name = "commitToolStripMenuItem";
			this.commitToolStripMenuItem.Size = new System.Drawing.Size (154, 22);
			this.commitToolStripMenuItem.Text = "Commit...";
			this.commitToolStripMenuItem.Click += new System.EventHandler (this.commitToolStripMenuItem_Click);
			//
			// toolStripMenuItem8
			//
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			this.toolStripMenuItem8.Size = new System.Drawing.Size (151, 6);
			//
			// openToolStripMenuItem
			//
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size (154, 22);
			this.openToolStripMenuItem.Text = "Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler (this.openToolStripMenuItem_Click);
			//
			// logToolStripMenuItem
			//
			this.logToolStripMenuItem.Name = "logToolStripMenuItem";
			this.logToolStripMenuItem.Size = new System.Drawing.Size (154, 22);
			this.logToolStripMenuItem.Text = "Log...";
			this.logToolStripMenuItem.Click += new System.EventHandler (this.contextMenuItemLog_Click);
			//
			// fetchToolStripMenuItem
			//
			this.fetchToolStripMenuItem.Name = "fetchToolStripMenuItem";
			this.fetchToolStripMenuItem.Size = new System.Drawing.Size (154, 22);
			this.fetchToolStripMenuItem.Text = "Fetch...";
			this.fetchToolStripMenuItem.Click += new System.EventHandler (this.contextMenuItemFetch_Click);
			//
			// toolStripMenuItem9
			//
			this.toolStripMenuItem9.Name = "toolStripMenuItem9";
			this.toolStripMenuItem9.Size = new System.Drawing.Size (151, 6);
			//
			// propertiesToolStripMenuItem
			//
			this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			this.propertiesToolStripMenuItem.Size = new System.Drawing.Size (154, 22);
			this.propertiesToolStripMenuItem.Text = "Properties";
			this.propertiesToolStripMenuItem.Click += new System.EventHandler (this.propertiesToolStripMenuItem_Click);
      // 
      // sortListToolStripMenuItem
      // 
      this.sortListToolStripMenuItem.Name = "sortListToolStripMenuItem";
      this.sortListToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
      this.sortListToolStripMenuItem.Text = "Sort list (Asc, Desc, None)";
      this.sortListToolStripMenuItem.Click += new System.EventHandler(this.sortListToolStripMenuItem_Click);
      //
			// statusStrip
			//
			this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			this.statusStrip.Items.AddRange (new System.Windows.Forms.ToolStripItem [] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
			this.statusStrip.Location = new System.Drawing.Point (0, 118);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size (504, 22);
			this.statusStrip.TabIndex = 10;
			this.statusStrip.Text = "statusStrip1";
			//
			// toolStripStatusLabel1
			//
			this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size (369, 17);
			this.toolStripStatusLabel1.Spring = true;
			this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			// toolStripStatusLabel2
			//
			this.toolStripStatusLabel2.AutoSize = false;
			this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
			this.toolStripStatusLabel2.Image = ((System.Drawing.Image) (resources.GetObject ("toolStripStatusLabel2.Image")));
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size (20, 17);
			this.toolStripStatusLabel2.Click += new System.EventHandler (this.toolStripStatusLabel2_Click);
			//
			// toolStripStatusLabel3
			//
			this.toolStripStatusLabel3.AutoSize = false;
			this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size (100, 17);
			//
			// toolStrip1
			//
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem [] {
            this.btnChangeLog,
            this.btnUpdate,
            this.btnCommit,
            this.btnOpenFolder,
            this.btnLog,
			this.btnFetch,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnAddFile,
            this.toolStripSeparator2,
            this.btnAddFolder});
			this.toolStrip1.Location = new System.Drawing.Point (0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size (504, 29);
			this.toolStrip1.TabIndex = 11;
			this.toolStrip1.Text = "toolStrip1";
			//
			// btnChangeLog
			//
			this.btnChangeLog.Enabled = false;
			this.btnChangeLog.Image = global::pocorall.SCM_Notifier.Properties.Resources.Toolbar_ShowChangeLogs;
			this.btnChangeLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnChangeLog.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnChangeLog.Name = "btnChangeLog";
			this.btnChangeLog.Size = new System.Drawing.Size (90, 26);
			this.btnChangeLog.Text = "Change Log";
			this.btnChangeLog.Click += new System.EventHandler (this.btnChangeLog_Click);
			//
			// btnUpdate
			//
			this.btnUpdate.Enabled = false;
			this.btnUpdate.Image = global::pocorall.SCM_Notifier.Properties.Resources.Toolbar_Update;
			this.btnUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size (68, 26);
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new System.EventHandler (this.btnUpdate_Click);
			//
			// btnCommit
			//
			this.btnCommit.Enabled = false;
			this.btnCommit.Image = global::pocorall.SCM_Notifier.Properties.Resources.Toolbar_Commit;
			this.btnCommit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnCommit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCommit.Name = "btnCommit";
			this.btnCommit.Size = new System.Drawing.Size (68, 26);
			this.btnCommit.Text = "Commit";
			this.btnCommit.Click += new System.EventHandler (this.btnCommit_Click);
			//
			// btnOpenFolder
			//
			this.btnOpenFolder.Enabled = false;
			this.btnOpenFolder.Image = global::pocorall.SCM_Notifier.Properties.Resources.Toolbar_OpenFolder;
			this.btnOpenFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnOpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnOpenFolder.Name = "btnOpenFolder";
			this.btnOpenFolder.Size = new System.Drawing.Size (59, 26);
			this.btnOpenFolder.Text = "Open";
			this.btnOpenFolder.Click += new System.EventHandler (this.btnOpenFolder_Click);
			//
			// btnLog
			//
			this.btnLog.Enabled = false;
			this.btnLog.Image = global::pocorall.SCM_Notifier.Properties.Resources.Toolbar_ShowLogs;
			this.btnLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnLog.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnLog.Name = "btnLog";
			this.btnLog.Size = new System.Drawing.Size (50, 26);
			this.btnLog.Text = "Log";
			this.btnLog.Click += new System.EventHandler (this.btnLog_Click);
			//
			// btnFetch
			//
			this.btnFetch.Enabled = false;
			this.btnFetch.Image = global::pocorall.SCM_Notifier.Properties.Resources.Toolbar_ShowLogs;
			this.btnFetch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnFetch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFetch.Name = "btnFetch";
			this.btnFetch.Size = new System.Drawing.Size (65, 26);
			this.btnFetch.Text = "Fetch";
			this.btnFetch.Click += new System.EventHandler (this.btnFetch_Click);
			//
			// btnDelete
			//
			this.btnDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnDelete.Enabled = false;
			this.btnDelete.Image = global::pocorall.SCM_Notifier.Properties.Resources.Toolbar_Remove;
			this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size (26, 26);
			this.btnDelete.Text = "Remove";
			this.btnDelete.Click += new System.EventHandler (this.menuItemDelete_Click);
			//
			// toolStripSeparator1
			//
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size (6, 29);
			//
			// btnAddFile
			//
			this.btnAddFile.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnAddFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAddFile.Image = global::pocorall.SCM_Notifier.Properties.Resources.Toolbar_AddFile;
			this.btnAddFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddFile.Name = "btnAddFile";
			this.btnAddFile.Size = new System.Drawing.Size (26, 26);
			this.btnAddFile.Text = "Add File";
			this.btnAddFile.Click += new System.EventHandler (this.menuItemAddFile_Click);
			//
			// toolStripSeparator2
			//
			this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size (6, 29);
			//
			// btnAddFolder
			//
			this.btnAddFolder.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnAddFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAddFolder.Image = global::pocorall.SCM_Notifier.Properties.Resources.Toolbar_AddFolder;
			this.btnAddFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddFolder.Name = "btnAddFolder";
			this.btnAddFolder.Size = new System.Drawing.Size (26, 26);
			this.btnAddFolder.Text = "Add Folder";
			this.btnAddFolder.Click += new System.EventHandler (this.menuItemAddFolder_Click);
			//
			// pauseTimer
			//
			this.pauseTimer.Tick += new System.EventHandler(this.pauseTimer_Tick);
			//
			// listViewFolders
			//
			this.listViewFolders.AllowDrop = true;
			this.listViewFolders.AllowReorder = true;
			this.listViewFolders.ContextMenuStrip = this.contextMenuStrip;
			this.listViewFolders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewFolders.HideSelection = false;
			this.listViewFolders.LineColor = System.Drawing.Color.LightGray;
			this.listViewFolders.Location = new System.Drawing.Point (0, 53);
			this.listViewFolders.MultiSelect = false;
			this.listViewFolders.Name = "listViewFolders";
			this.listViewFolders.Size = new System.Drawing.Size (504, 65);
			this.listViewFolders.SmallImageList = this.imageListFolderStatus;
			this.listViewFolders.TabIndex = 0;
			this.listViewFolders.UseCompatibleStateImageBehavior = false;
			this.listViewFolders.View = System.Windows.Forms.View.List;
			this.listViewFolders.SelectedIndexChanged += new System.EventHandler (this.listViewFolders_SelectedIndexChanged);
			this.listViewFolders.DoubleClick += new System.EventHandler (this.listViewFolders_DoubleClick);
			this.listViewFolders.DragDrop += new System.Windows.Forms.DragEventHandler (this.listViewFolders_DragDrop);
			this.listViewFolders.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewFolders_DragEnter);
			this.listViewFolders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewFolders_KeyDown);
			this.listViewFolders.DragOver += new System.Windows.Forms.DragEventHandler(this.listViewFolders_DragOver);
			//
			// MainForm
			//
			this.AutoScaleBaseSize = new System.Drawing.Size (5, 13);
			this.ClientSize = new System.Drawing.Size (504, 140);
			this.Controls.Add (this.listViewFolders);
			this.Controls.Add (this.toolStrip1);
			this.Controls.Add (this.menuStrip);
			this.Controls.Add (this.statusStrip);
			this.Icon = ((System.Drawing.Icon) (resources.GetObject ("$this.Icon")));
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size (512, 160);
			this.Name = "MainForm";
			this.Text = "SCM Notifier";
			this.Deactivate += new System.EventHandler (this.MainForm_Deactivate);
			this.Activated += new System.EventHandler (this.MainForm_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Closing += new System.ComponentModel.CancelEventHandler (this.MainForm_Closing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler (this.MainForm_KeyDown);
			this.ResizeEnd += new System.EventHandler (this.MainForm_ResizeEnd);
			((System.ComponentModel.ISupportInitialize) (this.statusUpdateTimer)).EndInit ();
			this.trayContextMenuStrip.ResumeLayout (false);
			this.menuStrip.ResumeLayout (false);
			this.menuStrip.PerformLayout ();
			this.contextMenuStrip.ResumeLayout (false);
			this.statusStrip.ResumeLayout (false);
			this.statusStrip.PerformLayout ();
			this.toolStrip1.ResumeLayout (false);
			this.toolStrip1.PerformLayout ();
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		#region Windows Forms Designer variables

		private ImageList imageListFolderStatus;
        private FolderSelect.FolderSelectDialog folderBrowserDialog;
		private System.Timers.Timer statusUpdateTimer;
		private Timer pauseTimer;
		private DragAndDropListView listViewFolders;
		private OpenFileDialog openFileDialog;
		private NotifyIcon notifyIcon;
		private ContextMenuStrip trayContextMenuStrip;
		private ToolStripMenuItem menuItem_ShowList;
		private ToolStripSeparator toolStripMenuItem1;
		private ToolStripMenuItem menuItem_UpdateAll;
		private ToolStripSeparator toolStripMenuItem2;
		private ToolStripMenuItem menuItem_Exit;
		private MenuStrip menuStrip;
		private ToolStripMenuItem editToolStripMenuItem;
		private ToolStripMenuItem toolsToolStripMenuItem;
		private ToolStripMenuItem helpToolStripMenuItem;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem importConfigurationToolStripMenuItem;
		private ToolStripMenuItem exportConfigurationToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem3;
		private ToolStripMenuItem exitToolStripMenuItem;
		private ToolStripMenuItem addFolderToolStripMenuItem;
		private ToolStripMenuItem addFileToolStripMenuItem;
		private ToolStripMenuItem deleteToolStripMenuItem;
		private ToolStripMenuItem updateAllToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem4;
		private ToolStripMenuItem settingsToolStripMenuItem;
		private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem5;
		private ToolStripMenuItem aboutSVNNotifierToolStripMenuItem;
		private ContextMenuStrip contextMenuStrip;
		private ToolStripMenuItem checkNowToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem6;
		private ToolStripMenuItem changeLogToolStripMenuItem;
		private ToolStripMenuItem updateToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem7;
		private ToolStripMenuItem commitToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem8;
		private ToolStripMenuItem openToolStripMenuItem;
		private ToolStripMenuItem logToolStripMenuItem;
		private ToolStripMenuItem fetchToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem9;
		private ToolStripMenuItem propertiesToolStripMenuItem;
		private StatusStrip statusStrip;
		private ToolStripStatusLabel toolStripStatusLabel1;
		private ToolStripStatusLabel toolStripStatusLabel2;
		private ToolStrip toolStrip1;
		private ToolStripButton btnChangeLog;
		private ToolStripButton btnUpdate;
		private ToolStripButton btnCommit;
		private ToolStripButton btnOpenFolder;
		private ToolStripButton btnLog;
		private ToolStripButton btnDelete;
		private ToolStripButton btnAddFile;
		private ToolStripButton btnAddFolder;
		private ToolStripButton btnFetch;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripStatusLabel toolStripStatusLabel3;

		#endregion
	}
}