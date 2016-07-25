tools\nuget.exe install MSBuildTasks -o .build\
tools\nuget.exe install xunit.runner.msbuild -o .build\
tools\nuget.exe restore src\Should.sln
msbuild.exe ms.build