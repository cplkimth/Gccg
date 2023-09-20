#region usings
#endregion

using Gccg.Core.Models;

namespace Gccg.Core.SchemaExtractors;

public abstract class SchemaExtractor
{
    public abstract Table[] Extract();
}