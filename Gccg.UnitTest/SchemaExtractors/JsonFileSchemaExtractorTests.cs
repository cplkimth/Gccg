#region usings
using Gccg.Core.SchemaExtractors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace Gccg.UnitTest.SchemaExtractors;

[TestClass]
public class JsonFileSchemaExtractorTests : SchemaExtractorTests
{
    [ClassInitialize]
    public static void Setup(TestContext testContext)
    {
        var schemaExtractor = new JsonFileSchemaExtractor(@"Files\Chinook.json");
        _database = schemaExtractor.Extract();
    }
}