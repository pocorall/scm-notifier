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

namespace CHD.SVN_Notifier
{
	public class SvnFolder: ICloneable
	{
		public string Path;
		public string origPath;
		public string VisiblePath;
		public int ActiveStatusUpdateInterval;
		public int IdleStatusUpdateInterval;
		public bool Disable;
		public PathType pathType;


		public enum PathType
		{
			Directory = 0,
			HeadDirectory = 1,
			File = 2
		}


		public SvnFolderStatus Status
		{
			get
			{
				return status;
			}
			set
			{
				status = value;
				statusTime = DateTime.Now;
			}
		}


		public DateTime StatusTime
		{
			get { return statusTime; }
		}


		public SvnFolder (string path, PathType type)
		{
			Path = DeserializePath (path);
			origPath = path;
			pathType = type;
			Status = SvnFolderStatus.Unknown;
			statusTime = DateTime.MinValue;
			ActiveStatusUpdateInterval = -1;
			IdleStatusUpdateInterval = -1;
			Disable = false;
		}


		public string Serialize ()
		{
			return origPath + "|" + ActiveStatusUpdateInterval + "|" + IdleStatusUpdateInterval + "|" + Disable + "|" + (int)pathType;
		}


		public static SvnFolder Deserialize (string s)
		{
			string[] p = s.Split ('|');
			SvnFolder f = new SvnFolder (p[0], (PathType) Int32.Parse (p[4]))
      		{
      			ActiveStatusUpdateInterval = Int32.Parse (p[1]),
      			IdleStatusUpdateInterval = Int32.Parse (p[2]),
      			Disable = Boolean.Parse (p[3])
      		};
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


		public object Clone()
		{
			return MemberwiseClone();
		}


		public int GetInterval (bool formIsActive)
		{
			return ActiveStatusUpdateInterval < 0
			       	? (formIsActive ? Config.DefaultActiveStatusUpdateInterval : Config.DefaultIdleStatusUpdateInterval)
			       	: (formIsActive ? ActiveStatusUpdateInterval : IdleStatusUpdateInterval);
		}


		private SvnFolderStatus status;
		private DateTime statusTime;

		internal int updateRevision;
		internal int reviewedRevision;
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

		
		public SvnFolder this [int index]
		{
			get
			{
				return (SvnFolder) list[index];
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


		public void Insert (int index, SvnFolder f)
		{
			list.Insert (index, f);
		}


		public int IndexOf (SvnFolder f)
		{
			return list.IndexOf (f);
		}


		public void Remove (SvnFolder f)
		{
			list.Remove (f);
		}


		public bool ContainsPath (string path)
		{
			foreach (SvnFolder f in list)
				if (f.Path == path)
					return true;
			return false;
		}


		public bool ContainsStatus (SvnFolderStatus status)
		{
			foreach (SvnFolder f in list)
				if (f.Status == status && !f.Disable)
					return true;

			return false;
		}

		
		public int Add (SvnFolder f)
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

			foreach (SvnFolder folder in list)
			{
				TimeSpan ts = new TimeSpan (0, 0, folder.GetInterval (formIsActive));
				DateTime nextTime = folder.StatusTime + ts;

				if (nextTime <= now)
					return 0;
				
				if (nextTime < minNextTime)
					minNextTime = nextTime;
			}

			return (int) (minNextTime - now).TotalMilliseconds;
		}
	}
}
