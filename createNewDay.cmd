@echo off
set "basePath=%CD%"
set "currentYear=%date:~-4%"
set /p year="year: (%currentYear%) "
set /p day="day: "

:: select programming Language
set defaultLanguage=0
echo Select the language:
echo "0 => JavaScript"
echo "1 => C#"
echo "2 => Go"
set /p languageId="Language: (%defaultLanguage%) "

if "%year%"=="" (
    set year=%currentYear%
)

if "%day%"=="" (
    goto :noDayValue
)

if "%languageId%"=="" (
    set languageId=%defaultLanguage%
)


if not exist %year% (
    mkdir %year% 2> nul
)
cd %year%

if  exist "Day%day%" (
    goto :projectExists
)

mkdir "Day%day%" 2> nul
cd "Day%day%"


:: Create the txt-files for the data
echo. 2> sample.txt
echo. 2> input.txt

if "%languageId%"=="0" (
    goto :javascript
) else if "%languageId%"=="1" (
    goto :csharp
) else if "%languageId%"=="2" (
    goto :go
) else (
    echo Invalid Language ID!
    goto :EOF
)


:::::::::::::::::::::::::::::::::::::::::::::::
:: JavaScript
:::::::::::::::::::::::::::::::::::::::::::::::
:javascript
more "%basePath%/templates/javascript_template/index.js" > part1.js
more "%basePath%/templates/javascript_template/index.js" > part2.js
goto :openProject

:::::::::::::::::::::::::::::::::::::::::::::::
:: go
:::::::::::::::::::::::::::::::::::::::::::::::
:go
more "%basePath%/templates/go_template/main.go" > main.go
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


:::::::::::::::::::::::::::::::::::::::::::::::
:: Open Project
:::::::::::::::::::::::::::::::::::::::::::::::
:openProject
cls
:: Open new project
code -r .
goto :EOF


:::::::::::::::::::::::::::::::::::::::::::::::
:: No value for the day
:::::::::::::::::::::::::::::::::::::::::::::::
:noDayValue
echo You need to specify a value for the day
goto :EOF

:::::::::::::::::::::::::::::::::::::::::::::::
:: Project exists already
:::::::::::::::::::::::::::::::::::::::::::::::
:projectExists
echo Poject already exists!
cd ..