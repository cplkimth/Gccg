#region
using System.Linq.Expressions;
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Synchronous;

public partial class AlbumDaoTest
{
    [TestMethod]
    public void ExecuteUpdateScalar()
    {
        int albumId = 9;

        Dao.Album.ExecuteUpdate(x => x.AlbumId == albumId, x => x.SetProperty(p => p.TypeCode, p => p.TypeCode + 1));

        var entity = Dao.Album.GetByKey(albumId);
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

    #region procedures

    [TestMethod]
    public void Album_Search()
    {
        var procedures = new ChinookContextProcedures(DbContextFactory.Create());

        // var result = procedures.Album_Search(1, "For").Result;
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

        (Dao.Album.GetCount()).ShouldBe(9);
    }

    [TestMethod]
    public void InsertIfNotExist()
    {
        var entity = Dao.Album.Create();
        entity.ArtistId = 1;
        entity.Title = DateTime.Now.ToString();
        Dao.Album.InsertIfNotExist(entity);

        (Dao.Album.GetCount()).ShouldBe(9);
    }

    [TestMethod]
    public void InsertIfNotExist2()
    {
        var entity = Dao.Album.GetByKey(2);
        entity.ArtistId = 1;
        Dao.Album.InsertIfNotExist(entity);

        (Dao.Album.GetCount()).ShouldBe(8);
    }

    #region other collections
    [TestMethod]
    public void GetByArtistIdAsArray()
    {
        var list = Dao.Album.GetByArtistIdAsArray(2);
        list.Length.ShouldBe(2);
    }

    [TestMethod]
    public void GetByArtistIdAsHastSet()
    {
        var list = Dao.Album.GetByArtistIdAsHastSet(2);
        list.Count.ShouldBe(2);
    }

    [TestMethod]
    public void GetByArtistIdAsDictionary1()
    {
        var list = Dao.Album.GetByArtistIdAsDictionary(2, x => x.AlbumId);
        list[2].Title.ShouldBe("Money");
        list[3].Title.ShouldBe("The Wall");
    }

    [TestMethod]
    public void GetByArtistIdAsDictionary2()
    {
        var list = Dao.Album.GetByArtistIdAsDictionary(2, x => x.AlbumId, x => x.Title);
        list[2].ShouldBe("Money");
        list[3].ShouldBe("The Wall");
    }
    #endregion
}