
#region usings
using Chinook.Data;
#endregion

namespace Chinook.Web.Grids;


public partial class CompanyGrid : EntityGrid<Company>
{
    protected override Company CreateEntity()
    {
        var company = Dao.Company.Create();
        // TODO : CreateEntity

        return company;
    }

    protected override Task<List<Company>> GetCoreAsync() => Dao.Company.GetAsync();

    protected override void InsertEntity(Company entity) => Dao.Company.Insert(entity);

    protected override void UpdateEntity(Company entity) => Dao.Company.Update(entity);

    protected override void DeleteEntity(Company entity) => Dao.Company.Delete(entity);
}

