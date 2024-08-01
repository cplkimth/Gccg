
#region usings
using Chinook.Data;
#endregion

namespace `WebProjectNamespace`.Grids;


public partial class PlaylistTrackHistoryGrid : EntityGrid<PlaylistTrackHistory>
{
    protected override PlaylistTrackHistory CreateEntity()
    {
        var playlistTrackHistory = Dao.PlaylistTrackHistory.Create();
        // TODO : CreateEntity

        return playlistTrackHistory;
    }

    protected override Task<List<PlaylistTrackHistory>> GetCoreAsync() => Dao.PlaylistTrackHistory.GetAsync();

    protected override void InsertEntity(PlaylistTrackHistory entity) => Dao.PlaylistTrackHistory.Insert(entity);

    protected override void UpdateEntity(PlaylistTrackHistory entity) => Dao.PlaylistTrackHistory.Update(entity);

    protected override void DeleteEntity(PlaylistTrackHistory entity) => Dao.PlaylistTrackHistory.Delete(entity);
}

