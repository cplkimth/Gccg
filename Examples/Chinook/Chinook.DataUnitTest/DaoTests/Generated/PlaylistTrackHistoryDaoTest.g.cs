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
public partial class PlaylistTrackHistoryDaoTest : EntityDaoTest<PlaylistTrackHistory>
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
        var count = Dao.PlaylistTrackHistory.GetCount();
        
        count.ShouldBeGreaterThan(0);
    }

    [TestMethod]
    public void GetByKey()
    {
        var first = Dao.PlaylistTrackHistory.GetFirst();
        var entity = Dao.PlaylistTrackHistory.GetByKey(first.PlaylistId , first.TrackId , first.WrittenAt );
        
        entity.PrimaryKeyValues.ShouldBe(first.PrimaryKeyValues);
    }

    [TestMethod]
    public void ExistsByKey()
    {
        var first = Dao.PlaylistTrackHistory.GetFirst();
        
        Dao.PlaylistTrackHistory.ExistsByKey(first.PlaylistId , first.TrackId , first.WrittenAt ).ShouldBeTrue();
    }

    [TestMethod]
    public void Exists()
    {
        var first = Dao.PlaylistTrackHistory.GetFirst();
        
        Dao.PlaylistTrackHistory.Exists(x => x.PlaylistId == first.PlaylistId  && x.TrackId == first.TrackId  && x.WrittenAt == first.WrittenAt ).ShouldBeTrue();
    }

    [TestMethod]
    public void DeleteByKey()
    {
        var first = GetForDelete();
        Dao.PlaylistTrackHistory.DeleteByKey(first.PlaylistId , first.TrackId , first.WrittenAt );
        
        Dao.PlaylistTrackHistory.ExistsByKey(first.PlaylistId , first.TrackId , first.WrittenAt ).ShouldBeFalse();
    }

    [TestMethod]
    public void DeleteAll()
    {
        var first = GetForDelete();
        var count = Dao.PlaylistTrackHistory.DeleteAll(x => x.PlaylistId == first.PlaylistId  && x.TrackId == first.TrackId  && x.WrittenAt == first.WrittenAt );
        count.ShouldBeGreaterThan(0);

        Dao.PlaylistTrackHistory.ExistsByKey(first.PlaylistId , first.TrackId , first.WrittenAt ).ShouldBeFalse();
    }

    [TestMethod]
    public void Insert()
    {
        var first = Dao.PlaylistTrackHistory.GetFirst();

        var oldCount = Dao.PlaylistTrackHistory.GetCount();

        var entity = first.Clone();
        entity.ClearKeyValues();
        FillForInsert(entity);
        entity = Dao.PlaylistTrackHistory.Insert(entity);

        var newCount = Dao.PlaylistTrackHistory.GetCount();

        newCount.ShouldBe(oldCount + 1);
    }

    [TestMethod]
    public void Update()
    {
        var entity = Dao.PlaylistTrackHistory.GetFirst();
        object value = SetUpdateField(entity);

        if (value == null)
            return;

        Dao.PlaylistTrackHistory.Update(entity);

        entity = Dao.PlaylistTrackHistory.GetFirst();

        GetUpdateField(entity).ShouldBe(value);
    }

    [TestMethod]
    public void GetFirst()
    {
        var entity = Dao.PlaylistTrackHistory.GetFirst();
        entity.ShouldNotBeNull();
    }
}


