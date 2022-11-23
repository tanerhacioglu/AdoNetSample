@echo off

SET Compile_Mode=%1

REM !!! Compile modu statik belirlemek icin asagidaki satiri duzeltin !!!
REM echo %Compile_Mode%=Release

IF [%1] EQU [] SET Compile_Mode=Debug

IF %Compile_Mode%==Release ( MSBuild PgSql.sln /t:Rebuild /p:Configuration=Release ) ELSE ( MSBuild PgSql.sln /t:Rebuild /p:Configuration=Debug )

IF %Compile_Mode%==Release ( SET Copy_Path="bin\Release\PgSql.dll" ) ELSE (SET Copy_Path="bin\Debug\PgSql.dll" )

IF EXIST %Copy_Path% ( COPY %Copy_Path% . ) 

echo.
echo ################
echo   %Compile_Mode% Mode
echo ################
echo.

pause