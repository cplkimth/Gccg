#region usings
using Chinook.Data;
#endregion

namespace Chinook.UnitTest;

[TestClass]
public class PlaylistTrackDaoTest
{
    [TestInitialize]
    public void Initialize()
    {
        var procedures = new ChinookContextProcedures(DbContextFactory.Create());
        procedures.usp_InitializeAsync().Wait();
    }

    [TestMethod]
    public void Insert()
    {
        var entity = new PlaylistTrack();
        entity.PlaylistId = 1;
        entity.TrackId = 2;

        Dao.PlaylistTrack.Insert(entity);

        Assert.AreEqual(7, Dao.PlaylistTrack.GetCount());
    }

    [TestMethod]
    public void Delete()
    {
        Dao.PlaylistTrack.DeleteByKey(2, 2);

        Assert.AreEqual(5, Dao.PlaylistTrack.GetCount());
    }
}