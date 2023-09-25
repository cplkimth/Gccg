
// This file has been generated by Gccg on 2023-09-26 오전 1:12:46.
#region using
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
#endregion

namespace Chinook.Data;

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

    public virtual async Task<List<T>> GetAsync()
    {
        return await CreateHttpClient().GetFromJsonAsync<List<T>>(GetAddress(), Options);
    }

    public virtual async Task<T> GetFirstAsync()
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<T>(GetAddress("first"), Options);
    }

    public virtual async Task<int> GetCountAsync()
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<int>(GetAddress("count"), Options);
    }

    public virtual async Task<T> InsertAsync(T entity)
    {
        using HttpClient client = CreateHttpClient();
        var response = await client.PostAsJsonAsync(GetAddress(), entity, Options);
        return await response.Content.ReadFromJsonAsync<T>();
    }

    public virtual async Task<int> UpdateAsync(T entity)
    {
        using HttpClient client = CreateHttpClient();
        var response = await client.PutAsJsonAsync(GetAddress(), entity, Options);
        return await response.Content.ReadFromJsonAsync<int>();
    }
}

#region clients

public partial class AlbumBaseApi : EntityApi<Album>
{
    protected override string EntityName => nameof(Album);

    public virtual async Task<Album> GetByKeyAsync(int albumId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<Album>(GetAddress(albumId ), Options);
    }

    public virtual async Task<bool> ExistsByKeyAsync(int albumId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<bool>(GetAddress("exists", albumId ), Options);
    }

    public virtual async Task<List<Album>> GetByArtistIdAsync(int artistId)
    {
        HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<List<Album>>(GetAddress("artistId", artistId), Options);
    }
    

    public virtual async Task<int> DeleteAsync(int albumId )
    {
        using HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(albumId ));
        return await response.Content.ReadFromJsonAsync<int>(Options);
    }
}

public partial class AlbumApi : AlbumBaseApi
{
}


public partial class ArtistBaseApi : EntityApi<Artist>
{
    protected override string EntityName => nameof(Artist);

    public virtual async Task<Artist> GetByKeyAsync(int artistId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<Artist>(GetAddress(artistId ), Options);
    }

    public virtual async Task<bool> ExistsByKeyAsync(int artistId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<bool>(GetAddress("exists", artistId ), Options);
    }

    

    public virtual async Task<int> DeleteAsync(int artistId )
    {
        using HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(artistId ));
        return await response.Content.ReadFromJsonAsync<int>(Options);
    }
}

public partial class ArtistApi : ArtistBaseApi
{
}


public partial class CompanyBaseApi : EntityApi<Company>
{
    protected override string EntityName => nameof(Company);

    public virtual async Task<Company> GetByKeyAsync(int companyId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<Company>(GetAddress(companyId ), Options);
    }

    public virtual async Task<bool> ExistsByKeyAsync(int companyId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<bool>(GetAddress("exists", companyId ), Options);
    }

    

    public virtual async Task<int> DeleteAsync(int companyId )
    {
        using HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(companyId ));
        return await response.Content.ReadFromJsonAsync<int>(Options);
    }
}

public partial class CompanyApi : CompanyBaseApi
{
}


public partial class CustomerBaseApi : EntityApi<Customer>
{
    protected override string EntityName => nameof(Customer);

    public virtual async Task<Customer> GetByKeyAsync(int customerId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<Customer>(GetAddress(customerId ), Options);
    }

    public virtual async Task<bool> ExistsByKeyAsync(int customerId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<bool>(GetAddress("exists", customerId ), Options);
    }

    public virtual async Task<List<Customer>> GetBySupportRepIdAsync(int? supportRepId)
    {
        HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<List<Customer>>(GetAddress("supportRepId", supportRepId), Options);
    }
    

    public virtual async Task<int> DeleteAsync(int customerId )
    {
        using HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(customerId ));
        return await response.Content.ReadFromJsonAsync<int>(Options);
    }
}

public partial class CustomerApi : CustomerBaseApi
{
}


public partial class EmployeeBaseApi : EntityApi<Employee>
{
    protected override string EntityName => nameof(Employee);

    public virtual async Task<Employee> GetByKeyAsync(int employeeId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<Employee>(GetAddress(employeeId ), Options);
    }

    public virtual async Task<bool> ExistsByKeyAsync(int employeeId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<bool>(GetAddress("exists", employeeId ), Options);
    }

    public virtual async Task<List<Employee>> GetByReportsToAsync(int? reportsTo)
    {
        HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<List<Employee>>(GetAddress("reportsTo", reportsTo), Options);
    }
    

    public virtual async Task<int> DeleteAsync(int employeeId )
    {
        using HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(employeeId ));
        return await response.Content.ReadFromJsonAsync<int>(Options);
    }
}

public partial class EmployeeApi : EmployeeBaseApi
{
}


public partial class GenreBaseApi : EntityApi<Genre>
{
    protected override string EntityName => nameof(Genre);

    public virtual async Task<Genre> GetByKeyAsync(int genreId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<Genre>(GetAddress(genreId ), Options);
    }

    public virtual async Task<bool> ExistsByKeyAsync(int genreId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<bool>(GetAddress("exists", genreId ), Options);
    }

    

    public virtual async Task<int> DeleteAsync(int genreId )
    {
        using HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(genreId ));
        return await response.Content.ReadFromJsonAsync<int>(Options);
    }
}

public partial class GenreApi : GenreBaseApi
{
}


public partial class InvoiceBaseApi : EntityApi<Invoice>
{
    protected override string EntityName => nameof(Invoice);

    public virtual async Task<Invoice> GetByKeyAsync(int invoiceId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<Invoice>(GetAddress(invoiceId ), Options);
    }

    public virtual async Task<bool> ExistsByKeyAsync(int invoiceId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<bool>(GetAddress("exists", invoiceId ), Options);
    }

    public virtual async Task<List<Invoice>> GetByCustomerIdAsync(int customerId)
    {
        HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<List<Invoice>>(GetAddress("customerId", customerId), Options);
    }
    

    public virtual async Task<int> DeleteAsync(int invoiceId )
    {
        using HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(invoiceId ));
        return await response.Content.ReadFromJsonAsync<int>(Options);
    }
}

public partial class InvoiceApi : InvoiceBaseApi
{
}


public partial class InvoiceLineBaseApi : EntityApi<InvoiceLine>
{
    protected override string EntityName => nameof(InvoiceLine);

    public virtual async Task<InvoiceLine> GetByKeyAsync(int invoiceLineId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<InvoiceLine>(GetAddress(invoiceLineId ), Options);
    }

    public virtual async Task<bool> ExistsByKeyAsync(int invoiceLineId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<bool>(GetAddress("exists", invoiceLineId ), Options);
    }

    public virtual async Task<List<InvoiceLine>> GetByInvoiceIdAsync(int invoiceId)
    {
        HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<List<InvoiceLine>>(GetAddress("invoiceId", invoiceId), Options);
    }
    public virtual async Task<List<InvoiceLine>> GetByTrackIdAsync(int trackId)
    {
        HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<List<InvoiceLine>>(GetAddress("trackId", trackId), Options);
    }
    

    public virtual async Task<int> DeleteAsync(int invoiceLineId )
    {
        using HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(invoiceLineId ));
        return await response.Content.ReadFromJsonAsync<int>(Options);
    }
}

public partial class InvoiceLineApi : InvoiceLineBaseApi
{
}


public partial class MediaTypeBaseApi : EntityApi<MediaType>
{
    protected override string EntityName => nameof(MediaType);

    public virtual async Task<MediaType> GetByKeyAsync(int mediaTypeId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<MediaType>(GetAddress(mediaTypeId ), Options);
    }

    public virtual async Task<bool> ExistsByKeyAsync(int mediaTypeId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<bool>(GetAddress("exists", mediaTypeId ), Options);
    }

    

    public virtual async Task<int> DeleteAsync(int mediaTypeId )
    {
        using HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(mediaTypeId ));
        return await response.Content.ReadFromJsonAsync<int>(Options);
    }
}

public partial class MediaTypeApi : MediaTypeBaseApi
{
}


public partial class PlaylistBaseApi : EntityApi<Playlist>
{
    protected override string EntityName => nameof(Playlist);

    public virtual async Task<Playlist> GetByKeyAsync(int playlistId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<Playlist>(GetAddress(playlistId ), Options);
    }

    public virtual async Task<bool> ExistsByKeyAsync(int playlistId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<bool>(GetAddress("exists", playlistId ), Options);
    }

    

    public virtual async Task<int> DeleteAsync(int playlistId )
    {
        using HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(playlistId ));
        return await response.Content.ReadFromJsonAsync<int>(Options);
    }
}

public partial class PlaylistApi : PlaylistBaseApi
{
}


public partial class PlaylistTrackBaseApi : EntityApi<PlaylistTrack>
{
    protected override string EntityName => nameof(PlaylistTrack);

    public virtual async Task<PlaylistTrack> GetByKeyAsync(int playlistId , int trackId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<PlaylistTrack>(GetAddress(playlistId , trackId ), Options);
    }

    public virtual async Task<bool> ExistsByKeyAsync(int playlistId , int trackId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<bool>(GetAddress("exists", playlistId , trackId ), Options);
    }

    public virtual async Task<List<PlaylistTrack>> GetByPlaylistIdAsync(int playlistId)
    {
        HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<List<PlaylistTrack>>(GetAddress("playlistId", playlistId), Options);
    }
    public virtual async Task<List<PlaylistTrack>> GetByTrackIdAsync(int trackId)
    {
        HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<List<PlaylistTrack>>(GetAddress("trackId", trackId), Options);
    }
    

    public virtual async Task<int> DeleteAsync(int playlistId , int trackId )
    {
        using HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(playlistId , trackId ));
        return await response.Content.ReadFromJsonAsync<int>(Options);
    }
}

public partial class PlaylistTrackApi : PlaylistTrackBaseApi
{
}


public partial class PlaylistTrackHistoryBaseApi : EntityApi<PlaylistTrackHistory>
{
    protected override string EntityName => nameof(PlaylistTrackHistory);

    public virtual async Task<PlaylistTrackHistory> GetByKeyAsync(int playlistId , int trackId , DateTime writtenAt )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<PlaylistTrackHistory>(GetAddress(playlistId , trackId , writtenAt ), Options);
    }

    public virtual async Task<bool> ExistsByKeyAsync(int playlistId , int trackId , DateTime writtenAt )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<bool>(GetAddress("exists", playlistId , trackId , writtenAt ), Options);
    }

    public virtual async Task<List<PlaylistTrackHistory>> GetByPlaylistIdAsync(int playlistId)
    {
        HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<List<PlaylistTrackHistory>>(GetAddress("playlistId", playlistId), Options);
    }
    public virtual async Task<List<PlaylistTrackHistory>> GetByTrackIdAsync(int trackId)
    {
        HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<List<PlaylistTrackHistory>>(GetAddress("trackId", trackId), Options);
    }
    

    public virtual async Task<int> DeleteAsync(int playlistId , int trackId , DateTime writtenAt )
    {
        using HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(playlistId , trackId , writtenAt ));
        return await response.Content.ReadFromJsonAsync<int>(Options);
    }
}

public partial class PlaylistTrackHistoryApi : PlaylistTrackHistoryBaseApi
{
}


public partial class TodoItemBaseApi : EntityApi<TodoItem>
{
    protected override string EntityName => nameof(TodoItem);

    public virtual async Task<TodoItem> GetByKeyAsync(int id )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<TodoItem>(GetAddress(id ), Options);
    }

    public virtual async Task<bool> ExistsByKeyAsync(int id )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<bool>(GetAddress("exists", id ), Options);
    }

    

    public virtual async Task<int> DeleteAsync(int id )
    {
        using HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(id ));
        return await response.Content.ReadFromJsonAsync<int>(Options);
    }
}

public partial class TodoItemApi : TodoItemBaseApi
{
}


public partial class TrackBaseApi : EntityApi<Track>
{
    protected override string EntityName => nameof(Track);

    public virtual async Task<Track> GetByKeyAsync(int trackId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<Track>(GetAddress(trackId ), Options);
    }

    public virtual async Task<bool> ExistsByKeyAsync(int trackId )
    {
        using HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<bool>(GetAddress("exists", trackId ), Options);
    }

    public virtual async Task<List<Track>> GetByAlbumIdAsync(int? albumId)
    {
        HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<List<Track>>(GetAddress("albumId", albumId), Options);
    }
    public virtual async Task<List<Track>> GetByGenreIdAsync(int genreId)
    {
        HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<List<Track>>(GetAddress("genreId", genreId), Options);
    }
    public virtual async Task<List<Track>> GetByMediaTypeIdAsync(int mediaTypeId)
    {
        HttpClient client = CreateHttpClient();
        return await client.GetFromJsonAsync<List<Track>>(GetAddress("mediaTypeId", mediaTypeId), Options);
    }
    

    public virtual async Task<int> DeleteAsync(int trackId )
    {
        using HttpClient client = CreateHttpClient();
        var response  = await client.DeleteAsync(GetAddress(trackId ));
        return await response.Content.ReadFromJsonAsync<int>(Options);
    }
}

public partial class TrackApi : TrackBaseApi
{
}


#endregion