﻿#region
using System.Linq.Expressions;
using Chinook.Data;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

public partial class AlbumDaoTest
{
    [TestMethod]
    public void ExecuteUpdateScalar()
    {
        int albumId = 9;

        Dao.Album.ExecuteUpdate(albumId, x => x
            .SetProperty(p => p.TypeCode, p => p.TypeCode + 1)
            .SetProperty(p => p.ArtistId, 2)
        );

        var entity = Dao.Album.GetByKey(albumId);
        entity.TypeCode.ShouldBe(20001);
        entity.ArtistId.ShouldBe(2);
    }

    [TestMethod]
    public async Task ExecuteUpdateScalarAsync()
    {
        int albumId = 9;

        await Dao.Album.ExecuteUpdateAsync(albumId, x => x.SetProperty(p => p.TypeCode, p => p.TypeCode + 1));

        var entity = await Dao.Album.GetByKeyAsync(albumId);
        entity.TypeCode.ShouldBe(20001);
    }

    [TestMethod]
    public void ExecuteUpdateMany()
    {
        Expression<Func<Album, bool>> predicate = x => x.ArtistId == 1 && x.TypeCode != 20002;

        var count = Dao.Album.ExecuteUpdate(predicate, x => x.SetProperty(p => p.TypeCode, p => p.TypeCode + 1));
        count.ShouldBe(5);

        var list = Dao.Album.Get(predicate);
        foreach (var entity in list)
            entity.TypeCode.ShouldBe(20001);
    }

    [TestMethod]
    public async Task ExecuteUpdateManyAsync()
    {
        Expression<Func<Album, bool>> predicate = x => x.ArtistId == 1 && x.TypeCode != 20002;

        var count = await Dao.Album.ExecuteUpdateAsync(predicate, x => x.SetProperty(p => p.TypeCode, p => p.TypeCode + 1));
        count.ShouldBe(5);

        var list = await Dao.Album.GetAsync(predicate);
        foreach (var entity in list)
            entity.TypeCode.ShouldBe(20001);
    }

    [TestMethod]
    public void ExecuteDeleteMany()
    {
        Expression<Func<Album, bool>> predicate = x => x.ArtistId == 1 && x.TypeCode != 20002;

        int oldCount = Dao.Album.GetCount(predicate);
        oldCount.ShouldBe(5);
        var count = Dao.Album.ExecuteDelete(predicate);
        count.ShouldBe(5);
        int newCount = Dao.Album.GetCount(predicate);
        newCount.ShouldBe(0);
    }

    [TestMethod]
    public async Task ExecuteDeleteManyAsync()
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
    public void InsertMany()
    {
        var value = DateTime.Now.ToString();

        var list = new List<Album>
        {
            new()
                { Title = value, ArtistId = 1 },
            new()
                { Title = value, ArtistId = 1 }
        };

        var oldCount = Dao.Album.GetCount();
        var insertedCount = Dao.Album.InsertMany(list);
        var newCount = Dao.Album.GetCount();

        insertedCount.ShouldBe(2);
        newCount.ShouldBe(oldCount + 2);
    }

    [TestMethod]
    public void UpdateMany()
    {
        var list = Dao.Album.Get();
        foreach (var entity in list)
            entity.Title = entity.AlbumId.ToString();

        Dao.Album.UpdateMany(list);

        foreach (var entity in list)
            entity.Title.ShouldBe(entity.AlbumId.ToString());
    }

    [TestMethod]
    public void GetFirst2()
    {
        var entity = Dao.Album.GetFirst(x => x.Title.Contains("Yellow"));
        entity.AlbumId.ShouldBe(9);
    }

    [TestMethod]
    public void GetFirst3()
    {
        var entity = Dao.Album.GetFirst(x => x.Title);
        entity.AlbumId.ShouldBe(8);
    }

    [TestMethod]
    public void GetFirst4()
    {
        var entity = Dao.Album.GetFirst(x => x.Title.Contains("ne"), x => x.Title);
        entity.AlbumId.ShouldBe(2);
    }

    [TestMethod]
    public void GetLast4()
    {
        var entity = Dao.Album.GetLast(x => x.AlbumId);
        entity.AlbumId.ShouldBe(9);
    }

    [TestMethod]
    public void GetLast2()
    {
        var entity = Dao.Album.GetLast(x => x.Title.Contains("ne"));
        entity.AlbumId.ShouldBe(2);
    }

    [TestMethod]
    public void GetLast3()
    {
        var entity = Dao.Album.GetLast(x => x.Title.Contains("ne"), x => x.AlbumId);
        entity.AlbumId.ShouldBe(9);
    }

    [TestMethod]
    public void SelectFirst()
    {
        var value = Dao.Album.SelectFirst(x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public void SelectFirst2()
    {
        var value = Dao.Album.SelectFirst(x => x.Title.Contains("ne"), x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public void SelectFirst3()
    {
        var value = Dao.Album.SelectFirst(x => x.AlbumId, x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public void SelectFirst4()
    {
        var value = Dao.Album.SelectFirst(x => x.Title.Contains("ne"), x => x.AlbumId, x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public void SelectLast()
    {
        var value = Dao.Album.SelectLast(x => x.AlbumId, x => x.Title);
        value.ShouldBe("Yellow Submarine");
    }

    [TestMethod]
    public void SelectLast2()
    {
        var value = Dao.Album.SelectLast(x => x.Title.Contains("Money"), x => x.Title);
        value.ShouldBe("Money");
    }

    [TestMethod]
    public void SelectLast3()
    {
        var value = Dao.Album.SelectLast(x => x.Title.Contains("Money"), x => x.AlbumId, x => x.Title);
        value.ShouldNotBeNull();
    }

    [TestMethod]
    public void GetT()
    {
        var count = Dao.Get<Album>().GetCount();
        count.ShouldBeGreaterThan(0);
    }

    [TestMethod]
    public void GetByArtistId()
    {
        var list = Dao.Album.GetByArtistId(2);
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
    public void InsertOrUpdate()
    {
        var value = DateTime.Now.ToString();

        var album = Dao.Album.GetByKey(2);
        album.Title = value;
        Dao.Album.InsertOrUpdate(album);

        album = Dao.Album.GetByKey(2);
        value.ShouldBe(album.Title);
    }

    [TestMethod]
    public void InsertOrUpdate2()
    {
        var value = DateTime.Now.ToString();

        var album = Dao.Album.Create();
        album.ArtistId = 1;
        album.Title = value;
        Dao.Album.InsertOrUpdate(album);

        Dao.Album.GetCount().ShouldBe(9);
    }

    [TestMethod]
    public void InsertIfNotExist()
    {
        var entity = Dao.Album.Create();
        entity.ArtistId = 1;
        entity.Title = DateTime.Now.ToString();
        Dao.Album.InsertIfNotExist(entity);

        Assert.AreEqual(9, Dao.Album.GetCount());
    }

    [TestMethod]
    public void InsertIfNotExist2()
    {
        var entity = Dao.Album.GetByKey(2);
        entity.ArtistId = 1;
        Dao.Album.InsertIfNotExist(entity);

        Assert.AreEqual(8, Dao.Album.GetCount());
    }

    #region async

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
        await Dao.Album.InsertAsync(album);

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

        Dao.Album.UpdateAsync(albums).Wait();

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

    #endregion
}