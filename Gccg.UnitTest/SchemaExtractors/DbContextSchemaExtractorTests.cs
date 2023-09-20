﻿#region usings
using Chinook.Data;
using Gccg.Core.SchemaExtractors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace Gccg.UnitTest.SchemaExtractors;

[TestClass]
public class DbContextSchemaExtractorTests : SchemaExtractorTests
{
    [ClassInitialize]
    public static void Setup(TestContext testContext)
    {
        var schemaExtractor = new DbContextSchemaExtractor(new ChinookContext());
        _database = schemaExtractor.Extract();
    }
}