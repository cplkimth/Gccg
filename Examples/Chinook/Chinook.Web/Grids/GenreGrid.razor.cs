
#region usings
using Chinook.Data;
#endregion

namespace Chinook.Web.Grids;


public partial class GenreGrid : EntityGrid<Genre>
{
    protected override Genre CreateEntity()
    {
        var genre = Dao.Genre.Create();
        // TODO : CreateEntity

        return genre;
    }

    protected override Task<List<Genre>> GetCoreAsync() => Dao.Genre.GetAsync();

    protected override void InsertEntity(Genre entity) => Dao.Genre.Insert(entity);

    protected override void UpdateEntity(Genre entity) => Dao.Genre.Update(entity);

    protected override void DeleteEntity(Genre entity) => Dao.Genre.Delete(entity);
}

