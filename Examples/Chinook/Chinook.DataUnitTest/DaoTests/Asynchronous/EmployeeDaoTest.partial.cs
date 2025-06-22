#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Asynchronous;

public partial class EmployeeDaoTestAsync
{
    internal static void FillForInsert(Employee entity)
    {
    }

    internal static object SetUpdateField(Employee entity)
    {
        return entity.FirstName = DateTime.Now.Ticks.ToString();
    }

    internal static object GetUpdateField(Employee entity)
    {
        return entity.FirstName;
    }

    [TestMethod]
    public async Task GetLast()
    {
        var entity = await Dao.Employee.GetLastAsync(x => x.EmployeeId );
        entity.ShouldNotBeNull();
    }

    internal override async Task<Employee> GetForDeleteAsync()
    {
        return await Dao.Employee.GetByKeyAsync(6);
    }
}