#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Asynchronous;

public partial class TimeTableDaoTestAsync
{
    internal static void FillForInsert(TimeTable entity)
    {
    }

    internal static object SetUpdateField(TimeTable entity)
    {
        return entity.TimeNull = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
    }

    internal static object GetUpdateField(TimeTable entity)
    {
        return entity.TimeNull;
    }

    [TestMethod]
    public async Task GetLast()
    {
        var entity = await Dao.TimeTable.GetLastAsync(x => x.Time );
        entity.ShouldNotBeNull();
    }
}