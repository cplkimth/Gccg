namespace Gccg.Core;

public class GeneratorHelper
{
    public static GccgConfig GccgConfig { get; private set; }

    public static void Generate(GccgConfig gccgConfig)
    {
        GccgConfig = gccgConfig;

        Console.WriteLine($"[{GccgConfig.DataEF}] 프로젝트에서 EF Core Power Tools를 실행하였습니까?");

        var commands = (Command[])Enum.GetValues(typeof(Command));
        foreach (var command in commands)
            Console.WriteLine($"{(int)command} : {command}");

        var commandInput = (Command)int.Parse(Console.ReadLine()!);

        switch (commandInput)
        {
            case Command.Preparation:
                Prepare();
                break;
            case Command.Generatation:
                Generate();
                break;
        }
        
        Console.WriteLine("done!");
    }

    private static void Prepare()
    {
        Console.WriteLine($"deleting [{GccgConfig.GccgEF}]");
        try
        {
            Directory.Delete(GccgConfig.GccgEF, true);
        }
        catch
        {
            // ignored
        }

        Thread.Sleep(GccgConfig.Sleep);

        Console.WriteLine($"copying [{GccgConfig.DataEF}] to [{GccgConfig.GccgEF}]");
        CopyDirectory(GccgConfig.DataEF, GccgConfig.GccgEF, true);
        Thread.Sleep(GccgConfig.Sleep);

        var contextFile = Directory.GetFiles(GccgConfig.DataEF, GccgConfig.ContextPostfix).FirstOrDefault();
        Console.WriteLine($"removing OnConfiguring in [{contextFile}]");
        var lines = File.ReadAllLines(contextFile);
        var indexToMove = FindIndexToDelete(lines, "protected override void OnConfiguring");

        if (indexToMove != -1)
        {
            var result = new List<string>();
            result.AddRange(lines.Take(indexToMove));
            result.AddRange(lines.Skip(indexToMove + 3));

            File.WriteAllLines(contextFile, result);
            Thread.Sleep(GccgConfig.Sleep);
        }

        Thread.Sleep(GccgConfig.Sleep);
    }

    private static void Generate()
    {
        var json = Generator.Generate(GccgConfig.DbContext);
        File.WriteAllText($"{GccgConfig.SolutionName}.json", json);
    }

    private static int FindIndexToDelete(string[] lines, string text)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains(text))
                return i;
        }

        return -1;
    }

    static void CopyDirectory(string source, string target, bool recursive)
    {
        var directory = new DirectoryInfo(source);

        if (!directory.Exists)
            throw new DirectoryNotFoundException($"Source directory not found: {directory.FullName}");

        DirectoryInfo[] children = directory.GetDirectories();

        if (Directory.Exists(target) == false)
            Directory.CreateDirectory(target);

        foreach (FileInfo file in directory.GetFiles())
        {
            string filePath = Path.Combine(target, file.Name);
            file.CopyTo(filePath, true);
        }

        if (recursive)
        {
            foreach (DirectoryInfo subDir in children)
            {
                string directoryPath = Path.Combine(target, subDir.Name);
                CopyDirectory(subDir.FullName, directoryPath, true);
            }
        }
    }
}

public enum Command
{
    Preparation = 1,
    Generatation
}