#region usings
using System.Text.Json;
using System.Text.Json.Serialization;
using Gccg.Core.Models;
#endregion

namespace Gccg.Core.SchemaExtractors;

public class JsonFileSchemaExtractor : SchemaExtractor
{
    private readonly string _jsonFilePath;

    public JsonFileSchemaExtractor(string jsonFilePath)
    {
        _jsonFilePath = jsonFilePath;
    }

    public override Table[] Extract()
    {
        var json = File.ReadAllText(_jsonFilePath);

        JsonSerializerOptions options = new()
                                        {
                                            ReferenceHandler = ReferenceHandler.Preserve
                                        };
        var tables = JsonSerializer.Deserialize<Table[]>(json, options);

        return tables;
    }
}