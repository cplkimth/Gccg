#region

using Chinook.Data;

#endregion

namespace Chinook.UnitTest;

public partial class AlbumDaoTest
{
    #region search

    [TestMethod]
    public void SearchWithArtistName()
    {
        var albums = Dao.Album.Search("Pink", null);

        Assert.AreEqual(2, albums.Count);
    }

    [TestMethod]
    public void SearchWithTrackName()
    {
        var albums = Dao.Album.Search(null, "Hey");

        Assert.AreEqual(1, albums.Count);
    }

    [TestMethod]
    public void SearchWithArtistNameAndTrackName()
    {
        var albums = Dao.Album.Search("Pink", "You");

        Assert.AreEqual(1, albums.Count);
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
}