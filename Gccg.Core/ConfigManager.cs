using System.Text;
using System.Text.Json;
using Gccg.Core.Exceptions;
using Gccg.Core.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Gccg.Core;

public class ConfigManager
{
    #region singleton
    private static readonly Lazy<ConfigManager> _instance = new(() => new ConfigManager());

    public static ConfigManager Instance => _instance.Value;

    private ConfigManager()
    {
    }
    #endregion

    private const string ConfigFile = "Gccg.config.json";

    private Dictionary<string, string> _variables = new();

    private const string SolutionName = "SolutionName";
    private const string SolutionDirectory = "SolutionDirectory";
    private const string DataProjectName = "DataProjectName";
    private const string DataProjectDirectory = "DataProjectDirectory";
    private const string DataProjectNamespace = "DataProjectNamespace";
    private const string DbContextName = "DbContextName";

    public string RootName { get; private set; }
    
    public string RootPath { get; private set; }

    public void Inialize(DbContext dbContext)
    {
        (RootPath, RootName) = GetRootPath();

        var jsonPath = Path.Combine(RootPath, ConfigFile);

        if (File.Exists(jsonPath) is false)
            throw new FileNotFoundException($@"{ConfigFile} file does NOT exist!");

        var json = File.ReadAllText(jsonPath);
        _variables = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

        if (dbContext != null)
        {
            _variables[DataProjectNamespace] = dbContext.GetType().Namespace;
            _variables[DbContextName] = dbContext.GetType().Name;
        }

        if (_variables.IsEmptyOrDefault(SolutionName))
            _variables[SolutionName] = RootName;

        if (_variables.IsEmptyOrDefault(SolutionDirectory))
            _variables[SolutionDirectory] = RootPath;

        if (_variables.IsEmptyOrDefault(DataProjectName))
            _variables[DataProjectName] = "Data";

        if (_variables.IsEmptyOrDefault(DataProjectDirectory))
            _variables[DataProjectDirectory] = Path.Combine(_variables[SolutionDirectory], _variables[SolutionName] + "." + _variables[DataProjectName]);

        if (_variables.IsEmptyOrDefault(DataProjectNamespace))
            _variables[DataProjectNamespace] = _variables[SolutionName] + "." + _variables[DataProjectName];

        if (_variables.IsEmptyOrDefault(DbContextName))
            _variables[DbContextName] = DbContextName;

        #region preset
        _variables["GeneratedTime"] = DateTime.Now.ToString();

        _variables["BeginOnView"] = "/*";
        _variables["BeginOnNoCache"] = "/*";
        _variables["BeginOnVoidReturn"] = "/*";

        _variables["EndOnView"] = "*/";
        _variables["EndOnNoCache"] = "*/";
        _variables["EndOnVoidReturn"] = "*/";
        #endregion
    }

    public string this[string variableName]
    {
        get
        {
            if (_variables.TryGetValue(variableName, out var item))
                return item;

            throw new VariableNotExistException(variableName);
        }
    }

    public string Fill(string input)
    {
        StringBuilder builder = new(input);

        Fill(builder);

        return builder.ToString();
    }

    public void Fill(StringBuilder builder)
    {
        foreach (var key in _variables.Keys)
            builder.Replace($"`{key}`", _variables[key]);
    }

    private (string path, string name) GetRootPath()
    {
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (directory != null && !directory.GetFiles(ConfigFile).Any())
            directory = directory.Parent;
        
        return (directory.FullName, directory.Name);
    }
}