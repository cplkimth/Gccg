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
public partial class CodeDaoTest : EntityDaoTest<Code>
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
        var count = Dao.Code.GetCount();
        
        count.Should().BeGreaterThan(0);
    }

    [TestMethod]
    public void GetByKey()
    {
        var first = Dao.Code.GetFirst();
        var entity = Dao.Code.GetByKey(first.CodeId );
        
        entity.PrimaryKeyValues.Should().Be(first.PrimaryKeyValues);
    }

    [TestMethod]
    public void ExistsByKey()
    {
        var first = Dao.Code.GetFirst();
        
        Dao.Code.ExistsByKey(first.CodeId ).Should().BeTrue();
    }

    [TestMethod]
    public void Exists()
    {
        var first = Dao.Code.GetFirst();
        
        Dao.Code.Exists(x => x.CodeId == first.CodeId ).Should().BeTrue();
    }

    [TestMethod]
    public void DeleteByKey()
    {
        var first = GetForDelete();
        Dao.Code.DeleteByKey(first.CodeId );
        
        Dao.Code.ExistsByKey(first.CodeId ).Should().BeFalse();
    }

    [TestMethod]
    public void DeleteAll()
    {
        var first = GetForDelete();
        var count = Dao.Code.DeleteAll(x => x.CodeId == first.CodeId );
        count.Should().BeGreaterThan(0);

        Dao.Code.ExistsByKey(first.CodeId ).Should().BeFalse();
    }

    [TestMethod]
    public void Insert()
    {
        var first = Dao.Code.GetFirst();

        var oldCount = Dao.Code.GetCount();

        var entity = first.Clone();
        entity.ClearKeyValues();
        FillForInsert(entity);
        entity = Dao.Code.Insert(entity);

        var newCount = Dao.Code.GetCount();

        newCount.Should().Be(oldCount + 1);
    }

    [TestMethod]
    public void Update()
    {
        var entity = Dao.Code.GetFirst();
        object value = SetUpdateField(entity);

        if (value == null)
            return;

        Dao.Code.Update(entity);

        entity = Dao.Code.GetFirst();

        GetUpdateField(entity).Should().Be(value);
    }

    [TestMethod]
    public void GetFirst()
    {
        var entity = Dao.Code.GetFirst();
        entity.Should().NotBeNull();
    }
}


