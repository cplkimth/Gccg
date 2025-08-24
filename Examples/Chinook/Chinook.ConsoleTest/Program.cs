#region
using System.Net;
using Chinook.Data;

#endregion

namespace Chinook.ConsoleTest;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // var procedures = new ChinookContextProcedures(DbContextFactory.Create());
        // await procedures.usp_InitializeAsync();
        //
        // var list = await Dao.Album.SelectAsHashSetAsync(x  => x.AlbumId > 0, x => x.Title);
        // foreach (var x in list)
        // {
        //     Console.WriteLine(x);
        // }
        // return;


        Api.BaseAddress = "https://localhost:7266";
        // await Api.Initialize();

        await Api.Login("1", "");
        var count = await Api.Album.GetCount();
        Console.WriteLine(count);
    }
}