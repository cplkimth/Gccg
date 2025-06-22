#region
using System.Linq.Expressions;
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Asynchronous;

public partial class AlbumDaoTestAsync
{
    [TestMethod]
    public async Task ExecuteUpdateScalar()
    {
        int albumId = 9;

        await Dao.Album.ExecuteUpdateAsync(x => x.AlbumId == albumId, x => x.SetProperty(p => p.TypeCode, p => p.TypeCode + 1));

        var entity = await Dao.Album.GetByKeyAsync(albumId);
        entity.TypeCode.ShouldBe(20001);
    }

    [TestMethod]
    public async Task ExecuteUpdateMany()
    {
        Expression<Func<Album, bool>> predicate = x => x.ArtistId == 1 && x.TypeCode != 20002;

        var count = await Dao.Album.ExecuteUpdateAsync(predicate, x => x.SetProperty(p => p.TypeCode, p => p.TypeCode + 1));
        count.ShouldBe(5);

        var list = await Dao.Album.GetAsync(predicate);
        foreach (var entity in list)
            entity.TypeCode.ShouldBe(20001);
    }

    [TestMethod]
    public async Task ExecuteDeleteMany()
    {
        Expression<Func<Album, bool>> predicate = x => x.ArtistId == 1 && x.TypeCode != 20002;

        int oldCount = await Dao.Album.GetCountAsync(predicate);
        oldCount.ShouldBe(5);
        var count = await Dao.Album.ExecuteDeleteAsync(predicate);
        count.ShouldBe(5);
        int newCount = await Dao.Album.GetCountAsync(predicate);
        newCount.ShouldBe(0);
    }

    [TestMethod]
    public async Task InsertMany()
    {
        var value = DateTime.Now.ToString();

        var list = new List<Album>
        {
            new()
                { Title = value, ArtistId = 1 },
            new()
                { Title = value, ArtistId = 1 }
        };

        var oldCount = await Dao.Album.GetCountAsync();
        var insertedCount = await Dao.Album.InsertManyAsync(list);
        var newCount = await Dao.Album.GetCountAsync();

        insertedCount.ShouldBe(2);
        newCount.ShouldBe(oldCount + 2);
    }

    [TestMethod]
    public async Task UpdateMany()
    {
        var list = await Dao.Album.GetAsync();
        foreach (var entity in list)
            entity.Title = entity.AlbumId.ToString();

        await Dao.Album.UpdateManyAsync(list);

        foreach (var entity in list)
            entity.Title.ShouldBe(entity.AlbumId.ToString());
    }

    [TestMethod]
    public async Task GetFirst2()
    {
        var entity = await Dao.Album.GetFirstAsync(x => x.Title.Contains("Yellow"));
        entity.AlbumId.ShouldBe(9);
    }

    [TestMethod]
    public async Task GetFirst3()
    {
        var entity = await Dao.Album.GetFirstAsync(x => x.Title);
        entity.AlbumId.ShouldBe(8);
    }

    [TestMethod]
    public async Task GetFirst4()
    {
        var entity = await Dao.Album.GetFirstAsync(x => x.Title.Contains("ne"), x => x.Title);
        entity.AlbumId.ShouldBe(2);
    }

    [TestMethod]
    public async Task GetLast4()
    {
        var entity = await Dao.Album.GetLastAsync(x => x.AlbumId);
        entity.AlbumId.ShouldBe(9);
    }

    [TestMethod]
    public async Task GetLast2()
    {
        var entity = await Dao.Album.GetLastAsync(x => x.Title.Contains("ne"));
        entity.AlbumId.ShouldBe(2);
    }

    [TestMethod]
    public async Task GetLast3()
    {
        var entity = await Dao.Album.GetLastAsync(x => x.Title.Contains("ne"), x => x.AlbumId);
        entity.AlbumId.ShouldBe(9);
    }

    [TestMethod]
    public async Task SelectFirst()
    {
        var value = await Dao.Album.SelectFirstAsync(x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public async Task SelectFirst2()
    {
        var value = await Dao.Album.SelectFirstAsync(x => x.Title.Contains("ne"), x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public async Task SelectFirst3()
    {
        var value = await Dao.Album.SelectFirstAsync(x => x.AlbumId, x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public async Task SelectFirst4()
    {
        var value = await Dao.Album.SelectFirstAsync(x => x.Title.Contains("ne"), x => x.AlbumId, x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public async Task SelectLast()
    {
        var value = await Dao.Album.SelectLastAsync(x => x.AlbumId, x => x.Title);
        value.ShouldBe("Yellow Submarine");
    }

    [TestMethod]
    public async Task SelectLast2()
    {
        var value = await Dao.Album.SelectLastAsync(x => x.Title.Contains("Money"), x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public async Task SelectLast3()
    {
        var value = await Dao.Album.SelectLastAsync(x => x.Title.Contains("Money"), x => x.AlbumId, x => x.Title);
        value.ShouldNotBeNull();
    }

    [TestMethod]
    public async Task GetT()
    {
        var count = await Dao.Get<Album>().GetCountAsync();
        count.ShouldBeGreaterThan(0);
    }

    [TestMethod]
    public async Task GetByArtistId()
    {
        var list = await Dao.Album.GetByArtistIdAsync(2);
        list.Count.ShouldBe(2);
    }

    #region search

    [TestMethod]
    public async Task SearchWithArtistName()
    {
        var albums = await Dao.Album.SearchAsync("Beatles", null);

        Assert.AreEqual(6, albums.Count);
    }

    [TestMethod]
    public async Task SearchWithTrackName()
    {
        var albums = await Dao.Album.SearchAsync(null, "You");

        Assert.AreEqual(1, albums.Count);
    }

    [TestMethod]
    public async Task SearchWithArtistNameAndTrackName()
    {
        var albums = await Dao.Album.SearchAsync("Beatles", "You");

        Assert.AreEqual(0, albums.Count);
    }

    #endregion

    #region procedures

    [TestMethod]
    public void Album_Search()
    {
        var procedures = new ChinookContextProcedures(DbContextFactory.Create());

        // var result = procedures.Album_SearchAsync(1, "For").Result;
        // Assert.AreEqual(1, result.Length);
        // Assert.AreEqual(1, result[0].AlbumId);
    }

    #endregion

    [TestMethod]
    public async Task InsertOrUpdate()
    {
        var value = DateTime.Now.ToString();

        var album = await Dao.Album.GetByKeyAsync(2);
        album.Title = value;
        await Dao.Album.InsertOrUpdateAsync(album);

        album = await Dao.Album.GetByKeyAsync(2);
        value.ShouldBe(album.Title);
    }

    [TestMethod]
    public async Task InsertOrUpdate2()
    {
        var value = DateTime.Now.ToString();

        var album = Dao.Album.Create();
        album.ArtistId = 1;
        album.Title = value;
        await Dao.Album.InsertOrUpdateAsync(album);

        (await Dao.Album.GetCountAsync()).ShouldBe(9);
    }

    [TestMethod]
    public async Task InsertIfNotExist()
    {
        var entity = Dao.Album.Create();
        entity.ArtistId = 1;
        entity.Title = DateTime.Now.ToString();
        await Dao.Album.InsertIfNotExistAsync(entity);

        (await Dao.Album.GetCountAsync()).ShouldBe(9);
    }

    [TestMethod]
    public async Task InsertIfNotExist2()
    {
        var entity = await Dao.Album.GetByKeyAsync(2);
        entity.ArtistId = 1;
        await Dao.Album.InsertIfNotExistAsync(entity);

        (await Dao.Album.GetCountAsync()).ShouldBe(8);
    }

    #region other collections
    [TestMethod]
    public async Task GetByArtistIdAsArray()
    {
        var list = await Dao.Album.GetByArtistIdAsArrayAsync(2);
        list.Length.ShouldBe(2);
    }

    [TestMethod]
    public async Task GetByArtistIdAsHastSet()
    {
        var list = await Dao.Album.GetByArtistIdAsHastSetAsync(2);
        list.Count.ShouldBe(2);
    }

    [TestMethod]
    public async Task GetByArtistIdAsDictionary1()
    {
        var list = await Dao.Album.GetByArtistIdAsDictionaryAsync(2, x => x.AlbumId);
        list[2].Title.ShouldBe("Money");
        list[3].Title.ShouldBe("The Wall");
    }

    [TestMethod]
    public async Task GetByArtistIdAsDictionary2()
    {
        var list = await Dao.Album.GetByArtistIdAsDictionaryAsync(2, x => x.AlbumId, x => x.Title);
        list[2].ShouldBe("Money");
        list[3].ShouldBe("The Wall");
    }
    #endregion
}