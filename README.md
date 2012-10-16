SCM Notifier is a tool to monitor Git and SVN repositories.

This program is forked from SVN Notifier (http://svnnotifier.tigris.org/).

### [Download Latest Version](https://github.com/downloads/pocorall/scm-notifier/SCM_Notifier.exe)

### Run requirements
* Subversion
* TortoiseSVN
* Git
* TortoiseGit
* Microsoft Windows 2000/XP/Vista/7
* Microsoft .NET Framework 4.0

### Build requirements
* Microsoft Visual Studio 2010, C#


### Configuration
To run SCM Notifier properly, you have to specify paths to executables of Subversion, TortoiseSVN, Git and TortoiseGit. It can be specified in Settings dialog shown below:

![Bad configuration](https://raw.github.com/pocorall/scm-notifier/master/docs/settings.png)

If it is not set properly, notification worn't work (shown in red icon).

![Bad configuration](https://raw.github.com/pocorall/scm-notifier/master/docs/badConfig.png)

If you want to use Git only, let the configuration for path to Subversion and TortoiseSVN left blank.

Git update will not work properly if you do not [configure private key for TortoiseGit](http://serverfault.com/questions/194567/how-to-i-tell-git-for-windows-where-to-find-my-private-rsa-key).  

### License

[GNU General Public License](http://www.gnu.org/licenses/licenses.html#GPL)
