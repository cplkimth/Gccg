// <auto-generated> This file has been generated by Gccg</auto-generated>
#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.ApiTests;


[TestClass]
public partial class DateTableApiTest
{
    [TestInitialize]
    public void Initialize()
    {
        Api.Initialize().Wait();
    }

    [TestMethod]
    public async Task GetCount()
    {
        var count = await Api.DateTable.GetCountAsync();

        count.Should().BeGreaterThan(0);
    }

    [TestMethod]
    public async Task GetByKey()
    {
        var first = await Api.DateTable.GetFirstAsync();
        var entity = await Api.DateTable.GetByKeyAsync(first.Date );

        entity.PrimaryKeyValues.Should().Be(first.PrimaryKeyValues);
    }

    [TestMethod]
    public async Task ExistsByKey()
    {
        var first = await Api.DateTable.GetFirstAsync();

        (await Dao.DateTable.ExistsByKeyAsync(first.Date )).Should().BeTrue();
    }

    [TestMethod]
    public async Task Exists()
    {
        var first = await Api.DateTable.GetFirstAsync();

        (await Api.DateTable.ExistsByKeyAsync(first.Date )).Should().BeTrue();
    }

    [TestMethod]
    public async Task DeleteByKey()
    {
        var first = await Api.DateTable.GetFirstAsync();
        await Api.DateTable.DeleteByKeyAsync(first.Date );

        (await Api.DateTable.ExistsByKeyAsync(first.Date )).Should().BeFalse();
    }

    [TestMethod]
    public async Task Insert()
    {
        var first = await Api.DateTable.GetFirstAsync();

        var oldCount = await Api.DateTable.GetCountAsync();

        var entity = first.Clone();
        entity.ClearKeyValues();
        DateTableDaoTest.FillForInsert(entity);
        entity = await Api.DateTable.InsertAsync(entity);

        var newCount = await Api.DateTable.GetCountAsync();

        newCount.Should().Be(oldCount + 1);
    }

    [TestMethod]
    public async Task Update()
    {
        var entity = await Api.DateTable.GetFirstAsync();
        object value = DateTableDaoTest.SetUpdateField(entity);
        await Api.DateTable.UpdateAsync(entity);

        entity = await Api.DateTable.GetFirstAsync();

        DateTableDaoTest.GetUpdateField(entity).Should().Be(value);
    }

    [TestMethod]
    public async Task GetFirst()
    {
        var entity = await Api.DateTable.GetFirstAsync();
        entity.Should().NotBeNull();
    }

    
}
