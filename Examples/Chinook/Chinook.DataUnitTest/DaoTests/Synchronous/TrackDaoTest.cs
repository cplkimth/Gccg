#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Synchronous;

public partial class TrackDaoTest
{
    [TestMethod]
    public void Get()
    {
        var tracks = Dao.Track.Get();
        Assert.AreEqual(4, tracks.Count);
    }

    [TestMethod]
    public void Get2()
    {
        var tracks = Dao.Track.Get(x => x.AlbumId == 3);
        Assert.AreEqual(4, tracks[0].TrackId);
        Assert.AreEqual(5, tracks[1].TrackId);
        Assert.AreEqual(2, tracks.Count);
    }

    [TestMethod]
    public void Get3()
    {
        var tracks = Dao.Track.Get(x => x.Name, true);
        Assert.AreEqual(6, tracks[0].TrackId);
    }

    [TestMethod]
    public void Get4()
    {
        var tracks = Dao.Track.Get(x => x.Name, false);
        Assert.AreEqual(5, tracks[0].TrackId);
    }

    [TestMethod]
    public void Get5()
    {
        var tracks = Dao.Track.Get(x => x.Name, false, 1, 2);
        Assert.AreEqual(7, tracks[0].TrackId);
        Assert.AreEqual(4, tracks[1].TrackId);
    }

    [TestMethod]
    public void Get6()
    {
        var tracks = Dao.Track.Get(x => x.AlbumId == 3, x => x.Name, true);
        Assert.AreEqual(4, tracks[0].TrackId);
        Assert.AreEqual(5, tracks[1].TrackId);
    }

    [TestMethod]
    public void Get7()
    {
        var tracks = Dao.Track.Get(x => x.AlbumId == 3, x => x.Name, false);
        Assert.AreEqual(5, tracks[0].TrackId);
        Assert.AreEqual(4, tracks[1].TrackId);
    }

    [TestMethod]
    public void Get8()
    {
        var tracks = Dao.Track.Get(x => x.AlbumId == 3, x => x.Name, true, 1, 1);
        Assert.AreEqual(5, tracks[0].TrackId);
        Assert.AreEqual(1, tracks.Count);
    }

    [TestMethod]
    public void Get9()
    {
        var tracks = Dao.Track.Get(x => x.AlbumId == 3, x => x.Name, false, 1, 1);
        Assert.AreEqual(4, tracks[0].TrackId);
        Assert.AreEqual(1, tracks.Count);
    }


    [TestMethod]
    public void Select()
    {
        var ids = Dao.Track.Select(x => x.TrackId);
        Assert.AreEqual(4, ids.Count);
    }

    [TestMethod]
    public void Select2()
    {
        var ids = Dao.Track.Select(x => x.AlbumId == 3, x => x.TrackId);
        Assert.AreEqual(4, ids[0]);
        Assert.AreEqual(5, ids[1]);
        Assert.AreEqual(2, ids.Count);
    }

    [TestMethod]
    public void Select3()
    {
        var ids = Dao.Track.Select(x => x.Name, true, x => x.TrackId);
        Assert.AreEqual(6, ids[0]);
    }

    [TestMethod]
    public void Select4()
    {
        var ids = Dao.Track.Select(x => x.Name, false, x => x.TrackId);
        Assert.AreEqual(5, ids[0]);
    }

    [TestMethod]
    public void Select5()
    {
        var ids = Dao.Track.Select(x => x.Name, false, 1, 2, x => x.TrackId);
        Assert.AreEqual(7, ids[0]);
        Assert.AreEqual(4, ids[1]);
    }

    [TestMethod]
    public void Select6()
    {
        var ids = Dao.Track.Select(x => x.AlbumId == 3, x => x.Name, true, x => x.TrackId);
        Assert.AreEqual(4, ids[0]);
        Assert.AreEqual(5, ids[1]);
    }

    [TestMethod]
    public void Select7()
    {
        var ids = Dao.Track.Select(x => x.AlbumId == 3, x => x.Name, false, x => x.TrackId);
        Assert.AreEqual(5, ids[0]);
        Assert.AreEqual(4, ids[1]);
    }

    [TestMethod]
    public void Select8()
    {
        var ids = Dao.Track.Select(x => x.AlbumId == 3, x => x.Name, true, 1, 1, x => x.TrackId);
        Assert.AreEqual(5, ids[0]);
        Assert.AreEqual(1, ids.Count);
    }

    [TestMethod]
    public void Select9()
    {
        var ids = Dao.Track.Select(x => x.AlbumId == 3, x => x.Name, false, 1, 1, x => x.TrackId);
        Assert.AreEqual(4, ids[0]);
        Assert.AreEqual(1, ids.Count);
    }

    #region GetAsArrayAsync
    [TestMethod]
    public void GetAsArray()
    {
        var tracks = Dao.Track.GetAsArray();
        Assert.AreEqual(4, tracks.Length);
    }

    [TestMethod]
    public void GetAsArray2()
    {
        var tracks = Dao.Track.GetAsArray(x => x.AlbumId == 3);
        Assert.AreEqual(4, tracks[0].TrackId);
        Assert.AreEqual(5, tracks[1].TrackId);
        Assert.AreEqual(2, tracks.Length);
    }

    [TestMethod]
    public void GetAsArray3()
    {
        var tracks = Dao.Track.GetAsArray(x => x.Name, true);
        Assert.AreEqual(6, tracks[0].TrackId);
    }

    [TestMethod]
    public void GetAsArray4()
    {
        var tracks = Dao.Track.GetAsArray(x => x.Name, false);
        Assert.AreEqual(5, tracks[0].TrackId);
    }

    [TestMethod]
    public void GetAsArray5()
    {
        var tracks = Dao.Track.GetAsArray(x => x.Name, false, 1, 2);
        Assert.AreEqual(7, tracks[0].TrackId);
        Assert.AreEqual(4, tracks[1].TrackId);
    }

    [TestMethod]
    public void GetAsArray6()
    {
        var tracks = Dao.Track.GetAsArray(x => x.AlbumId == 3, x => x.Name, true);
        Assert.AreEqual(4, tracks[0].TrackId);
        Assert.AreEqual(5, tracks[1].TrackId);
    }

    [TestMethod]
    public void GetAsArray7()
    {
        var tracks = Dao.Track.GetAsArray(x => x.AlbumId == 3, x => x.Name, false);
        Assert.AreEqual(5, tracks[0].TrackId);
        Assert.AreEqual(4, tracks[1].TrackId);
    }

    [TestMethod]
    public void GetAsArray8()
    {
        var tracks = Dao.Track.GetAsArray(x => x.AlbumId == 3, x => x.Name, true, 1, 1);
        Assert.AreEqual(5, tracks[0].TrackId);
        Assert.AreEqual(1, tracks.Length);
    }

    [TestMethod]
    public void GetAsArray9()
    {
        var tracks = Dao.Track.GetAsArray(x => x.AlbumId == 3, x => x.Name, false, 1, 1);
        Assert.AreEqual(4, tracks[0].TrackId);
        Assert.AreEqual(1, tracks.Length);
    }


    [TestMethod]
    public void SelectAsArray()
    {
        var ids = Dao.Track.SelectAsArray(x => x.TrackId);
        Assert.AreEqual(4, ids.Length);
    }

    [TestMethod]
    public void SelectAsArray2()
    {
        var ids = Dao.Track.SelectAsArray(x => x.AlbumId == 3, x => x.TrackId);
        Assert.AreEqual(4, ids[0]);
        Assert.AreEqual(5, ids[1]);
        Assert.AreEqual(2, ids.Length);
    }

    [TestMethod]
    public void SelectAsArray3()
    {
        var ids = Dao.Track.SelectAsArray(x => x.Name, true, x => x.TrackId);
        Assert.AreEqual(6, ids[0]);
    }

    [TestMethod]
    public void SelectAsArray4()
    {
        var ids = Dao.Track.SelectAsArray(x => x.Name, false, x => x.TrackId);
        Assert.AreEqual(5, ids[0]);
    }

    [TestMethod]
    public void SelectAsArray5()
    {
        var ids = Dao.Track.SelectAsArray(x => x.Name, false, 1, 2, x => x.TrackId);
        Assert.AreEqual(7, ids[0]);
        Assert.AreEqual(4, ids[1]);
    }

    [TestMethod]
    public void SelectAsArray6()
    {
        var ids = Dao.Track.SelectAsArray(x => x.AlbumId == 3, x => x.Name, true, x => x.TrackId);
        Assert.AreEqual(4, ids[0]);
        Assert.AreEqual(5, ids[1]);
    }

    [TestMethod]
    public void SelectAsArray7()
    {
        var ids = Dao.Track.SelectAsArray(x => x.AlbumId == 3, x => x.Name, false, x => x.TrackId);
        Assert.AreEqual(5, ids[0]);
        Assert.AreEqual(4, ids[1]);
    }

    [TestMethod]
    public void SelectAsArray8()
    {
        var ids = Dao.Track.SelectAsArray(x => x.AlbumId == 3, x => x.Name, true, 1, 1, x => x.TrackId);
        Assert.AreEqual(5, ids[0]);
        Assert.AreEqual(1, ids.Length);
    }

    [TestMethod]
    public void SelectAsArray9()
    {
        var ids = Dao.Track.SelectAsArray(x => x.AlbumId == 3, x => x.Name, false, 1, 1, x => x.TrackId);
        Assert.AreEqual(4, ids[0]);
        Assert.AreEqual(1, ids.Length);
    }
    #endregion

    #region AsHashSet
    [TestMethod]
    public void GetAsHashSet()
    {
        var tracks = Dao.Track.GetAsHashSet();
        Assert.AreEqual(4, tracks.Count);
    }

    [TestMethod]
    public void GetAsHashSet2()
    {
        var tracks = Dao.Track.GetAsHashSet(x => x.AlbumId == 3);
        Assert.AreEqual(2, tracks.Count);
        tracks.ShouldContain(x => x.TrackId == 4);
        tracks.ShouldContain(x => x.TrackId == 5);
    }

    [TestMethod]
    public void SelectAsHashSet()
    {
        var ids = Dao.Track.SelectAsHashSet(x => x.TrackId);
        Assert.AreEqual(4, ids.Count);
    }

    [TestMethod]
    public void SelectAsHashSet2()
    {
        var ids = Dao.Track.SelectAsHashSet(x => x.AlbumId == 3, x => x.TrackId);
        ids.ShouldContain(x => x == 4);
        ids.ShouldContain(x => x == 5);
        Assert.AreEqual(2, ids.Count);
    }
    #endregion

    #region AsDictionary0
    [TestMethod]
    public void GetAsDictionary0()
    {
        var tracks = Dao.Track.GetAsDictionary(x => x.TrackId);
        Assert.AreEqual(4, tracks.Count);
        tracks.ShouldContain(x => x.Key == 4 && x.Value.AlbumId == 3);
        tracks.ShouldContain(x => x.Key == 5 && x.Value.AlbumId == 3);
        tracks.ShouldContain(x => x.Key == 6 && x.Value.AlbumId == 4);
        tracks.ShouldContain(x => x.Key == 7 && x.Value.AlbumId == 4);
    }

    [TestMethod]
    public void GetAsDictionary3()
    {
        var tracks = Dao.Track.GetAsDictionary(keySelector:x => x.TrackId, where:x => x.AlbumId == 3);
        Assert.AreEqual(2, tracks.Count);
        tracks.ShouldContain(x => x.Key == 4 && x.Value.AlbumId == 3);
        tracks.ShouldContain(x => x.Key == 5 && x.Value.AlbumId == 3);
    }
    #endregion

    #region AsDictionary
    [TestMethod]
    public void GetAsDictionary1()
    {
        var tracks = Dao.Track.GetAsDictionary(x => x.TrackId, x => x.AlbumId);
        Assert.AreEqual(4, tracks.Count);
        tracks.ShouldContain(x => x.Key == 4 && x.Value == 3);
        tracks.ShouldContain(x => x.Key == 5 && x.Value == 3);
        tracks.ShouldContain(x => x.Key == 6 && x.Value == 4);
        tracks.ShouldContain(x => x.Key == 7 && x.Value == 4);
    }

    [TestMethod]
    public void GetAsDictionary4()
    {
        var tracks = Dao.Track.GetAsDictionary(x => x.AlbumId == 3, x => x.TrackId, x => x.AlbumId);
        Assert.AreEqual(2, tracks.Count);
        tracks.ShouldContain(x => x.Key == 4 && x.Value == 3);
        tracks.ShouldContain(x => x.Key == 5 && x.Value == 3);
    }
    #endregion

    #region FK
    [TestMethod]
    public void GetByArtistId()
    {
        var list = Dao.Track.GetByAlbumId(4);
        list.Count.ShouldBe(2);
        list.ShouldContain(x => x.TrackId == 6);
        list.ShouldContain(x => x.TrackId == 7);
    }

    [TestMethod]
    public void GetByArtistIdAsArray()
    {
        var list = Dao.Track.GetByAlbumIdAsArray(4);
        list.Length.ShouldBe(2);
        list.ShouldContain(x => x.TrackId == 6);
        list.ShouldContain(x => x.TrackId == 7);
    }

    [TestMethod]
    public void GetByArtistIdAsHastSet()
    {
        var list = Dao.Track.GetByAlbumIdAsHastSet(4);
        list.Count.ShouldBe(2);
        list.ShouldContain(x => x.TrackId == 6);
        list.ShouldContain(x => x.TrackId == 7);
    }

    [TestMethod]
    public void GetByArtistIdAsDictionary1()
    {
        var list = Dao.Track.GetByAlbumIdAsDictionary(4, x => x.TrackId);
        list.Count.ShouldBe(2);
        list.ShouldContain(x => x.Key == 6 && x.Value.AlbumId == 4);
        list.ShouldContain(x => x.Key == 7 && x.Value.AlbumId == 4);
    }

    [TestMethod]
    public void GetByArtistIdAsDictionary2()
    {
        var list = Dao.Track.GetByAlbumIdAsDictionary(4, x => x.TrackId, x => x.AlbumId);
        list.Count.ShouldBe(2);
        list.ShouldContain(x => x.Key == 6 && x.Value == 4);
        list.ShouldContain(x => x.Key == 7 && x.Value == 4);
    }
    #endregion
}