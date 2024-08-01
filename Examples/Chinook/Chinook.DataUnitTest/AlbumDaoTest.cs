#region usings
using Chinook.Data;
#endregion

namespace Chinook.UnitTest;

[TestClass]
public partial class AlbumDaoTest
{
    [TestInitialize]
    public void Initialize()
    {
        var procedures = new ChinookContextProcedures(DbContextFactory.Create());
        procedures.usp_InitializeAsync().Wait();
    }

    [TestMethod]
    public void GetCount()
    {
        var count = Dao.Album.GetCount();
        Assert.AreEqual(8, count);
    }

    [TestMethod]
    public void GetByArtistId()
    {
        var albums = Dao.Album.GetByArtistId(2);
        Assert.AreEqual(2, albums.Count);
    }

    [TestMethod]
    public void GetByKey()
    {
        var album = Dao.Album.GetByKey(9);
        Assert.AreEqual(9, album.AlbumId);
    }

    [TestMethod]
    public void ExistsByKey()
    {
        var exist = Dao.Album.ExistsByKey(9);
        Assert.IsTrue(exist);
    }

    [TestMethod]
    public void Exists()
    {
        var exist = Dao.Album.Exists(x => x.AlbumId == 9);
        Assert.IsTrue(exist);
    }

    [TestMethod]
    public void DeleteByKey()
    {
        Dao.Album.DeleteByKey(1);
        Assert.IsFalse(Dao.Album.ExistsByKey(1));
    }

    [TestMethod]
    public void DeleteAll()
    {
        var count = Dao.Album.DeleteAll(x => x.Title.Contains("Yellow"));
        Assert.AreEqual(1, count);
        Assert.IsFalse(Dao.Album.ExistsByKey(1));
    }

    [TestMethod]
    public void Insert()
    {
        var oldCount = Dao.Album.GetCount();

        var album = new Album();
        album.Title = DateTime.Now.ToString();
        album.ArtistId = 1;
        album = Dao.Album.Insert(album);

        var newCount = Dao.Album.GetCount();

        Assert.AreEqual(oldCount + 1, newCount);
        Assert.IsTrue(album.AlbumId != 0);
    }

    [TestMethod]
    public void InsertMany()
    {
        var title = DateTime.Now.ToString();

        var albums = new List<Album>
                     {
                         new()
                         {Title = title, ArtistId = 1},
                         new()
                         {Title = title, ArtistId = 1}
                     };

        var oldCount = Dao.Album.GetCount();
        var insertedCount = Dao.Album.InsertMany(albums);
        var newCount = Dao.Album.GetCount();

        Assert.AreEqual(2, insertedCount);
        Assert.AreEqual(oldCount + 2, newCount);
    }

    [TestMethod]
    public void Update()
    {
        var title = DateTime.Now.ToString();

        var album = Dao.Album.GetLast(x => x.AlbumId);
        album.Title = title;
        Dao.Album.Update(album);

        album = Dao.Album.GetLast(x => x.AlbumId);

        Assert.AreEqual(title, album.Title);
    }

    [TestMethod]
    public void UpdateMany()
    {
        var albums = Dao.Album.Get();
        foreach (var album in albums)
            album.Title = album.AlbumId.ToString();

        Dao.Album.UpdateMany(albums);

        foreach (var album in albums)
            Assert.AreEqual(album.AlbumId, int.Parse(album.Title));
    }

    [TestMethod]
    public void GetFirst()
    {
        var album = Dao.Album.GetFirst();
        Assert.AreEqual(2, album.AlbumId);
    }

    [TestMethod]
    public void GetFirst2()
    {
        var album = Dao.Album.GetFirst(x => x.Title.Contains("Yellow"));
        Assert.AreEqual(9, album.AlbumId);
    }

    [TestMethod]
    public void GetFirst3()
    {
        var album = Dao.Album.GetFirst(x => x.Title);
        Assert.AreEqual(8, album.AlbumId);
    }

    [TestMethod]
    public void GetFirst4()
    {
        var album = Dao.Album.GetFirst(x => x.Title.Contains("ne"), x => x.Title);
        Assert.AreEqual(2, album.AlbumId);
    }

    [TestMethod]
    public void GetLast()
    {
        var album = Dao.Album.GetLast(x => x.AlbumId);
        Assert.AreEqual(9, album.AlbumId);
    }

    [TestMethod]
    public void GetLast2()
    {
        var album = Dao.Album.GetLast(x => x.Title.Contains("ne"));
        Assert.AreEqual(2, album.AlbumId);
    }

    [TestMethod]
    public void GetLast3()
    {
        var album = Dao.Album.GetLast(x => x.Title.Contains("ne"), x => x.AlbumId);
        Assert.AreEqual(9, album.AlbumId);
    }

    [TestMethod]
    public void SelectFirst()
    {
        var title = Dao.Album.SelectFirst(x => x.Title);
        Assert.AreEqual("Money", title);
    }

    [TestMethod]
    public void SelectFirst2()
    {
        var title = Dao.Album.SelectFirst(x => x.Title.Contains("ne"), x => x.Title);
        Assert.AreEqual("Money", title);
    }

    [TestMethod]
    public void SelectFirst3()
    {
        var title = Dao.Album.SelectFirst(x => x.AlbumId, x => x.Title);
        Assert.AreEqual("Money", title);
    }

    [TestMethod]
    public void SelectFirst4()
    {
        var title = Dao.Album.SelectFirst(x => x.Title.Contains("ne"), x => x.AlbumId, x => x.Title);
        Assert.AreEqual("Money", title);
    }

    [TestMethod]
    public void SelectLast()
    {
        var title = Dao.Album.SelectLast(x => x.AlbumId, x => x.Title);
        Assert.AreEqual("Yellow Submarine", title);
    }

    [TestMethod]
    public void SelectLast2()
    {
        var title = Dao.Album.SelectLast(x => x.Title.Contains("Rock"), x => x.Title);
        Assert.AreEqual("The Wall", title);
    }

    [TestMethod]
    public void SelectLast3()
    {
        var title = Dao.Album.SelectLast(x => x.Title.Contains("Rock"), x => x.AlbumId, x => x.Title);
        Assert.IsNull(title);
    }

    [TestMethod]
    public void GetT()
    {
        var count = Dao.Get<Album>().GetCount();
    }
}