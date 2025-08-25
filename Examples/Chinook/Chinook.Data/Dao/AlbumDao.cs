#region using
#endregion

#region
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
#endregion

namespace Chinook.Data;

public partial class AlbumDao
{
    public record SearchArgs(string ArtistName, string TrackName);

    public async Task<List<Album>> Search(string artistName, string trackName)
    {
        await using var context = DbContextFactory.Create();

        var query = from x in context.Albums
            select x;

        if (artistName != null)
            query = query.Where(x => x.Artist.Name.Contains(artistName));

        if (trackName != null)
            query = query.Where(x => x.Tracks.Any(t => t.Name.Contains(trackName)));

        var list = await query
            .Select(x => new { Album = x, ArtistName = x.Artist.Name, TrackCount = x.Tracks.Count })
            .ToListAsync();

        foreach (var x in list)
        {
            x.Album.ArtistName = x.ArtistName;
            x.Album.TrackCount = x.TrackCount;
        }

        return list.ConvertAll(x => x.Album);
    }
}