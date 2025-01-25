## usage

### using DbContext (only for Entity Framework)
Gccg.Core.Generator.Generate({DbContext object});
ex) Gccg.Core.Generator.Generate(new ChinookContext());

### using  schema file
Gccg.Core.Generator.Generate({schema file path});
ex) Gccg.Core.Generator.Generate(@"C:\git\Gccg\Examples\Chinook\Chinnok.Gccg\Chinook.json");


Check out README.md in GitHub repository for basic usage and examples.
https://github.com/cplkimth/Gccg

```
string Root = @"I:\git\Gccg\Examples\Chinook";

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

```