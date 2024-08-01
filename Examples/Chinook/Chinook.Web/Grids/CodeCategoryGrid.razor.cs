
#region usings
using Chinook.Data;
#endregion

namespace `WebProjectNamespace`.Grids;


public partial class CodeCategoryGrid : EntityGrid<CodeCategory>
{
    protected override CodeCategory CreateEntity()
    {
        var codeCategory = Dao.CodeCategory.Create();
        // TODO : CreateEntity

        return codeCategory;
    }

    protected override Task<List<CodeCategory>> GetCoreAsync() => Dao.CodeCategory.GetAsync();

    protected override void InsertEntity(CodeCategory entity) => Dao.CodeCategory.Insert(entity);

    protected override void UpdateEntity(CodeCategory entity) => Dao.CodeCategory.Update(entity);

    protected override void DeleteEntity(CodeCategory entity) => Dao.CodeCategory.Delete(entity);
}

