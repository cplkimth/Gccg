
// This file has been generated by Gccg on 2023-09-21 오전 2:37:01.
#region using
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Chinook.Data;
#endregion

namespace Chinook.WebApiClient;

public partial class Api
{
    public static string JwtToken { get; set; }

    public static string BaseAddress { get; set; }
    
    private const string Authorization = "Authorization";
    private const string Bearer = "Bearer";

    internal static HttpClient CreateHttpClient()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(Api.BaseAddress);

        if (Api.JwtToken != null)
            client.DefaultRequestHeaders.Add(Authorization, $"{Bearer} {Api.JwtToken}");

        return client;
    }

    public static async Task<string> GetJwtToken(string userName, string password)
    {
        var authInfo = new {UserName = "5", Password = "Andrew"};
        var response = await CreateHttpClient().PostAsJsonAsync("api/auth", authInfo);
        return response.Content.ReadAsStringAsync().Result;
    }

    #region clients
     public static AlbumApi Album => new AlbumApi(); 
 public static ArtistApi Artist => new ArtistApi(); 
 public static CompanyApi Company => new CompanyApi(); 
 public static CustomerApi Customer => new CustomerApi(); 
 public static EmployeeApi Employee => new EmployeeApi(); 
 public static GenreApi Genre => new GenreApi(); 
 public static InvoiceApi Invoice => new InvoiceApi(); 
 public static InvoiceLineApi InvoiceLine => new InvoiceLineApi(); 
 public static MediaTypeApi MediaType => new MediaTypeApi(); 
 public static PlaylistApi Playlist => new PlaylistApi(); 
 public static PlaylistTrackApi PlaylistTrack => new PlaylistTrackApi(); 
 public static PlaylistTrackHistoryApi PlaylistTrackHistory => new PlaylistTrackHistoryApi(); 
 public static TodoItemApi TodoItem => new TodoItemApi(); 
 public static TrackApi Track => new TrackApi(); 

    #endregion
}

public abstract partial class EntityApi<T>
{
    protected const string Authorization = "Authorization";
    protected const string Bearer = "Bearer";

    protected string GetAddress(params object[] parameters)
    {
        StringBuilder builder = new ($"api/{EntityName}");
        
        foreach (var parameter in parameters)
            builder.Append($"/{parameter}");

        return builder.ToString();
    }

    protected HttpClient CreateHttpClient() => Api.CreateHttpClient();

    protected static JsonSerializerOptions Options { get; } = new ()
      {
          DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
      };

    protected abstract string EntityName { get; }

    public Task<List<T>> GetAsync()
    {
        return CreateHttpClient().GetFromJsonAsync<List<T>>(GetAddress(), Options);
    }

    public Task<T> GetFirstAsync()
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<T>(GetAddress("first"), Options);
    }

    public Task<int> GetCountAsync()
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<int>(GetAddress("count"), Options);
    }

    public async Task<T> InsertAsync(T entity)
    {
        HttpClient client = CreateHttpClient();
        var response = await client.PostAsJsonAsync(GetAddress(), entity);
        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        HttpClient client = CreateHttpClient();
        var response = await client.PutAsJsonAsync(GetAddress(), entity);
        return await response.Content.ReadFromJsonAsync<int>();
    }
}

#region clients

public partial class AlbumApi : EntityApi<Album>
{
    protected override string EntityName => nameof(Album);

    public Task<Album> GetByKeyAsync(int albumId )
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<Album>(GetAddress(albumId ), Options);
    }

    public async Task<int> DeleteAsync(int albumId )
    {
        HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(albumId ));
        return await response.Content.ReadFromJsonAsync<int>();
    }
}


public partial class ArtistApi : EntityApi<Artist>
{
    protected override string EntityName => nameof(Artist);

    public Task<Artist> GetByKeyAsync(int artistId )
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<Artist>(GetAddress(artistId ), Options);
    }

    public async Task<int> DeleteAsync(int artistId )
    {
        HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(artistId ));
        return await response.Content.ReadFromJsonAsync<int>();
    }
}


public partial class CompanyApi : EntityApi<Company>
{
    protected override string EntityName => nameof(Company);

    public Task<Company> GetByKeyAsync(int companyId )
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<Company>(GetAddress(companyId ), Options);
    }

    public async Task<int> DeleteAsync(int companyId )
    {
        HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(companyId ));
        return await response.Content.ReadFromJsonAsync<int>();
    }
}


public partial class CustomerApi : EntityApi<Customer>
{
    protected override string EntityName => nameof(Customer);

    public Task<Customer> GetByKeyAsync(int customerId )
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<Customer>(GetAddress(customerId ), Options);
    }

    public async Task<int> DeleteAsync(int customerId )
    {
        HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(customerId ));
        return await response.Content.ReadFromJsonAsync<int>();
    }
}


public partial class EmployeeApi : EntityApi<Employee>
{
    protected override string EntityName => nameof(Employee);

    public Task<Employee> GetByKeyAsync(int employeeId )
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<Employee>(GetAddress(employeeId ), Options);
    }

    public async Task<int> DeleteAsync(int employeeId )
    {
        HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(employeeId ));
        return await response.Content.ReadFromJsonAsync<int>();
    }
}


public partial class GenreApi : EntityApi<Genre>
{
    protected override string EntityName => nameof(Genre);

    public Task<Genre> GetByKeyAsync(int genreId )
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<Genre>(GetAddress(genreId ), Options);
    }

    public async Task<int> DeleteAsync(int genreId )
    {
        HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(genreId ));
        return await response.Content.ReadFromJsonAsync<int>();
    }
}


public partial class InvoiceApi : EntityApi<Invoice>
{
    protected override string EntityName => nameof(Invoice);

    public Task<Invoice> GetByKeyAsync(int invoiceId )
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<Invoice>(GetAddress(invoiceId ), Options);
    }

    public async Task<int> DeleteAsync(int invoiceId )
    {
        HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(invoiceId ));
        return await response.Content.ReadFromJsonAsync<int>();
    }
}


public partial class InvoiceLineApi : EntityApi<InvoiceLine>
{
    protected override string EntityName => nameof(InvoiceLine);

    public Task<InvoiceLine> GetByKeyAsync(int invoiceLineId )
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<InvoiceLine>(GetAddress(invoiceLineId ), Options);
    }

    public async Task<int> DeleteAsync(int invoiceLineId )
    {
        HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(invoiceLineId ));
        return await response.Content.ReadFromJsonAsync<int>();
    }
}


public partial class MediaTypeApi : EntityApi<MediaType>
{
    protected override string EntityName => nameof(MediaType);

    public Task<MediaType> GetByKeyAsync(int mediaTypeId )
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<MediaType>(GetAddress(mediaTypeId ), Options);
    }

    public async Task<int> DeleteAsync(int mediaTypeId )
    {
        HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(mediaTypeId ));
        return await response.Content.ReadFromJsonAsync<int>();
    }
}


public partial class PlaylistApi : EntityApi<Playlist>
{
    protected override string EntityName => nameof(Playlist);

    public Task<Playlist> GetByKeyAsync(int playlistId )
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<Playlist>(GetAddress(playlistId ), Options);
    }

    public async Task<int> DeleteAsync(int playlistId )
    {
        HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(playlistId ));
        return await response.Content.ReadFromJsonAsync<int>();
    }
}


public partial class PlaylistTrackApi : EntityApi<PlaylistTrack>
{
    protected override string EntityName => nameof(PlaylistTrack);

    public Task<PlaylistTrack> GetByKeyAsync(int playlistId , int trackId )
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<PlaylistTrack>(GetAddress(playlistId , trackId ), Options);
    }

    public async Task<int> DeleteAsync(int playlistId , int trackId )
    {
        HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(playlistId , trackId ));
        return await response.Content.ReadFromJsonAsync<int>();
    }
}


public partial class PlaylistTrackHistoryApi : EntityApi<PlaylistTrackHistory>
{
    protected override string EntityName => nameof(PlaylistTrackHistory);

    public Task<PlaylistTrackHistory> GetByKeyAsync(int playlistId , int trackId , DateTime writtenAt )
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<PlaylistTrackHistory>(GetAddress(playlistId , trackId , writtenAt ), Options);
    }

    public async Task<int> DeleteAsync(int playlistId , int trackId , DateTime writtenAt )
    {
        HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(playlistId , trackId , writtenAt ));
        return await response.Content.ReadFromJsonAsync<int>();
    }
}


public partial class TodoItemApi : EntityApi<TodoItem>
{
    protected override string EntityName => nameof(TodoItem);

    public Task<TodoItem> GetByKeyAsync(int id )
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<TodoItem>(GetAddress(id ), Options);
    }

    public async Task<int> DeleteAsync(int id )
    {
        HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(id ));
        return await response.Content.ReadFromJsonAsync<int>();
    }
}


public partial class TrackApi : EntityApi<Track>
{
    protected override string EntityName => nameof(Track);

    public Task<Track> GetByKeyAsync(int trackId )
    {
        HttpClient client = CreateHttpClient();
        return client.GetFromJsonAsync<Track>(GetAddress(trackId ), Options);
    }

    public async Task<int> DeleteAsync(int trackId )
    {
        HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(trackId ));
        return await response.Content.ReadFromJsonAsync<int>();
    }
}


#endregion