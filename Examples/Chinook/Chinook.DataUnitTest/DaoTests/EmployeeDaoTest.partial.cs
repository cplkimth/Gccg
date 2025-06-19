#region

using Chinook.Data;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

public partial class EmployeeDaoTest
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
        var entity = await Dao.Employee.GetLast(x => x.EmployeeId );
        entity.ShouldNotBeNull();
    }

    internal override async Task<Employee> GetForDelete()
    {
        return await Dao.Employee.GetByKey(6);
    }
}