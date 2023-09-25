
#region using
#endregion

using System.Net.Http.Json;

namespace Chinook.Data;


public partial class AlbumApi
{
    public async Task<int> Initialize()
    {
        using HttpClient client = CreateHttpClient();
        var response = await client.PostAsJsonAsync(GetAddress("Initialize"), Options);
        return await response.Content.ReadFromJsonAsync<int>();
    }
}

