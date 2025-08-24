using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Chinook.Data;

public partial class Api
{
    public static async Task<int> Initialize()
    {
        using HttpClient client = CreateHttpClient();
        var response = await client.PostAsJsonAsync("/api/Chinook", string.Empty);
        return await response.Content.ReadFromJsonAsync<int>();
    }

    public static async Task<string> Login(string userName, string password)
    {
        // var json = LoginInfo.ToJson(userName, password);
        var loginInfo = new LoginInfo { Username = userName, Password = password };
        using HttpClient client = CreateHttpClient();
        var response = await client.PostAsJsonAsync("api/Auth/Login", loginInfo);

        Jwt = await response.Content.ReadAsStringAsync();
        return Jwt;
    }
}