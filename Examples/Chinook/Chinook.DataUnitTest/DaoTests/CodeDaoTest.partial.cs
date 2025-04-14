#region

using Chinook.Data;

#endregion

namespace Chinook.DataUnitTest.DaoTests;

public partial class CodeDaoTest
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
    public void GetLast()
    {
        var entity = Dao.Code.GetLast(x => x.CodeId);
        entity.ShouldNotBeNull();
    }

}