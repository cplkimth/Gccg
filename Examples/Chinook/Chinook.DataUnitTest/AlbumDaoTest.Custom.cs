using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chinook.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.UnitTest
{
    public partial class AlbumDaoTest
    {
        #region search
        [TestMethod]
        public void SearchWithArtistName()
        {
            var albums = Dao.Album.Search("Beatles", null);

            Assert.AreEqual(6, albums.Count);
        }

        [TestMethod]
        public void SearchWithTrackName()
        {
            var albums = Dao.Album.Search(null, "You");

            Assert.AreEqual(1, albums.Count);
        }

        [TestMethod]
        public void SearchWithArtistNameAndTrackName()
        {
            var albums = Dao.Album.Search("Beatles", "You");

            Assert.AreEqual(0, albums.Count);
        }
        #endregion

        #region procedures
        [TestMethod]
        public void Album_Search()
        {
            ChinookContextProcedures procedures = new ChinookContextProcedures(DbContextFactory.Create());

            // var result = procedures.Album_SearchAsync(1, "For").Result;
            // Assert.AreEqual(1, result.Length);
            // Assert.AreEqual(1, result[0].AlbumId);
        }
        #endregion
    }
}