﻿// <auto-generated> This file has been generated by Gccg</auto-generated>
#region using
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests;


[TestClass]
public partial class MediaTypeDaoTest : EntityDaoTest<MediaType>
{
    [TestInitialize]
    public void Initialize()
    {
        var procedures = new ChinookContextProcedures(DbContextFactory.Create());
        procedures.usp_InitializeAsync().Wait();
    }

    [TestMethod]
    public void GetCount()
    {
        var count = Dao.MediaType.GetCount();
        
        count.Should().BeGreaterThan(0);
    }

    [TestMethod]
    public void GetByKey()
    {
        var first = Dao.MediaType.GetFirst();
        var entity = Dao.MediaType.GetByKey(first.MediaTypeId );
        
        entity.PrimaryKeyValues.Should().Be(first.PrimaryKeyValues);
    }

    [TestMethod]
    public void ExistsByKey()
    {
        var first = Dao.MediaType.GetFirst();
        
        Dao.MediaType.ExistsByKey(first.MediaTypeId ).Should().BeTrue();
    }

    [TestMethod]
    public void Exists()
    {
        var first = Dao.MediaType.GetFirst();
        
        Dao.MediaType.Exists(x => x.MediaTypeId == first.MediaTypeId ).Should().BeTrue();
    }

    [TestMethod]
    public void DeleteByKey()
    {
        var first = GetForDelete();
        Dao.MediaType.DeleteByKey(first.MediaTypeId );
        
        Dao.MediaType.ExistsByKey(first.MediaTypeId ).Should().BeFalse();
    }

    [TestMethod]
    public void DeleteAll()
    {
        var first = GetForDelete();
        var count = Dao.MediaType.DeleteAll(x => x.MediaTypeId == first.MediaTypeId );
        count.Should().BeGreaterThan(0);

        Dao.MediaType.ExistsByKey(first.MediaTypeId ).Should().BeFalse();
    }

    [TestMethod]
    public void Insert()
    {
        var first = Dao.MediaType.GetFirst();

        var oldCount = Dao.MediaType.GetCount();

        var entity = first.Clone();
        entity.ClearKeyValues();
        FillForInsert(entity);
        Dao.MediaType.Insert(entity);

        var newCount = Dao.MediaType.GetCount();

        newCount.Should().Be(oldCount + 1);
    }

    [TestMethod]
    public void Update()
    {
        var entity = Dao.MediaType.GetFirst();
        object value = SetUpdateField(entity);

        if (value == null)
            return;

        Dao.MediaType.Update(entity);

        entity = Dao.MediaType.GetFirst();

        GetUpdateField(entity).Should().Be(value);
    }

    [TestMethod]
    public void GetFirst()
    {
        var entity = Dao.MediaType.GetFirst();
        entity.Should().NotBeNull();
    }
}


