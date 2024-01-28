
#region usings
using Chinook.Data;
#endregion

namespace Chinook.Web.Grids;


public partial class DateTableGrid : EntityGrid<DateTable>
{
    protected override DateTable CreateEntity()
    {
        var dateTable = Dao.DateTable.Create();
        // TODO : CreateEntity

        return dateTable;
    }

    protected override Task<List<DateTable>> GetCoreAsync() => Dao.DateTable.GetAsync();

    protected override void InsertEntity(DateTable entity) => Dao.DateTable.Insert(entity);

    protected override void UpdateEntity(DateTable entity) => Dao.DateTable.Update(entity);

    protected override void DeleteEntity(DateTable entity) => Dao.DateTable.Delete(entity);
}

