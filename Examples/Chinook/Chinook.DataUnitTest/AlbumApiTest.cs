#region usings
using Chinook.Data;
#endregion

namespace Chinook.UnitTest;

[TestClass]
public class AlbumApiTest
{
    [ClassInitialize]
    public static void InitializeTest(TestContext context)
    {
        Api.BaseAddress = "https://localhost:7098";
    }

    [TestInitialize]
    public void Initialize()
    {
        Api.Album.Initialize().Wait();
    }

    [TestMethod]
    public void GetCount()
    {
        var count = Api.Album.GetCountAsync().Result;
        Assert.AreEqual(2, count);
    }

    [TestMethod]
    public void GetByArtistId()
    {
        var albums = Api.Album.GetByArtistIdAsync(1).Result;
        Assert.AreEqual(2, albums.Count);
    }

    [TestMethod]
    public void GetByKey()
    {
        var album = Api.Album.GetByKeyAsync(1).Result;
        Assert.AreEqual(1, album.AlbumId);
    }

    [TestMethod]
    public void ExistsByKey()
    {
        var exist = Api.Album.ExistsByKeyAsync(1).Result;
        Assert.IsTrue(exist);
    }

    [TestMethod]
    public void DeleteByKey()
    {
        Api.Album.DeleteAsync(1).Wait();
        Assert.IsFalse(Api.Album.ExistsByKeyAsync(1).Result);
    }

    [TestMethod]
    public void Insert()
    {
        var oldCount = Api.Album.GetCountAsync().Result;

        var album = new Album();
        album.Title = DateTime.Now.ToString();
        album.ArtistId = 1;
        album = Api.Album.InsertAsync(album).Result;

        var newCount = Api.Album.GetCountAsync().Result;

        Assert.AreEqual(oldCount + 1, newCount);
        Assert.IsTrue(album.AlbumId != 0);
    }

    [TestMethod]
    public void Update()
    {
        var title = DateTime.Now.ToString();

        var album = Api.Album.GetFirstAsync().Result;
        album.Title = title;
        Api.Album.UpdateAsync(album).Wait();

        album = Api.Album.GetFirstAsync().Result;

        Assert.AreEqual(title, album.Title);
    }

    [TestMethod]
    public void GetFirst()
    {
        var album = Api.Album.GetFirstAsync().Result;
        Assert.AreEqual(1, album.AlbumId);
    }
}