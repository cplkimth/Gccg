#region

using Chinook.Data;

#endregion

namespace Chinook.ConsoleTest;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var procedures = new ChinookContextProcedures(DbContextFactory.Create());
        await procedures.usp_InitializeAsync();

        Console.WriteLine(await Dao.Album.GetCountAsync());
        return;


        Api.BaseAddress = "http://localhost:5213";
        int value = await Api.Initialize();
        Console.WriteLine(value);
    }
}