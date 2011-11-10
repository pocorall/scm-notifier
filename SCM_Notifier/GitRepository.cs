//
// SCM Notifier
// Copyright Sung-Ho Lee
//
// This file is part of SCM Notifier.
//
// SCM Notifier is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
//
// SCM Notifier is distributed in the hope that it will be useful,
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
    public class GitRepository : ScmRepository
    {
        public GitRepository(string path) : base("Git", path, ScmRepository.PathType.Directory)
        {
            
        }


        public override int GetRepositoryHeadRevision()
        {
            return GetRepositoryRevision(Config.GitPath, Path, "HEAD");
        }


        public override int GetRepositoryCommitedRevision()
        {
            return GetRepositoryRevision(Config.GitPath, Path, "COMMITTED");
        }

        public override void OpenChangeLogWindow(bool updateRevisions)
        {
            if (updateRevisions)
            {
                reviewedRevision = GetRepositoryHeadRevision();
                updateRevision = GetRepositoryCommitedRevision();
            }
            string arguments = String.Format("/command:log /path:\"{0}\" /revend:{1}", Path, updateRevision);
            ExecuteProcess(Config.TortoiseGitPath, null, arguments, false, false);
        }


        public override void OpenLogWindow()
        {
            string arguments = String.Format("/command:log /path:\"{0}\"", Path);
            ExecuteProcess(Config.TortoiseGitPath, null, arguments, false, false);
        }


        /// <summary>
        /// This method waits until updating will finish
        /// </summary>
        public override void Update(bool updateAll)
        {
            string revision = Config.ChangeLogBeforeUpdate && !updateAll ? " /rev:" + reviewedRevision : "";
            string arguments = String.Format("/command:pull /path:\"{0}\"{1} /notempfile /closeonend:{2}", Path, revision, Config.UpdateWindowAction);
            ExecuteProcess(Config.TortoiseGitPath, null, arguments, true, false);
        }

        public override void Commit()
        {
            string path = Path;
            string arguments = String.Format("status -u \"{0}\"", path);
            ExecuteResult er = ExecuteProcess(Config.GitPath, path, arguments, true, true);
            if (er.processOutput.Contains("othing added to commit"))
            {

                arguments = String.Format("/command:push /path:\"{0}\" /notempfile", Path);
                er = ExecuteProcess(Config.TortoiseGitPath, null, arguments, false, false);
                svnFolderProcesses.Add(new ScmRepositoryProcess(this, er.process, false));
            }
            else
            {
                arguments = String.Format("/command:commit /path:\"{0}\" /notempfile", Path);
                er = ExecuteProcess(Config.TortoiseGitPath, null, arguments, false, false);
                svnFolderProcesses.Add(new ScmRepositoryProcess(this, er.process, false));
            }
        }

        public override ScmRepositoryStatus GetSvnFolderStatus()
        {
            string path = Path;
            if (!Directory.Exists(path) && !File.Exists(path))
            {
                OnErrorAdded(path, "File or folder don't exist!");
                return ScmRepositoryStatus.Error;
            }

            try
            {
                string arguments = String.Format("status -u \"{0}\"", path);
                ExecuteResult er = ExecuteProcess(Config.GitPath, path, arguments, true, true);

                if (er.processOutput.Contains("Changed but not updated"))
                {
                        return ScmRepositoryStatus.UpToDate_Modified;
                }
                else if (er.processOutput.Contains("branch is ahead of"))
                {
                    return ScmRepositoryStatus.UpToDate_Modified;
                }
                else if (er.processOutput.Contains("othing added to commit"))
                {
                    return ScmRepositoryStatus.UpToDate;
                }

                return ScmRepositoryStatus.Unknown;
            }
            catch
            {
                return ScmRepositoryStatus.Unknown;
            }
        }

        public override void BeginUpdateSilently()
        {
            // Skip this folder if update or commit is in progress
            foreach (ScmRepositoryProcess sp in svnFolderProcesses)
                if (sp.folder.Path == Path)
                    return;

            updateRevision = GetRepositoryCommitedRevision();
            string arguments = String.Format("update --non-interactive \"{0}\"", Path);
            ExecuteResult er = ExecuteProcess(Config.GitPath, null, arguments, false, false);
            Config.WriteLog("Svn", arguments);
            svnFolderProcesses.Add(new ScmRepositoryProcess(this, er.process, true));
        }

        public override int ImageIndex()
        {
            return (int)Status + 6;
        }


    }
}