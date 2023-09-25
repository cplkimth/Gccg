
#region usings
using Chinook.Data;
#endregion

namespace Chinook.Web.Grids;


public partial class TrackGrid : EntityGrid<Track>
{
    protected override Track CreateEntity()
    {
        var track = Dao.Track.Create();
        // TODO : CreateEntity

        return track;
    }

    protected override Task<List<Track>> GetCoreAsync() => Dao.Track.GetAsync();

    protected override void InsertEntity(Track entity) => Dao.Track.Insert(entity);

    protected override void UpdateEntity(Track entity) => Dao.Track.Update(entity);

    protected override void DeleteEntity(Track entity) => Dao.Track.Delete(entity);
}

