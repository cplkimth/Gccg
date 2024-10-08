// <auto-generated> This file has been generated by Gccg</auto-generated>
#region using
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.DaoTests;


[TestClass]
public partial class CustomerDaoTest : EntityDaoTest<Customer>
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
        var count = Dao.Customer.GetCount();
        
        count.Should().BeGreaterThan(0);
    }

    [TestMethod]
    public void GetByKey()
    {
        var first = Dao.Customer.GetFirst();
        var entity = Dao.Customer.GetByKey(first.CustomerId );
        
        entity.PrimaryKeyValues.Should().Be(first.PrimaryKeyValues);
    }

    [TestMethod]
    public void ExistsByKey()
    {
        var first = Dao.Customer.GetFirst();
        
        Dao.Customer.ExistsByKey(first.CustomerId ).Should().BeTrue();
    }

    [TestMethod]
    public void Exists()
    {
        var first = Dao.Customer.GetFirst();
        
        Dao.Customer.Exists(x => x.CustomerId == first.CustomerId ).Should().BeTrue();
    }

    [TestMethod]
    public void DeleteByKey()
    {
        var first = GetForDelete();
        Dao.Customer.DeleteByKey(first.CustomerId );
        
        Dao.Customer.ExistsByKey(first.CustomerId ).Should().BeFalse();
    }

    [TestMethod]
    public void DeleteAll()
    {
        var first = GetForDelete();
        var count = Dao.Customer.DeleteAll(x => x.CustomerId == first.CustomerId );
        count.Should().BeGreaterThan(0);

        Dao.Customer.ExistsByKey(first.CustomerId ).Should().BeFalse();
    }

    [TestMethod]
    public void Insert()
    {
        var first = Dao.Customer.GetFirst();

        var oldCount = Dao.Customer.GetCount();

        var entity = first.Clone();
        entity.ClearKeyValues();
        FillForInsert(entity);
        entity = Dao.Customer.Insert(entity);

        var newCount = Dao.Customer.GetCount();

        newCount.Should().Be(oldCount + 1);
    }

    [TestMethod]
    public void Update()
    {
        var entity = Dao.Customer.GetFirst();
        object value = SetUpdateField(entity);

        if (value == null)
            return;

        Dao.Customer.Update(entity);

        entity = Dao.Customer.GetFirst();

        GetUpdateField(entity).Should().Be(value);
    }

    [TestMethod]
    public void GetFirst()
    {
        var entity = Dao.Customer.GetFirst();
        entity.Should().NotBeNull();
    }
}


