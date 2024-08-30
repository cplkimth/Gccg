// <auto-generated> This file has been generated by Gccg</auto-generated>
#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.ApiTests;


[TestClass]
public partial class TimeTableApiTest
{
    [TestInitialize]
    public void Initialize()
    {
        Api.Initialize().Wait();
    }

    [TestMethod]
    public async Task GetCount()
    {
        var count = await Api.TimeTable.GetCountAsync();

        count.Should().BeGreaterThan(0);
    }

    [TestMethod]
    public async Task GetByKey()
    {
        var first = await Api.TimeTable.GetFirstAsync();
        var entity = await Api.TimeTable.GetByKeyAsync(first.Time );

        entity.PrimaryKeyValues.Should().Be(first.PrimaryKeyValues);
    }

    [TestMethod]
    public async Task ExistsByKey()
    {
        var first = await Api.TimeTable.GetFirstAsync();

        (await Dao.TimeTable.ExistsByKeyAsync(first.Time )).Should().BeTrue();
    }

    [TestMethod]
    public async Task Exists()
    {
        var first = await Api.TimeTable.GetFirstAsync();

        (await Api.TimeTable.ExistsByKeyAsync(first.Time )).Should().BeTrue();
    }

    [TestMethod]
    public async Task DeleteByKey()
    {
        var first = await Api.TimeTable.GetFirstAsync();
        await Api.TimeTable.DeleteByKeyAsync(first.Time );

        (await Api.TimeTable.ExistsByKeyAsync(first.Time )).Should().BeFalse();
    }

    [TestMethod]
    public async Task Insert()
    {
        var first = await Api.TimeTable.GetFirstAsync();

        var oldCount = await Api.TimeTable.GetCountAsync();

        var entity = first.Clone();
        entity.ClearKeyValues();
        TimeTableDaoTest.FillForInsert(entity);
        entity = await Api.TimeTable.InsertAsync(entity);

        var newCount = await Api.TimeTable.GetCountAsync();

        newCount.Should().Be(oldCount + 1);
    }

    [TestMethod]
    public async Task Update()
    {
        var entity = await Api.TimeTable.GetFirstAsync();
        object value = TimeTableDaoTest.SetUpdateField(entity);
        await Api.TimeTable.UpdateAsync(entity);

        entity = await Api.TimeTable.GetFirstAsync();

        TimeTableDaoTest.GetUpdateField(entity).Should().Be(value);
    }

    [TestMethod]
    public async Task GetFirst()
    {
        var entity = await Api.TimeTable.GetFirstAsync();
        entity.Should().NotBeNull();
    }

    
}

