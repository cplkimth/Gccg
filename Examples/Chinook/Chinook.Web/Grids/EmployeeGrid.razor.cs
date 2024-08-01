
#region usings
using Chinook.Data;
#endregion

namespace `WebProjectNamespace`.Grids;


public partial class EmployeeGrid : EntityGrid<Employee>
{
    protected override Employee CreateEntity()
    {
        var employee = Dao.Employee.Create();
        // TODO : CreateEntity

        return employee;
    }

    protected override Task<List<Employee>> GetCoreAsync() => Dao.Employee.GetAsync();

    protected override void InsertEntity(Employee entity) => Dao.Employee.Insert(entity);

    protected override void UpdateEntity(Employee entity) => Dao.Employee.Update(entity);

    protected override void DeleteEntity(Employee entity) => Dao.Employee.Delete(entity);
}

