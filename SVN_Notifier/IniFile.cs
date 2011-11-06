using System;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.IO;

namespace CHD
{
	public class IniFile
	{
		/// <summary>
		/// Constructs a new IniFile instance
		/// </summary>
		public IniFile (string fileName, bool checkExistance)
		{
			if (checkExistance && !File.Exists (fileName)) 
				throw new ApplicationException ("File " + fileName + " not found");
			FileName = fileName;
			FullFileName = new FileInfo (fileName).FullName;
		}


		public readonly string FileName;

		/// <summary>
		/// Full path to the INI file.
		/// </summary>
		public readonly string FullFileName;
		
		/// <summary>
		/// Active section name
		/// </summary>
		public string Section;
		
		/// <summary>Reads an Integer from the specified key of the specified section.</summary>
		/// <param name="section">The section to search in.</param>
		/// <param name="key">The key from which to return the value.</param>
		/// <param name="defVal">The value to return if the specified key isn't found.</param>
		/// <returns>Returns the value of the specified section/key pair, or returns the default value if the specified section/key pair isn't found in the INI file.</returns>
		public int ReadInteger(string section, string key, int defVal) 
		{
			return GetPrivateProfileInt(section, key, defVal, FullFileName);
		}
		
		/// <summary>Reads an Integer from the specified key of the specified section.</summary>
		/// <param name="section">The section to search in.</param>
		/// <param name="key">The key from which to return the value.</param>
		/// <returns>Returns the value of the specified section/key pair, or returns 0 if the specified section/key pair isn't found in the INI file.</returns>
		public int ReadInteger(string section, string key) 
		{
			return ReadInteger(section, key, 0);
		}
		
		/// <summary>Reads an Integer from the specified key of the active section.</summary>
		/// <param name="key">The key from which to return the value.</param>
		/// <param name="defVal">The section to search in.</param>
		/// <returns>Returns the value of the specified Key, or returns the default value if the specified Key isn't found in the active section of the INI file.</returns>
		public int ReadInteger(string key, int defVal) 
		{
			return ReadInteger(Section, key, defVal);
		}
		
		/// <summary>Reads an Integer from the specified key of the active section.</summary>
		/// <param name="key">The key from which to return the value.</param>
		/// <returns>Returns the value of the specified key, or returns 0 if the specified key isn't found in the active section of the INI file.</returns>
		public int ReadInteger(string key) 
		{
			return ReadInteger(key, 0);
		}
		
		/// <summary>Reads a String from the specified key of the specified section.</summary>
		/// <param name="section">The section to search in.</param>
		/// <param name="key">The key from which to return the value.</param>
		/// <param name="defVal">The value to return if the specified key isn't found.</param>
		/// <returns>Returns the value of the specified section/key pair, or returns the default value if the specified section/key pair isn't found in the INI file.</returns>
		public string ReadString(string section, string key, string defVal) 
		{
			int size = GetPrivateProfileString(section, key, defVal, buffer, buffer.Length, FullFileName);
			return Encoding.Default.GetString(buffer, 0, size);
		}
		
		/// <summary>Reads a String from the specified key of the specified section.</summary>
		/// <param name="section">The section to search in.</param>
		/// <param name="key">The key from which to return the value.</param>
		/// <returns>Returns the value of the specified section/key pair, or returns an empty String if the specified section/key pair isn't found in the INI file.</returns>
		public string ReadString(string section, string key) 
		{
			return ReadString(section, key, "");
		}
		
		/// <summary>Reads a String from the specified key of the active section.</summary>
		/// <param name="key">The key from which to return the value.</param>
		/// <returns>Returns the value of the specified key, or returns an empty String if the specified key isn't found in the active section of the INI file.</returns>
		public string ReadString(string key) 
		{
			return ReadString(Section, key);
		}
		
		/// <summary>Reads a Long from the specified key of the specified section.</summary>
		/// <param name="section">The section to search in.</param>
		/// <param name="key">The key from which to return the value.</param>
		/// <param name="defVal">The value to return if the specified key isn't found.</param>
		/// <returns>Returns the value of the specified section/key pair, or returns the default value if the specified section/key pair isn't found in the INI file.</returns>
		public long ReadLong(string section, string key, long defVal) 
		{
			return long.Parse(ReadString(section, key, defVal.ToString()));
		}
		
		/// <summary>Reads a Long from the specified key of the specified section.</summary>
		/// <param name="section">The section to search in.</param>
		/// <param name="key">The key from which to return the value.</param>
		/// <returns>Returns the value of the specified section/key pair, or returns 0 if the specified section/key pair isn't found in the INI file.</returns>
		public long ReadLong(string section, string key) 
		{
			return ReadLong(section, key, 0);
		}
		
		/// <summary>Reads a Long from the specified key of the active section.</summary>
		/// <param name="key">The key from which to return the value.</param>
		/// <param name="defVal">The section to search in.</param>
		/// <returns>Returns the value of the specified key, or returns the default value if the specified key isn't found in the active section of the INI file.</returns>
		public long ReadLong(string key, long defVal) 
		{
			return ReadLong(Section, key, defVal);
		}
		
		/// <summary>Reads a Long from the specified key of the active section.</summary>
		/// <param name="key">The key from which to return the value.</param>
		/// <returns>Returns the value of the specified Key, or returns 0 if the specified Key isn't found in the active section of the INI file.</returns>
		public long ReadLong(string key) 
		{
			return ReadLong(key, 0);
		}
		
		/// <summary>Reads a Byte array from the specified key of the specified section.</summary>
		/// <param name="section">The section to search in.</param>
		/// <param name="key">The key from which to return the value.</param>
		/// <returns>Returns the value of the specified section/key pair, or returns null (Nothing in VB.NET) if the specified section/key pair isn't found in the INI file.</returns>
		public byte[] ReadByteArray(string section, string key) 
		{
			return Convert.FromBase64String(ReadString(section, key));
		}
		
		/// <summary>Reads a Byte array from the specified key of the active section.</summary>
		/// <param name="key">The key from which to return the value.</param>
		/// <returns>Returns the value of the specified key, or returns null (Nothing in VB.NET) if the specified key pair isn't found in the active section of the INI file.</returns>
		public byte[] ReadByteArray(string key) 
		{
			return ReadByteArray(Section, key);
		}
		
		/// <summary>Reads a Boolean from the specified key of the specified section.</summary>
		/// <param name="section">The section to search in.</param>
		/// <param name="key">The key from which to return the value.</param>
		/// <param name="defVal">The value to return if the specified key isn't found.</param>
		/// <returns>Returns the value of the specified section/key pair, or returns the default value if the specified section/key pair isn't found in the INI file.</returns>
		public bool ReadBoolean (string section, string key, bool defVal) 
		{
			switch (ReadString (section, key, defVal.ToString()).ToUpper())
			{
				case "TRUE":
				case "YES": 
					return true;
				case "FALSE":
				case "NO":
					return false;
				default:
					throw new ApplicationException ("Bad boolean value for '" + key + "' in [" + section + "]");
			}
		}
		
		/// <summary>Reads a Boolean from the specified key of the specified section.</summary>
		/// <param name="section">The section to search in.</param>
		/// <param name="key">The key from which to return the value.</param>
		/// <returns>Returns the value of the specified section/key pair, or returns false if the specified section/key pair isn't found in the INI file.</returns>
		public bool ReadBoolean(string section, string key) 
		{
			return ReadBoolean(section, key, false);
		}
		
		/// <summary>Reads a Boolean from the specified key of the specified section.</summary>
		/// <param name="key">The key from which to return the value.</param>
		/// <param name="defVal">The value to return if the specified key isn't found.</param>
		/// <returns>Returns the value of the specified key pair, or returns the default value if the specified key isn't found in the active section of the INI file.</returns>
		public bool ReadBoolean(string key, bool defVal) 
		{
			return ReadBoolean(Section, key, defVal);
		}
		
		/// <summary>Reads a Boolean from the specified key of the specified section.</summary>
		/// <param name="key">The key from which to return the value.</param>
		/// <returns>Returns the value of the specified key, or returns false if the specified key isn't found in the active section of the INI file.</returns>
		public bool ReadBoolean(string key) 
		{
			return ReadBoolean(Section, key);
		}
		
		/// <summary>Writes a String to the specified key in the specified section.</summary>
		/// <param name="section">Specifies the section to write in.</param>
		/// <param name="key">Specifies the key to write to.</param>
		/// <param name="value">Specifies the value to write.</param>
		public void Write(string section, string key, string value) 
		{
			int result = WritePrivateProfileString(section, key, value, FullFileName);
			if (result == 0) throw new Win32Exception();
			Flush ();
		}

		/// <summary>Writes an Integer to the specified key in the specified section.</summary>
		/// <param name="section">The section to write in.</param>
		/// <param name="key">The key to write to.</param>
		/// <param name="value">The value to write.</param>
		public void Write(string section, string key, int value) 
		{
			Write(section, key, value.ToString());
		}

		/// <summary>Writes an Integer to the specified key in the active section.</summary>
		/// <param name="key">The key to write to.</param>
		/// <param name="value">The value to write.</param>
		public void Write(string key, int value) 
		{
			Write(Section, key, value);
		}

		/// <summary>Writes a String to the specified key in the active section.</summary>
		///	<param name="key">The key to write to.</param>
		/// <param name="value">The value to write.</param>
		public void Write(string key, string value) 
		{
			Write(Section, key, value);
		}

		/// <summary>Writes a Long to the specified key in the specified section.</summary>
		/// <param name="section">The section to write in.</param>
		/// <param name="key">The key to write to.</param>
		/// <param name="value">The value to write.</param>
		public void Write(string section, string key, long value) 
		{
			Write(section, key, value.ToString());
		}
		
		/// <summary>Writes a Long to the specified key in the active section.</summary>
		/// <param name="key">The key to write to.</param>
		/// <param name="value">The value to write.</param>
		public void Write(string key, long value) 
		{
			Write(Section, key, value);
		}

		/// <summary>Writes a Byte array to the specified key in the specified section.</summary>
		/// <param name="section">The section to write in.</param>
		/// <param name="key">The key to write to.</param>
		/// <param name="value">The value to write.</param>
		public void Write(string section, string key, byte[] value) 
		{
			if (value == null)
				Write(section, key, (string) null);
			else
				Write(section, key, value, 0, value.Length);
		}
		
		/// <summary>Writes a Byte array to the specified key in the active section.</summary>
		/// <param name="key">The key to write to.</param>
		/// <param name="value">The value to write.</param>
		public void Write(string key, byte[] value) 
		{
			Write(Section, key, value);
		}
		
		/// <summary>Writes a Byte array to the specified key in the specified section.</summary>
		/// <param name="section">The section to write in.</param>
		/// <param name="key">The key to write to.</param>
		/// <param name="value">The value to write.</param>
		/// <param name="offset">An offset in <i>value</i>.</param>
		/// <param name="length">The number of elements of <i>value</i> to convert.</param>
		public void Write(string section, string key, byte[] value, int offset, int length) 
		{
			if (value == null)
				Write(section, key, (string) null);
			else
				Write(section, key, Convert.ToBase64String(value, offset, length));
		}
		
		/// <summary>Writes a Boolean to the specified key in the specified section.</summary>
		/// <param name="section">The section to write in.</param>
		/// <param name="key">The key to write to.</param>
		/// <param name="value">The value to write.</param>
		public void Write(string section, string key, bool value) 
		{
			Write(section, key, value.ToString());
		}
		
		/// <summary>Writes a Boolean to the specified key in the active section.</summary>
		/// <param name="key">The key to write to.</param>
		/// <param name="value">The value to write.</param>
		public void Write(string key, bool value) 
		{
			Write(Section, key, value);
		}
		
		/// <summary>Deletes a key from the specified section.</summary>
		/// <param name="section">The section to delete from.</param>
		/// <param name="key">The key to delete.</param>
		public void DeleteKey(string section, string key) 
		{
			int result = WritePrivateProfileString(section, key, null, FullFileName);
			if (result == 0) throw new Win32Exception();
			Flush ();
		}
		
		/// <summary>Deletes a key from the active section.</summary>
		/// <param name="key">The key to delete.</param>
		public void DeleteKey(string key) 
		{
			DeleteKey(Section, key);
		}
		
		/// <summary>Deletes a section from an INI file.</summary>
		/// <param name="section">The section to delete.</param>
		public void DeleteSection(string section) 
		{
			int result = WritePrivateProfileSection(section, null, FullFileName);
			if (result == 0) throw new Win32Exception();
			Flush ();
		}
		
		/// <summary>Retrieves a list of all available sections in the INI file.</summary>
		/// <returns>Returns a string array with all available sections.</returns>
		public string[] GetSectionNames() 
		{
			int size = GetPrivateProfileSectionNames(buffer, buffer.Length, FullFileName);
			if (size == 0) return new string[0];
			return Encoding.Default.GetString(buffer, 0, size).TrimEnd('\0').Split('\0');
		}

		/// <summary>
		/// Retrieves all the keys and values for the specified section of an INI file.
		/// </summary>
		/// <param name="section">Name of the section in which data is written.</param>
		/// <returns>Returns a string array with name and value pairs associated with the section.</returns>
		public string[] GetKeysAndValues (string section)
		{
			int size = GetPrivateProfileSection(section, buffer, buffer.Length, FullFileName);
			if (size == 0) return new string[0];
			return Encoding.Default.GetString(buffer, 0, size).TrimEnd('\0').Split('\0');
		}


		/// <summary>
		/// Retrieves all the keys for the specified section of an INI file.
		/// </summary>
		/// <param name="section">Name of the section in which data is written.</param>
		/// <returns>Returns a string array with names associated with the section.</returns>
		public string[] GetKeys (string section)
		{
			string[] keysAndValues = GetKeysAndValues (section);
			if (keysAndValues.Length == 0)
				return keysAndValues;

			string[] keys = new string[keysAndValues.Length];
			for (int i = 0; i < keys.Length; i++)
				keys[i] = keysAndValues[i].Substring (0, keysAndValues[i].IndexOf ("="));

			return keys;
		}

		
		private void Flush ()
		{
			WritePrivateProfileString (null, null, null, FullFileName);
		}


		private byte[] buffer = new byte [32767];


		// API declarations

		/// <summary>
		/// The GetPrivateProfileInt function retrieves an integer associated with a key in the specified section of an initialization file.
		/// </summary>
		/// <param name="lpApplicationName">Pointer to a null-terminated string specifying the name of the section in the initialization file.</param>
		/// <param name="lpKeyName">Pointer to the null-terminated string specifying the name of the key whose value is to be retrieved. This value is in the form of a string; the GetPrivateProfileInt function converts the string into an integer and returns the integer.</param>
		/// <param name="nDefault">Specifies the default value to return if the key name cannot be found in the initialization file.</param>
		/// <param name="lpFileName">Pointer to a null-terminated string that specifies the name of the initialization file. If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.</param>
		/// <returns>The return value is the integer equivalent of the string following the specified key name in the specified initialization file. If the key is not found, the return value is the specified default value. If the value of the key is less than zero, the return value is zero.</returns>
		[DllImport("KERNEL32.DLL", EntryPoint="GetPrivateProfileIntA", SetLastError = true)]
		private static extern int GetPrivateProfileInt(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName);

		/// <summary>
		/// The WritePrivateProfileString function copies a string into the specified section of an initialization file.
		/// </summary>
		/// <param name="lpApplicationName">Pointer to a null-terminated string containing the name of the section to which the string will be copied. If the section does not exist, it is created. The name of the section is case-independent; the string can be any combination of uppercase and lowercase letters.</param>
		/// <param name="lpKeyName">Pointer to the null-terminated string containing the name of the key to be associated with a string. If the key does not exist in the specified section, it is created. If this parameter is NULL, the entire section, including all entries within the section, is deleted.</param>
		/// <param name="lpString">Pointer to a null-terminated string to be written to the file. If this parameter is NULL, the key pointed to by the lpKeyName parameter is deleted.</param>
		/// <param name="lpFileName">Pointer to a null-terminated string that specifies the name of the initialization file.</param>
		/// <returns>If the function successfully copies the string to the initialization file, the return value is nonzero; if the function fails, or if it flushes the cached version of the most recently accessed initialization file, the return value is zero.</returns>
		[DllImport("KERNEL32.DLL", EntryPoint="WritePrivateProfileStringA", SetLastError = true)]
		private static extern int WritePrivateProfileString (string lpApplicationName, string lpKeyName, string lpString, string lpFileName);
		
		/// <summary>
		/// The GetPrivateProfileString function retrieves a string from the specified section in an initialization file.
		/// </summary>
		/// <param name="lpApplicationName">Pointer to a null-terminated string that specifies the name of the section containing the key name. If this parameter is NULL, the GetPrivateProfileString function copies all section names in the file to the supplied buffer.</param>
		/// <param name="lpKeyName">Pointer to the null-terminated string specifying the name of the key whose associated string is to be retrieved. If this parameter is NULL, all key names in the section specified by the lpAppName parameter are copied to the buffer specified by the lpReturnedString parameter.</param>
		/// <param name="lpDefault">Pointer to a null-terminated default string. If the lpKeyName key cannot be found in the initialization file, GetPrivateProfileString copies the default string to the lpReturnedString buffer. This parameter cannot be NULL. <br>Avoid specifying a default string with trailing blank characters. The function inserts a null character in the lpReturnedString buffer to strip any trailing blanks.</br></param>
		/// <param name="lpReturnedString">Pointer to the buffer that receives the retrieved string.</param>
		/// <param name="nSize">Specifies the size, in TCHARs, of the buffer pointed to by the lpReturnedString parameter.</param>
		/// <param name="lpFileName">Pointer to a null-terminated string that specifies the name of the initialization file. If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.</param>
		/// <returns>The return value is the number of characters copied to the buffer, not including the terminating null character.</returns>
		[DllImport("KERNEL32.DLL", EntryPoint="GetPrivateProfileStringA", SetLastError = true)]
		private static extern int GetPrivateProfileString (string lpApplicationName, string lpKeyName, string lpDefault, byte[] lpReturnedString, int nSize, string lpFileName);
		
		/// <summary>
		/// The GetPrivateProfileSectionNames function retrieves the names of all sections in an initialization file.
		/// </summary>
		/// <param name="lpszReturnBuffer">Pointer to a buffer that receives the section names associated with the named file. The buffer is filled with one or more null-terminated strings; the last string is followed by a second null character.</param>
		/// <param name="nSize">Specifies the size, in TCHARs, of the buffer pointed to by the lpszReturnBuffer parameter.</param>
		/// <param name="lpFileName">Pointer to a null-terminated string that specifies the name of the initialization file. If this parameter is NULL, the function searches the Win.ini file. If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.</param>
		/// <returns>The return value specifies the number of characters copied to the specified buffer, not including the terminating null character. If the buffer is not large enough to contain all the section names associated with the specified initialization file, the return value is equal to the length specified by nSize minus two.</returns>
		[DllImport("KERNEL32.DLL", EntryPoint="GetPrivateProfileSectionNamesA", SetLastError = true)]
		private static extern int GetPrivateProfileSectionNames (byte[] lpszReturnBuffer, int nSize, string lpFileName);

		/// <summary>
		/// Retrieves all the keys and values for the specified section of an initialization file.
		/// </summary>
		/// <param name="lpAppName">Pointer to a null-terminated string specifying the name of the section in the initialization file.</param>
		/// <param name="lpReturnedString">Pointer to a buffer that receives the key name and value pairs associated with the named section. The buffer is filled with one or more null-terminated strings; the last string is followed by a second null character.</param>
		/// <param name="nSize">Specifies the size, in TCHARs, of the buffer pointed to by the lpReturnedString parameter.</param>
		/// <param name="lpFileName">Pointer to a null-terminated string that specifies the name of the initialization file. If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.</param>
		/// <returns>The return value specifies the number of characters copied to the buffer, not including the terminating null character. If the buffer is not large enough to contain all the key name and value pairs associated with the named section, the return value is equal to nSize minus two.</returns>
		[DllImport("KERNEL32.DLL", EntryPoint="GetPrivateProfileSectionA", SetLastError = true)]
		private static extern int GetPrivateProfileSection (string lpAppName, byte[] lpReturnedString, int nSize, string lpFileName);
		
		/// <summary>
		/// The WritePrivateProfileSection function replaces the keys and values for the specified section in an initialization file.
		/// </summary>
		/// <param name="lpAppName">Pointer to a null-terminated string specifying the name of the section in which data is written. This section name is typically the name of the calling application.</param>
		/// <param name="lpString">Pointer to a buffer containing the new key names and associated values that are to be written to the named section.</param>
		/// <param name="lpFileName">Pointer to a null-terminated string containing the name of the initialization file. If this parameter does not contain a full path for the file, the function searches the Windows directory for the file. If the file does not exist and lpFileName does not contain a full path, the function creates the file in the Windows directory. The function does not create a file if lpFileName contains the full path and file name of a file that does not exist.</param>
		/// <returns>If the function succeeds, the return value is nonzero.<br>If the function fails, the return value is zero.</br></returns>
		[DllImport("KERNEL32.DLL", EntryPoint="WritePrivateProfileSectionA", SetLastError = true)]
		private static extern int WritePrivateProfileSection (string lpAppName, string lpString, string lpFileName);
	}
}