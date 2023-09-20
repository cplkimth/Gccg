using Chinook.Data;

namespace Chinook.Services;

internal class Program
{
    static void Main(string[] args)
    {
        Service.BaseAddress = "https://localhost:7098/";
        Service.JwtToken  = Service.GetJwtToken("5", "Andrew").Result;

        Console.WriteLine("count : ");
        Console.WriteLine("  " + Service.Album.GetCountAsync().Result);

        Console.WriteLine("first : ");
        var first = Service.Album.GetFirstAsync().Result;
        Console.WriteLine("  " + first);

        Console.WriteLine("get : ");
        foreach (var album in Service.Album.GetAsync().Result)
            Console.WriteLine("  " + album);

        Console.WriteLine("insert : ");
        var clone = first.Clone();
        clone.AlbumId = 0;
        clone = Service.Album.InsertAsync(clone).Result;
        Console.WriteLine("  " + clone);

        Console.WriteLine("update : ");
        clone.Title = DateTime.Now.ToString();
        Console.WriteLine("  " + Service.Album.UpdateAsync(clone).Result);

        Console.WriteLine("delete : ");
        Console.WriteLine("  " + Service.Album.DeleteAsync(clone.AlbumId).Result);

        Console.WriteLine(nameof(PlaylistTrack));
        Console.WriteLine("  " + Service.PlaylistTrack.GetByKeyAsync(1, 1).Result);
        Console.WriteLine();
    }
}