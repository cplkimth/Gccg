using Chinook.Data;

namespace Chinook.DataUnitTest;

[TestClass]
public class AssemblyInitializer
{
    [AssemblyInitialize()]
    public static void AssemblyInit(TestContext context)
    {
        Api.BaseAddress = "http://localhost:5213";

        Assert.IsTrue(true);
    }
}