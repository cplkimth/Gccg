#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Synchronous;

public partial class AlbumDaoTest
{
    internal static void FillForInsert(Album entity)
    {
    }

    internal static object SetUpdateField(Album entity)
    {
        return entity.Title = DateTime.Now.Ticks.ToString();
    }

    internal static object GetUpdateField(Album entity)
    {
        return entity.Title;
    }

    [TestMethod]
    public void GetLast()
    {
        var entity = Dao.Album.GetLast(x => x.AlbumId );
        entity.ShouldNotBeNull();
    }
}