
#region usings
using Chinook.Data;
#endregion

namespace Chinook.Web.Grids;


public partial class ArtistGrid : EntityGrid<Artist>
{
    protected override Artist CreateEntity()
    {
        var artist = Dao.Artist.Create();
        // TODO : CreateEntity

        return artist;
    }

    protected override Task<List<Artist>> GetCoreAsync() => Dao.Artist.GetAsync();

    protected override void InsertEntity(Artist entity) => Dao.Artist.Insert(entity);

    protected override void UpdateEntity(Artist entity) => Dao.Artist.Update(entity);

    protected override void DeleteEntity(Artist entity) => Dao.Artist.Delete(entity);
}

