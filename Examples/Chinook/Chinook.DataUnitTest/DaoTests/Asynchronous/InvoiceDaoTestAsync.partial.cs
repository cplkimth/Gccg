#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Asynchronous;

public partial class InvoiceDaoTestAsync
{
    internal static void FillForInsert(Invoice entity)
    {
    }

    internal static object SetUpdateField(Invoice entity)
    {
        return entity.BillingAddress = DateTime.Now.Ticks.ToString();
    }

    internal static object GetUpdateField(Invoice entity)
    {
        return entity.BillingAddress;
    }

    [TestMethod]
    public async Task GetLast()
    {
        var entity = await Dao.Invoice.GetLastAsync(x => x.InvoiceId );
        entity.ShouldNotBeNull();
    }
}