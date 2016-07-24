tools\nuget.exe install MSBuildTasks -o .build\
tools\nuget.exe install
msbuild.exe ms.build /p:BuildNumber=1.0.0.1