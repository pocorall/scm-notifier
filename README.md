SCM Notifier is a tool to monitor Git and SVN repositories.

This program is forked from SVN Notifier (http://svnnotifier.tigris.org/).

### [Download Latest Version](https://pocorall.github.io/scm-notifier/SCM_Notifier.exe)
### [Download Latest .net 4.5 Version](https://github.com/regisbsb/scm-notifier/releases/download/21.05.2015/SCM_Notifier.exe)


### Run requirements
* Subversion (optional)
* TortoiseSVN (optional)
* Git
* TortoiseGit
* Microsoft Windows 2000/XP/Vista/7/8/8.1
* Microsoft .NET Framework 4.5

Git update will **not work** properly if you do not [configure private key for TortoiseGit](http://serverfault.com/questions/194567/how-to-i-tell-git-for-windows-where-to-find-my-private-rsa-key).  
Make sure you can run "git fetch" command in git repositories folder without errors or prompts before configuring them in SCM Notifier.

If you want to use Git only, let the configuration for path to Subversion and TortoiseSVN left blank.

### Build requirements
* Microsoft Visual Studio 2012, .net 4.5, C#


### Configuration
To run SCM Notifier properly, you have to specify paths to executables of Subversion, TortoiseSVN, Git and TortoiseGit. It can be specified in Settings dialog shown below:

![Bad configuration](https://raw.github.com/pocorall/scm-notifier/master/docs/settings.png)

If it is not set properly, notification worn't work (shown in red icon).

![Bad configuration](https://raw.github.com/pocorall/scm-notifier/master/docs/badConfig.png)


### License

This software is licensed under [GNU General Public License](http://www.gnu.org/licenses/licenses.html#GPL)
