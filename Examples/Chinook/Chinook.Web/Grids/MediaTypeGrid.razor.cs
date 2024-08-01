
#region usings
using Chinook.Data;
#endregion

namespace `WebProjectNamespace`.Grids;


public partial class MediaTypeGrid : EntityGrid<MediaType>
{
    protected override MediaType CreateEntity()
    {
        var mediaType = Dao.MediaType.Create();
        // TODO : CreateEntity

        return mediaType;
    }

    protected override Task<List<MediaType>> GetCoreAsync() => Dao.MediaType.GetAsync();

    protected override void InsertEntity(MediaType entity) => Dao.MediaType.Insert(entity);

    protected override void UpdateEntity(MediaType entity) => Dao.MediaType.Update(entity);

    protected override void DeleteEntity(MediaType entity) => Dao.MediaType.Delete(entity);
}

