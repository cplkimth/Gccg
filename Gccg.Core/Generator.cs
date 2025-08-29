#region usings
using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Gccg.Core.Elements;
using Gccg.Core.Models;
using Gccg.Core.SchemaExtractors;
using Gccg.Core.Utilities;
using Microsoft.EntityFrameworkCore;
#endregion

namespace Gccg.Core;

public static class Generator
{
    public const string TemplatePostfix = ".jsonmp";

    internal static string Generate(DbContext dbContext)
    {
        var schemaExtractor = new DbContextSchemaExtractor(dbContext);

        return GenerateCore(schemaExtractor, dbContext);
    }

    public static string Generate(string modelFilePath)
    {
        var schemaExtractor = new JsonFileSchemaExtractor(modelFilePath);

        return GenerateCore(schemaExtractor, null);
    }

    private static string GenerateCore(SchemaExtractor schemaExtractor, DbContext dbContext)
    {
        string[] templatePaths = ReadTemplates();
        Console.WriteLine();

        var tables = schemaExtractor.Extract();

        Console.WriteLine("Inflating templates ...");
        InflatePackage(templatePaths, tables);
        Console.WriteLine();

        Console.WriteLine("Finished without error(s)");

        return JsonSerializer.Serialize(tables);
    }

    private static string[] ReadTemplates()
    {
        var files = Directory
            .GetFiles(GccgConfig.Instance[C.SolutionDirectory], $"*{TemplatePostfix}", SearchOption.AllDirectories)
            .Where(x => Path.GetFileName(x).StartsWith("__") == false)
            .ToArray();

        Console.WriteLine($"{files.Length:N0} template files are found.");
        foreach (var file in files)
            Console.WriteLine("  " + file);

        return files;
    }

    private static void InflatePackage(string[] templatePaths, Table[] tables)
    {
        foreach (var templatePath in templatePaths)
        {
            Console.WriteLine($"{Path.GetFileName(templatePath)}");

            var templateText = File.ReadAllText(templatePath);
            var template = Template.Load(templateText);

            if (template.Scope == TemplateScope.Database)
                InflatePackageCore(template, templatePath, tables.ToArray());
            else if (template.Scope == TemplateScope.Table)
                foreach (var table in tables)
                    InflatePackageCore(template, templatePath, table);
        }
    }

    private static void InflatePackageCore(Template template, string templatePath, params Table[] tables)
    {
        var code = Inflater.Inflate(template.Body, tables);

        var pathToWrite = GetPathToWrite(template.TargetPath, tables.Length > 0 ? tables[0].Name : "", templatePath);
        WriteFileIfNone(pathToWrite, code, template.Overwritable);

        // Console.WriteLine($"  => {pathToWrite}");
    }

    private static string GetPathToWrite(string pathToWrite, string tableName, string templatePath)
    {
        if (tableName != null)
            pathToWrite = GccgConfig.Instance.Fill(pathToWrite);

        var matches = Regex.Matches(pathToWrite, "`(.*?)`");
        foreach (Match match in matches)
            if (match.Value == "`Name`")
                pathToWrite = pathToWrite.Replace(match.Value, tableName);

        var templateDirectory = new FileInfo(templatePath).Directory.FullName;
        pathToWrite = Path.Combine(templateDirectory, pathToWrite);
        return pathToWrite;
    }

    private static void WriteFileIfNone(string path, string code, bool overwritable)
    {
        if (overwritable == false && File.Exists(path))
            return;

        if (Directory.Exists(Path.GetDirectoryName(path)) == false)
            Directory.CreateDirectory(Path.GetDirectoryName(path));

        File.WriteAllText(path, code);
    }
}