@echo off

rem ---------------------- UPDATE SOURCES ---------------------

echo SVN: Updating to latest revision ...
svn update

rem ------------------------- BUILD ---------------------------

echo Rebuilding solution ...

set Compiler="%VS90COMNTOOLS%\..\IDE\devenv.com"
set Solution=SVN_Notifier

%Compiler% /REBUILD Debug %Solution%.sln
if not "%errorlevel%" == "0" PAUSE