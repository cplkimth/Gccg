
#region usings
using Chinook.Data;
#endregion

namespace `WebProjectNamespace`.Grids;


public partial class PlaylistGrid : EntityGrid<Playlist>
{
    protected override Playlist CreateEntity()
    {
        var playlist = Dao.Playlist.Create();
        // TODO : CreateEntity

        return playlist;
    }

    protected override Task<List<Playlist>> GetCoreAsync() => Dao.Playlist.GetAsync();

    protected override void InsertEntity(Playlist entity) => Dao.Playlist.Insert(entity);

    protected override void UpdateEntity(Playlist entity) => Dao.Playlist.Update(entity);

    protected override void DeleteEntity(Playlist entity) => Dao.Playlist.Delete(entity);
}

