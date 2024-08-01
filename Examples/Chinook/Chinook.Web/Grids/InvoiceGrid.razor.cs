
#region usings
using Chinook.Data;
#endregion

namespace `WebProjectNamespace`.Grids;


public partial class InvoiceGrid : EntityGrid<Invoice>
{
    protected override Invoice CreateEntity()
    {
        var invoice = Dao.Invoice.Create();
        // TODO : CreateEntity

        return invoice;
    }

    protected override Task<List<Invoice>> GetCoreAsync() => Dao.Invoice.GetAsync();

    protected override void InsertEntity(Invoice entity) => Dao.Invoice.Insert(entity);

    protected override void UpdateEntity(Invoice entity) => Dao.Invoice.Update(entity);

    protected override void DeleteEntity(Invoice entity) => Dao.Invoice.Delete(entity);
}

