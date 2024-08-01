
#region usings
using Chinook.Data;
#endregion

namespace `WebProjectNamespace`.Grids;


public partial class CodeGrid : EntityGrid<Code>
{
    protected override Code CreateEntity()
    {
        var code = Dao.Code.Create();
        // TODO : CreateEntity

        return code;
    }

    protected override Task<List<Code>> GetCoreAsync() => Dao.Code.GetAsync();

    protected override void InsertEntity(Code entity) => Dao.Code.Insert(entity);

    protected override void UpdateEntity(Code entity) => Dao.Code.Update(entity);

    protected override void DeleteEntity(Code entity) => Dao.Code.Delete(entity);
}

