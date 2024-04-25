namespace Gccg.Tools.RowGenerators;

public class RowGeneratorConfig
{
    public required string Namespace { get; init; }
    public required string Directory { get; init; }

    public required RowGenerator[] RowGenerators {
        get;
        init;
    }
}