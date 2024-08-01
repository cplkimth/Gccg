#region

using Chinook.Data;

#endregion

namespace Chinook.ConsoleTest;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var oldCount = Dao.Album.GetCount();

        var album = new Album
        {
            Title = DateTime.Now.ToString(),
            ArtistId = 1
        };
        album = await Dao.Album.InsertAsync(album);
        // album = Dao.Album.Insert(album);

        Console.WriteLine(album.AlbumId);
        var newCount = await Dao.Album.GetCountAsync();
        Console.WriteLine(newCount);
    }
}