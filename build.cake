#load build/paths.cake

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Test");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./src/CalcService/bin") + Directory(configuration);

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(ctx =>
{
   // Executed BEFORE the first task.
   Information("Running tasks...");
});

Teardown(ctx =>
{
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore")
.IsDependentOn("Clean")
.Does(() => {
  DotNetCoreRestore("./src/CalcService.sln");
});

Task("Build")
.IsDependentOn("Restore")
.Does(() => {
  DotNetCoreBuild("./src/CalcService.sln", new DotNetCoreBuildSettings {
    Configuration = configuration
  });
});

Task("Test")
.IsDependentOn("Restore")
.Does(() => {
  DotNetCoreTest(Paths.TestProjectDirectory);
});

Task("Default")
.IsDependentOn("Build")
.Does(() => {
   Information("Default Build");
});

RunTarget(target);