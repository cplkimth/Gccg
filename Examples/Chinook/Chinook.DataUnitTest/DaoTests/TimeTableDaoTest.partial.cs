#region

using Chinook.Data;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

public partial class TimeTableDaoTest
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
    public void GetLast()
    {
        var entity = Dao.TimeTable.GetLast(x => x.Time );
        entity.ShouldNotBeNull();
    }
}