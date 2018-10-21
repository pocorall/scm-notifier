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
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace pocorall.SCM_Notifier
{
    public enum ScmRepositoryStatus
    {
        Unknown = 3,
        Error =2,
        NeedUpdate =1,
        NeedUpdate_Modified = 5,
        UpToDate=0,
        UpToDate_Modified=4
    }

    public class ScmRepositoryStatusEx
    {
        public ScmRepositoryStatus status;
        public string branchName;
    }

    public class ScmRepositoryProcess
    {
        public readonly ScmRepository repository;
        public readonly Process process;
        public readonly bool isUpdateCommand;
        public ArrayList processOutput = new ArrayList();
        public bool updateError;

        public ScmRepositoryProcess(ScmRepository f, Process p, bool isUpdateCommand)
        {
            repository = f;
            process = p;
            updateError = false;
            this.isUpdateCommand = isUpdateCommand;
        }
    }

    abstract public class ScmRepository : ICloneable
    {
		public string Path;
		public string origPath;
		public string VisiblePath;
		public int ActiveStatusUpdateInterval;
		public int IdleStatusUpdateInterval;
		public bool Disable;
		public PathType pathType;

		public enum PathType {
			Directory = 0,
			HeadDirectory = 1,
			File = 2
		}

		public ScmRepositoryStatus Status {
			get	{ return status; }
			set	{
				status = value;
				statusUpdateTime = DateTime.Now;
			}
		}

		public DateTime StatusUpdateTime {
			get { return statusUpdateTime; }
		}

        private string scmType;

		public ScmRepository (string scmtype, string path, PathType type) {
			Path = DeserializePath (path);
			origPath = path;
			pathType = type;
            this.scmType = scmtype;
			Status = ScmRepositoryStatus.Unknown;
			statusUpdateTime = DateTime.MinValue;
			ActiveStatusUpdateInterval = -1;
			IdleStatusUpdateInterval = -1;
			Disable = false;
		}

        public string IconName
        {
            get { return scmType + "_FolderStatus_" + Status.ToString(); }
        }

		public string Serialize () {
			return scmType + "|"+origPath + "|" + ActiveStatusUpdateInterval + "|" + IdleStatusUpdateInterval + "|" + Disable + "|" + (int)pathType;
		}

        public static ScmRepository create(string path)
        {
            if (Directory.Exists(path + @"\.svn") || Directory.Exists(path + @"\_svn"))
            {
                return new SvnRepository(path, ScmRepository.PathType.Directory);
            }
            if (GitRepository.IsGitRepositoryDir(path))
            {
                return new GitRepository(path);
            }
            return null;
        }

		public static ScmRepository Deserialize(string s)
		{
			string[] p = s.Split ('|');
            ScmRepository f;
            if("Git".Equals(p[0])) {
                f = (new GitRepository(p[1]));
            } else {
                f = (new SvnRepository(p[1], (PathType)Int32.Parse(p[5])));
            }
            f.ActiveStatusUpdateInterval = Int32.Parse(p[2]);
      		f.IdleStatusUpdateInterval = Int32.Parse (p[3]);
      		f.Disable = Boolean.Parse (p[4]);
			return f;
		}

		private static string DeserializePath (string s)
		{
			Regex r = new Regex ("%(.*)%", RegexOptions.None);
			Match m = r.Match (s);
			string v = m.Groups[1].ToString().Trim();
			if (v != "")
			{
				try
				{
					string path = Environment.GetEnvironmentVariable (v);
					if (path != null)
						s = s.Replace ("%" + v + "%", path);
				}
				catch
				{
					// TODO: ...
					// ...variable is a null reference
					// ...The caller does not have EnvironmentPermission with Read access.
				}
			}
			return s;
		}


		public object Clone() {
			return MemberwiseClone();
		}


		public int GetInterval (bool formIsActive) {
			return ActiveStatusUpdateInterval < 0
			       	? (formIsActive ? Config.DefaultActiveStatusUpdateInterval : Config.DefaultIdleStatusUpdateInterval)
			       	: (formIsActive ? ActiveStatusUpdateInterval : IdleStatusUpdateInterval);
		}


		private ScmRepositoryStatus status = ScmRepositoryStatus.Unknown;
		private DateTime statusUpdateTime;

		internal int updateRevision;
		internal int reviewedRevision;

       
        protected struct ExecuteResult
        {
            public Process process;
            public string processError;
            public string processOutput;
        }

        public delegate void SvnErrorAddedHandler(string path, string error);

        public static event SvnErrorAddedHandler ErrorAdded;

        protected static void OnErrorAdded(string path, string error)
        {
            var handler = ErrorAdded;
            if (handler != null) handler(path, error);
        }

        public static ArrayList svnFolderProcesses = ArrayList.Synchronized(new ArrayList());
        private static Process backgroundProcess;

        protected static ExecuteResult ExecuteProcess(string executionFile, string workingPath, string arguments, bool waitForExit, bool lowPriority)
        {
            SetEnvironmentVariable();
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = executionFile,
                Arguments = arguments,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = Encoding.ASCII,
                WorkingDirectory=workingPath
            };

            ExecuteResult er = new ExecuteResult();
            er.process = Process.Start(psi);

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
                while ((line = er.process.StandardOutput.ReadLine()) != null)
                    lines.Add(line);

                er.processOutput = String.Join("\n", (string[])lines.ToArray(typeof(string)));
                lines.Clear();

                // Read error stream
                while ((line = er.process.StandardError.ReadLine()) != null)
                    lines.Add(line);

                er.processError = String.Join("\n", (string[])lines.ToArray(typeof(string)));
                lines.Clear();

                er.process.WaitForExit();

                if (er.process.ExitCode != 0 && er.processError.Length > 0)
                    OnErrorAdded(workingPath, er.processError);

                if ((uint)er.process.ExitCode == 0xc0000142)		// STATUS_DLL_INIT_FAILED - Occurs when Windows shutdown in progress
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

        private static void SetEnvironmentVariable()
        {
            Environment.SetEnvironmentVariable(
                    "HOME",
                    Environment.GetEnvironmentVariable("USERPROFILE"));
            Environment.SetEnvironmentVariable("TERM", "msys");
        }
        // TODO: Optimize speed; join GetRepositoryHeadRevision and GetRepositoryCommitedRevision functions into one:
        // void int GetRepositoryRevisions (string path, out int headRevision, out int committedRevision)
        protected static int GetRepositoryRevision(string binaryPath, string path, string arg)
        {
            string arguments = String.Format("info --non-interactive --xml \"{0}\" -r {1}", path, arg);
            ExecuteResult er = ExecuteProcess(binaryPath, path, arguments, true, false);

            try
            {
                SvnXml.Create(er.processOutput);
                SvnXml.ParseXmlForStatus();
                return Convert.ToInt32(SvnXml.GetValue("revision"));
            }
            catch
            {
                return 0;
            }
        }

        abstract public int GetRepositoryHeadRevision();

        abstract public int GetRepositoryCommitedRevision();

        abstract public void OpenChangeLogWindow(bool updateRevisions);

        abstract public void OpenLogWindow();

        abstract public void Update(bool updateAll);

        abstract public void Commit();

        abstract public ScmRepositoryStatusEx GetStatus();

        abstract public void BeginUpdateSilently();

        public static void ReadProcessOutput(ScmRepositoryProcess sfp)
        {
            while (!sfp.process.StandardOutput.EndOfStream)
            {
                var line = sfp.process.StandardOutput.ReadLine();
                sfp.processOutput.Add(line);
                if (sfp.isUpdateCommand && (line.Length > 1))
                {
                    if (line.StartsWith("C ") || line.StartsWith("svn"))
                        sfp.updateError = true;

                    else if (line.StartsWith("Skipped "))
                        sfp.updateError = true;
                }
            }

            while (!sfp.process.StandardError.EndOfStream)
            {
                sfp.processOutput.Add(sfp.process.StandardError.ReadLine());
                if (sfp.isUpdateCommand)
                    sfp.updateError = true;
            }
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
 	}


	public class SvnFolderCollection: IEnumerable, ICloneable
	{
		private readonly ArrayList list;


		public int Count
		{
			get
			{
				return list.Count;
			}
		}

		
		public IEnumerator GetEnumerator()
		{
			return list.GetEnumerator();
		}

		
		public ScmRepository this [int index]
		{
			get
			{
				return (ScmRepository) list[index];
			}
			set
			{
				list[index] = value;
			}
		}


		public void Clear()
		{
			list.Clear();
		}

		
		public void RemoveAt (int index)
		{
			list.RemoveAt (index);
		}


		public void Insert (int index, ScmRepository f)
		{
			list.Insert (index, f);
		}


		public int IndexOf (ScmRepository f)
		{
			return list.IndexOf (f);
		}


		public void Remove (ScmRepository f)
		{
			list.Remove (f);
		}


		public bool ContainsPath (string path)
		{
			foreach (ScmRepository f in list)
				if (f.Path == path)
					return true;
			return false;
		}


		public bool ContainsStatus (ScmRepositoryStatus status)
		{
			foreach (ScmRepository f in list)
				if (f.Status == status && !f.Disable)
					return true;

			return false;
		}

		
		public int Add (ScmRepository f)
		{
			return list.Add (f);
		}

		
		public SvnFolderCollection ()
		{
			list = ArrayList.Synchronized (new ArrayList());
		}


		public object Clone()
		{
			return new SvnFolderCollection ((ArrayList) list.Clone());
		}


		protected SvnFolderCollection (ArrayList list)
		{
			this.list = list;
		}


		public int FindNextStatusUpdateTimeMs (bool formIsActive)
		{
			if (list.Count == 0) return 3000;							// Return just some good value

			DateTime minNextTime = DateTime.MaxValue;
			DateTime now = DateTime.Now;

			foreach (ScmRepository folder in list)
			{
				TimeSpan ts = new TimeSpan (0, 0, folder.GetInterval (formIsActive));
				DateTime nextTime = folder.StatusUpdateTime + ts;

				if (nextTime <= now)
					return 0;
				
				if (nextTime < minNextTime)
					minNextTime = nextTime;
			}

			return (int) (minNextTime - now).TotalMilliseconds;
		}
	}
}
