#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Asynchronous;

public partial class PlaylistDaoTestAsync
{
    internal static void FillForInsert(Playlist entity)
    {
    }

    internal static object SetUpdateField(Playlist entity)
    {
        return entity.Name = DateTime.Now.Ticks.ToString();
    }

    internal static object GetUpdateField(Playlist entity)
    {
        return entity.Name;
    }

    [TestMethod]
    public async Task GetLast()
    {
        var entity = await Dao.Playlist.GetLastAsync(x => x.PlaylistId );
        entity.ShouldNotBeNull();
    }
}