
#region using
using Chinook.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using static Chinook.Data.AlbumDao;
#endregion

namespace Chinook.Web.Controllers;


public partial class AlbumController
{
    [HttpGet(nameof(GetCount2))]
    public virtual async Task<string> GetCount2()
    {
        var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        return await Task.FromResult($"{role} <- {DateTime.Now:s}");
    }

    [HttpGet($"{nameof(Search)}/{{json}}")]
    public virtual async Task<List<Album>> Search(string json)
    {
        var args = JsonSerializer.Deserialize<SearchArgs>(json);
        return await Dao.Album.Search(args.ArtistName, args.TrackName);
    }
}


