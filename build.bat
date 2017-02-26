tools\nuget.exe install MSBuildTasks -o .build\ -version 1.5.0.214 
tools\nuget.exe install xunit.runner.msbuild -o .build\ -version 2.2.0
REM tools\nuget.exe restore src\Should.sln
REM tools\nuget.exe restore src\Should.DotNetCore.sln
msbuild.exe ms.build