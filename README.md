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
