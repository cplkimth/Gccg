﻿namespace Gccg.Core;

public class GeneratorHelper
{
    private static GccgConfig _gccgConfig;

    public static void Generate(GccgConfig gccgConfig)
    {
        _gccgConfig = gccgConfig;

        Console.WriteLine($"[{_gccgConfig.DataEF}] 프로젝트에서 EF Core Power Tools를 실행하였습니까?");

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
        Console.WriteLine($"deleting [{_gccgConfig.GccgEF}]");
        try
        {
            Directory.Delete(_gccgConfig.GccgEF, true);
        }
        catch
        {
            // ignored
        }

        Thread.Sleep(_gccgConfig.Sleep);

        Console.WriteLine($"copying [{_gccgConfig.DataEF}] to [{_gccgConfig.GccgEF}]");
        CopyDirectory(_gccgConfig.DataEF, _gccgConfig.GccgEF, true);
        Thread.Sleep(_gccgConfig.Sleep);

        var contextFile = Directory.GetFiles(_gccgConfig.DataEF, _gccgConfig.ContextPostfix).FirstOrDefault();
        Console.WriteLine($"removing OnConfiguring in [{contextFile}]");
        var lines = File.ReadAllLines(contextFile);
        var indexToMove = FindIndexToDelete(lines, "protected override void OnConfiguring");

        if (indexToMove != -1)
        {
            var result = new List<string>();
            result.AddRange(lines.Take(indexToMove));
            result.AddRange(lines.Skip(indexToMove + 3));

            File.WriteAllLines(contextFile, result);
            Thread.Sleep(_gccgConfig.Sleep);
        }

        Thread.Sleep(_gccgConfig.Sleep);
    }

    private static void Generate()
    {
        var json = Generator.Generate(_gccgConfig.DbContext);
        File.WriteAllText($"{_gccgConfig.SolutionName}.json", json);
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

    static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
    {
        // Get information about the source directory
        var dir = new DirectoryInfo(sourceDir);

        // Check if the source directory exists
        if (!dir.Exists)
            throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

        // Cache directories before we start copying
        DirectoryInfo[] dirs = dir.GetDirectories();

        // Create the destination directory
        if (Directory.Exists(destinationDir) == false)
            Directory.CreateDirectory(destinationDir);

        // Get the files in the source directory and copy to the destination directory
        foreach (FileInfo file in dir.GetFiles())
        {
            string targetFilePath = Path.Combine(destinationDir, file.Name);
            file.CopyTo(targetFilePath, true);
        }

        // If recursive and copying subdirectories, recursively call this method
        if (recursive)
        {
            foreach (DirectoryInfo subDir in dirs)
            {
                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                CopyDirectory(subDir.FullName, newDestinationDir, true);
            }
        }
    }
}

public enum Command
{
    Preparation = 1,
    Generatation
}