#region usings
using Chinook.Data;
#endregion

namespace Chinook.UnitTest;

[TestClass]
public partial class ArtistDaoTest
{
    [TestInitialize]
    public void Initialize()
    {
        var procedures = new ChinookContextProcedures(DbContextFactory.Create());
        procedures.InitializeAsync().Wait();
    }

    [TestMethod]
    public void InsertOrUpdate()
    {
        var artistName = DateTime.Now.ToString();

        var artist = Dao.Artist.GetByKey(1);
        artist.Name = artistName;
        Dao.Artist.InsertOrUpdate(artist);

        artist = Dao.Artist.GetByKey(1);
        Assert.AreEqual(artistName, artist.Name);
    }

    [TestMethod]
    public void InsertOrUpdate2()
    {
        var artistName = DateTime.Now.ToString();

        var artist = Dao.Artist.Create();
        artist.Name = artistName;
        Dao.Artist.InsertOrUpdate(artist);

        Assert.AreEqual(2, Dao.Artist.GetCount());
    }

    [TestMethod]
    public void InsertIfNotExist()
    {
        var artist = Dao.Artist.Create();
        artist.Name = DateTime.Now.ToString();
        Dao.Artist.InsertIfNotExist(artist);

        Assert.AreEqual(2, Dao.Artist.GetCount());
    }

    [TestMethod]
    public void InsertIfNotExist2()
    {
        var artist = Dao.Artist.GetByKey(1);
        Dao.Artist.InsertIfNotExist(artist);

        Assert.AreEqual(1, Dao.Artist.GetCount());
    }
}