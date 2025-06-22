#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Asynchronous;

public partial class PlaylistTrackHistoryDaoTestAsync
{
    internal static void FillForInsert(PlaylistTrackHistory entity)
    {
        entity.PlaylistId = 1;
        entity.TrackId = 4;
        entity.WrittenAt = DateTime.Now;
    }

    internal static object SetUpdateField(PlaylistTrackHistory entity)
    {
        return entity.Memo = DateTime.Now.Ticks.ToString();
    }

    internal static object GetUpdateField(PlaylistTrackHistory entity)
    {
        return entity.Memo;
    }
}