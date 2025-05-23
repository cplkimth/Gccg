﻿// <auto-generated> This file has been generated by Gccg</auto-generated>
#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.ApiTests;


[TestClass]
public partial class EmployeeApiTest
{
    [TestInitialize]
    public void Initialize()
    {
        Api.Initialize().Wait();
    }

    [TestMethod]
    public async Task GetCount()
    {
        var count = await Api.Employee.GetCountAsync();

        count.ShouldBeGreaterThan(0);
    }

    [TestMethod]
    public async Task GetByKey()
    {
        var first = await Api.Employee.GetFirstAsync();
        var entity = await Api.Employee.GetByKeyAsync(first.EmployeeId );

        entity.PrimaryKeyValues.ShouldBe(first.PrimaryKeyValues);
    }

    [TestMethod]
    public async Task ExistsByKey()
    {
        var first = await Api.Employee.GetFirstAsync();

        (await Dao.Employee.ExistsByKeyAsync(first.EmployeeId )).ShouldBeTrue();
    }

    [TestMethod]
    public async Task Exists()
    {
        var first = await Api.Employee.GetFirstAsync();

        (await Api.Employee.ExistsByKeyAsync(first.EmployeeId )).ShouldBeTrue();
    }

    [TestMethod]
    public async Task DeleteByKey()
    {
        var first = await Api.Employee.GetByKeyAsync(4);
        await Api.Employee.DeleteByKeyAsync(first.EmployeeId );

        (await Api.Employee.ExistsByKeyAsync(first.EmployeeId )).ShouldBeFalse();
    }

    [TestMethod]
    public async Task Insert()
    {
        var first = await Api.Employee.GetFirstAsync();

        var oldCount = await Api.Employee.GetCountAsync();

        var entity = first.Clone();
        entity.ClearKeyValues();
        EmployeeDaoTest.FillForInsert(entity);
        entity = await Api.Employee.InsertAsync(entity);

        var newCount = await Api.Employee.GetCountAsync();

        newCount.ShouldBe(oldCount + 1);
    }

    [TestMethod]
    public async Task Update()
    {
        var entity = await Api.Employee.GetFirstAsync();
        object value = EmployeeDaoTest.SetUpdateField(entity);
        await Api.Employee.UpdateAsync(entity);

        entity = await Api.Employee.GetFirstAsync();

        EmployeeDaoTest.GetUpdateField(entity).ShouldBe(value);
    }

    [TestMethod]
    public async Task GetFirst()
    {
        var entity = await Api.Employee.GetFirstAsync();
        entity.ShouldNotBeNull();
    }

    
	[TestMethod]
    public async Task GetByReportsTo()
    {
        var list = await Api.Employee.GetByReportsToAsync(1);

        foreach (var item in list)
            item.ReportsTo.ShouldBe(1);
    }
	
}

