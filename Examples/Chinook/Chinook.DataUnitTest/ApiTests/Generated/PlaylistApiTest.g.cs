﻿// <auto-generated> This file has been generated by Gccg</auto-generated>
#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.ApiTests;


[TestClass]
public partial class PlaylistApiTest
{
    [TestInitialize]
    public void Initialize()
    {
        Api.Initialize().Wait();
    }

    [TestMethod]
    public async Task GetCount()
    {
        var count = await Api.Playlist.GetCountAsync();

        count.ShouldBeGreaterThan(0);
    }

    [TestMethod]
    public async Task GetByKey()
    {
        var first = await Api.Playlist.GetFirstAsync();
        var entity = await Api.Playlist.GetByKeyAsync(first.PlaylistId );

        entity.PrimaryKeyValues.ShouldBe(first.PrimaryKeyValues);
    }

    [TestMethod]
    public async Task ExistsByKey()
    {
        var first = await Api.Playlist.GetFirstAsync();

        (await Dao.Playlist.ExistsByKeyAsync(first.PlaylistId )).ShouldBeTrue();
    }

    [TestMethod]
    public async Task Exists()
    {
        var first = await Api.Playlist.GetFirstAsync();

        (await Api.Playlist.ExistsByKeyAsync(first.PlaylistId )).ShouldBeTrue();
    }

    [TestMethod]
    public async Task DeleteByKey()
    {
        var first = await Api.Playlist.GetFirstAsync();
        await Api.Playlist.DeleteByKeyAsync(first.PlaylistId );

        (await Api.Playlist.ExistsByKeyAsync(first.PlaylistId )).ShouldBeFalse();
    }

    [TestMethod]
    public async Task Insert()
    {
        var first = await Api.Playlist.GetFirstAsync();

        var oldCount = await Api.Playlist.GetCountAsync();

        var entity = first.Clone();
        entity.ClearKeyValues();
        PlaylistDaoTest.FillForInsert(entity);
        entity = await Api.Playlist.InsertAsync(entity);

        var newCount = await Api.Playlist.GetCountAsync();

        newCount.ShouldBe(oldCount + 1);
    }

    [TestMethod]
    public async Task Update()
    {
        var entity = await Api.Playlist.GetFirstAsync();
        object value = PlaylistDaoTest.SetUpdateField(entity);
        await Api.Playlist.UpdateAsync(entity);

        entity = await Api.Playlist.GetFirstAsync();

        PlaylistDaoTest.GetUpdateField(entity).ShouldBe(value);
    }

    [TestMethod]
    public async Task GetFirst()
    {
        var entity = await Api.Playlist.GetFirstAsync();
        entity.ShouldNotBeNull();
    }

    
}

