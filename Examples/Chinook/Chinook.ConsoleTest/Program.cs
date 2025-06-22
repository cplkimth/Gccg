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
        
        var list = await Dao.Album.SelectAsHashSetAsync(x  => x.AlbumId > 0, x => x.Title);
        foreach (var x in list)
        {
            Console.WriteLine(x);
        }
        return;


        Api.BaseAddress = "http://localhost:5213";
        int value = await Api.Initialize();
        Console.WriteLine(value);
    }
}