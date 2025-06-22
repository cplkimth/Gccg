#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Asynchronous;

public partial class CodeDaoTestAsync
{
    internal static void FillForInsert(Code entity)
    {
    }

    internal static object SetUpdateField(Code entity)
    {
        return entity.Text = DateTime.Now.Ticks.ToString();
    }

    internal static object GetUpdateField(Code entity)
    {
        return entity.Text;
    }

    [TestMethod]
    public async Task GetLast()
    {
        var entity = await Dao.Code.GetLastAsync(x => x.CodeId);
        entity.ShouldNotBeNull();
    }

}