#region

using Chinook.Data;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

public partial class GenreDaoTest
{
    internal static void FillForInsert(Genre entity)
    {
    }

    internal static object SetUpdateField(Genre entity)
    {
        return entity.Name = DateTime.Now.Ticks.ToString();
    }

    internal static object GetUpdateField(Genre entity)
    {
        return entity.Name;
    }

    [TestMethod]
    public async Task GetLast()
    {
        var entity = await Dao.Genre.GetLast(x => x.GenreId );
        entity.ShouldNotBeNull();
    }
}