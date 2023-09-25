
#region usings
using Chinook.Data;
#endregion

namespace Chinook.Web.Grids;


public partial class PlaylistTrackGrid : EntityGrid<PlaylistTrack>
{
    protected override PlaylistTrack CreateEntity()
    {
        var playlistTrack = Dao.PlaylistTrack.Create();
        // TODO : CreateEntity

        return playlistTrack;
    }

    protected override Task<List<PlaylistTrack>> GetCoreAsync() => Dao.PlaylistTrack.GetAsync();

    protected override void InsertEntity(PlaylistTrack entity) => Dao.PlaylistTrack.Insert(entity);

    protected override void UpdateEntity(PlaylistTrack entity) => Dao.PlaylistTrack.Update(entity);

    protected override void DeleteEntity(PlaylistTrack entity) => Dao.PlaylistTrack.Delete(entity);
}

