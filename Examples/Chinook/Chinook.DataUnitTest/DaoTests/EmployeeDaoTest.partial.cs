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
    public void GetLast()
    {
        var entity = Dao.Employee.GetLast(x => x.EmployeeId );
        entity.Should().NotBeNull();
    }

    internal override Employee GetForDelete()
    {
        return Dao.Employee.GetByKey(6);
    }
}