#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Asynchronous;

public partial class DateTableDaoTestAsync
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
    public async Task GetLast()
    {
        var entity = await Dao.DateTable.GetLastAsync(x => x.Date );
        entity.ShouldNotBeNull();
    }
}