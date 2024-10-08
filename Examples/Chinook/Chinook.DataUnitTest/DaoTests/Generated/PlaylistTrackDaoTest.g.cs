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
public partial class PlaylistTrackDaoTest : EntityDaoTest<PlaylistTrack>
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
        var count = Dao.PlaylistTrack.GetCount();
        
        count.Should().BeGreaterThan(0);
    }

    [TestMethod]
    public void GetByKey()
    {
        var first = Dao.PlaylistTrack.GetFirst();
        var entity = Dao.PlaylistTrack.GetByKey(first.PlaylistId , first.TrackId );
        
        entity.PrimaryKeyValues.Should().Be(first.PrimaryKeyValues);
    }

    [TestMethod]
    public void ExistsByKey()
    {
        var first = Dao.PlaylistTrack.GetFirst();
        
        Dao.PlaylistTrack.ExistsByKey(first.PlaylistId , first.TrackId ).Should().BeTrue();
    }

    [TestMethod]
    public void Exists()
    {
        var first = Dao.PlaylistTrack.GetFirst();
        
        Dao.PlaylistTrack.Exists(x => x.PlaylistId == first.PlaylistId  && x.TrackId == first.TrackId ).Should().BeTrue();
    }

    [TestMethod]
    public void DeleteByKey()
    {
        var first = GetForDelete();
        Dao.PlaylistTrack.DeleteByKey(first.PlaylistId , first.TrackId );
        
        Dao.PlaylistTrack.ExistsByKey(first.PlaylistId , first.TrackId ).Should().BeFalse();
    }

    [TestMethod]
    public void DeleteAll()
    {
        var first = GetForDelete();
        var count = Dao.PlaylistTrack.DeleteAll(x => x.PlaylistId == first.PlaylistId  && x.TrackId == first.TrackId );
        count.Should().BeGreaterThan(0);

        Dao.PlaylistTrack.ExistsByKey(first.PlaylistId , first.TrackId ).Should().BeFalse();
    }

    [TestMethod]
    public void Insert()
    {
        var first = Dao.PlaylistTrack.GetFirst();

        var oldCount = Dao.PlaylistTrack.GetCount();

        var entity = first.Clone();
        entity.ClearKeyValues();
        FillForInsert(entity);
        entity = Dao.PlaylistTrack.Insert(entity);

        var newCount = Dao.PlaylistTrack.GetCount();

        newCount.Should().Be(oldCount + 1);
    }

    [TestMethod]
    public void Update()
    {
        var entity = Dao.PlaylistTrack.GetFirst();
        object value = SetUpdateField(entity);

        if (value == null)
            return;

        Dao.PlaylistTrack.Update(entity);

        entity = Dao.PlaylistTrack.GetFirst();

        GetUpdateField(entity).Should().Be(value);
    }

    [TestMethod]
    public void GetFirst()
    {
        var entity = Dao.PlaylistTrack.GetFirst();
        entity.Should().NotBeNull();
    }
}


