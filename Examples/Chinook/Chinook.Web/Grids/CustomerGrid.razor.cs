
#region usings
using Chinook.Data;
#endregion

namespace `WebProjectNamespace`.Grids;


public partial class CustomerGrid : EntityGrid<Customer>
{
    protected override Customer CreateEntity()
    {
        var customer = Dao.Customer.Create();
        // TODO : CreateEntity

        return customer;
    }

    protected override Task<List<Customer>> GetCoreAsync() => Dao.Customer.GetAsync();

    protected override void InsertEntity(Customer entity) => Dao.Customer.Insert(entity);

    protected override void UpdateEntity(Customer entity) => Dao.Customer.Update(entity);

    protected override void DeleteEntity(Customer entity) => Dao.Customer.Delete(entity);
}

