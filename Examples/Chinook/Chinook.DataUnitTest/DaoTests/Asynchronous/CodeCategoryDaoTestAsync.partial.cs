#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Asynchronous;

public partial class CodeCategoryDaoTestAsync
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
        var entity = await Dao.CodeCategory.GetLastAsync(x => x.CodeCategoryId );
        entity.ShouldNotBeNull();
    }
}