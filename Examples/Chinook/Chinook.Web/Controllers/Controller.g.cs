
// This file has been generated by Gccg on 2024-08-01 오후 1:56:57.
#region using
using Chinook.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
#endregion

namespace Chinook.Web.Controllers;

public abstract partial class EntityController<T> : ControllerBase where T : Entity<T>, new()
{
    [HttpGet]
    public virtual async Task<List<T>> GetAsync()
    {
        return await Dao.Get<T>().GetAsync();
    }
    
    [HttpGet("first")]
    public virtual async Task<T> GetFirstAsync()
    {
        return await Dao.Get<T>().GetFirstAsync();
    }

    [HttpGet("count")]
    public virtual async Task<int> GetCountAsync()
    {
        return await Dao.Get<T>().GetCountAsync();
    }

    [HttpPost]
    public virtual async Task<T> InsertAsync(T entity)
    {
        return await Dao.Get<T>().InsertAsync(entity);
    }

    [HttpPut]
    public virtual async Task<int> UpdateAsync(T entity)
    {
        return await Dao.Get<T>().UpdateAsync(entity);
    }
}


#region AlbumController
public abstract partial class AlbumControllerBase : EntityController<Album>
{
    [HttpGet("{albumId}")]
    public virtual async Task<Album> GetByKeyAsync(int albumId )
    {
        return await Dao.Album.GetByKeyAsync(albumId );
    }

    [HttpGet("exists/{albumId}")]
    public virtual async Task<bool> ExistsByKeyAsync(int albumId )
    {
        return await Dao.Album.ExistsByKeyAsync(albumId );
    }

     [HttpGet("ArtistId/{artistId}")]
    public virtual async Task<List<Album>> GetByArtistIdAsync(int artistId)
    {
        return await Dao.Album.GetByArtistIdAsync(artistId);
    }
    

    [HttpDelete("{albumId}")]
    public virtual async Task<int> DeleteByKeyAsync(int albumId )
    {
        return await Dao.Album.DeleteByKeyAsync(albumId );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class AlbumController : AlbumControllerBase
{
}
#endregion


#region ArtistController
public abstract partial class ArtistControllerBase : EntityController<Artist>
{
    [HttpGet("{artistId}")]
    public virtual async Task<Artist> GetByKeyAsync(int artistId )
    {
        return await Dao.Artist.GetByKeyAsync(artistId );
    }

    [HttpGet("exists/{artistId}")]
    public virtual async Task<bool> ExistsByKeyAsync(int artistId )
    {
        return await Dao.Artist.ExistsByKeyAsync(artistId );
    }

    

    [HttpDelete("{artistId}")]
    public virtual async Task<int> DeleteByKeyAsync(int artistId )
    {
        return await Dao.Artist.DeleteByKeyAsync(artistId );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class ArtistController : ArtistControllerBase
{
}
#endregion


#region CodeController
public abstract partial class CodeControllerBase : EntityController<Code>
{
    [HttpGet("{codeId}")]
    public virtual async Task<Code> GetByKeyAsync(int codeId )
    {
        return await Dao.Code.GetByKeyAsync(codeId );
    }

    [HttpGet("exists/{codeId}")]
    public virtual async Task<bool> ExistsByKeyAsync(int codeId )
    {
        return await Dao.Code.ExistsByKeyAsync(codeId );
    }

     [HttpGet("CodeCategoryId/{codeCategoryId}")]
    public virtual async Task<List<Code>> GetByCodeCategoryIdAsync(int codeCategoryId)
    {
        return await Dao.Code.GetByCodeCategoryIdAsync(codeCategoryId);
    }
    

    [HttpDelete("{codeId}")]
    public virtual async Task<int> DeleteByKeyAsync(int codeId )
    {
        return await Dao.Code.DeleteByKeyAsync(codeId );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class CodeController : CodeControllerBase
{
}
#endregion


#region CodeCategoryController
public abstract partial class CodeCategoryControllerBase : EntityController<CodeCategory>
{
    [HttpGet("{codeCategoryId}")]
    public virtual async Task<CodeCategory> GetByKeyAsync(int codeCategoryId )
    {
        return await Dao.CodeCategory.GetByKeyAsync(codeCategoryId );
    }

    [HttpGet("exists/{codeCategoryId}")]
    public virtual async Task<bool> ExistsByKeyAsync(int codeCategoryId )
    {
        return await Dao.CodeCategory.ExistsByKeyAsync(codeCategoryId );
    }

    

    [HttpDelete("{codeCategoryId}")]
    public virtual async Task<int> DeleteByKeyAsync(int codeCategoryId )
    {
        return await Dao.CodeCategory.DeleteByKeyAsync(codeCategoryId );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class CodeCategoryController : CodeCategoryControllerBase
{
}
#endregion


#region CustomerController
public abstract partial class CustomerControllerBase : EntityController<Customer>
{
    [HttpGet("{customerId}")]
    public virtual async Task<Customer> GetByKeyAsync(int customerId )
    {
        return await Dao.Customer.GetByKeyAsync(customerId );
    }

    [HttpGet("exists/{customerId}")]
    public virtual async Task<bool> ExistsByKeyAsync(int customerId )
    {
        return await Dao.Customer.ExistsByKeyAsync(customerId );
    }

     [HttpGet("SupportRepId/{supportRepId}")]
    public virtual async Task<List<Customer>> GetBySupportRepIdAsync(int? supportRepId)
    {
        return await Dao.Customer.GetBySupportRepIdAsync(supportRepId);
    }
    

    [HttpDelete("{customerId}")]
    public virtual async Task<int> DeleteByKeyAsync(int customerId )
    {
        return await Dao.Customer.DeleteByKeyAsync(customerId );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class CustomerController : CustomerControllerBase
{
}
#endregion


#region EmployeeController
public abstract partial class EmployeeControllerBase : EntityController<Employee>
{
    [HttpGet("{employeeId}")]
    public virtual async Task<Employee> GetByKeyAsync(int employeeId )
    {
        return await Dao.Employee.GetByKeyAsync(employeeId );
    }

    [HttpGet("exists/{employeeId}")]
    public virtual async Task<bool> ExistsByKeyAsync(int employeeId )
    {
        return await Dao.Employee.ExistsByKeyAsync(employeeId );
    }

     [HttpGet("ReportsTo/{reportsTo}")]
    public virtual async Task<List<Employee>> GetByReportsToAsync(int? reportsTo)
    {
        return await Dao.Employee.GetByReportsToAsync(reportsTo);
    }
    

    [HttpDelete("{employeeId}")]
    public virtual async Task<int> DeleteByKeyAsync(int employeeId )
    {
        return await Dao.Employee.DeleteByKeyAsync(employeeId );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class EmployeeController : EmployeeControllerBase
{
}
#endregion


#region GenreController
public abstract partial class GenreControllerBase : EntityController<Genre>
{
    [HttpGet("{genreId}")]
    public virtual async Task<Genre> GetByKeyAsync(int genreId )
    {
        return await Dao.Genre.GetByKeyAsync(genreId );
    }

    [HttpGet("exists/{genreId}")]
    public virtual async Task<bool> ExistsByKeyAsync(int genreId )
    {
        return await Dao.Genre.ExistsByKeyAsync(genreId );
    }

    

    [HttpDelete("{genreId}")]
    public virtual async Task<int> DeleteByKeyAsync(int genreId )
    {
        return await Dao.Genre.DeleteByKeyAsync(genreId );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class GenreController : GenreControllerBase
{
}
#endregion


#region InvoiceController
public abstract partial class InvoiceControllerBase : EntityController<Invoice>
{
    [HttpGet("{invoiceId}")]
    public virtual async Task<Invoice> GetByKeyAsync(int invoiceId )
    {
        return await Dao.Invoice.GetByKeyAsync(invoiceId );
    }

    [HttpGet("exists/{invoiceId}")]
    public virtual async Task<bool> ExistsByKeyAsync(int invoiceId )
    {
        return await Dao.Invoice.ExistsByKeyAsync(invoiceId );
    }

     [HttpGet("CustomerId/{customerId}")]
    public virtual async Task<List<Invoice>> GetByCustomerIdAsync(int customerId)
    {
        return await Dao.Invoice.GetByCustomerIdAsync(customerId);
    }
    

    [HttpDelete("{invoiceId}")]
    public virtual async Task<int> DeleteByKeyAsync(int invoiceId )
    {
        return await Dao.Invoice.DeleteByKeyAsync(invoiceId );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class InvoiceController : InvoiceControllerBase
{
}
#endregion


#region InvoiceLineController
public abstract partial class InvoiceLineControllerBase : EntityController<InvoiceLine>
{
    [HttpGet("{invoiceLineId}")]
    public virtual async Task<InvoiceLine> GetByKeyAsync(int invoiceLineId )
    {
        return await Dao.InvoiceLine.GetByKeyAsync(invoiceLineId );
    }

    [HttpGet("exists/{invoiceLineId}")]
    public virtual async Task<bool> ExistsByKeyAsync(int invoiceLineId )
    {
        return await Dao.InvoiceLine.ExistsByKeyAsync(invoiceLineId );
    }

     [HttpGet("InvoiceId/{invoiceId}")]
    public virtual async Task<List<InvoiceLine>> GetByInvoiceIdAsync(int invoiceId)
    {
        return await Dao.InvoiceLine.GetByInvoiceIdAsync(invoiceId);
    }
    

    [HttpDelete("{invoiceLineId}")]
    public virtual async Task<int> DeleteByKeyAsync(int invoiceLineId )
    {
        return await Dao.InvoiceLine.DeleteByKeyAsync(invoiceLineId );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class InvoiceLineController : InvoiceLineControllerBase
{
}
#endregion


#region MediaTypeController
public abstract partial class MediaTypeControllerBase : EntityController<MediaType>
{
    [HttpGet("{mediaTypeId}")]
    public virtual async Task<MediaType> GetByKeyAsync(int mediaTypeId )
    {
        return await Dao.MediaType.GetByKeyAsync(mediaTypeId );
    }

    [HttpGet("exists/{mediaTypeId}")]
    public virtual async Task<bool> ExistsByKeyAsync(int mediaTypeId )
    {
        return await Dao.MediaType.ExistsByKeyAsync(mediaTypeId );
    }

    

    [HttpDelete("{mediaTypeId}")]
    public virtual async Task<int> DeleteByKeyAsync(int mediaTypeId )
    {
        return await Dao.MediaType.DeleteByKeyAsync(mediaTypeId );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class MediaTypeController : MediaTypeControllerBase
{
}
#endregion


#region PlaylistController
public abstract partial class PlaylistControllerBase : EntityController<Playlist>
{
    [HttpGet("{playlistId}")]
    public virtual async Task<Playlist> GetByKeyAsync(int playlistId )
    {
        return await Dao.Playlist.GetByKeyAsync(playlistId );
    }

    [HttpGet("exists/{playlistId}")]
    public virtual async Task<bool> ExistsByKeyAsync(int playlistId )
    {
        return await Dao.Playlist.ExistsByKeyAsync(playlistId );
    }

    

    [HttpDelete("{playlistId}")]
    public virtual async Task<int> DeleteByKeyAsync(int playlistId )
    {
        return await Dao.Playlist.DeleteByKeyAsync(playlistId );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class PlaylistController : PlaylistControllerBase
{
}
#endregion


#region PlaylistTrackController
public abstract partial class PlaylistTrackControllerBase : EntityController<PlaylistTrack>
{
    [HttpGet("{playlistId}/{trackId}")]
    public virtual async Task<PlaylistTrack> GetByKeyAsync(int playlistId , int trackId )
    {
        return await Dao.PlaylistTrack.GetByKeyAsync(playlistId , trackId );
    }

    [HttpGet("exists/{playlistId}/{trackId}")]
    public virtual async Task<bool> ExistsByKeyAsync(int playlistId , int trackId )
    {
        return await Dao.PlaylistTrack.ExistsByKeyAsync(playlistId , trackId );
    }

     [HttpGet("PlaylistId/{playlistId}")]
    public virtual async Task<List<PlaylistTrack>> GetByPlaylistIdAsync(int playlistId)
    {
        return await Dao.PlaylistTrack.GetByPlaylistIdAsync(playlistId);
    }
    

    [HttpDelete("{playlistId}/{trackId}")]
    public virtual async Task<int> DeleteByKeyAsync(int playlistId , int trackId )
    {
        return await Dao.PlaylistTrack.DeleteByKeyAsync(playlistId , trackId );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class PlaylistTrackController : PlaylistTrackControllerBase
{
}
#endregion


#region PlaylistTrackHistoryController
public abstract partial class PlaylistTrackHistoryControllerBase : EntityController<PlaylistTrackHistory>
{
    [HttpGet("{playlistId}/{trackId}/{writtenAt}")]
    public virtual async Task<PlaylistTrackHistory> GetByKeyAsync(int playlistId , int trackId , DateTime writtenAt )
    {
        return await Dao.PlaylistTrackHistory.GetByKeyAsync(playlistId , trackId , writtenAt );
    }

    [HttpGet("exists/{playlistId}/{trackId}/{writtenAt}")]
    public virtual async Task<bool> ExistsByKeyAsync(int playlistId , int trackId , DateTime writtenAt )
    {
        return await Dao.PlaylistTrackHistory.ExistsByKeyAsync(playlistId , trackId , writtenAt );
    }

     [HttpGet("PlaylistId/{playlistId}")]
    public virtual async Task<List<PlaylistTrackHistory>> GetByPlaylistIdAsync(int playlistId)
    {
        return await Dao.PlaylistTrackHistory.GetByPlaylistIdAsync(playlistId);
    }
     [HttpGet("TrackId/{trackId}")]
    public virtual async Task<List<PlaylistTrackHistory>> GetByTrackIdAsync(int trackId)
    {
        return await Dao.PlaylistTrackHistory.GetByTrackIdAsync(trackId);
    }
    

    [HttpDelete("{playlistId}/{trackId}/{writtenAt}")]
    public virtual async Task<int> DeleteByKeyAsync(int playlistId , int trackId , DateTime writtenAt )
    {
        return await Dao.PlaylistTrackHistory.DeleteByKeyAsync(playlistId , trackId , writtenAt );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class PlaylistTrackHistoryController : PlaylistTrackHistoryControllerBase
{
}
#endregion


#region TrackController
public abstract partial class TrackControllerBase : EntityController<Track>
{
    [HttpGet("{trackId}")]
    public virtual async Task<Track> GetByKeyAsync(int trackId )
    {
        return await Dao.Track.GetByKeyAsync(trackId );
    }

    [HttpGet("exists/{trackId}")]
    public virtual async Task<bool> ExistsByKeyAsync(int trackId )
    {
        return await Dao.Track.ExistsByKeyAsync(trackId );
    }

     [HttpGet("AlbumId/{albumId}")]
    public virtual async Task<List<Track>> GetByAlbumIdAsync(int? albumId)
    {
        return await Dao.Track.GetByAlbumIdAsync(albumId);
    }
     [HttpGet("GenreId/{genreId}")]
    public virtual async Task<List<Track>> GetByGenreIdAsync(int genreId)
    {
        return await Dao.Track.GetByGenreIdAsync(genreId);
    }
     [HttpGet("MediaTypeId/{mediaTypeId}")]
    public virtual async Task<List<Track>> GetByMediaTypeIdAsync(int mediaTypeId)
    {
        return await Dao.Track.GetByMediaTypeIdAsync(mediaTypeId);
    }
    

    [HttpDelete("{trackId}")]
    public virtual async Task<int> DeleteByKeyAsync(int trackId )
    {
        return await Dao.Track.DeleteByKeyAsync(trackId );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class TrackController : TrackControllerBase
{
}
#endregion

