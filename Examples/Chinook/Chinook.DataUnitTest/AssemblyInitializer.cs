using Chinook.Data;

namespace Chinook.DataUnitTest;

[TestClass]
public class AssemblyInitializer
{
    [AssemblyInitialize()]
    public static void AssemblyInit(TestContext context)
    {
        Api.BaseAddress = "https://localhost:7266";
        Api.Login("1", "").Wait();

        Assert.IsTrue(true);
    }
}