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

using System.ComponentModel;
using System.Windows.Forms;
using Iae.Windows.Forms;

namespace CHD.SVN_Notifier
{
	/// <summary>
	/// Summary description for SettingsProjectForm.
	/// </summary>
	public class SettingsProjectForm : Form
	{
		#region Windows Form Designer generated code

		private Button btnOK;
		private CheckableGroupBox groupBox1;
		private Label label3;
		private Label label4;
		private Button btnCancel;
		private Container components = null;
		private Label label9;
		private Label label6;
		private NumericUpDown numericUpDown_IdleStatusUpdateIntervalSec;
		private NumericUpDown numericUpDown_ActiveStatusUpdateIntervalSec;
		private NumericUpDown numericUpDown_IdleStatusUpdateIntervalMin;
		private NumericUpDown numericUpDown_ActiveStatusUpdateIntervalMin;
		private Label label8;
		private Label label5;
		private Label label1;
		private NumericUpDown numericUpDown_IdleStatusUpdateIntervalHour;
		private NumericUpDown numericUpDown_ActiveStatusUpdateIntervalHour;
		private Label label2;
		private Label label7;
		private CheckBox checkBoxDisable;
		private TextBox textBox_folder;
		private FolderBrowserDialog folderBrowserDialog;
		private Label label10;
		private SvnFolder folder;



		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose (disposing);
		}

		
		private void InitializeComponent()
		{
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new Iae.Windows.Forms.CheckableGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_IdleStatusUpdateIntervalHour = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_ActiveStatusUpdateIntervalHour = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown_IdleStatusUpdateIntervalMin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_ActiveStatusUpdateIntervalMin = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_IdleStatusUpdateIntervalSec = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_ActiveStatusUpdateIntervalSec = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkBoxDisable = new System.Windows.Forms.CheckBox();
            this.textBox_folder = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IdleStatusUpdateIntervalHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ActiveStatusUpdateIntervalHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IdleStatusUpdateIntervalMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ActiveStatusUpdateIntervalMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IdleStatusUpdateIntervalSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ActiveStatusUpdateIntervalSec)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Location = new System.Drawing.Point(200, 170);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown_IdleStatusUpdateIntervalHour);
            this.groupBox1.Controls.Add(this.numericUpDown_ActiveStatusUpdateIntervalHour);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numericUpDown_IdleStatusUpdateIntervalMin);
            this.groupBox1.Controls.Add(this.numericUpDown_ActiveStatusUpdateIntervalMin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDown_IdleStatusUpdateIntervalSec);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDown_ActiveStatusUpdateIntervalSec);
            this.groupBox1.Location = new System.Drawing.Point(5, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 88);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status update interval when...";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(237, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = ":";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(237, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(8, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = ":";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(199, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Hours";
            // 
            // numericUpDown_IdleStatusUpdateIntervalHour
            // 
            this.numericUpDown_IdleStatusUpdateIntervalHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_IdleStatusUpdateIntervalHour.Location = new System.Drawing.Point(197, 56);
            this.numericUpDown_IdleStatusUpdateIntervalHour.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_IdleStatusUpdateIntervalHour.Name = "numericUpDown_IdleStatusUpdateIntervalHour";
            this.numericUpDown_IdleStatusUpdateIntervalHour.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_IdleStatusUpdateIntervalHour.TabIndex = 22;
            this.numericUpDown_IdleStatusUpdateIntervalHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_IdleStatusUpdateIntervalHour.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // numericUpDown_ActiveStatusUpdateIntervalHour
            // 
            this.numericUpDown_ActiveStatusUpdateIntervalHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_ActiveStatusUpdateIntervalHour.Location = new System.Drawing.Point(197, 32);
            this.numericUpDown_ActiveStatusUpdateIntervalHour.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_ActiveStatusUpdateIntervalHour.Name = "numericUpDown_ActiveStatusUpdateIntervalHour";
            this.numericUpDown_ActiveStatusUpdateIntervalHour.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_ActiveStatusUpdateIntervalHour.TabIndex = 21;
            this.numericUpDown_ActiveStatusUpdateIntervalHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_ActiveStatusUpdateIntervalHour.Value = new decimal(new int[] {
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
            this.label8.TabIndex = 20;
            this.label8.Text = "Seconds";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(243, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Minutes";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(285, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(8, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = ":";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_IdleStatusUpdateIntervalMin
            // 
            this.numericUpDown_IdleStatusUpdateIntervalMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_IdleStatusUpdateIntervalMin.Location = new System.Drawing.Point(245, 56);
            this.numericUpDown_IdleStatusUpdateIntervalMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_IdleStatusUpdateIntervalMin.Name = "numericUpDown_IdleStatusUpdateIntervalMin";
            this.numericUpDown_IdleStatusUpdateIntervalMin.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_IdleStatusUpdateIntervalMin.TabIndex = 17;
            this.numericUpDown_IdleStatusUpdateIntervalMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_IdleStatusUpdateIntervalMin.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // numericUpDown_ActiveStatusUpdateIntervalMin
            // 
            this.numericUpDown_ActiveStatusUpdateIntervalMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_ActiveStatusUpdateIntervalMin.Location = new System.Drawing.Point(245, 32);
            this.numericUpDown_ActiveStatusUpdateIntervalMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_ActiveStatusUpdateIntervalMin.Name = "numericUpDown_ActiveStatusUpdateIntervalMin";
            this.numericUpDown_ActiveStatusUpdateIntervalMin.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_ActiveStatusUpdateIntervalMin.TabIndex = 16;
            this.numericUpDown_ActiveStatusUpdateIntervalMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_ActiveStatusUpdateIntervalMin.Value = new decimal(new int[] {
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
            this.label6.TabIndex = 15;
            this.label6.Text = ":";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "... form is active:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_IdleStatusUpdateIntervalSec
            // 
            this.numericUpDown_IdleStatusUpdateIntervalSec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_IdleStatusUpdateIntervalSec.Enabled = false;
            this.numericUpDown_IdleStatusUpdateIntervalSec.Location = new System.Drawing.Point(293, 56);
            this.numericUpDown_IdleStatusUpdateIntervalSec.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_IdleStatusUpdateIntervalSec.Name = "numericUpDown_IdleStatusUpdateIntervalSec";
            this.numericUpDown_IdleStatusUpdateIntervalSec.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_IdleStatusUpdateIntervalSec.TabIndex = 1;
            this.numericUpDown_IdleStatusUpdateIntervalSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_IdleStatusUpdateIntervalSec.Value = new decimal(new int[] {
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
            this.label4.TabIndex = 5;
            this.label4.Text = "... form is not active:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_ActiveStatusUpdateIntervalSec
            // 
            this.numericUpDown_ActiveStatusUpdateIntervalSec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_ActiveStatusUpdateIntervalSec.Enabled = false;
            this.numericUpDown_ActiveStatusUpdateIntervalSec.Location = new System.Drawing.Point(293, 32);
            this.numericUpDown_ActiveStatusUpdateIntervalSec.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_ActiveStatusUpdateIntervalSec.Name = "numericUpDown_ActiveStatusUpdateIntervalSec";
            this.numericUpDown_ActiveStatusUpdateIntervalSec.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_ActiveStatusUpdateIntervalSec.TabIndex = 0;
            this.numericUpDown_ActiveStatusUpdateIntervalSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_ActiveStatusUpdateIntervalSec.Value = new decimal(new int[] {
            34,
            0,
            0,
            0});
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(280, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            // 
            // checkBoxDisable
            // 
            this.checkBoxDisable.Location = new System.Drawing.Point(8, 144);
            this.checkBoxDisable.Name = "checkBoxDisable";
            this.checkBoxDisable.Size = new System.Drawing.Size(136, 24);
            this.checkBoxDisable.TabIndex = 8;
            this.checkBoxDisable.Text = "Disable checking";
            this.checkBoxDisable.CheckedChanged += new System.EventHandler(this.checkBoxDisable_CheckedChanged);
            // 
            // textBox_folder
            // 
            this.textBox_folder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_folder.Location = new System.Drawing.Point(51, 12);
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.Size = new System.Drawing.Size(301, 20);
            this.textBox_folder.TabIndex = 9;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select folder controlled by Subversion";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Path:";
            // 
            // SettingsProjectForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(362, 201);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkBoxDisable);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBox_folder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsProjectForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Properties";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IdleStatusUpdateIntervalHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ActiveStatusUpdateIntervalHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IdleStatusUpdateIntervalMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ActiveStatusUpdateIntervalMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IdleStatusUpdateIntervalSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ActiveStatusUpdateIntervalSec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		
		public SettingsProjectForm (SvnFolder folder)
		{
			InitializeComponent();		// Required for Windows Form Designer support

			this.folder = folder;
			textBox_folder.Text = folder.Path;

			if (folder.ActiveStatusUpdateInterval < 0)
			{
				numericUpDown_ActiveStatusUpdateIntervalHour.Value = Config.DefaultActiveStatusUpdateInterval / 3600;
				numericUpDown_ActiveStatusUpdateIntervalMin.Value = (Config.DefaultActiveStatusUpdateInterval % 3600) / 60;
				numericUpDown_ActiveStatusUpdateIntervalSec.Value = Config.DefaultActiveStatusUpdateInterval % 60;

				numericUpDown_IdleStatusUpdateIntervalHour.Value = Config.DefaultIdleStatusUpdateInterval / 3600;
				numericUpDown_IdleStatusUpdateIntervalMin.Value = (Config.DefaultIdleStatusUpdateInterval % 3600) / 60;
				numericUpDown_IdleStatusUpdateIntervalSec.Value = Config.DefaultIdleStatusUpdateInterval % 60;

				groupBox1.Checked = false;
			}
			else
			{
				numericUpDown_ActiveStatusUpdateIntervalHour.Value = folder.ActiveStatusUpdateInterval / 3600;
				numericUpDown_ActiveStatusUpdateIntervalMin.Value = (folder.ActiveStatusUpdateInterval % 3600) / 60;
				numericUpDown_ActiveStatusUpdateIntervalSec.Value = folder.ActiveStatusUpdateInterval % 60;

				numericUpDown_IdleStatusUpdateIntervalHour.Value = folder.IdleStatusUpdateInterval / 3600;
				numericUpDown_IdleStatusUpdateIntervalMin.Value = (folder.IdleStatusUpdateInterval % 3600) / 60;
				numericUpDown_IdleStatusUpdateIntervalSec.Value = folder.IdleStatusUpdateInterval % 60;

				groupBox1.Checked = true;
			}

			checkBoxDisable.Checked = folder.Disable;
			groupBox1.Enabled = !checkBoxDisable.Checked;
		}


		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (!groupBox1.Checked)
			{
				folder.ActiveStatusUpdateInterval = -1;
				folder.IdleStatusUpdateInterval = -1;
			}
			else
			{
				folder.ActiveStatusUpdateInterval = 
					(int)numericUpDown_ActiveStatusUpdateIntervalHour.Value * 3600 
					+ (int)numericUpDown_ActiveStatusUpdateIntervalMin.Value * 60
					+ (int)numericUpDown_ActiveStatusUpdateIntervalSec.Value;

				folder.IdleStatusUpdateInterval = 
					(int)numericUpDown_IdleStatusUpdateIntervalHour.Value * 3600
					+ (int)numericUpDown_IdleStatusUpdateIntervalMin.Value * 60
					+ (int)numericUpDown_IdleStatusUpdateIntervalSec.Value;
			}

			folder.Disable = checkBoxDisable.Checked;
			folder.Path = folder.origPath = textBox_folder.Text;
		}


		private void checkBoxDisable_CheckedChanged(object sender, System.EventArgs e)
		{
			groupBox1.Enabled = !checkBoxDisable.Checked;
		}
	}
}
