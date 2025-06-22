
#region using
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Asynchronous;


public partial class AlbumDaoTestAsync
{
    internal static void FillForInsert(Album entity)
    {
    }

    internal static object SetUpdateField(Album entity)
    {
        return entity.Title = DateTime.Now.Ticks.ToString();
    }

    internal static object GetUpdateField(Album entity)
    {
        return entity.Title;
    }

    [TestMethod]
    public void GetLast()
    {
        var entity = Dao.Album.GetLast(x => x.AlbumId );
        entity.ShouldNotBeNull();
    }
}