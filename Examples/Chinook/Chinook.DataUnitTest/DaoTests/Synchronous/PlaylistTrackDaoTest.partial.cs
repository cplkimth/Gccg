#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Synchronous;

public partial class PlaylistTrackDaoTest
{
    internal static void FillForInsert(PlaylistTrack entity)
    {
        entity.PlaylistId = 1;
        entity.TrackId = 6;
    }

    internal static object SetUpdateField(PlaylistTrack entity) 
        => null;

    internal static object GetUpdateField(PlaylistTrack entity)
    {
        throw new NotImplementedException("PlaylistTrackDaoTest.GetUpdateField");
    }
}