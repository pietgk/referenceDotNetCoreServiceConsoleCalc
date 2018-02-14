///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

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

Task("Restore")
.Does(() => {
  DotNetCoreRestore();
});

Task("Build")
.IsDependentOn("Restore")
.Does(() => {
  DotNetCoreBuild("./referenceDotNetCoreServiceConsoleCalc.csproj", new DotNetCoreBuildSettings {
    Configuration = configuration
  });
});

Task("Default")
.IsDependentOn("Build")
.Does(() => {
   Information("Default Build");
});

RunTarget(target);