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
        procedures.InitializeAsync().Wait();
    }

    [TestMethod]
    public void Insert()
    {
        var entity = new PlaylistTrack();
        entity.PlaylistId = 2;
        entity.TrackId = 2;

        Dao.PlaylistTrack.Insert(entity);

        Assert.AreEqual(4, Dao.PlaylistTrack.GetCount());
    }

    [TestMethod]
    public void Delete()
    {
        Dao.PlaylistTrack.DeleteByKey(2, 1);

        Assert.AreEqual(2, Dao.PlaylistTrack.GetCount());
    }
}