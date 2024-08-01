#region

using Chinook.Data;

#endregion

namespace Chinook.UnitTest;

public partial class AlbumDaoTest
{
    [TestMethod]
    public void GetCountAsync()
    {
        var count = Dao.Album.GetCountAsync().Result;
        Assert.AreEqual(8, count);
    }

    [TestMethod]
    public void GetByArtistIdAsync()
    {
        var albums = Dao.Album.GetByArtistIdAsync(2).Result;
        Assert.AreEqual(2, albums.Count);
    }

    [TestMethod]
    public void GetByKeyAsync()
    {
        var album = Dao.Album.GetByKeyAsync(9).Result;
        Assert.AreEqual(9, album.AlbumId);
    }

    [TestMethod]
    public void ExistsByKeyAsync()
    {
        var exist = Dao.Album.ExistsByKeyAsync(9).Result;
        Assert.IsTrue(exist);
    }

    [TestMethod]
    public void ExistsAsync()
    {
        var exist = Dao.Album.ExistsAsync(x => x.AlbumId == 9).Result;
        Assert.IsTrue(exist);
    }

    [TestMethod]
    public void DeleteByKeyAsync()
    {
        Dao.Album.DeleteByKey(9);
        Assert.IsFalse(Dao.Album.ExistsByKeyAsync(9).Result);
    }

    [TestMethod]
    public void DeleteAllAsync()
    {
        var count = Dao.Album.DeleteAllAsync(x => x.Title.Contains("Submarine")).Result;
        Assert.AreEqual(1, count);
        Assert.IsFalse(Dao.Album.ExistsByKey(9));
    }

    [TestMethod]
    public async Task InsertAsync()
    {
        // var oldCount = await Dao.Album.GetCountAsync();
        var oldCount = Dao.Album.GetCount();

        var album = new Album
        {
            Title = DateTime.Now.ToString(),
            ArtistId = 1
        };
        album = await Dao.Album.InsertAsync(album);

        var newCount = await Dao.Album.GetCountAsync();

        Assert.AreEqual(oldCount + 1, newCount);
        Assert.IsTrue(album.AlbumId != 0);
    }

    [TestMethod]
    public void InsertManyAsync()
    {
        var title = DateTime.Now.ToString();

        var albums = new List<Album>
        {
            new() { Title = title, ArtistId = 1 },
            new() { Title = title, ArtistId = 1 }
        };

        var oldCount = Dao.Album.GetCount();
        var insertedCount = Dao.Album.InsertManyAsync(albums).Result;
        var newCount = Dao.Album.GetCount();

        Assert.AreEqual(2, insertedCount);
        Assert.AreEqual(oldCount + 2, newCount);
    }

    [TestMethod]
    public void UpdateAsync()
    {
        var title = DateTime.Now.ToString();

        var album = Dao.Album.GetLast(x => x.AlbumId);
        album.Title = title;
        Dao.Album.UpdateAsync(album).Wait();

        album = Dao.Album.GetLast(x => x.AlbumId);

        Assert.AreEqual(title, album.Title);
    }

    [TestMethod]
    public void UpdateManyAsync()
    {
        var albums = Dao.Album.Get();
        foreach (var album in albums)
            album.Title = album.AlbumId.ToString();

        Dao.Album.UpdateManyAsync(albums).Wait();

        foreach (var album in albums)
            Assert.AreEqual(album.AlbumId, int.Parse(album.Title));
    }

    [TestMethod]
    public void GetFirstAsync()
    {
        var album = Dao.Album.GetFirstAsync().Result;
        Assert.AreEqual(2, album.AlbumId);
    }

    [TestMethod]
    public void GetFirst2Async()
    {
        var album = Dao.Album.GetFirstAsync(x => x.Title.Contains("Yellow")).Result;
        Assert.AreEqual(9, album.AlbumId);
    }

    [TestMethod]
    public void GetFirst3Async()
    {
        var album = Dao.Album.GetFirstAsync(x => x.Title).Result;
        Assert.AreEqual(8, album.AlbumId);
    }

    [TestMethod]
    public void GetFirst4Async()
    {
        var album = Dao.Album.GetFirstAsync(x => x.Title.Contains("ne"), x => x.Title).Result;
        Assert.AreEqual(2, album.AlbumId);
    }

    [TestMethod]
    public void GetLastAsync()
    {
        var album = Dao.Album.GetLastAsync(x => x.AlbumId).Result;
        Assert.AreEqual(9, album.AlbumId);
    }

    [TestMethod]
    public void GetLast2Async()
    {
        var album = Dao.Album.GetLastAsync(x => x.Title.Contains("ne")).Result;
        Assert.AreEqual(2, album.AlbumId);
    }

    [TestMethod]
    public void GetLast3Async()
    {
        var album = Dao.Album.GetLastAsync(x => x.Title.Contains("ne"), x => x.AlbumId).Result;
        Assert.AreEqual(9, album.AlbumId);
    }

    [TestMethod]
    public void SelectFirstAsync()
    {
        var title = Dao.Album.SelectFirstAsync(x => x.Title).Result;
        Assert.AreEqual("Money", title);
    }

    [TestMethod]
    public void SelectFirst2Async()
    {
        var title = Dao.Album.SelectFirstAsync(x => x.Title.Contains("ne"), x => x.Title).Result;
        Assert.AreEqual("Money", title);
    }

    [TestMethod]
    public void SelectFirst3Async()
    {
        var title = Dao.Album.SelectFirstAsync(x => x.AlbumId, x => x.Title).Result;
        Assert.AreEqual("Money", title);
    }

    [TestMethod]
    public void SelectFirst4Async()
    {
        var title = Dao.Album.SelectFirstAsync(x => x.Title.Contains("ne"), x => x.AlbumId, x => x.Title).Result;
        Assert.AreEqual("Money", title);
    }

    [TestMethod]
    public void SelectLastAsync()
    {
        var title = Dao.Album.SelectLastAsync(x => x.AlbumId, x => x.Title).Result;
        Assert.AreEqual("Yellow Submarine", title);
    }

    [TestMethod]
    public void SelectLast2Async()
    {
        var title = Dao.Album.SelectLastAsync(x => x.Title.Contains("Rock"), x => x.Title).Result;
        Assert.AreEqual("The Wall", title);
    }

    [TestMethod]
    public void SelectLast3Async()
    {
        var title = Dao.Album.SelectLastAsync(x => x.Title.Contains("Rock"), x => x.AlbumId, x => x.Title).Result;
        Assert.IsNull(title);
    }
}