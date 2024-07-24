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
        Dao.Initialize();
    }

    [TestMethod]
    public void InsertAsync()
    {
        var entity = new PlaylistTrack();
        entity.PlaylistId = 1;
        entity.TrackId = 70;

        Dao.PlaylistTrack.InsertAsync(entity).Wait();

        Assert.AreEqual(7, Dao.PlaylistTrack.GetCountAsync().Result);
    }

    [TestMethod]
    public void Delete()
    {
        Dao.PlaylistTrack.DeleteByKeyAsync(2, 2).Wait();

        Assert.AreEqual(5, Dao.PlaylistTrack.GetCountAsync().Result);
    }
}