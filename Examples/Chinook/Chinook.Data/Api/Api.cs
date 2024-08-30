using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Chinook.Data;

public partial class Api
{
    public static async Task<int> Initialize()
    {
        using HttpClient client = CreateHttpClient();
        var response = await client.PostAsJsonAsync("http://localhost:5213/api/Chinook", string.Empty);
        return await response.Content.ReadFromJsonAsync<int>();
    }
}