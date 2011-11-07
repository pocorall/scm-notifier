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

using System.Collections;
using System.IO;
using System.Xml;

namespace CHD.SCM_Notifier
{
	public class SvnXml
	{
		private static XmlReader xmlReader;
		private static Hashtable ht = new Hashtable ();


		public static void Create (string output)
		{
			xmlReader = new XmlTextReader (new StringReader (output));
			ht = new Hashtable ();
		}


		public static void ParseXmlForStatus ()
		{
			bool skipNextReposStatus = false;
			while (xmlReader.Read())
			{
				xmlReader.MoveToElement();
				string elementName = xmlReader.Name;

				if (xmlReader.HasAttributes)
				{
					for (int i = 0; i < xmlReader.AttributeCount; i++)
					{
						xmlReader.MoveToAttribute(i);
						string attributeName = xmlReader.Name;
						string attributeValue = xmlReader.Value;

						if ((elementName == "wc-status") && (attributeName == "item") && (xmlReader.Depth == 4))
						{
							if ((attributeValue != "normal") && (attributeValue != "unversioned"))
								ht ["Modified"] = true;

							skipNextReposStatus = (attributeValue == "conflicted");				// Because it always updated in repository
						}
						else if ((elementName == "repos-status") && (attributeName == "item") && !skipNextReposStatus)
						{
							if ((attributeValue != "normal") && (attributeValue != "unversioned") && (attributeValue != "none") && (attributeValue != "external"))
								ht ["NeedUpdate"] = true;
						}
						else if ((elementName == "against") && (attributeName == "revision") && (xmlReader.Depth == 3))
						{
							ht[attributeName] = attributeValue;
						}
						else if ((elementName == "commit") && (attributeName == "revision"))
						{
							ht[attributeName] = attributeValue;
						}
					}
					xmlReader.MoveToElement();
				}
			}
		}


		public static bool ContainsKey (string key)
		{
			return ht.ContainsKey (key);
		}

	
		public static string GetValue (string key)
		{
			return (string) ht[key];
		}
	}
}
