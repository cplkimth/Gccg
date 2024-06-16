#region

using Chinook.Data;

#endregion

namespace Chinook.UnitTest;

[TestClass]
public class ArtistDaoTest
{
    [TestInitialize]
    public void Initialize()
    {
        Dao.Initialize();
    }

    [TestMethod]
    public void InsertOrUpdateAsync()
    {
        var artistName = DateTime.Now.ToString();

        var artist = Dao.Artist.GetByKey(1);
        artist.Name = artistName;
        Dao.Artist.InsertOrUpdateAsync(artist).Wait();

        artist = Dao.Artist.GetByKey(1);
        Assert.AreEqual(artistName, artist.Name);
    }

    [TestMethod]
    public void InsertOrUpdate2Async()
    {
        var artistName = DateTime.Now.ToString();

        var artist = Dao.Artist.Create();
        artist.Name = artistName;
        Dao.Artist.InsertOrUpdateAsync(artist).Wait();

        Assert.AreEqual(7, Dao.Artist.GetCount());
    }

    [TestMethod]
    public void InsertIfNotExistAsync()
    {
        var artist = Dao.Artist.Create();
        artist.Name = DateTime.Now.ToString();
        Dao.Artist.InsertIfNotExistAsync(artist).Wait();

        Assert.AreEqual(7, Dao.Artist.GetCount());
    }

    [TestMethod]
    public void InsertIfNotExist2Async()
    {
        var artist = Dao.Artist.GetByKey(1);
        Dao.Artist.InsertIfNotExistAsync(artist).Wait();

        Assert.AreEqual(6, Dao.Artist.GetCount());
    }
}