#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Asynchronous;

public partial class InvoiceLineDaoTestAsync
{
    internal static void FillForInsert(InvoiceLine entity)
    {
    }

    internal static object SetUpdateField(InvoiceLine entity)
    {
        return entity.Quantity = Random.Shared.Next(100);
    }

    internal static object GetUpdateField(InvoiceLine entity)
    {
        return entity.Quantity;
    }

    [TestMethod]
    public async Task GetLast()
    {
        var entity = await Dao.InvoiceLine.GetLastAsync(x => x.InvoiceLineId );
        entity.ShouldNotBeNull();
    }
}