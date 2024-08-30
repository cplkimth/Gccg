#region

using Chinook.Data;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

public partial class TrackDaoTest
{
    internal static void FillForInsert(Track entity)
    {
    }

    internal static object SetUpdateField(Track entity)
    {
        return entity.Name = DateTime.Now.Ticks.ToString();
    }

    internal static object GetUpdateField(Track entity)
    {
        return entity.Name;
    }

    [TestMethod]
    public void GetLast()
    {
        var entity = Dao.Track.GetLast(x => x.TrackId );
        entity.Should().NotBeNull();
    }
}