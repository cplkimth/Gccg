#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Synchronous;

public partial class MediaTypeDaoTest
{
    internal static void FillForInsert(MediaType entity)
    {
    }

    internal static object SetUpdateField(MediaType entity)
    {
        return entity.Name = DateTime.Now.Ticks.ToString();
    }

    internal static object GetUpdateField(MediaType entity)
    {
        return entity.Name;
    }

    [TestMethod]
    public void GetLast()
    {
        var entity = Dao.MediaType.GetLast(x => x.MediaTypeId );
        entity.ShouldNotBeNull();
    }
}