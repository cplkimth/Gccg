
#region usings
using Chinook.Data;
#endregion

namespace `WebProjectNamespace`.Grids;


public partial class AlbumGrid : EntityGrid<Album>
{
    protected override Album CreateEntity()
    {
        var album = Dao.Album.Create();
        // TODO : CreateEntity

        return album;
    }

    protected override Task<List<Album>> GetCoreAsync() => Dao.Album.GetAsync();

    protected override void InsertEntity(Album entity) => Dao.Album.Insert(entity);

    protected override void UpdateEntity(Album entity) => Dao.Album.Update(entity);

    protected override void DeleteEntity(Album entity) => Dao.Album.Delete(entity);
}

