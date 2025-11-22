# .NET 10.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that an .NET 10.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 10.0 upgrade.
3. Upgrade Examples\Chinook\Chinook.Data\Chinook.Data.csproj
4. Upgrade Gccg.Tools\Gccg.Tools.csproj
5. Upgrade Gccg.Core\Gccg.Core.csproj
6. Upgrade Examples\Chinook\Chinook.Web\Chinook.Web.csproj
7. Upgrade Examples\Chinook\Chinook.GccgTool\Chinook.GccgTool.csproj
8. Upgrade Examples\Chinook\Chinook.Gccg\Chinook.Gccg.csproj
9. Upgrade Examples\Chinook\Chinook.DataUnitTest\Chinook.DataUnitTest.csproj
10. Upgrade Examples\Chinook\Chinook.ConsoleTest\Chinook.ConsoleTest.csproj
11. Upgrade Gccg.UnitTest\Gccg.UnitTest.csproj
12. Run unit tests to validate upgrade in the projects listed below:
  - Examples\Chinook\Chinook.DataUnitTest\Chinook.DataUnitTest.csproj
  - Gccg.UnitTest\Gccg.UnitTest.csproj

## Settings

This section contains settings and data used by execution steps.

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                                | Current Version | New Version | Description                                   |
|:--------------------------------------------|:---------------:|:-----------:|:----------------------------------------------|
| Microsoft.AspNetCore.Authentication.JwtBearer |   9.0.8         |  10.0.0     | Recommended for .NET 10.0                     |
| Microsoft.AspNetCore.OpenApi                |   9.0.8         |  10.0.0     | Recommended for .NET 10.0                     |
| Microsoft.EntityFrameworkCore               |   9.0.8         |  10.0.0     | Recommended for .NET 10.0                     |
| Microsoft.EntityFrameworkCore.SqlServer     |   9.0.8         |  10.0.0     | Recommended for .NET 10.0                     |
| Microsoft.EntityFrameworkCore.SqlServer.HierarchyId |   9.0.8         |  10.0.0     | Recommended for .NET 10.0                     |
| Microsoft.EntityFrameworkCore.Tools         |   9.0.8         |  10.0.0     | Recommended for .NET 10.0                     |
| Microsoft.Extensions.ApiDescription.Server  |   9.0.*-*       |  10.0.0     | Recommended for .NET 10.0                     |

### Project upgrade details

#### Examples\Chinook\Chinook.Data\Chinook.Data.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`

NuGet packages changes:
  - Microsoft.EntityFrameworkCore.SqlServer should be updated from `9.0.8` to `10.0.0`
  - Microsoft.EntityFrameworkCore.SqlServer.HierarchyId should be updated from `9.0.8` to `10.0.0`
  - Microsoft.EntityFrameworkCore.Tools should be updated from `9.0.8` to `10.0.0`

#### Gccg.Tools\Gccg.Tools.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`

#### Gccg.Core\Gccg.Core.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`

NuGet packages changes:
  - Microsoft.EntityFrameworkCore should be updated from `9.0.8` to `10.0.0`
  - Microsoft.EntityFrameworkCore.SqlServer should be updated from `9.0.8` to `10.0.0`
  - Microsoft.EntityFrameworkCore.SqlServer.HierarchyId should be updated from `9.0.8` to `10.0.0`

#### Examples\Chinook\Chinook.Web\Chinook.Web.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`

NuGet packages changes:
  - Microsoft.AspNetCore.Authentication.JwtBearer should be updated from `9.0.8` to `10.0.0`
  - Microsoft.AspNetCore.OpenApi should be updated from `9.0.8` to `10.0.0`
  - Microsoft.Extensions.ApiDescription.Server should be updated from `9.0.*-*` to `10.0.0`

#### Examples\Chinook\Chinook.GccgTool\Chinook.GccgTool.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`

#### Examples\Chinook\Chinook.Gccg\Chinook.Gccg.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`

NuGet packages changes:
  - Microsoft.EntityFrameworkCore should be updated from `9.0.8` to `10.0.0`
  - Microsoft.EntityFrameworkCore.SqlServer should be updated from `9.0.8` to `10.0.0`
  - Microsoft.EntityFrameworkCore.SqlServer.HierarchyId should be updated from `9.0.8` to `10.0.0`

#### Examples\Chinook\Chinook.DataUnitTest\Chinook.DataUnitTest.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`

#### Examples\Chinook\Chinook.ConsoleTest\Chinook.ConsoleTest.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`

NuGet packages changes:
  - Microsoft.EntityFrameworkCore.Tools should be updated from `9.0.8` to `10.0.0`

#### Gccg.UnitTest\Gccg.UnitTest.csproj modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`