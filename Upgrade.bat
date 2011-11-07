@ECHO off 

echo.
echo -----------------------------
echo Please close SVN Notifier !!!
echo -----------------------------
echo.
pause

SET Compiler=%VS90COMNTOOLS%
SET Compiler="%Compiler:\Tools\=\IDE\devenv.com%"

rem -------------------- GET LATEST VERSION ---------------------

svn update
SET errmsg=SVN update failed (errorlevel=%errorlevel%)
IF not %errorlevel% == 0 GOTO ERROR

rem ----------------------- UNINSTALL ----------------------------


if not exist SCM_NotifierSetup\Release\SCM_NotifierSetup.msi goto BUILD
msiexec -q -promptrestart -x SCM_NotifierSetup\Release\SCM_NotifierSetup.msi

rem If product is not installed
IF %errorlevel% == 1605 goto BUILD

SET errmsg=Uninstall failed (errorlevel=%errorlevel%)
IF %errorlevel% == 1638 SET errmsg=Another version of this product is already installed. Remove it manually in "Add/Remove Programs"

IF not %errorlevel% == 0 GOTO ERROR


rem ------------------------ BUILD ------------------------------

:BUILD

SET build=Release
%Compiler% /rebuild %build% SCM_Notifier.sln 
SET errmsg=Build failed (errorlevel=%errorlevel%)
IF not %errorlevel% == 0 GOTO ERROR

rem ----------------------- INSTALL ----------------------------

msiexec -i SCM_NotifierSetup\Release\SCM_NotifierSetup.msi
SET errmsg=Install failed (errorlevel=%errorlevel%)
IF not %errorlevel% == 0 GOTO ERROR

rem -------------------------------------------------------------

echo Completed OK
goto :EOF

rem -------------------------------------------------------------

:ERROR
echo Error: %errmsg% !!!