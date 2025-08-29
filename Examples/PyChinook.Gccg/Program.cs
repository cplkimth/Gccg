#region
using System.Text.Json;
using Chinook.Data;
using Gccg.Core;

#endregion

string Root = @"d:\git\Gccg\Examples\PyChinook";

string solutionName = new DirectoryInfo(Root).Name;
string dataEf = $@"D:\git\Gccg\Examples\PyChinook";
string gccgEf = $@"D:\git\Gccg\Examples\PyChinook";

GccgConfig.CreateSingleton
(
    new ChinookContext(),
    solutionName,
    Root,
    dataEf,
    gccgEf,
    variables: [
        ("WebProjectNamespace", $"{solutionName}.Web"),
        ("ServiceProjectNamespace", $"{solutionName}.Service")
        ]
);

Generator.Generate(@"D:\git\Gccg\Examples\PyChinook.Gccg\Chinook.json");