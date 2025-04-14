﻿// <auto-generated> This file has been generated by Gccg</auto-generated>
#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.ApiTests;


[TestClass]
public partial class CustomerApiTest
{
    [TestInitialize]
    public void Initialize()
    {
        Api.Initialize().Wait();
    }

    [TestMethod]
    public async Task GetCount()
    {
        var count = await Api.Customer.GetCountAsync();

        count.ShouldBeGreaterThan(0);
    }

    [TestMethod]
    public async Task GetByKey()
    {
        var first = await Api.Customer.GetFirstAsync();
        var entity = await Api.Customer.GetByKeyAsync(first.CustomerId );

        entity.PrimaryKeyValues.ShouldBe(first.PrimaryKeyValues);
    }

    [TestMethod]
    public async Task ExistsByKey()
    {
        var first = await Api.Customer.GetFirstAsync();

        (await Dao.Customer.ExistsByKeyAsync(first.CustomerId )).ShouldBeTrue();
    }

    [TestMethod]
    public async Task Exists()
    {
        var first = await Api.Customer.GetFirstAsync();

        (await Api.Customer.ExistsByKeyAsync(first.CustomerId )).ShouldBeTrue();
    }

    [TestMethod]
    public async Task DeleteByKey()
    {
        var first = await Api.Customer.GetFirstAsync();
        await Api.Customer.DeleteByKeyAsync(first.CustomerId );

        (await Api.Customer.ExistsByKeyAsync(first.CustomerId )).ShouldBeFalse();
    }

    [TestMethod]
    public async Task Insert()
    {
        var first = await Api.Customer.GetFirstAsync();

        var oldCount = await Api.Customer.GetCountAsync();

        var entity = first.Clone();
        entity.ClearKeyValues();
        CustomerDaoTest.FillForInsert(entity);
        entity = await Api.Customer.InsertAsync(entity);

        var newCount = await Api.Customer.GetCountAsync();

        newCount.ShouldBe(oldCount + 1);
    }

    [TestMethod]
    public async Task Update()
    {
        var entity = await Api.Customer.GetFirstAsync();
        object value = CustomerDaoTest.SetUpdateField(entity);
        await Api.Customer.UpdateAsync(entity);

        entity = await Api.Customer.GetFirstAsync();

        CustomerDaoTest.GetUpdateField(entity).ShouldBe(value);
    }

    [TestMethod]
    public async Task GetFirst()
    {
        var entity = await Api.Customer.GetFirstAsync();
        entity.ShouldNotBeNull();
    }

    
	[TestMethod]
    public async Task GetBySupportRepId()
    {
        var list = await Api.Customer.GetBySupportRepIdAsync(1);

        foreach (var item in list)
            item.SupportRepId.ShouldBe(1);
    }
	
}

