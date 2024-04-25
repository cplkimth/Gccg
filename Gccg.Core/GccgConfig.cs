#region

using System.Runtime;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Gccg.Core;

public class GccgConfig
{
    public DbContext DbContext { get; init; }
    public string ModelFilePath { get; init; }

    public required string SolutionName { get; init; }
    public required string Root { get; init; }
    public required string DataEF { get; init; }
    public required string GccgEF { get; init; }

    public string ContextPostfix { get; init; } = "*Context.cs";
    public int Sleep { get; init; } = 1500;
}