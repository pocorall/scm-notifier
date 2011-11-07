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
using System.IO;

namespace CHD.SCM_Notifier
{
	public class Config
	{
		/// <summary>
		/// Path to svn.exe
		/// </summary>
		public static string SVNpath;


		/// <summary>
		/// Path to TortoiseProc.exe
		/// </summary>
		public static string TortoiseSVNpath;

		
		/// <summary>
		/// Status check interval (in seconds) when MainForm is activated.
		/// </summary>
		public static int DefaultActiveStatusUpdateInterval;


		/// <summary>
		/// Status check interval (in seconds) when MainForm is not activated.
		/// </summary>
		public static int DefaultIdleStatusUpdateInterval;


		/// <summary>
		/// Interval (in seconds) to suspend status check after application startup.
		/// </summary>
		public static int PauseAfterApplicationStartupInterval;


		/// <summary>
		/// Interval (in seconds) to suspend status check after Windows resume.
		/// </summary>
		public static int PauseAfterWindowsResumeInterval;

		/// <summary>
		/// Pause after startup is active
		/// </summary>
		public static bool DoPauseAfterApplicationStartup;

		/// <summary>
		/// Pause after Windows resume is active
		/// </summary>
		public static bool DoPauseAfterWindowsResume;

		/// <summary>
		/// ShowBalloon hide interval in milliseconds.
		/// </summary>
		public static int ShowBalloonInterval;


		/// <summary>
		/// Item double click action.
		/// </summary>
		public enum Action
		{
			openAction = 0,
			logAction = 1,
			updateAction = 2,
			commitAction = 3,
			checkNow = 4
		}
		
		
		public static Action ItemDoubleClickAction;

		/// <summary>
		/// Main window status on startup
		/// </summary>
		public static bool HideOnStartup;
		public static bool ShowInTaskbar;
		public static bool CheckForNewVersion;


		/// <summary>
		/// Force to see Change Log before Update
		/// </summary>
		public static bool ChangeLogBeforeUpdate;


		/// <summary>
		/// Don't show the status during all updating
		/// </summary>
		public static bool UpdateAllSilently;


		/// <summary>
		/// Close the progress dialog at the end of a update command automatically.
		/// </summary>
		public static int UpdateWindowAction;


		public static void Init (string fileName)
		{
			iniFileName = fileName;
			logFileName = Path.ChangeExtension (fileName, "log");
			Init ();
		}


		public static void Init ()
		{
			iniFile = new IniFile (iniFileName, false);

			MigrateIfNecessary ();

			// Read settings

			SVNpath = iniFile.ReadString ("Settings", "SVN_path", defaultSVNpath);
			TortoiseSVNpath = iniFile.ReadString ("Settings", "TortoiseSVN_path", defaultTortoiseSVN_path);

			DefaultActiveStatusUpdateInterval = iniFile.ReadInteger ("Settings", "DefaultActiveStatusUpdateInterval", 5);
			DefaultIdleStatusUpdateInterval = iniFile.ReadInteger ("Settings", "DefaultIdleStatusUpdateInterval", 60);

			PauseAfterApplicationStartupInterval = iniFile.ReadInteger("Settings", "PauseAfterApplicationStartupInterval", 15);
			DoPauseAfterApplicationStartup = iniFile.ReadBoolean("Settings", "DoPauseAfterApplicationStartup", true);
			PauseAfterWindowsResumeInterval = iniFile.ReadInteger("Settings", "PauseAfterWindowsResumeInterval", 15);
			DoPauseAfterWindowsResume = iniFile.ReadBoolean("Settings", "DoPauseAfterWindowsResume", true);

			ItemDoubleClickAction = (Action) iniFile.ReadInteger ("Settings", "ItemDoubleClickAction", 0);
			ShowBalloonInterval = iniFile.ReadInteger ("Settings", "ShowBallonInterval", 10000);
			HideOnStartup = iniFile.ReadBoolean ("Settings", "HideOnStartup", false);
			ShowInTaskbar = iniFile.ReadBoolean ("Settings", "ShowInTaskbar", false);
			CheckForNewVersion = iniFile.ReadBoolean ("Settings", "CheckForNewVersion", true);
			UpdateAllSilently = iniFile.ReadBoolean ("Settings", "UpdateAllSilently", true);
			UpdateWindowAction = iniFile.ReadInteger ("Settings", "UpdateWindowAction", 2);

			ChangeLogBeforeUpdate = IsTortoiseVersion_1_5_orHigher() && iniFile.ReadBoolean ("Settings", "ChangeLogBeforeUpdate", false);
		}


		public static bool IsSettingsOK()
		{
			return File.Exists (SVNpath) && File.Exists (TortoiseSVNpath);
		}


		public static void SaveSettings ()
		{
			iniFile.Write ("Settings", "SVN_path", SVNpath);
			iniFile.Write ("Settings", "TortoiseSVN_path", TortoiseSVNpath);

			iniFile.Write ("Settings", "DefaultActiveStatusUpdateInterval", DefaultActiveStatusUpdateInterval);
			iniFile.Write ("Settings", "DefaultIdleStatusUpdateInterval", DefaultIdleStatusUpdateInterval);

			iniFile.Write("Settings", "PauseAfterApplicationStartupInterval", PauseAfterApplicationStartupInterval);
			iniFile.Write("Settings", "DoPauseAfterApplicationStartup", DoPauseAfterApplicationStartup);
			iniFile.Write("Settings", "PauseAfterWindowsResumeInterval", PauseAfterWindowsResumeInterval);
			iniFile.Write("Settings", "DoPauseAfterWindowsResume", DoPauseAfterWindowsResume);

			iniFile.Write ("Settings", "ItemDoubleClickAction", (int) ItemDoubleClickAction);
			iniFile.Write ("Settings", "ShowBallonInterval", ShowBalloonInterval);
			iniFile.Write ("Settings", "HideOnStartup", HideOnStartup);
			iniFile.Write ("Settings", "ShowInTaskbar", ShowInTaskbar);
			iniFile.Write ("Settings", "CheckForNewVersion", CheckForNewVersion);
			iniFile.Write ("Settings", "ChangeLogBeforeUpdate", ChangeLogBeforeUpdate);
			iniFile.Write ("Settings", "UpdateAllSilently", UpdateAllSilently);
			iniFile.Write ("Settings", "UpdateWindowAction", UpdateWindowAction);
		}


		public static void MigrateIfNecessary ()
		{
			string iniVersion = iniFile.ReadString ("Settings", "Version");
			if (iniVersion == IniFileVersion) return;

			#region Migrate earlier ini-file versions to 1.5

			if (iniVersion == "")
			{
				for (int i = 1;; i++)
				{
					string s = iniFile.ReadString ("Folders", "Folder" + i);
					if (s.Length == 0) break;

					string[] p = s.Split (',');

					if ((p.Length == 0) || (p.Length == 2) || (p.Length > 4))
						throw new ApplicationException ("INI-file: Bad format for Folder" + i);

					//	For SCM_Notifier versions < 1.?.?
					if (p.Length == 1)
						s += ",-1,-1";

					//	For SCM_Notifier versions < 1.3.0
					if (p.Length <= 3)		
						s += ",False";

					//	For SCM_Notifier versions < 1.5.0
					if (p.Length <= 4)													
						s += "," + (File.Exists (p[0]) ? (int) SvnFolder.PathType.File : (int) SvnFolder.PathType.Directory);

					iniFile.Write ("Folders", "Folder" + i, s);
				}

				iniVersion = "1.5";
			}

			#endregion

			#region Migrate 1.5 to 1.7

			if (iniVersion == "1.5")
			{
				for (int i = 1;; i++)
				{
					string s = iniFile.ReadString ("Folders", "Folder" + i);
					if (s.Length == 0) break;

					s = s.Replace (',', '|');
					iniFile.Write ("Folders", "Folder" + i, s);
				}

				iniVersion = "1.7";
			}

			#endregion

			#region Place for next migration code

			// TODO: Fix misspelling: "ShowBallonInterval" -> "ShowBalloonInterval"

			#endregion

			if (iniVersion != IniFileVersion)
				throw new ApplicationException ("INI-file migration code is incomplete");

			iniFile.Write ("Settings", "Version", IniFileVersion);
		}


		public static bool IsTortoiseVersion_1_5_orHigher()
		{
			return GetTortoiseVersion() >= new Version ("1.5");
		}


		private static Version GetTortoiseVersion ()
		{
			try
			{
				string s = (string) Microsoft.Win32.Registry.CurrentUser.OpenSubKey (@"Software\TortoiseSVN").GetValue("CurrentVersion");
				return new Version (s.Replace (',','.'));
			}
			catch
			{
				return new Version ("0.0.0");
			}
		}


		public static SvnFolderCollection ReadSvnFolders ()
		{
			SvnFolderCollection folders = new SvnFolderCollection();

			for (int i = 1;; i++)
			{
				string s = iniFile.ReadString ("Folders", "Folder" + i);
				if (s.Length == 0) break;

				folders.Add (SvnFolder.Deserialize (s));
			}

			return folders;
		}


		public static void SaveSvnFolders (SvnFolderCollection folders)
		{
			iniFile.DeleteSection ("Folders");

			int i = 1;
			foreach (SvnFolder folder in folders)
			{
				iniFile.Write ("Folders", "Folder" + i, folder.Serialize());
				i++;
			}
		}


		public static void SaveMainFormSize (int width, int height)
		{
			if ((formWidth != width) || (formHeight != height))
			{
				formWidth = width;
				formHeight = height;
				iniFile.Write ("Settings", "MainFormWidth", width);
				iniFile.Write ("Settings", "MainFormHeight", height);
			}
		}


		public static int[] ReadMainFormSize ()
		{
			formWidth = iniFile.ReadInteger ("Settings", "MainFormWidth", 0);
			formHeight = iniFile.ReadInteger ("Settings", "MainFormHeight", 0);
			return new[] {formWidth, formHeight};
		}


		/// <summary>
		/// Write text logs to log-file
		/// </summary>
		/// <param name="section"></param>
		/// <param name="arguments"></param>
		public static void WriteLog (string section, string arguments)
		{
			File.AppendAllText (logFileName, string.Format ("{0}\t{1}\t{2}\r\n", DateTime.Now, section, arguments));
		}


		/// <summary>
		/// Path to SCM_Notifier.ini
		/// </summary>
		internal static string iniFileName;

		/// <summary>
		/// Path to log file
		/// </summary>
		internal static string logFileName;

		#region Private fields
		
		private const string defaultSVNpath = @"C:\Program Files\CollabNet Subversion Client\svn.exe";
		private const string defaultTortoiseSVN_path = @"C:\Program Files\TortoiseSVN\bin\TortoiseProc.exe";

		private static IniFile iniFile;

		private static int formWidth;
		private static int formHeight;

		/// <summary>
		/// Current version of ini-file format
		/// </summary>
		private const string IniFileVersion = "1.7";

		#endregion
	}
}
