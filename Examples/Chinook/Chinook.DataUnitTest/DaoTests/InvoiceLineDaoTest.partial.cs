#region

using Chinook.Data;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

public partial class InvoiceLineDaoTest
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
    public void GetLast()
    {
        var entity = Dao.InvoiceLine.GetLast(x => x.InvoiceLineId );
        entity.ShouldNotBeNull();
    }
}