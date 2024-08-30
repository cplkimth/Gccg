#region

using Chinook.Data;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

public partial class DateTableDaoTest
{
    internal static void FillForInsert(DateTable entity)
    {
    }

    internal static object SetUpdateField(DateTable entity)
    {
        return entity.DateNull = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
    }

    internal static object GetUpdateField(DateTable entity)
    {
        return entity.DateNull;
    }

    [TestMethod]
    public void GetLast()
    {
        var entity = Dao.DateTable.GetLast(x => x.Date );
        entity.Should().NotBeNull();
    }
}