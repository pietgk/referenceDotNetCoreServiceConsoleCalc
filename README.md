# referenceDotNetCoreServiceConsoleCalc

Reference DotNetCore Console Service with a simple Calculator

This projects tries to document creating a dotnet core console app.
The goal is to have a development, staging  and production context on MacOS, Linux and Windows.

## Step 1

create new github project with a visual studio .gitignore
clone it to your dev directory

### Perform

```bash
dotnet new console
dotnet run
```

In Visual Studio Code you now have a development environment with runs (and has debugging) on F5.

## Step 2 Add GitFlow to the project

I use [SourceTree](https://www.sourcetreeapp.com/) to add [GitFlow](http://nvie.com/posts/a-successful-git-branching-model/) support to the project.

## Step 3 add cake support

Please install the VSCode [cake](https://cakebuild.net/) extension to enable adding cake build automation support to the project.
in VSCode use Shift-Cmd-p to install

- cake bootstrapper (both linux mac and windows) => build.sh and build.ps1,
- configuration file => cake.config,
- debug dependancies,
- intellisense support,
- sample build file => build.cake

extend .gitignore with

```gitignore
# Misc folders
[Bb]in/
[Oo]bj/
[Pp]ackages/

# Build related
tools/**
!tools/packages.config
```
## Step 4 change Cake to run on dotnet core

Add tools/packages.config with

```xml
<?xml version="1.0" encoding="utf-8"?>
<packages>
    <package id="Cake.CoreCLR" version="0.25.0" />
</packages>
```

Change ./build.sh CAKE_EXE to

```bash
CAKE_EXE=$TOOLS_DIR/Cake.CoreCLR/Cake.dll
```

and change mono to dotnet at the bottom of ./build.sh

```bash
# Start Cake
exec dotnet "$CAKE_EXE" $SCRIPT "${CAKE_ARGUMENTS[@]}"
```

check if Cake is running on dotnet with

```bash
piets-mbpro:referenceDotNetCoreServiceConsoleCalc grop$ ./build.sh --version
Downloading NuGet...
Feeds used:
  /Users/grop/.nuget/packages/
  https://api.nuget.org/v3/index.json

Restoring NuGet package Cake.CoreCLR.0.25.0.
Adding package 'Cake.CoreCLR.0.25.0' to folder '/Users/grop/dev/reference/referenceDotNetCoreServiceConsoleCalc/tools'
Added package 'Cake.CoreCLR.0.25.0' to folder '/Users/grop/dev/reference/referenceDotNetCoreServiceConsoleCalc/tools'

             +##   #;;'
             #;;#  .+;;;;+,
             '+;;#;,+';;;;;'#.
             ++'''';;;;;;;;;;# ;#;
            ##';;;;++'+#;;;;;'.   `#:
         ;#   '+'';;;;;;;;;'#`       #.
      `#,        .'++;;;;;':..........#
    '+      `.........';;;;':.........#
   #..................+;;;;;':........#
   #..................#';;;;;'+''''''.#
   #.......,:;''''''''##';;;;;'+'''''#,
   #''''''''''''''''''###';;;;;;+''''#
   #''''''''''''''''''####';;;;;;#'''#
   #''''''''''''''''''#####';;;;;;#''#
   #''''''''''''''''''######';;;;;;#'#
   #''''''''''''''''''#######';;;;;;##
   #''''''''''''''''''########';;;;;;#
   #''''''''''''++####+;#######';;;;;;#
   #+####':,`             ,#####';;;;;;'
                              +##'''''+.
   ___      _          ___       _ _     _
  / __\__ _| | _____  / __\_   _(_) | __| |
 / /  / _` | |/ / _ \/__\// | | | | |/ _` |
/ /___ (_| |   <  __/ \/  \ |_| | | | (_| |
\____/\__,_|_|\_\___\_____/\__,_|_|_|\__,_|

                             Version 0.25.0+Branch.main.Sha.05b4d3f596defbdf5baecdb3712c9bc17f849b55
                       Running on .NET Core
```

## step 5 check if Hello Cake! works

run the cake bootstrapper and check that it works as shown below.
```
piets-mbpro:referenceDotNetCoreServiceConsoleCalc grop$ ./build.sh
Feeds used:
  /Users/grop/.nuget/packages/
  https://api.nuget.org/v3/index.json

All packages listed in /Users/grop/dev/reference/referenceDotNetCoreServiceConsoleCalc/tools/packages.config are alreadyinstalled.

----------------------------------------
Setup
----------------------------------------
Running tasks...

========================================
Default
========================================
Hello Cake!

----------------------------------------
Teardown
----------------------------------------
Finished running tasks.

Task                          Duration
--------------------------------------------------
Default                       00:00:00.0067590
--------------------------------------------------
Total:                        00:00:00.0067590
```

## step 6 restore build and run with Cake bootstrapper

```bash
piets-mbpro:referenceDotNetCoreServiceConsoleCalc grop$ ./build.sh
Feeds used:
  /Users/grop/.nuget/packages/
  https://api.nuget.org/v3/index.json

All packages listed in /Users/grop/dev/reference/referenceDotNetCoreServiceConsoleCalc/tools/packages.config are alreadyinstalled.

----------------------------------------
Setup
----------------------------------------
Running tasks...

========================================
Restore
========================================
  Restore completed in 18.01 ms for /Users/grop/dev/reference/referenceDotNetCoreServiceConsoleCalc/referenceDotNetCoreServiceConsoleCalc.csproj.

========================================
Build
========================================
Microsoft (R) Build Engine version 15.3.409.57025 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  referenceDotNetCoreServiceConsoleCalc -> /Users/grop/dev/reference/referenceDotNetCoreServiceConsoleCalc/bin/Release/netcoreapp2.0/referenceDotNetCoreServiceConsoleCalc.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:02.57

========================================
Default
========================================
Default Build

----------------------------------------
Teardown
----------------------------------------
Finished running tasks.

Task                          Duration
--------------------------------------------------
Restore                       00:00:01.9856295
Build                         00:00:04.5600727
Default                       00:00:00.0006752
--------------------------------------------------
Total:                        00:00:06.5463774
piets-mbpro:referenceDotNetCoreServiceConsoleCalc grop$ dotnet run
Hello World!
```