#region

using Chinook.Data;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

public partial class ArtistDaoTest
{
    internal static void FillForInsert(Artist entity)
    {
    }

    internal static object SetUpdateField(Artist entity)
    {
        return entity.Name = DateTime.Now.Ticks.ToString();
    }

    internal static object GetUpdateField(Artist entity)
    {
        return entity.Name;
    }
    
    [TestMethod]
    public async Task GetLast()
    {
        var entity = await Dao.Artist.GetLast(x => x.ArtistId );
        entity.ShouldNotBeNull();
    }
}