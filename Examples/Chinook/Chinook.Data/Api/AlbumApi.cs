
#region using
#endregion

using Chinook.Data.Utilities;
using System.Net.Http.Json;
using System.Text.Json;

namespace Chinook.Data;


public partial class AlbumApi
{
    public virtual async Task<int> GetCount2()
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<int>(GetAddress(nameof(GetCount2)), Options);
    }

    public virtual async Task<List<Album>> Search(string artistName, string trackName)  
    {
        var json = JsonSerializer.Serialize(new AlbumDao.SearchArgs(artistName, trackName), JsonHelper.DefaultOptions);

        using var http = CreateHttpClient();
        var address = GetAddress(nameof(Search), json);
        return await http.GetFromJsonAsync<List<Album>>(address);
    }
}

