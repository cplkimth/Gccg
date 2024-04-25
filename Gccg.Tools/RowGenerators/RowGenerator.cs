namespace Gccg.Tools.RowGenerators;

public abstract class RowGenerator
{
    protected const string CharsToRemove = " /().,+-♥♡[]&▩▨▧▦▥▤▣□>＊＆#";

    protected RowGenerator(string className, Func<List<object>> onLoad,
        Func<object, int> onGetId, Func<object, string> onGetText, Func<object, int> onGetPrefix)
    {
        OnLoad = onLoad;
        OnGetId = onGetId;
        OnGetPrefix = onGetPrefix;
        OnGetText = onGetText;
        ClassName = className;
    }

    public Func<List<object>> OnLoad { get; init; }
    public Func<object, int> OnGetId { get; init; }
    public Func<object, int> OnGetPrefix { get; init; }
    public Func<object, string> OnGetText { get; init; }

    public string ClassName { get; init; }
    public string Directory { get; internal set; }
    public string Namespace { get; internal set; }

    public abstract string FileName { get; }

    public string FilePath => Path.Combine(Directory, FileName);

    public abstract string Generate();

    public static void Run(RowGeneratorConfig config)
    {
        foreach (var rowGenerator in config.RowGenerators)
        {
            rowGenerator.Directory = config.Directory;
            rowGenerator.Namespace = config.Namespace;
            rowGenerator.Generate();
        }
    }
}