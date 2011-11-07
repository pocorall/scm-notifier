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
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CHD.SCM_Notifier
{
	public enum SvnFolderStatus
	{
		Unknown,
		Error,
		NeedUpdate,
		NeedUpdate_Modified,
		UpToDate,
		UpToDate_Modified
	}


	public class SvnFolderProcess
	{
		public readonly SvnFolder folder;
		public readonly Process process;
		public readonly bool isUpdateCommand;
		public ArrayList processOutput = new ArrayList ();
		public bool updateError;


		public SvnFolderProcess (SvnFolder f, Process p, bool isUpdateCommand)
		{
			folder = f;
			process = p;
			updateError = false;
			this.isUpdateCommand = isUpdateCommand;
		}
	}


	public delegate void SvnErrorAddedHandler (string path, string error);


	public class SvnTools
	{
		public static event SvnErrorAddedHandler ErrorAdded;

		// TortoiseSVN switches
		private const string tortoiseChangeLogArguments = "/command:log /path:\"{0}\" /revend:{1}";
		private const string tortoiseLogArguments = "/command:log /path:\"{0}\"";
		private const string tortoiseUpdateArguments = "/command:update /path:\"{0}\"{1} /notempfile /closeonend:{2}";
		private const string tortoiseCommitArguments = "/command:commit /path:\"{0}\" /notempfile";

		// SVN switches
		private const string svnStatusArguments = "status -u --non-interactive --xml \"{0}\"";
		private const string svnInfoArguments = "info --non-interactive --xml \"{0}\" -r {1}";
		private const string svnUpdateArguments = "update --non-interactive \"{0}\"";

		public static ArrayList svnFolderProcesses = ArrayList.Synchronized (new ArrayList());
		private static Process backgroundProcess;


		// TODO: Optimize speed; join GetRepositoryHeadRevision and GetRepositoryCommitedRevision functions into one:
		// void int GetRepositoryRevisions (string path, out int headRevision, out int committedRevision)
		private static int GetRepositoryRevision (string path, string arg)
		{
			string arguments = String.Format (svnInfoArguments, path, arg);
			ExecuteResult er = ExecuteProcess (Config.SVNpath, path, arguments, true, false);

			try
			{
				SvnXml.Create (er.processOutput);
				SvnXml.ParseXmlForStatus ();
				return Convert.ToInt32 (SvnXml.GetValue ("revision"));
			}
			catch
			{
				return 0;
			}
		}


		public static int GetRepositoryHeadRevision (SvnFolder folder)
		{
			return GetRepositoryRevision (folder.Path, "HEAD");
		}


		public static int GetRepositoryCommitedRevision (SvnFolder folder)
		{
			return GetRepositoryRevision (folder.Path, "COMMITTED");
		}


		public static void OpenChangeLogWindow (SvnFolder folder, bool updateRevisions)
		{
			if (updateRevisions)
			{
				folder.reviewedRevision = GetRepositoryHeadRevision (folder);
				folder.updateRevision = GetRepositoryCommitedRevision (folder);
			}
			string arguments = String.Format (tortoiseChangeLogArguments, folder.Path, folder.updateRevision);
			ExecuteProcess (Config.TortoiseSVNpath, null, arguments, false, false);
		}


		public static void OpenLogWindow (string path)
		{
			string arguments = String.Format (tortoiseLogArguments, path);
			ExecuteProcess (Config.TortoiseSVNpath, null, arguments, false, false);
		}


		/// <summary>
		/// This method waits until updating will finish
		/// </summary>
		public static void Update (SvnFolder folder, bool updateAll)
		{
			string revision = Config.ChangeLogBeforeUpdate && !updateAll ? " /rev:" + folder.reviewedRevision : "";
			string arguments = String.Format (tortoiseUpdateArguments, folder.Path, revision, Config.UpdateWindowAction);
			ExecuteProcess (Config.TortoiseSVNpath, null, arguments, true, false);
		}
		

		public static void BeginUpdateSilently (SvnFolder folder)
		{
			// Skip this folder if update or commit is in progress
			foreach (SvnFolderProcess sp in svnFolderProcesses)
				if (sp.folder.Path == folder.Path)
					return;

			folder.updateRevision = GetRepositoryCommitedRevision (folder);
			string arguments = String.Format (svnUpdateArguments, folder.Path);
			ExecuteResult er = ExecuteProcess (Config.SVNpath, null, arguments, false, false);
			Config.WriteLog ("Svn", arguments);
			svnFolderProcesses.Add (new SvnFolderProcess (folder, er.process, true));
		}


		public static void ReadProcessOutput (SvnFolderProcess sfp)
		{
			while (!sfp.process.StandardOutput.EndOfStream)
			{
				var line = sfp.process.StandardOutput.ReadLine ();
				sfp.processOutput.Add (line);
				if (sfp.isUpdateCommand && (line.Length > 1))
				{
					if (line.StartsWith ("C ") || line.StartsWith ("svn"))
						sfp.updateError = true;

					else if (line.StartsWith ("Skipped "))
						sfp.updateError = true;
				}
			}

			while (!sfp.process.StandardError.EndOfStream)
			{
				sfp.processOutput.Add (sfp.process.StandardError.ReadLine ());
				if (sfp.isUpdateCommand)
					sfp.updateError = true;
			}
		}


		public static void Commit (SvnFolder folder)
		{
			string arguments = String.Format (tortoiseCommitArguments, folder.Path);
			ExecuteResult er = ExecuteProcess (Config.TortoiseSVNpath, null, arguments, false, false);
			svnFolderProcesses.Add (new SvnFolderProcess (folder, er.process, false));
		}


		public static SvnFolderStatus GetSvnFolderStatus (SvnFolder folder)
		{
			string path = folder.Path;
			if (!Directory.Exists (path) && !File.Exists (path))
			{
				ErrorAdded (path, "File or folder don't exist!");
				return SvnFolderStatus.Error;
			}

			try
			{
				string arguments = String.Format (svnStatusArguments, path);
				ExecuteResult er = ExecuteProcess (Config.SVNpath, path, arguments, true, true);

				SvnXml.Create (er.processOutput);		// Because SVN may return non-valid XML in some cases?

				try
				{
					//http://svn.collab.net/repos/svn/trunk/subversion/svn/status.c
					//http://blog.wolfman.com/articles/category/svn

					SvnXml.ParseXmlForStatus ();

					if (!SvnXml.ContainsKey ("revision"))
					{
						ErrorAdded (path, "Folder not found in repository");
						return SvnFolderStatus.Error;
					}
					
					if (SvnXml.ContainsKey ("NeedUpdate"))
					{
						if (SvnXml.ContainsKey ("Modified"))
							return SvnFolderStatus.NeedUpdate_Modified;
					
						return SvnFolderStatus.NeedUpdate;
					}

					if (SvnXml.ContainsKey ("Modified"))
							return SvnFolderStatus.UpToDate_Modified;

					return SvnFolderStatus.UpToDate;
				}
				catch
				{
					return SvnFolderStatus.Error;
				}
			}
			catch
			{
				return SvnFolderStatus.Unknown;
			}
		}


		private static ExecuteResult ExecuteProcess (string executionFile, string workingPath, string arguments, bool waitForExit, bool lowPriority)
		{
			ProcessStartInfo psi = new ProcessStartInfo
           	{
           		FileName = executionFile,
           		Arguments = arguments,
           		CreateNoWindow = true,
           		UseShellExecute = false,
           		RedirectStandardOutput = true,
           		RedirectStandardError = true,
                StandardOutputEncoding = Encoding.ASCII
           	};

			ExecuteResult er = new ExecuteResult();
			er.process = Process.Start (psi);

			if (waitForExit) backgroundProcess = er.process;
			
			if (lowPriority)
			{
				try
				{
					er.process.PriorityClass = ProcessPriorityClass.Idle;
				}
				catch	// Exception may occur if process finishing or already finished
				{
				}
			}

			if (waitForExit)
			{
				ArrayList lines = new ArrayList();
				string line;

				// Read output stream
				while (( line = er.process.StandardOutput.ReadLine() ) != null)
					lines.Add (line);

				er.processOutput = String.Join ("\n", (string[]) lines.ToArray (typeof (string)));
				lines.Clear();

				// Read error stream
				while (( line = er.process.StandardError.ReadLine() ) != null)
					lines.Add (line);

				er.processError = String.Join ("\n", (string[]) lines.ToArray (typeof (string)));
				lines.Clear();

				if (er.processError.Length > 0)
					ErrorAdded (workingPath, er.processError);

				er.process.WaitForExit();

				if ((uint) er.process.ExitCode == 0xc0000142)		// STATUS_DLL_INIT_FAILED - Occurs when Windows shutdown in progress
				{
					Application.Exit();

					if (Thread.CurrentThread == MainForm.statusThread)
						Thread.CurrentThread.Abort();
				}

				backgroundProcess = null;
			}
			else
			{
				er.processOutput = "";
				er.processError = "";
			}

			return er;
		}


		public static void KillBackgroundProcess()
		{
			if (backgroundProcess != null)
			{
				try
				{
					backgroundProcess.Kill();
				}
				catch
				{
				}
			}
		}


		private struct ExecuteResult
		{
			public Process process;
			public string processError;
			public string processOutput;
		}
	}
}
