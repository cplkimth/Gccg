#region

using Chinook.Data;
using Gccg.Core;

#endregion

namespace Chinook.Gccg;

internal static class Program
{
    private const string SolutionName = "Chinook";
    private const string Root = @$"D:\git\Gccg\Examples\{SolutionName}";

    private const string DataEF = $@"{Root}\{SolutionName}.Data\EF";
    private const string GccgEF = $@"{Root}\{SolutionName}.Gccg\EF";

    private static void Main(string[] args)
    {
        var config = new GccgConfig
        {
            DbContext = new ChinookContext(),
            SolutionName = SolutionName,
            Root = Root,
            DataEF = DataEF,
            GccgEF = GccgEF
        };

        GeneratorHelper.Generate(config);
    }
}