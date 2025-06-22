#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Asynchronous;

public partial class TrackDaoTestAsync
{
    [TestMethod]
    public async Task Get()
    {
        var tracks = await Dao.Track.GetAsync();
        Assert.AreEqual(4, tracks.Count);
    }

    [TestMethod]
    public async Task Get2()
    {
        var tracks = await Dao.Track.GetAsync(x => x.AlbumId == 3);
        Assert.AreEqual(4, tracks[0].TrackId);
        Assert.AreEqual(5, tracks[1].TrackId);
        Assert.AreEqual(2, tracks.Count);
    }

    [TestMethod]
    public async Task Get3()
    {
        var tracks = await Dao.Track.GetAsync(x => x.Name, true);
        Assert.AreEqual(6, tracks[0].TrackId);
    }

    [TestMethod]
    public async Task Get4()
    {
        var tracks = await Dao.Track.GetAsync(x => x.Name, false);
        Assert.AreEqual(5, tracks[0].TrackId);
    }

    [TestMethod]
    public async Task Get5()
    {
        var tracks = await Dao.Track.GetAsync(x => x.Name, false, 1, 2);
        Assert.AreEqual(7, tracks[0].TrackId);
        Assert.AreEqual(4, tracks[1].TrackId);
    }

    [TestMethod]
    public async Task Get6()
    {
        var tracks = await Dao.Track.GetAsync(x => x.AlbumId == 3, x => x.Name, true);
        Assert.AreEqual(4, tracks[0].TrackId);
        Assert.AreEqual(5, tracks[1].TrackId);
    }

    [TestMethod]
    public async Task Get7()
    {
        var tracks = await Dao.Track.GetAsync(x => x.AlbumId == 3, x => x.Name, false);
        Assert.AreEqual(5, tracks[0].TrackId);
        Assert.AreEqual(4, tracks[1].TrackId);
    }

    [TestMethod]
    public async Task Get8()
    {
        var tracks = await Dao.Track.GetAsync(x => x.AlbumId == 3, x => x.Name, true, 1, 1);
        Assert.AreEqual(5, tracks[0].TrackId);
        Assert.AreEqual(1, tracks.Count);
    }

    [TestMethod]
    public async Task Get9()
    {
        var tracks = await Dao.Track.GetAsync(x => x.AlbumId == 3, x => x.Name, false, 1, 1);
        Assert.AreEqual(4, tracks[0].TrackId);
        Assert.AreEqual(1, tracks.Count);
    }


    [TestMethod]
    public async Task Select()
    {
        var ids = await Dao.Track.SelectAsync(x => x.TrackId);
        Assert.AreEqual(4, ids.Count);
    }

    [TestMethod]
    public async Task Select2()
    {
        var ids = await Dao.Track.SelectAsync(x => x.AlbumId == 3, x => x.TrackId);
        Assert.AreEqual(4, ids[0]);
        Assert.AreEqual(5, ids[1]);
        Assert.AreEqual(2, ids.Count);
    }

    [TestMethod]
    public async Task Select3()
    {
        var ids = await Dao.Track.SelectAsync(x => x.Name, true, x => x.TrackId);
        Assert.AreEqual(6, ids[0]);
    }

    [TestMethod]
    public async Task Select4()
    {
        var ids = await Dao.Track.SelectAsync(x => x.Name, false, x => x.TrackId);
        Assert.AreEqual(5, ids[0]);
    }

    [TestMethod]
    public async Task Select5()
    {
        var ids = await Dao.Track.SelectAsync(x => x.Name, false, 1, 2, x => x.TrackId);
        Assert.AreEqual(7, ids[0]);
        Assert.AreEqual(4, ids[1]);
    }

    [TestMethod]
    public async Task Select6()
    {
        var ids = await Dao.Track.SelectAsync(x => x.AlbumId == 3, x => x.Name, true, x => x.TrackId);
        Assert.AreEqual(4, ids[0]);
        Assert.AreEqual(5, ids[1]);
    }

    [TestMethod]
    public async Task Select7()
    {
        var ids = await Dao.Track.SelectAsync(x => x.AlbumId == 3, x => x.Name, false, x => x.TrackId);
        Assert.AreEqual(5, ids[0]);
        Assert.AreEqual(4, ids[1]);
    }

    [TestMethod]
    public async Task Select8()
    {
        var ids = await Dao.Track.SelectAsync(x => x.AlbumId == 3, x => x.Name, true, 1, 1, x => x.TrackId);
        Assert.AreEqual(5, ids[0]);
        Assert.AreEqual(1, ids.Count);
    }

    [TestMethod]
    public async Task Select9()
    {
        var ids = await Dao.Track.SelectAsync(x => x.AlbumId == 3, x => x.Name, false, 1, 1, x => x.TrackId);
        Assert.AreEqual(4, ids[0]);
        Assert.AreEqual(1, ids.Count);
    }

    #region GetAsArrayAsync
    [TestMethod]
    public async Task GetAsArray()
    {
        var tracks = await Dao.Track.GetAsArrayAsync();
        Assert.AreEqual(4, tracks.Length);
    }

    [TestMethod]
    public async Task GetAsArray2()
    {
        var tracks = await Dao.Track.GetAsArrayAsync(x => x.AlbumId == 3);
        Assert.AreEqual(4, tracks[0].TrackId);
        Assert.AreEqual(5, tracks[1].TrackId);
        Assert.AreEqual(2, tracks.Length);
    }

    [TestMethod]
    public async Task GetAsArray3()
    {
        var tracks = await Dao.Track.GetAsArrayAsync(x => x.Name, true);
        Assert.AreEqual(6, tracks[0].TrackId);
    }

    [TestMethod]
    public async Task GetAsArray4()
    {
        var tracks = await Dao.Track.GetAsArrayAsync(x => x.Name, false);
        Assert.AreEqual(5, tracks[0].TrackId);
    }

    [TestMethod]
    public async Task GetAsArray5()
    {
        var tracks = await Dao.Track.GetAsArrayAsync(x => x.Name, false, 1, 2);
        Assert.AreEqual(7, tracks[0].TrackId);
        Assert.AreEqual(4, tracks[1].TrackId);
    }

    [TestMethod]
    public async Task GetAsArray6()
    {
        var tracks = await Dao.Track.GetAsArrayAsync(x => x.AlbumId == 3, x => x.Name, true);
        Assert.AreEqual(4, tracks[0].TrackId);
        Assert.AreEqual(5, tracks[1].TrackId);
    }

    [TestMethod]
    public async Task GetAsArray7()
    {
        var tracks = await Dao.Track.GetAsArrayAsync(x => x.AlbumId == 3, x => x.Name, false);
        Assert.AreEqual(5, tracks[0].TrackId);
        Assert.AreEqual(4, tracks[1].TrackId);
    }

    [TestMethod]
    public async Task GetAsArray8()
    {
        var tracks = await Dao.Track.GetAsArrayAsync(x => x.AlbumId == 3, x => x.Name, true, 1, 1);
        Assert.AreEqual(5, tracks[0].TrackId);
        Assert.AreEqual(1, tracks.Length);
    }

    [TestMethod]
    public async Task GetAsArray9()
    {
        var tracks = await Dao.Track.GetAsArrayAsync(x => x.AlbumId == 3, x => x.Name, false, 1, 1);
        Assert.AreEqual(4, tracks[0].TrackId);
        Assert.AreEqual(1, tracks.Length);
    }


    [TestMethod]
    public async Task SelectAsArray()
    {
        var ids = await Dao.Track.SelectAsArrayAsync(x => x.TrackId);
        Assert.AreEqual(4, ids.Length);
    }

    [TestMethod]
    public async Task SelectAsArray2()
    {
        var ids = await Dao.Track.SelectAsArrayAsync(x => x.AlbumId == 3, x => x.TrackId);
        Assert.AreEqual(4, ids[0]);
        Assert.AreEqual(5, ids[1]);
        Assert.AreEqual(2, ids.Length);
    }

    [TestMethod]
    public async Task SelectAsArray3()
    {
        var ids = await Dao.Track.SelectAsArrayAsync(x => x.Name, true, x => x.TrackId);
        Assert.AreEqual(6, ids[0]);
    }

    [TestMethod]
    public async Task SelectAsArray4()
    {
        var ids = await Dao.Track.SelectAsArrayAsync(x => x.Name, false, x => x.TrackId);
        Assert.AreEqual(5, ids[0]);
    }

    [TestMethod]
    public async Task SelectAsArray5()
    {
        var ids = await Dao.Track.SelectAsArrayAsync(x => x.Name, false, 1, 2, x => x.TrackId);
        Assert.AreEqual(7, ids[0]);
        Assert.AreEqual(4, ids[1]);
    }

    [TestMethod]
    public async Task SelectAsArray6()
    {
        var ids = await Dao.Track.SelectAsArrayAsync(x => x.AlbumId == 3, x => x.Name, true, x => x.TrackId);
        Assert.AreEqual(4, ids[0]);
        Assert.AreEqual(5, ids[1]);
    }

    [TestMethod]
    public async Task SelectAsArray7()
    {
        var ids = await Dao.Track.SelectAsArrayAsync(x => x.AlbumId == 3, x => x.Name, false, x => x.TrackId);
        Assert.AreEqual(5, ids[0]);
        Assert.AreEqual(4, ids[1]);
    }

    [TestMethod]
    public async Task SelectAsArray8()
    {
        var ids = await Dao.Track.SelectAsArrayAsync(x => x.AlbumId == 3, x => x.Name, true, 1, 1, x => x.TrackId);
        Assert.AreEqual(5, ids[0]);
        Assert.AreEqual(1, ids.Length);
    }

    [TestMethod]
    public async Task SelectAsArray9()
    {
        var ids = await Dao.Track.SelectAsArrayAsync(x => x.AlbumId == 3, x => x.Name, false, 1, 1, x => x.TrackId);
        Assert.AreEqual(4, ids[0]);
        Assert.AreEqual(1, ids.Length);
    }
    #endregion

    #region AsHashSet
    [TestMethod]
    public async Task GetAsHashSet()
    {
        var tracks = await Dao.Track.GetAsHashSetAsync();
        Assert.AreEqual(4, tracks.Count);
    }

    [TestMethod]
    public async Task GetAsHashSet2()
    {
        var tracks = await Dao.Track.GetAsHashSetAsync(x => x.AlbumId == 3);
        Assert.AreEqual(2, tracks.Count);
        tracks.ShouldContain(x => x.TrackId == 4);
        tracks.ShouldContain(x => x.TrackId == 5);
    }

    [TestMethod]
    public async Task SelectAsHashSet()
    {
        var ids = await Dao.Track.SelectAsHashSetAsync(x => x.TrackId);
        Assert.AreEqual(4, ids.Count);
    }

    [TestMethod]
    public async Task SelectAsHashSet2()
    {
        var ids = await Dao.Track.SelectAsHashSetAsync(x => x.AlbumId == 3, x => x.TrackId);
        ids.ShouldContain(x => x == 4);
        ids.ShouldContain(x => x == 5);
        Assert.AreEqual(2, ids.Count);
    }
    #endregion

    #region AsDictionary0
    [TestMethod]
    public async Task GetAsDictionary0()
    {
        var tracks = await Dao.Track.GetAsDictionaryAsync(x => x.TrackId);
        Assert.AreEqual(4, tracks.Count);
        tracks.ShouldContain(x => x.Key == 4 && x.Value.AlbumId == 3);
        tracks.ShouldContain(x => x.Key == 5 && x.Value.AlbumId == 3);
        tracks.ShouldContain(x => x.Key == 6 && x.Value.AlbumId == 4);
        tracks.ShouldContain(x => x.Key == 7 && x.Value.AlbumId == 4);
    }

    [TestMethod]
    public async Task GetAsDictionary3()
    {
        var tracks = await Dao.Track.GetAsDictionaryAsync(keySelector:x => x.TrackId, where:x => x.AlbumId == 3);
        Assert.AreEqual(2, tracks.Count);
        tracks.ShouldContain(x => x.Key == 4 && x.Value.AlbumId == 3);
        tracks.ShouldContain(x => x.Key == 5 && x.Value.AlbumId == 3);
    }
    #endregion

    #region AsDictionary
    [TestMethod]
    public async Task GetAsDictionary1()
    {
        var tracks = await Dao.Track.GetAsDictionaryAsync(x => x.TrackId, x => x.AlbumId);
        Assert.AreEqual(4, tracks.Count);
        tracks.ShouldContain(x => x.Key == 4 && x.Value == 3);
        tracks.ShouldContain(x => x.Key == 5 && x.Value == 3);
        tracks.ShouldContain(x => x.Key == 6 && x.Value == 4);
        tracks.ShouldContain(x => x.Key == 7 && x.Value == 4);
    }

    [TestMethod]
    public async Task GetAsDictionary4()
    {
        var tracks = await Dao.Track.GetAsDictionaryAsync(x => x.AlbumId == 3, x => x.TrackId, x => x.AlbumId);
        Assert.AreEqual(2, tracks.Count);
        tracks.ShouldContain(x => x.Key == 4 && x.Value == 3);
        tracks.ShouldContain(x => x.Key == 5 && x.Value == 3);
    }
    #endregion

    #region FK
    [TestMethod]
    public async Task GetByArtistId()
    {
        var list = await Dao.Track.GetByAlbumIdAsync(4);
        list.Count.ShouldBe(2);
        list.ShouldContain(x => x.TrackId == 6);
        list.ShouldContain(x => x.TrackId == 7);
    }

    [TestMethod]
    public async Task GetByArtistIdAsArray()
    {
        var list = await Dao.Track.GetByAlbumIdAsArrayAsync(4);
        list.Length.ShouldBe(2);
        list.ShouldContain(x => x.TrackId == 6);
        list.ShouldContain(x => x.TrackId == 7);
    }

    [TestMethod]
    public async Task GetByArtistIdAsHastSet()
    {
        var list = await Dao.Track.GetByAlbumIdAsHastSetAsync(4);
        list.Count.ShouldBe(2);
        list.ShouldContain(x => x.TrackId == 6);
        list.ShouldContain(x => x.TrackId == 7);
    }

    [TestMethod]
    public async Task GetByArtistIdAsDictionary1()
    {
        var list = await Dao.Track.GetByAlbumIdAsDictionaryAsync(4, x => x.TrackId);
        list.Count.ShouldBe(2);
        list.ShouldContain(x => x.Key == 6 && x.Value.AlbumId == 4);
        list.ShouldContain(x => x.Key == 7 && x.Value.AlbumId == 4);
    }

    [TestMethod]
    public async Task GetByArtistIdAsDictionary2()
    {
        var list = await Dao.Track.GetByAlbumIdAsDictionaryAsync(4, x => x.TrackId, x => x.AlbumId);
        list.Count.ShouldBe(2);
        list.ShouldContain(x => x.Key == 6 && x.Value == 4);
        list.ShouldContain(x => x.Key == 7 && x.Value == 4);
    }
    #endregion
}