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
    variables: [("Var1", "Text1"),("ServiceProjectNamespace", "Chinook.Service")]
);

GeneratorHelper.Generate();
