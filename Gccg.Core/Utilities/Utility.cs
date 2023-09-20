namespace Gccg.Core.Utilities;

public static class Utility
{
    private const string DefaultTemplateDirectory = "templates";

    public static DirectoryInfo GetSolutionRoot(string currentPath = null)
    {
        var directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());

        while (directory != null && !directory.GetFiles("*.sln").Any())
            directory = directory.Parent;
        
        return directory;
    }

    public static bool IsEmptyOrDefault(this Dictionary<string, string> dictionary, string key)
    {
        if (dictionary.ContainsKey(key) == false) 
            return true;

        if (string.IsNullOrEmpty(dictionary[key]))
            return true;

        return false;
    }

    public static string GetTemplateDirectory(string templateDirectoryPath)
    {
        var current = new FileInfo(templateDirectoryPath).Directory;

        while (true)
        {
            var projectFile  = current.GetFiles("*.csproj").FirstOrDefault();

            if (projectFile != null)
                break;

            current = current.Parent;
        }

        return Path.Combine(current.FullName, DefaultTemplateDirectory);
    }

    public static string ToPascalCase(this string Name) => Name[..1].ToUpper() + Name[1..];
    
    public static string ToCamelCase(this string Name) => Name[..1].ToLower() + Name[1..];
    
    public static string ToSnakeCase(this string Name) => Name[..1].ToLower() + Name[1..];
}