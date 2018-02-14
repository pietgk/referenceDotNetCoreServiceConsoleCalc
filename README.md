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
