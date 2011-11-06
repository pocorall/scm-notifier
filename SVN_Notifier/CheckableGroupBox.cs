// http://rsdn.ru/forum/message/1415538.1.aspx
#region Using Directives

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Iae.Windows.Forms
{
	public enum CheckableType
	{
		CheckBox,
		RadioButton
	}

	/// <summary>
	/// Summary description for CheckableGroupBox.
	/// </summary>
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(CheckableGroupBox), "CheckableGroupBox.ico")]
	public sealed class CheckableGroupBox : GroupBox
	{
		#region Constants

		private const int WSCOUNT = 5;

		#endregion

		private IContainer components = null;

		#region Constructors

		public CheckableGroupBox()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			_checkBox = new CheckBox();
			_checkBox.Name = "checkBox";
			_checkBox.TabIndex = 1;
			_checkBox.Text = string.Empty;
			_checkBox.Checked = false;
			_checkBox.AutoCheck = true;
			_checkBox.Location = new Point(8, 0);
			_checkBox.Size = new Size(16, 16);
			_checkBox.CheckedChanged += new EventHandler(_checkBox_CheckedChanged);
			_checkBox.Click += new EventHandler(_checkBox_Click);

			_radioButton = new RadioButton();
			_radioButton.Name = "radioButton";
			_radioButton.TabIndex = 1;
			_radioButton.Text = string.Empty;
			_radioButton.Checked = false;
			_radioButton.AutoCheck = false;
			_radioButton.Location = new Point(8, 0);
			_radioButton.Size = new Size(16, 16);
			_radioButton.CheckedChanged +=new EventHandler(_radioButton_CheckedChanged);
			_radioButton.Click += new EventHandler(_radioButton_Click);

			this.Controls.Add(_checkBox);
			this.Controls.Add(_radioButton);

		}

		#endregion

		#region Fields

		private bool _isFirstTime = true;
		private bool _lastCheckedState = false;
		private bool _autoCheck = true;
		private CheckableType _checkableType = CheckableType.CheckBox;
		private Control _parent;
		private ArrayList _radioButtons = new ArrayList();
		private CheckBox _checkBox;
		private RadioButton _radioButton;

		#endregion

		#region Properties

		[Browsable(true)]
		[Description("The text contained in the control.")]
		public new string Text
		{
			get
			{
				if (base.Text.Length > WSCOUNT)
				{
					return base.Text.Substring(WSCOUNT);
				}
				else
				{
					return base.Text;
				}
			}
			set
			{
				base.Text = new string(' ', WSCOUNT) + value;

				// by CHD.Vosogop
				int textWidth = (int) CreateGraphics().MeasureString (value, Font).Width + 20;
				_checkBox.Text = value;
				_radioButton.Text = value;
				_checkBox.Size = new Size(textWidth, 18);
				_radioButton.Size = new Size(textWidth, 18);
			}
		}

		[Browsable(true)]
		[DefaultValue(true)]
		[Description("Causes the checkable group box to automaticaly change state when clicked.")]
		public bool AutoCheck
		{
			get
			{
				return _autoCheck;
			}
			set
			{
				_autoCheck = value;
				_checkBox.AutoCheck = value;
			}
		}

		[Browsable(true)]
		[DefaultValue(false)]
		[Description("Indicates whether the radio button is checked or not.")]
		public bool Checked
		{
			get
			{
				switch (_checkableType)
				{
					case CheckableType.CheckBox:
						return _checkBox.Checked;
					case CheckableType.RadioButton:
						return _radioButton.Checked;
					default:
						return _checkBox.Checked;
				}
			}
			set
			{
				switch (_checkableType)
				{
					case CheckableType.CheckBox:
						_checkBox.Checked = value;
						break;
					case CheckableType.RadioButton:
						_radioButton.Checked = value;
						break;
					default:
						break;
				}
			}
		}

		[Browsable(true)]
		[DefaultValue(CheckableType.CheckBox)]
		[Description("Determines the checkable type of the control (check box or radio button).")]
		public CheckableType CheckableType
		{
			get
			{
				return _checkableType;
			}
			set
			{
				_checkableType = value;
				switch (_checkableType)
				{
					case CheckableType.CheckBox:
						_checkBox.Visible = true;
						_radioButton.Visible = false;
						break;
					case CheckableType.RadioButton:
						_checkBox.Visible = false;
						_radioButton.Visible = true;
						break;
				}
			}
		}

		#endregion

		#region Overrides

		protected override void OnPaint(PaintEventArgs e)
		{
			if ((_lastCheckedState != _checkBox.Checked) || _isFirstTime)
			{
				switch (_checkableType)
				{
					case CheckableType.CheckBox:
						_checkBox_CheckedChanged(this, new EventArgs());
						break;
					case CheckableType.RadioButton:
						_radioButton_CheckedChanged(this, new EventArgs());
						break;
					default:
						break;
				}
				if (_isFirstTime)
				{
					_isFirstTime = false;
				}
			}
			base.OnPaint(e);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// CheckableGroupBox
			// 
			this.ParentChanged += new System.EventHandler(this.CheckableGroupBox_ParentChanged);

		}
		#endregion

		#region Event Handlers

		private void _checkBox_CheckedChanged(object sender, EventArgs e)
		{
			if ((_lastCheckedState != _checkBox.Checked) || _isFirstTime)
			{
				_lastCheckedState = _checkBox.Checked;
				if (!this.DesignMode)
				{
					foreach (Control control in this.Controls)
					{
						if ((control != null) && (control != _checkBox))
						{
							control.Enabled = _lastCheckedState;
						}
					}
				}
			}
			if (CheckedChanged != null)
			{
				CheckedChanged(this, new EventArgs());
			}
		}

		private void _radioButton_Click(object sender, EventArgs e)
		{
			if ((_radioButton.Checked == false) && AutoCheck)
			{
				_radioButton.Checked = true;
			}
			if (Click != null)
			{
				Click(this, new EventArgs());
			}
		}

		private void _radioButton_CheckedChanged(object sender, EventArgs e)
		{
			if ((_lastCheckedState != _radioButton.Checked) || _isFirstTime)
			{
				_lastCheckedState = _radioButton.Checked;
				if (!this.DesignMode)
				{
					foreach (Control control in this.Controls)
					{
						if ((control != null) && (control != _radioButton))
						{
							control.Enabled = _lastCheckedState;
						}
					}
				}
				if (_lastCheckedState && this.AutoCheck)
				{
					foreach (Control control in _radioButtons)
					{
						if (control is RadioButton)
						{
							RadioButton radioButton = (RadioButton)control;
							if (radioButton.AutoCheck)
							{
								radioButton.Checked = false;
							}
						}
						if (control is CheckableGroupBox)
						{
							CheckableGroupBox checkableGroupBox = (CheckableGroupBox)control;
							if (checkableGroupBox.AutoCheck 
								&& (this != checkableGroupBox)
								&& (checkableGroupBox._checkableType == CheckableType.RadioButton))
							{
								checkableGroupBox.Checked = false;
							}
						}
					}
				}
			}
			if (CheckedChanged != null)
			{
				CheckedChanged(this, new EventArgs());
			}
		}

		private void CheckableGroupBox_ParentChanged(object sender, EventArgs e)
		{
			_parent = this.Parent;
			foreach (Control control in _parent.Controls)
			{
				this.AddRadioControl(control);
			}
			_parent.ControlAdded += new ControlEventHandler(_parent_ControlAdded);
			_parent.ControlRemoved += new ControlEventHandler(_parent_ControlRemoved);
		}

		private void _checkBox_Click(object sender, EventArgs e)
		{
			if (Click != null)
			{
				Click(this, new EventArgs());
			}
		}

		private void _parent_ControlAdded(object sender, ControlEventArgs e)
		{
			this.AddRadioControl(e.Control);
		}

		private void _parent_ControlRemoved(object sender, ControlEventArgs e)
		{
			if (IsRadioControl(e.Control) && _radioButtons.Contains(e.Control))
			{
				_radioButtons.Remove(e.Control);
			}
		}

		private void RadioButton_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = sender as RadioButton;
			if (radioButton != null)
			{
				if (radioButton.AutoCheck && radioButton.Checked && this.AutoCheck)
				{
					_radioButton.Checked = false;
				}
			}
		}

		private void CheckableGroupBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckableGroupBox checkableGroupBox = sender as CheckableGroupBox;
			if (checkableGroupBox != null && checkableGroupBox != this)
			{
				if ((checkableGroupBox.CheckableType == CheckableType.RadioButton) 
					&& checkableGroupBox.AutoCheck 
					&& checkableGroupBox.Checked 
					&& this.AutoCheck)
				{
					_radioButton.Checked = false;
				}
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Determines whether control is RadioButton control or CheckableGroupBox with CheckableType == RadioButton.
		/// </summary>
		/// <returns><b>true</b> if control is RadioButton control or CheckableGroupBox with CheckableType == RadioButton; otherwise <b>false</b>.</returns>
		private bool IsRadioControl(Control control)
		{
			return 
				(this != control) 
				&& ((control is RadioButton)
				|| (control is CheckableGroupBox));
		}

		private void AddRadioControl(Control control)
		{
			if (IsRadioControl(control) && !_radioButtons.Contains(control))
			{
				_radioButtons.Add(control);
				
				if (control is RadioButton)
				{
					((RadioButton)control).CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
				}
				if (control is CheckableGroupBox)
				{
					((CheckableGroupBox)control).CheckedChanged += new EventHandler(CheckableGroupBox_CheckedChanged);
				}
			}
		}

		#endregion

		#region Events

		[Browsable(true)]
		[Description("Occurs whenever the Checked property is changed.")]
		public event EventHandler CheckedChanged;

		[Browsable(true)]
		[Description("Occurs whenever the Checked property is changed.")]
		public new event EventHandler Click;

		#endregion
	}
}

