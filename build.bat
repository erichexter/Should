tools\nuget.exe install MSBuildTasks -o .build\
tools\nuget.exe restore src\Should.sln
msbuild.exe ms.build