# NWCommon

A cross-platform .NET setup for creating mods for Neon White.

## Dependencies

This project supports at least .NET 8.0 out of the box, and utilizes its SDK. Some projects may require higher .NET versions.

- Windows: [Download the SDK manually](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or use the [Visual Studio Installer.](https://visualstudio.microsoft.com/downloads/)
- macOS: [Download the SDK.](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) 
- Linux: Follow the instructions on [how to get the .NET SDK](https://learn.microsoft.com/en-us/dotnet/core/install/linux) for your distro.

## Building

To build a NWCommon project:
1. Make sure you have [**setup the dependencies.**](#dependencies)
2. Copy `NWConfig.props.base` to `NWConfig.props` and configure it to match your setup.
3. Run `dotnet build -v d`, which will build the project and copy it directly to your Neon White directory as configured in `NWConfig.props`.
  - You can also open the project in Visual Studio on Windows and build from there. 
  - To build a release build, run `dotnet build -c Release -v d`.

## Development

To setup a new NWCommon project:
1. Make sure you have [**setup the dependencies.**](#dependencies)
2. **Download** this repository and setup git inside of it by using `git init`.
  - It is **not recommended** to clone/fork this repository, as the example project-specific files will conflict.
3. Open and rename `ExampleMod.csproj` to configure the mod. The project file is where things like the mod name, authors, version, and further configuration goes.
4. Restructure the source files as you see fit. All `.cs`, `.resx`, etc files will all be picked up and automatically compiled.
5. Further configuration can be done in the project file just like as you would any other MSBuild project.
  - This includes adding new references, as commented in the project file.
  - **Do not use Visual Studio to further configure the project.** This may disrupt the project file and will make it harder for other contributors to use.
    - If you are using Visual Studio to work on the project and it needs configuring, **unload the project and edit the project file manually.** 
6. Follow the [building instructions](#building) to build and publish your project.
  - Make sure to setup a repository (GitHub, GitLab, etc) for easy viewing of source code for speedrun.com verification!
