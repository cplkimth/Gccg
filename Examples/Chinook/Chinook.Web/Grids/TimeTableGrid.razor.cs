
#region usings
using Chinook.Data;
#endregion

namespace Chinook.Web.Grids;


public partial class TimeTableGrid : EntityGrid<TimeTable>
{
    protected override TimeTable CreateEntity()
    {
        var timeTable = Dao.TimeTable.Create();
        // TODO : CreateEntity

        return timeTable;
    }

    protected override Task<List<TimeTable>> GetCoreAsync() => Dao.TimeTable.GetAsync();

    protected override void InsertEntity(TimeTable entity) => Dao.TimeTable.Insert(entity);

    protected override void UpdateEntity(TimeTable entity) => Dao.TimeTable.Update(entity);

    protected override void DeleteEntity(TimeTable entity) => Dao.TimeTable.Delete(entity);
}

