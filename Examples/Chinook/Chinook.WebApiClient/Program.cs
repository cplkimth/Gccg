#region usings
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Chinook.Data;
#endregion

namespace Chinook.WebApiClient;

internal class Program
{
    private static void Main(string[] args)
    {
        Api.BaseAddress = "https://localhost:7098/";
        Api.JwtToken  = Api.GetJwtToken("5", "Andrew").Result;

        Console.WriteLine("count : ");
        Console.WriteLine("  " + Api.Album.GetCountAsync().Result);

        Console.WriteLine("first : ");
        var first = Api.Album.GetFirstAsync().Result;
        Console.WriteLine("  " + first);

        Console.WriteLine("get : ");
        foreach (var album in Api.Album.GetAsync().Result)
            Console.WriteLine("  " + album);

        Console.WriteLine("insert : ");
        var clone = first.Clone();
        clone.AlbumId = 0;
        clone = Api.Album.InsertAsync(clone).Result;
        Console.WriteLine("  " + clone);

        Console.WriteLine("update : ");
        clone.Title = DateTime.Now.ToString();
        Console.WriteLine("  " + Api.Album.UpdateAsync(clone).Result);

        Console.WriteLine("delete : ");
        Console.WriteLine("  " + Api.Album.DeleteAsync(clone.AlbumId).Result);

        Console.WriteLine(nameof(PlaylistTrack));
        Console.WriteLine("  " + Api.PlaylistTrack.GetByKeyAsync(1, 1).Result);
        Console.WriteLine();
    }
}