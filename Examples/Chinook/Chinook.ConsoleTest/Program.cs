#region
using Chinook.Data;
using Chinook.Data.Utilities;
using System.Net;
using System.Text.Json;

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

        var a1 = await Dao.Album.GetFirstAsync();
        a1.ArtistName = DateTime.Now.ToString();
        // await Dao.Album.UpdateAsync(a1);
        await Dao.Album.UpdatePartiallyAsync(a1);
        return;


        Api.BaseAddress = "https://localhost:7266";
        // await Api.Initialize();

        await Api.Login("1", "");

        // var list = await Api.Album.Search("pink", "");
        // var list = await Dao.Album.SearchAsync("pink", "");

        var list = await Api.Employee.Load("a", null, null, null, DateTime.Today);
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(await Api.Employee.GetCountByName("a"));
    }
}