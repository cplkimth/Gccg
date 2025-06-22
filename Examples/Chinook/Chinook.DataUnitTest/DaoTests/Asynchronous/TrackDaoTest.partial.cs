#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Asynchronous;

public partial class TrackDaoTestAsync
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
    public async Task GetLast()
    {
        var entity = await Dao.Track.GetLastAsync(x => x.TrackId );
        entity.ShouldNotBeNull();
    }
}