@echo off
set "basePath=%CD%"
set "currentYear=%date:~-4%"
set /p year="year: (%currentYear%) "
set /p day="day: "
set /p languageId="languageId: "

if "%year%"=="" (
    set year=%currentYear%
)

if not exist %year% (
    mkdir %year% 2> nul
)
cd %year%

if exist "Day%day%" (
    goto :projectExists
)
mkdir "Day%day%" 2> nul
cd "Day%day%"

:: Create the txt-files for the data
echo. 2> sample.txt
echo. 2> input.txt

goto :go


:::::::::::::::::::::::::::::::::::::::::::::::
:: go
:::::::::::::::::::::::::::::::::::::::::::::::
:go
echo "%basePath%/templates/go_template/code.go"
more "%basePath%/templates/go_template/code.go" > code.go
pause
goto :openProject



:::::::::::::::::::::::::::::::::::::::::::::::
:: C#
:::::::::::::::::::::::::::::::::::::::::::::::
:csharp
:: Create new Project
dotnet new console --use-program-main

:: copy the default code
more ..\..\templates\csharp_template\Program.cs > Program.cs



goto :openProject






::::::::::::::::::::::::::::::::::::::::::
:: Open Project
::::::::::::::::::::::::::::::::::::::::::
:openProject
cd ..\..\..
cls
set "projectPath=%year%\Day%day%"
:: Open new project
code -r .
goto :EOF



:::::::::::::::::::::::::::::::::::::::::::::::
:: Project exists already
:::::::::::::::::::::::::::::::::::::::::::::::
:projectExists
echo Poject already exists!
cd ..