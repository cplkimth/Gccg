#region
using System.Text.Json;
using Chinook.Data;
using Gccg.Core;

#endregion

string Root = @"d:\git\Gccg\Examples\Chinook";

string solutionName = new DirectoryInfo(Root).Name;
string dataEf = $@"{Root}\{solutionName}.Data\EF";
string gccgEf = $@"{Root}\{solutionName}.Gccg\EF";

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

if (args.Length > 0)
{
    if (args[0] == "P")
        GeneratorHelper.OnPreparation();
    if (args[0] == "G")
        GeneratorHelper.OnGeneration();
}
else
{
    GeneratorHelper.Generate();
}