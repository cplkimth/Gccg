#region

using Chinook.Data;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

public partial class CodeCategoryDaoTest
{
    internal static void FillForInsert(CodeCategory entity)
    {
    }

    internal static object SetUpdateField(CodeCategory entity)
    {
        return entity.Name = DateTime.Now.Ticks.ToString();
    }

    internal static object GetUpdateField(CodeCategory entity)
    {
        return entity.Name;
    }
    
    [TestMethod]
    public async Task GetLast()
    {
        var entity = await Dao.CodeCategory.GetLast(x => x.CodeCategoryId );
        entity.ShouldNotBeNull();
    }
}