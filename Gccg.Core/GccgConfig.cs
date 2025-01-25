#region

using System.Runtime;
using System.Text;
using System.Text.Json.Serialization;
using Gccg.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Gccg.Core;

public partial class GccgConfig
{
    public static GccgConfig Instance { get; private set; }

    private GccgConfig()
    {
    }

    public static GccgConfig CreateSingleton(DbContext dbContext, string solutionName, string solutionDirectory, string dataEf, string gccgEf,
        string contextPostfix = "*Context.cs", int sleep = 1500, params (string Key, string Value)[] variables)
    {
        Instance = new GccgConfig
        {
            DbContext = dbContext,
            DataEF = dataEf,
            GccgEF = gccgEf,
            ContextPostfix = contextPostfix,
            Sleep = sleep,
            _variables = variables.ToDictionary(x => x.Key, x => x.Value)
        };

        #region preset
        Instance.TryAdd(C.SolutionName, solutionName);
        Instance.TryAdd(C.SolutionDirectory, solutionDirectory);

        Instance.TryAdd(C.DataProjectNamespace, dbContext.GetType().Namespace);
        Instance.TryAdd(C.DbContextName,dbContext.GetType().Name);
        Instance.TryAdd(C.DataProjectName, "Data");
        Instance.TryAdd(C.DataProjectDirectory,
            Path.Combine(Instance[C.SolutionDirectory], Instance[C.SolutionName] + "." + Instance[C.DataProjectName]));

        Instance.TryAdd(C.DataProjectNamespace, Instance[C.SolutionName] + "." + Instance[C.DataProjectName]);

        Instance.TryAdd(C.DbContextName, Instance[C.DbContextName]);

        Instance.TryAdd(C.GeneratedTime, DateTime.Now.ToString());
        Instance.TryAdd(C.BeginOnView, "/*");
        Instance.TryAdd(C.BeginOnNoCache, "/*");
        Instance.TryAdd(C.BeginOnVoidReturn, "/*");
        Instance.TryAdd(C.EndOnView, "*/");
        Instance.TryAdd(C.EndOnNoCache, "*/");
        Instance.TryAdd(C.EndOnVoidReturn, "*/");
        #endregion

        return Instance;
    }

    public DbContext DbContext { get; init; }
    public string DataEF { get; init; }
    public string GccgEF { get; init; }
    public string ContextPostfix { get; init; }
    public int Sleep { get; init; }

    private Dictionary<string, string> _variables;

    public string this[string key]
    {
        get
        {
            if (_variables.TryGetValue(key, out var value) == false)
                throw new VariableNotExistException(key);

            return value;
        }
    }

    private void TryAdd(string key, string value)
    {
        _variables.TryAdd(key, value);
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
}