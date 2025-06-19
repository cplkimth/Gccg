#region

using Chinook.Data;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

public partial class CustomerDaoTest
{
    internal static void FillForInsert(Customer entity)
    {
    }

    internal static object SetUpdateField(Customer entity)
    {
        return entity.FirstName = DateTime.Now.Ticks.ToString();
    }

    internal static object GetUpdateField(Customer entity)
    {
        return entity.FirstName;
    }

    [TestMethod]
    public async Task GetLast()
    {
        var entity = await Dao.Customer.GetLast(x => x.CustomerId );
        entity.ShouldNotBeNull();
    }
}