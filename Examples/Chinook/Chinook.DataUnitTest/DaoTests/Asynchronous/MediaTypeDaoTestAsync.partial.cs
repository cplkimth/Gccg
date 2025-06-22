#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests.Asynchronous;

public partial class MediaTypeDaoTestAsync
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
    public async Task GetLast()
    {
        var entity = await Dao.MediaType.GetLastAsync(x => x.MediaTypeId );
        entity.ShouldNotBeNull();
    }
}