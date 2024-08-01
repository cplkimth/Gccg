
#region usings
using Chinook.Data;
#endregion

namespace `WebProjectNamespace`.Grids;


public partial class InvoiceLineGrid : EntityGrid<InvoiceLine>
{
    protected override InvoiceLine CreateEntity()
    {
        var invoiceLine = Dao.InvoiceLine.Create();
        // TODO : CreateEntity

        return invoiceLine;
    }

    protected override Task<List<InvoiceLine>> GetCoreAsync() => Dao.InvoiceLine.GetAsync();

    protected override void InsertEntity(InvoiceLine entity) => Dao.InvoiceLine.Insert(entity);

    protected override void UpdateEntity(InvoiceLine entity) => Dao.InvoiceLine.Update(entity);

    protected override void DeleteEntity(InvoiceLine entity) => Dao.InvoiceLine.Delete(entity);
}

