namespace Gccg.Core;

public class GeneratorHelper
{
    public static void Generate()
    {
        Console.WriteLine($"Ensure executing EF Core Power Tools in [{GccgConfig.Instance.DataEF}] project.");

        var commands = (Command[])Enum.GetValues(typeof(Command));
        foreach (var command in commands)
            Console.WriteLine($"{(int)command} : {command}");

        var commandInput = (Command)int.Parse(Console.ReadLine()!);

        switch (commandInput)
        {
            case Command.Preparation:
                OnPreparation();
                break;
            case Command.Generation:
                OnGeneration();
                break;
        }
        
        Console.WriteLine("done!");
    }

    public static void OnPreparation()
    {
        Console.WriteLine($"deleting [{GccgConfig.Instance.GccgEF}]");
        try
        {
            Directory.Delete(GccgConfig.Instance.GccgEF, true);
        }
        catch
        {
            // ignored
        }

        Thread.Sleep(GccgConfig.Instance.Sleep);

        Console.WriteLine($"copying [{GccgConfig.Instance.DataEF}] to [{GccgConfig.Instance.GccgEF}]");
        CopyDirectory(GccgConfig.Instance.DataEF, GccgConfig.Instance.GccgEF, true);
        Thread.Sleep(GccgConfig.Instance.Sleep);

        var contextFile = Directory.GetFiles(GccgConfig.Instance.DataEF, GccgConfig.Instance.ContextPostfix).FirstOrDefault();
        Console.WriteLine($"removing OnConfiguring in [{contextFile}]");
        var lines = File.ReadAllLines(contextFile);
        var indexToMove = FindIndexToDelete(lines, "protected override void OnConfiguring");

        if (indexToMove != -1)
        {
            var result = new List<string>();
            result.AddRange(lines.Take(indexToMove));
            result.AddRange(lines.Skip(indexToMove + 3));

            File.WriteAllLines(contextFile, result);
            Thread.Sleep(GccgConfig.Instance.Sleep);
        }

        Thread.Sleep(GccgConfig.Instance.Sleep);
    }

    public static void OnGeneration()
    {
        var json = Generator.Generate(GccgConfig.Instance.DbContext);
        File.WriteAllText($"{GccgConfig.Instance[C.SolutionName]}.json", json);
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
    Generation
}