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
    public class SvnRepository : ScmRepository
    {
        public SvnRepository(string path, PathType type) : base("Svn", path, type)
        {
        }


        public override int GetRepositoryHeadRevision()
        {
            return GetRepositoryRevision(Config.SvnPath, Path, "HEAD");
        }


        public override int GetRepositoryCommitedRevision()
        {
            return GetRepositoryRevision(Config.SvnPath, Path, "COMMITTED");
        }

        public override void OpenChangeLogWindow(bool updateRevisions)
        {
            if (updateRevisions)
            {
                reviewedRevision = GetRepositoryHeadRevision();
                updateRevision = GetRepositoryCommitedRevision();
            }
            string arguments = String.Format("/command:log /path:\"{0}\" /revend:{1}", Path, updateRevision);
            ExecuteProcess(Config.TortoiseSvnPath, null, arguments, false, false);
        }


        public override void OpenLogWindow()
        {
            string arguments = String.Format("/command:log /path:\"{0}\"", Path);
            ExecuteProcess(Config.TortoiseSvnPath, null, arguments, false, false);
        }

        /// <summary>
        /// This method waits until updating will finish
        /// </summary>
        public override void Update(bool updateAll)
        {
            string revision = Config.ChangeLogBeforeUpdate && !updateAll ? " /rev:" + reviewedRevision : "";
            string arguments = String.Format("/command:update /path:\"{0}\"{1} /notempfile /closeonend:{2}", Path, revision, Config.UpdateWindowAction);
            ExecuteProcess(Config.TortoiseSvnPath, null, arguments, true, false);
        }

        public override void Commit()
        {
            string arguments = String.Format("/command:commit /path:\"{0}\" /notempfile", Path);
            ExecuteResult er = ExecuteProcess(Config.TortoiseSvnPath, null, arguments, false, false);
            svnFolderProcesses.Add(new ScmRepositoryProcess(this, er.process, false));
        }

        public override ScmRepositoryStatusEx GetStatus()
        {
            if (!Directory.Exists(Path) && !File.Exists(Path))
            {
                OnErrorAdded(Path, "File or folder don't exist!");
                return new ScmRepositoryStatusEx() { status = ScmRepositoryStatus.Error };
            }

            try
            {
                string arguments = String.Format("status -u --non-interactive --xml \"{0}\"", Path);
                ExecuteResult er = ExecuteProcess(Config.SvnPath, Path, arguments, true, true);

                SvnXml.Create(er.processOutput);		// Because SVN may return non-valid XML in some cases?

                try
                {
                    //http://svn.collab.net/repos/svn/trunk/subversion/svn/status.c
                    //http://blog.wolfman.com/articles/category/svn

                    SvnXml.ParseXmlForStatus();

                    if (!SvnXml.ContainsKey("revision"))
                    {
                        OnErrorAdded(Path, "Folder not found in repository");
                        return new ScmRepositoryStatusEx() { status = ScmRepositoryStatus.Error }; 
                    }

                    if (SvnXml.ContainsKey("NeedUpdate"))
                    {
                        if (SvnXml.ContainsKey("Modified"))
                            return new ScmRepositoryStatusEx() { status = ScmRepositoryStatus.NeedUpdate_Modified };

                        return new ScmRepositoryStatusEx() { status = ScmRepositoryStatus.NeedUpdate };
                    }

                    if (SvnXml.ContainsKey("Modified"))
                        return new ScmRepositoryStatusEx() { status = ScmRepositoryStatus.UpToDate_Modified };

                    return new ScmRepositoryStatusEx() { status = ScmRepositoryStatus.UpToDate };
                }
                catch
                {
                    return new ScmRepositoryStatusEx() { status = ScmRepositoryStatus.Error }; 
                }
            }
            catch
            {
                return new ScmRepositoryStatusEx() { status = ScmRepositoryStatus.Unknown }; 
            }
        }

        public override void BeginUpdateSilently()
        {
            // Skip this folder if update or commit is in progress
            foreach (ScmRepositoryProcess sp in svnFolderProcesses)
                if (sp.repository.Path == Path)
                    return;

            updateRevision = GetRepositoryCommitedRevision();
            string arguments = String.Format("update --non-interactive \"{0}\"", Path);
            ExecuteResult er = ExecuteProcess(Config.SvnPath, null, arguments, false, false);
            Config.WriteLog("Svn", arguments);
            svnFolderProcesses.Add(new ScmRepositoryProcess(this, er.process, true));
        }
    }
}