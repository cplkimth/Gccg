#region

using Chinook.Data;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

public partial class InvoiceDaoTest
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
    public void GetLast()
    {
        var entity = Dao.Invoice.GetLast(x => x.InvoiceId );
        entity.ShouldNotBeNull();
    }
}