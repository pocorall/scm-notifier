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

using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CHD.SVN_Notifier
{
	/// <summary>
	/// Summary description for SettingsProjectForm.
	/// </summary>
	public class ErrorLogForm : Form
	{
		#region Windows Form Designer generated code

		private Button btnCancel;
		private IContainer components;
		private TextBox textBox1;
		private Timer timer1;
		private Button btnClear;		// Required designer variable.


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
			this.components = new System.ComponentModel.Container ();
			this.btnCancel = new System.Windows.Forms.Button ();
			this.textBox1 = new System.Windows.Forms.TextBox ();
			this.btnClear = new System.Windows.Forms.Button ();
			this.timer1 = new System.Windows.Forms.Timer (this.components);
			this.SuspendLayout ();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Enabled = false;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancel.Location = new System.Drawing.Point (496, 332);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size (72, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Close";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point (0, 0);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size (576, 320);
			this.textBox1.TabIndex = 8;
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Abort;
			this.btnClear.Enabled = false;
			this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnClear.Location = new System.Drawing.Point (416, 332);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size (72, 23);
			this.btnClear.TabIndex = 9;
			this.btnClear.Text = "Clear";
			this.btnClear.Click += new System.EventHandler (this.btnClear_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler (this.timer1_Tick);
			// 
			// ErrorLogForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size (5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size (576, 365);
			this.Controls.Add (this.btnClear);
			this.Controls.Add (this.textBox1);
			this.Controls.Add (this.btnCancel);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size (480, 296);
			this.Name = "ErrorLogForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Errors";
			this.ResumeLayout (false);
			this.PerformLayout ();

		}
		#endregion

		
		public ErrorLogForm (Hashtable errorLog)
		{
			InitializeComponent();		// Required for Windows Form Designer support

			foreach (DictionaryEntry de in errorLog)
			{
				textBox1.Text += de.Value;
			}
		}


		private void btnClear_Click(object sender, System.EventArgs e)
		{
			textBox1.Clear();
		}


		private void timer1_Tick(object sender, System.EventArgs e)
		{
			btnClear.Enabled = true;
			btnCancel.Enabled = true;
			timer1.Enabled = false;
		}
	}
}
