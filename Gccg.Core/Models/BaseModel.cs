#region usings
using System.Text.Json.Serialization;
using Gccg.Core.Utilities;
#endregion

namespace Gccg.Core.Models;

public abstract class BaseModel
{
    protected BaseModel()
    {
    }

    protected BaseModel(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
}