@echo off
set "year=%1"
set "day=%2"

if not exist %year% (
    mkdir %year% 2> nul 
)
cd %year%

if exist "Day%day%" (
    goto :projectExists
)
mkdir "Day%day%" 2> nul
cd "Day%day%"

:: Create new Project
dotnet new console --use-program-main

:: copy the default code
more ..\..\templates\csharp_template\Program.cs > Program.cs

:: Create the txt-files for the data
echo. 2> sample.txt
echo. 2> input.txt

:: Generate Assests for Build and Debug:
mkdir ".\.vscode"
cd ".\.vscode"
:: Create launch.json
echo { >> launch.json
echo     "version": "0.2.0", >> launch.json
echo     "configurations": [ >> launch.json
echo         { >> launch.json
echo             "name": ".NET Core Launch (console)", >> launch.json
echo             "type": "coreclr", >> launch.json
echo             "request": "launch", >> launch.json
echo             "preLaunchTask": "build", >> launch.json
echo             "program": "${workspaceFolder}/bin/Debug/net9.0/Day%day%.dll", >> launch.json
echo             "args": [], >> launch.json
echo             "cwd": "${workspaceFolder}", >> launch.json
echo             "console": "internalConsole", >> launch.json
echo             "stopAtEntry": false >> launch.json
echo         }, >> launch.json
echo         { >> launch.json
echo             "name": ".NET Core Attach", >> launch.json
echo             "type": "coreclr", >> launch.json
echo             "request": "attach" >> launch.json
echo         } >> launch.json
echo     ] >> launch.json
echo } >> launch.json

:: Create tasks.json
echo { >> tasks.json
echo     "version": "2.0.0", >> tasks.json
echo     "tasks": [ >> tasks.json
echo         { >> tasks.json
echo             "label": "build", >> tasks.json
echo             "command": "dotnet", >> tasks.json
echo             "type": "process", >> tasks.json
echo             "args": [ >> tasks.json
echo                 "build", >> tasks.json
echo                 "${workspaceFolder}/Day%day%.sln", >> tasks.json
echo                 "/property:GenerateFullPaths=true", >> tasks.json
echo                 "/consoleloggerparameters:NoSummary;ForceNoAlign" >> tasks.json
echo             ], >> tasks.json
echo             "problemMatcher": "$msCompile" >> tasks.json
echo         }, >> tasks.json
echo         { >> tasks.json
echo             "label": "publish", >> tasks.json
echo             "command": "dotnet", >> tasks.json
echo             "type": "process", >> tasks.json
echo             "args": [ >> tasks.json
echo                 "publish", >> tasks.json
echo                 "${workspaceFolder}/Day%day%.sln", >> tasks.json
echo                 "/property:GenerateFullPaths=true", >> tasks.json
echo                 "/consoleloggerparameters:NoSummary;ForceNoAlign" >> tasks.json
echo             ], >> tasks.json
echo             "problemMatcher": "$msCompile" >> tasks.json
echo         }, >> tasks.json
echo         { >> tasks.json
echo             "label": "watch", >> tasks.json
echo             "command": "dotnet", >> tasks.json
echo             "type": "process", >> tasks.json
echo             "args": [ >> tasks.json
echo                 "watch", >> tasks.json
echo                 "run", >> tasks.json
echo                 "--project", >> tasks.json
echo                 "${workspaceFolder}/Day%day%.sln" >> tasks.json
echo             ], >> tasks.json
echo             "problemMatcher": "$msCompile" >> tasks.json
echo         } >> tasks.json
echo     ] >> tasks.json
echo } >> tasks.json


cd ..\..\..
cls
set "projectPath=%year%\Day%day%"
:: Open new project
code -r %projectPath%
goto :EOF

:projectExists
echo Poject already exists!
cd ..