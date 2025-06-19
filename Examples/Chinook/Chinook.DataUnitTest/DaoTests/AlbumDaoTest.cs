#region
using Chinook.Data;
using Shouldly;
using System.Linq.Expressions;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

public partial class AlbumDaoTest
{
    [TestMethod]
    public async Task ExecuteUpdateScalar()
    {
        int albumId = 9;

        await Dao.Album.ExecuteUpdate(x => x.AlbumId == albumId, x => x.SetProperty(p => p.TypeCode, p => p.TypeCode + 1));

        var entity = await Dao.Album.GetByKey(albumId);
        entity.TypeCode.ShouldBe(20001);
    }

    [TestMethod]
    public async Task ExecuteUpdateMany()
    {
        Expression<Func<Album, bool>> predicate = x => x.ArtistId == 1 && x.TypeCode != 20002;

        var count = await Dao.Album.ExecuteUpdate(predicate, x => x.SetProperty(p => p.TypeCode, p => p.TypeCode + 1));
        count.ShouldBe(5);

        var list = await Dao.Album.Get(predicate);
        foreach (var entity in list)
            entity.TypeCode.ShouldBe(20001);
    }

    [TestMethod]
    public async Task ExecuteDeleteMany()
    {
        Expression<Func<Album, bool>> predicate = x => x.ArtistId == 1 && x.TypeCode != 20002;

        int oldCount = await Dao.Album.GetCount(predicate);
        oldCount.ShouldBe(5);
        var count = await Dao.Album.ExecuteDelete(predicate);
        count.ShouldBe(5);
        int newCount = await Dao.Album.GetCount(predicate);
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

        var oldCount = await Dao.Album.GetCount();
        var insertedCount = await Dao.Album.InsertMany(list);
        var newCount = await Dao.Album.GetCount();

        insertedCount.ShouldBe(2);
        newCount.ShouldBe(oldCount + 2);
    }

    [TestMethod]
    public async Task UpdateMany()
    {
        var list = await Dao.Album.Get();
        foreach (var entity in list)
            entity.Title = entity.AlbumId.ToString();

        await Dao.Album.UpdateMany(list);

        foreach (var entity in list)
            entity.Title.ShouldBe(entity.AlbumId.ToString());
    }

    [TestMethod]
    public async Task GetFirst2()
    {
        var entity = await Dao.Album.GetFirst(x => x.Title.Contains("Yellow"));
        entity.AlbumId.ShouldBe(9);
    }

    [TestMethod]
    public async Task GetFirst3()
    {
        var entity = await Dao.Album.GetFirst(x => x.Title);
        entity.AlbumId.ShouldBe(8);
    }

    [TestMethod]
    public async Task GetFirst4()
    {
        var entity = await Dao.Album.GetFirst(x => x.Title.Contains("ne"), x => x.Title);
        entity.AlbumId.ShouldBe(2);
    }

    [TestMethod]
    public async Task GetLast4()
    {
        var entity = await Dao.Album.GetLast(x => x.AlbumId);
        entity.AlbumId.ShouldBe(9);
    }

    [TestMethod]
    public async Task GetLast2()
    {
        var entity = await Dao.Album.GetLast(x => x.Title.Contains("ne"));
        entity.AlbumId.ShouldBe(2);
    }

    [TestMethod]
    public async Task GetLast3()
    {
        var entity = await Dao.Album.GetLast(x => x.Title.Contains("ne"), x => x.AlbumId);
        entity.AlbumId.ShouldBe(9);
    }

    [TestMethod]
    public async Task SelectFirst()
    {
        var value = await Dao.Album.SelectFirst(x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public async Task SelectFirst2()
    {
        var value = await Dao.Album.SelectFirst(x => x.Title.Contains("ne"), x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public async Task SelectFirst3()
    {
        var value = await Dao.Album.SelectFirst(x => x.AlbumId, x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public async Task SelectFirst4()
    {
        var value = await Dao.Album.SelectFirst(x => x.Title.Contains("ne"), x => x.AlbumId, x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public async Task SelectLast()
    {
        var value = await Dao.Album.SelectLast(x => x.AlbumId, x => x.Title);
        value.ShouldBe("Yellow Submarine");
    }

    [TestMethod]
    public async Task SelectLast2()
    {
        var value = await Dao.Album.SelectLast(x => x.Title.Contains("Money"), x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public async Task SelectLast3()
    {
        var value = await Dao.Album.SelectLast(x => x.Title.Contains("Money"), x => x.AlbumId, x => x.Title);
        value.ShouldNotBeNull();
    }

    [TestMethod]
    public async Task GetT()
    {
        var count = await Dao.Get<Album>().GetCount();
        count.ShouldBeGreaterThan(0);
    }

    [TestMethod]
    public async Task GetByArtistId()
    {
        var list = await Dao.Album.GetByArtistId(2);
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

        var album = await Dao.Album.GetByKey(2);
        album.Title = value;
        await Dao.Album.InsertOrUpdate(album);

        album = await Dao.Album.GetByKey(2);
        value.ShouldBe(album.Title);
    }

    [TestMethod]
    public async Task InsertOrUpdate2()
    {
        var value = DateTime.Now.ToString();

        var album = Dao.Album.Create();
        album.ArtistId = 1;
        album.Title = value;
        await Dao.Album.InsertOrUpdate(album);

        (await Dao.Album.GetCount()).ShouldBe(9);
    }

    [TestMethod]
    public async Task InsertIfNotExist()
    {
        var entity = Dao.Album.Create();
        entity.ArtistId = 1;
        entity.Title = DateTime.Now.ToString();
        await Dao.Album.InsertIfNotExist(entity);

        (await Dao.Album.GetCount()).ShouldBe(9);
    }

    [TestMethod]
    public async Task InsertIfNotExist2()
    {
        var entity = await Dao.Album.GetByKey(2);
        entity.ArtistId = 1;
        await Dao.Album.InsertIfNotExist(entity);

        (await Dao.Album.GetCount()).ShouldBe(8);
    }

    #region other collections
    [TestMethod]
    public async Task GetByArtistIdAsArray()
    {
        var list = await Dao.Album.GetByArtistIdAsArray(2);
        list.Length.ShouldBe(2);
    }

    [TestMethod]
    public async Task GetByArtistIdAsHastSet()
    {
        var list = await Dao.Album.GetByArtistIdAsHastSet(2);
        list.Count.ShouldBe(2);
    }

    [TestMethod]
    public async Task GetByArtistIdAsDictionary1()
    {
        var list = await Dao.Album.GetByArtistIdAsDictionary(2, x => x.AlbumId);
        list[2].Title.ShouldBe("Money");
        list[3].Title.ShouldBe("The Wall");
    }

    [TestMethod]
    public async Task GetByArtistIdAsDictionary2()
    {
        var list = await Dao.Album.GetByArtistIdAsDictionary(2, x => x.AlbumId, x => x.Title);
        list[2].ShouldBe("Money");
        list[3].ShouldBe("The Wall");
    }
    #endregion
}