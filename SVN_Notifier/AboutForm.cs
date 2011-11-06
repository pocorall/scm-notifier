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
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace CHD.SVN_Notifier
{
	/// <summary>
	/// Summary description for AboutForm.
	/// </summary>
	public class AboutForm : Form
	{
		public static Version Version = new Version ("1.8.4");
		public static string VersionStatus = " alpha";		// " alpha", " beta", ""

		#region Windows Form Designer generated fields

		private Button btnOK;
		private LinkLabel linkLabel1;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private LinkLabel linkLabel3;
		private PictureBox pictureBox1;
		private Panel panel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>

		
		public AboutForm ()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			if (this.Parent == null)
				this.StartPosition = FormStartPosition.CenterScreen;
		}

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (AboutForm));
			this.btnOK = new System.Windows.Forms.Button ();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel ();
			this.label1 = new System.Windows.Forms.Label ();
			this.label2 = new System.Windows.Forms.Label ();
			this.label3 = new System.Windows.Forms.Label ();
			this.label4 = new System.Windows.Forms.Label ();
			this.label5 = new System.Windows.Forms.Label ();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel ();
			this.pictureBox1 = new System.Windows.Forms.PictureBox ();
			this.panel1 = new System.Windows.Forms.Panel ();
			((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit ();
			this.panel1.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOK.Location = new System.Drawing.Point (248, 240);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size (80, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb (((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (255)))));
			this.linkLabel1.Location = new System.Drawing.Point (120, 48);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size (88, 16);
			this.linkLabel1.TabIndex = 2;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "www.chd.lv";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler (this.linkLabel1_LinkClicked);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label1.Location = new System.Drawing.Point (8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size (320, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "SVN Notifier. Version $VER";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label2.Location = new System.Drawing.Point (8, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size (312, 24);
			this.label2.TabIndex = 4;
			this.label2.Text = "Copyright (C) 2007-2010 Computer Hardware Design Ltd";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label3.Location = new System.Drawing.Point (8, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size (312, 32);
			this.label3.TabIndex = 5;
			this.label3.Text = "SVN Notifier is Open Source Software released under the GNU General Public Licens" +
				"e v3.";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point (0, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size (336, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Developers: Vlad Rudenko, Aleksej Vaschenko, Nikolaj Nahimov";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point (48, 88);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size (80, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "Project home:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// linkLabel3
			// 
			this.linkLabel3.Location = new System.Drawing.Point (128, 88);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size (144, 16);
			this.linkLabel3.TabIndex = 9;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "svnnotifier.tigris.org";
			this.linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler (this.linkLabel3_LinkClicked);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject ("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point (0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size (338, 41);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add (this.label4);
			this.panel1.Controls.Add (this.label1);
			this.panel1.Controls.Add (this.label5);
			this.panel1.Controls.Add (this.linkLabel3);
			this.panel1.Controls.Add (this.linkLabel1);
			this.panel1.Controls.Add (this.label2);
			this.panel1.Controls.Add (this.label3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point (0, 41);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size (338, 191);
			this.panel1.TabIndex = 11;
			// 
			// AboutForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size (5, 13);
			this.CancelButton = this.btnOK;
			this.ClientSize = new System.Drawing.Size (338, 271);
			this.Controls.Add (this.panel1);
			this.Controls.Add (this.pictureBox1);
			this.Controls.Add (this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.Load += new System.EventHandler (this.AboutForm_Load);
			((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit ();
			this.panel1.ResumeLayout (false);
			this.ResumeLayout (false);

		}
		#endregion

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			OpenLink ("http://www.chd.lv/en/produkti");
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			OpenLink ("http://svnnotifier.tigris.org/");
		}

		private void AboutForm_Load(object sender, EventArgs e)
		{
			label1.Text = label1.Text.Replace ("$VER", Version.ToString() + VersionStatus);
		}

		private void OpenLink (string link)
		{
			try
			{
				Process.Start (link);
			}
			catch		// Ignore browser missing or delayed situations
			{
			}
		}
	}
}
