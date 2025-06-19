#region

using Chinook.Data;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

public partial class PlaylistDaoTest
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
        var entity = await Dao.Playlist.GetLast(x => x.PlaylistId );
        entity.ShouldNotBeNull();
    }
}