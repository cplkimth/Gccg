
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
    public virtual async Task<List<T>> Get()
    {
        return await Dao.Get<T>().Get();
    }
    
    [HttpGet("first")]
    public virtual async Task<T> GetFirst()
    {
        return await Dao.Get<T>().GetFirst();
    }

    [HttpGet("count")]
    public virtual async Task<int> GetCount()
    {
        return await Dao.Get<T>().GetCount();
    }

    [HttpPost]
    public virtual async Task<T> Insert(T entity)
    {
        return await Dao.Get<T>().Insert(entity);
    }

    [HttpPut]
    public virtual async Task<int> Update(T entity)
    {
        return await Dao.Get<T>().Update(entity);
    }
}


#region AlbumController
public abstract partial class AlbumControllerBase : EntityController<Album>
{
    [HttpGet("{albumId}")]
    public virtual async Task<Album> GetByKey(int albumId )
    {
        return await Dao.Album.GetByKey(albumId );
    }

    [HttpGet("exists/{albumId}")]
    public virtual async Task<bool> ExistsByKey(int albumId )
    {
        return await Dao.Album.ExistsByKey(albumId );
    }

    [HttpGet("ArtistId/{artistId}")]
    public virtual async Task<List<Album>> GetByArtistId(int artistId)
    {
        return await Dao.Album.GetByArtistId(artistId);
    }
    

    [HttpDelete("{albumId}")]
    public virtual async Task<int> DeleteByKey(int albumId )
    {
        return await Dao.Album.DeleteByKey(albumId );
    }
    
    [HttpGet("last")]
    public virtual async Task<Album> GetLast()
    {
        return await Dao.Album.GetLast(x => new {x.AlbumId } );
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
    public virtual async Task<Artist> GetByKey(int artistId )
    {
        return await Dao.Artist.GetByKey(artistId );
    }

    [HttpGet("exists/{artistId}")]
    public virtual async Task<bool> ExistsByKey(int artistId )
    {
        return await Dao.Artist.ExistsByKey(artistId );
    }

    

    [HttpDelete("{artistId}")]
    public virtual async Task<int> DeleteByKey(int artistId )
    {
        return await Dao.Artist.DeleteByKey(artistId );
    }
    
    [HttpGet("last")]
    public virtual async Task<Artist> GetLast()
    {
        return await Dao.Artist.GetLast(x => new {x.ArtistId } );
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
    public virtual async Task<Code> GetByKey(int codeId )
    {
        return await Dao.Code.GetByKey(codeId );
    }

    [HttpGet("exists/{codeId}")]
    public virtual async Task<bool> ExistsByKey(int codeId )
    {
        return await Dao.Code.ExistsByKey(codeId );
    }

    [HttpGet("CodeCategoryId/{codeCategoryId}")]
    public virtual async Task<List<Code>> GetByCodeCategoryId(int codeCategoryId)
    {
        return await Dao.Code.GetByCodeCategoryId(codeCategoryId);
    }
    

    [HttpDelete("{codeId}")]
    public virtual async Task<int> DeleteByKey(int codeId )
    {
        return await Dao.Code.DeleteByKey(codeId );
    }
    
    [HttpGet("last")]
    public virtual async Task<Code> GetLast()
    {
        return await Dao.Code.GetLast(x => new {x.CodeId } );
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
    public virtual async Task<CodeCategory> GetByKey(int codeCategoryId )
    {
        return await Dao.CodeCategory.GetByKey(codeCategoryId );
    }

    [HttpGet("exists/{codeCategoryId}")]
    public virtual async Task<bool> ExistsByKey(int codeCategoryId )
    {
        return await Dao.CodeCategory.ExistsByKey(codeCategoryId );
    }

    

    [HttpDelete("{codeCategoryId}")]
    public virtual async Task<int> DeleteByKey(int codeCategoryId )
    {
        return await Dao.CodeCategory.DeleteByKey(codeCategoryId );
    }
    
    [HttpGet("last")]
    public virtual async Task<CodeCategory> GetLast()
    {
        return await Dao.CodeCategory.GetLast(x => new {x.CodeCategoryId } );
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
    public virtual async Task<Customer> GetByKey(int customerId )
    {
        return await Dao.Customer.GetByKey(customerId );
    }

    [HttpGet("exists/{customerId}")]
    public virtual async Task<bool> ExistsByKey(int customerId )
    {
        return await Dao.Customer.ExistsByKey(customerId );
    }

    [HttpGet("SupportRepId/{supportRepId}")]
    public virtual async Task<List<Customer>> GetBySupportRepId(int? supportRepId)
    {
        return await Dao.Customer.GetBySupportRepId(supportRepId);
    }
    

    [HttpDelete("{customerId}")]
    public virtual async Task<int> DeleteByKey(int customerId )
    {
        return await Dao.Customer.DeleteByKey(customerId );
    }
    
    [HttpGet("last")]
    public virtual async Task<Customer> GetLast()
    {
        return await Dao.Customer.GetLast(x => new {x.CustomerId } );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class CustomerController : CustomerControllerBase
{
}
#endregion


#region DateTableController
public abstract partial class DateTableControllerBase : EntityController<DateTable>
{
    [HttpGet("{date}")]
    public virtual async Task<DateTable> GetByKey(DateOnly date )
    {
        return await Dao.DateTable.GetByKey(date );
    }

    [HttpGet("exists/{date}")]
    public virtual async Task<bool> ExistsByKey(DateOnly date )
    {
        return await Dao.DateTable.ExistsByKey(date );
    }

    

    [HttpDelete("{date}")]
    public virtual async Task<int> DeleteByKey(DateOnly date )
    {
        return await Dao.DateTable.DeleteByKey(date );
    }
    
    [HttpGet("last")]
    public virtual async Task<DateTable> GetLast()
    {
        return await Dao.DateTable.GetLast(x => new {x.Date } );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class DateTableController : DateTableControllerBase
{
}
#endregion


#region EmployeeController
public abstract partial class EmployeeControllerBase : EntityController<Employee>
{
    [HttpGet("{employeeId}")]
    public virtual async Task<Employee> GetByKey(int employeeId )
    {
        return await Dao.Employee.GetByKey(employeeId );
    }

    [HttpGet("exists/{employeeId}")]
    public virtual async Task<bool> ExistsByKey(int employeeId )
    {
        return await Dao.Employee.ExistsByKey(employeeId );
    }

    [HttpGet("ReportsTo/{reportsTo}")]
    public virtual async Task<List<Employee>> GetByReportsTo(int? reportsTo)
    {
        return await Dao.Employee.GetByReportsTo(reportsTo);
    }
    

    [HttpDelete("{employeeId}")]
    public virtual async Task<int> DeleteByKey(int employeeId )
    {
        return await Dao.Employee.DeleteByKey(employeeId );
    }
    
    [HttpGet("last")]
    public virtual async Task<Employee> GetLast()
    {
        return await Dao.Employee.GetLast(x => new {x.EmployeeId } );
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
    public virtual async Task<Genre> GetByKey(int genreId )
    {
        return await Dao.Genre.GetByKey(genreId );
    }

    [HttpGet("exists/{genreId}")]
    public virtual async Task<bool> ExistsByKey(int genreId )
    {
        return await Dao.Genre.ExistsByKey(genreId );
    }

    

    [HttpDelete("{genreId}")]
    public virtual async Task<int> DeleteByKey(int genreId )
    {
        return await Dao.Genre.DeleteByKey(genreId );
    }
    
    [HttpGet("last")]
    public virtual async Task<Genre> GetLast()
    {
        return await Dao.Genre.GetLast(x => new {x.GenreId } );
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
    public virtual async Task<Invoice> GetByKey(int invoiceId )
    {
        return await Dao.Invoice.GetByKey(invoiceId );
    }

    [HttpGet("exists/{invoiceId}")]
    public virtual async Task<bool> ExistsByKey(int invoiceId )
    {
        return await Dao.Invoice.ExistsByKey(invoiceId );
    }

    [HttpGet("CustomerId/{customerId}")]
    public virtual async Task<List<Invoice>> GetByCustomerId(int customerId)
    {
        return await Dao.Invoice.GetByCustomerId(customerId);
    }
    

    [HttpDelete("{invoiceId}")]
    public virtual async Task<int> DeleteByKey(int invoiceId )
    {
        return await Dao.Invoice.DeleteByKey(invoiceId );
    }
    
    [HttpGet("last")]
    public virtual async Task<Invoice> GetLast()
    {
        return await Dao.Invoice.GetLast(x => new {x.InvoiceId } );
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
    public virtual async Task<InvoiceLine> GetByKey(int invoiceLineId )
    {
        return await Dao.InvoiceLine.GetByKey(invoiceLineId );
    }

    [HttpGet("exists/{invoiceLineId}")]
    public virtual async Task<bool> ExistsByKey(int invoiceLineId )
    {
        return await Dao.InvoiceLine.ExistsByKey(invoiceLineId );
    }

    [HttpGet("InvoiceId/{invoiceId}")]
    public virtual async Task<List<InvoiceLine>> GetByInvoiceId(int invoiceId)
    {
        return await Dao.InvoiceLine.GetByInvoiceId(invoiceId);
    }
    

    [HttpDelete("{invoiceLineId}")]
    public virtual async Task<int> DeleteByKey(int invoiceLineId )
    {
        return await Dao.InvoiceLine.DeleteByKey(invoiceLineId );
    }
    
    [HttpGet("last")]
    public virtual async Task<InvoiceLine> GetLast()
    {
        return await Dao.InvoiceLine.GetLast(x => new {x.InvoiceLineId } );
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
    public virtual async Task<MediaType> GetByKey(int mediaTypeId )
    {
        return await Dao.MediaType.GetByKey(mediaTypeId );
    }

    [HttpGet("exists/{mediaTypeId}")]
    public virtual async Task<bool> ExistsByKey(int mediaTypeId )
    {
        return await Dao.MediaType.ExistsByKey(mediaTypeId );
    }

    

    [HttpDelete("{mediaTypeId}")]
    public virtual async Task<int> DeleteByKey(int mediaTypeId )
    {
        return await Dao.MediaType.DeleteByKey(mediaTypeId );
    }
    
    [HttpGet("last")]
    public virtual async Task<MediaType> GetLast()
    {
        return await Dao.MediaType.GetLast(x => new {x.MediaTypeId } );
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
    public virtual async Task<Playlist> GetByKey(int playlistId )
    {
        return await Dao.Playlist.GetByKey(playlistId );
    }

    [HttpGet("exists/{playlistId}")]
    public virtual async Task<bool> ExistsByKey(int playlistId )
    {
        return await Dao.Playlist.ExistsByKey(playlistId );
    }

    

    [HttpDelete("{playlistId}")]
    public virtual async Task<int> DeleteByKey(int playlistId )
    {
        return await Dao.Playlist.DeleteByKey(playlistId );
    }
    
    [HttpGet("last")]
    public virtual async Task<Playlist> GetLast()
    {
        return await Dao.Playlist.GetLast(x => new {x.PlaylistId } );
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
    public virtual async Task<PlaylistTrack> GetByKey(int playlistId , int trackId )
    {
        return await Dao.PlaylistTrack.GetByKey(playlistId , trackId );
    }

    [HttpGet("exists/{playlistId}/{trackId}")]
    public virtual async Task<bool> ExistsByKey(int playlistId , int trackId )
    {
        return await Dao.PlaylistTrack.ExistsByKey(playlistId , trackId );
    }

    [HttpGet("PlaylistId/{playlistId}")]
    public virtual async Task<List<PlaylistTrack>> GetByPlaylistId(int playlistId)
    {
        return await Dao.PlaylistTrack.GetByPlaylistId(playlistId);
    }
    [HttpGet("TrackId/{trackId}")]
    public virtual async Task<List<PlaylistTrack>> GetByTrackId(int trackId)
    {
        return await Dao.PlaylistTrack.GetByTrackId(trackId);
    }
    

    [HttpDelete("{playlistId}/{trackId}")]
    public virtual async Task<int> DeleteByKey(int playlistId , int trackId )
    {
        return await Dao.PlaylistTrack.DeleteByKey(playlistId ,trackId );
    }
    
    [HttpGet("last")]
    public virtual async Task<PlaylistTrack> GetLast()
    {
        return await Dao.PlaylistTrack.GetLast(x => new {x.PlaylistId , x.TrackId } );
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
    public virtual async Task<PlaylistTrackHistory> GetByKey(int playlistId , int trackId , DateTime writtenAt )
    {
        return await Dao.PlaylistTrackHistory.GetByKey(playlistId , trackId , writtenAt );
    }

    [HttpGet("exists/{playlistId}/{trackId}/{writtenAt}")]
    public virtual async Task<bool> ExistsByKey(int playlistId , int trackId , DateTime writtenAt )
    {
        return await Dao.PlaylistTrackHistory.ExistsByKey(playlistId , trackId , writtenAt );
    }

    [HttpGet("PlaylistId/{playlistId}")]
    public virtual async Task<List<PlaylistTrackHistory>> GetByPlaylistId(int playlistId)
    {
        return await Dao.PlaylistTrackHistory.GetByPlaylistId(playlistId);
    }
    [HttpGet("TrackId/{trackId}")]
    public virtual async Task<List<PlaylistTrackHistory>> GetByTrackId(int trackId)
    {
        return await Dao.PlaylistTrackHistory.GetByTrackId(trackId);
    }
    

    [HttpDelete("{playlistId}/{trackId}/{writtenAt}")]
    public virtual async Task<int> DeleteByKey(int playlistId , int trackId , DateTime writtenAt )
    {
        return await Dao.PlaylistTrackHistory.DeleteByKey(playlistId ,trackId ,writtenAt );
    }
    
    [HttpGet("last")]
    public virtual async Task<PlaylistTrackHistory> GetLast()
    {
        return await Dao.PlaylistTrackHistory.GetLast(x => new {x.PlaylistId , x.TrackId , x.WrittenAt } );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class PlaylistTrackHistoryController : PlaylistTrackHistoryControllerBase
{
}
#endregion


#region TimeTableController
public abstract partial class TimeTableControllerBase : EntityController<TimeTable>
{
    [HttpGet("{time}")]
    public virtual async Task<TimeTable> GetByKey(TimeOnly time )
    {
        return await Dao.TimeTable.GetByKey(time );
    }

    [HttpGet("exists/{time}")]
    public virtual async Task<bool> ExistsByKey(TimeOnly time )
    {
        return await Dao.TimeTable.ExistsByKey(time );
    }

    

    [HttpDelete("{time}")]
    public virtual async Task<int> DeleteByKey(TimeOnly time )
    {
        return await Dao.TimeTable.DeleteByKey(time );
    }
    
    [HttpGet("last")]
    public virtual async Task<TimeTable> GetLast()
    {
        return await Dao.TimeTable.GetLast(x => new {x.Time } );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class TimeTableController : TimeTableControllerBase
{
}
#endregion


#region TrackController
public abstract partial class TrackControllerBase : EntityController<Track>
{
    [HttpGet("{trackId}")]
    public virtual async Task<Track> GetByKey(int trackId )
    {
        return await Dao.Track.GetByKey(trackId );
    }

    [HttpGet("exists/{trackId}")]
    public virtual async Task<bool> ExistsByKey(int trackId )
    {
        return await Dao.Track.ExistsByKey(trackId );
    }

    [HttpGet("AlbumId/{albumId}")]
    public virtual async Task<List<Track>> GetByAlbumId(int? albumId)
    {
        return await Dao.Track.GetByAlbumId(albumId);
    }
    [HttpGet("GenreId/{genreId}")]
    public virtual async Task<List<Track>> GetByGenreId(int genreId)
    {
        return await Dao.Track.GetByGenreId(genreId);
    }
    [HttpGet("MediaTypeId/{mediaTypeId}")]
    public virtual async Task<List<Track>> GetByMediaTypeId(int mediaTypeId)
    {
        return await Dao.Track.GetByMediaTypeId(mediaTypeId);
    }
    

    [HttpDelete("{trackId}")]
    public virtual async Task<int> DeleteByKey(int trackId )
    {
        return await Dao.Track.DeleteByKey(trackId );
    }
    
    [HttpGet("last")]
    public virtual async Task<Track> GetLast()
    {
        return await Dao.Track.GetLast(x => new {x.TrackId } );
    }
}

[Route("api/[controller]")]
[ApiController]
public partial class TrackController : TrackControllerBase
{
}
#endregion

