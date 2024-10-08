#region

using Chinook.Data;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

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
}