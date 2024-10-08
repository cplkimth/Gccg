// <auto-generated> This file has been generated by Gccg</auto-generated>
#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.ApiTests;


[TestClass]
public partial class PlaylistTrackHistoryApiTest
{
    [TestInitialize]
    public void Initialize()
    {
        Api.Initialize().Wait();
    }

    [TestMethod]
    public async Task GetCount()
    {
        var count = await Api.PlaylistTrackHistory.GetCountAsync();

        count.Should().BeGreaterThan(0);
    }

    [TestMethod]
    public async Task ExistsByKey()
    {
        var first = await Api.PlaylistTrackHistory.GetFirstAsync();

        (await Dao.PlaylistTrackHistory.ExistsByKeyAsync(first.PlaylistId , first.TrackId , first.WrittenAt )).Should().BeTrue();
    }

    [TestMethod]
    public async Task Insert()
    {
        var first = await Api.PlaylistTrackHistory.GetFirstAsync();

        var oldCount = await Api.PlaylistTrackHistory.GetCountAsync();

        var entity = first.Clone();
        entity.ClearKeyValues();
        PlaylistTrackHistoryDaoTest.FillForInsert(entity);
        entity = await Api.PlaylistTrackHistory.InsertAsync(entity);

        var newCount = await Api.PlaylistTrackHistory.GetCountAsync();

        newCount.Should().Be(oldCount + 1);
    }

    [TestMethod]
    public async Task Update()
    {
        var entity = await Api.PlaylistTrackHistory.GetFirstAsync();
        object value = PlaylistTrackHistoryDaoTest.SetUpdateField(entity);
        await Api.PlaylistTrackHistory.UpdateAsync(entity);

        entity = await Api.PlaylistTrackHistory.GetFirstAsync();

        PlaylistTrackHistoryDaoTest.GetUpdateField(entity).Should().Be(value);
    }

    [TestMethod]
    public async Task GetFirst()
    {
        var entity = await Api.PlaylistTrackHistory.GetFirstAsync();
        entity.Should().NotBeNull();
    }

    
	[TestMethod]
    public async Task GetByPlaylistId()
    {
        var list = await Api.PlaylistTrackHistory.GetByPlaylistIdAsync(1);

        foreach (var item in list)
            item.PlaylistId.Should().Be(1);
    }
	
	[TestMethod]
    public async Task GetByTrackId()
    {
        var list = await Api.PlaylistTrackHistory.GetByTrackIdAsync(1);

        foreach (var item in list)
            item.TrackId.Should().Be(1);
    }
	
}

