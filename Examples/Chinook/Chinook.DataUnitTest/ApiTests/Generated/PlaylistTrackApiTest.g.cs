// <auto-generated> This file has been generated by Gccg</auto-generated>
#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.ApiTests;


[TestClass]
public partial class PlaylistTrackApiTest
{
    [TestInitialize]
    public void Initialize()
    {
        Api.Initialize().Wait();
    }

    [TestMethod]
    public async Task GetCount()
    {
        var count = await Api.PlaylistTrack.GetCountAsync();

        count.Should().BeGreaterThan(0);
    }

    [TestMethod]
    public async Task GetByKey()
    {
        var first = await Api.PlaylistTrack.GetFirstAsync();
        var entity = await Api.PlaylistTrack.GetByKeyAsync(first.PlaylistId , first.TrackId );

        entity.PrimaryKeyValues.Should().Be(first.PrimaryKeyValues);
    }

    [TestMethod]
    public async Task ExistsByKey()
    {
        var first = await Api.PlaylistTrack.GetFirstAsync();

        (await Dao.PlaylistTrack.ExistsByKeyAsync(first.PlaylistId , first.TrackId )).Should().BeTrue();
    }

    [TestMethod]
    public async Task Exists()
    {
        var first = await Api.PlaylistTrack.GetFirstAsync();

        (await Api.PlaylistTrack.ExistsByKeyAsync(first.PlaylistId , first.TrackId )).Should().BeTrue();
    }

    [TestMethod]
    public async Task DeleteByKey()
    {
        var first = await Api.PlaylistTrack.GetFirstAsync();
        await Api.PlaylistTrack.DeleteByKeyAsync(first.PlaylistId , first.TrackId );

        (await Api.PlaylistTrack.ExistsByKeyAsync(first.PlaylistId , first.TrackId )).Should().BeFalse();
    }

    [TestMethod]
    public async Task Insert()
    {
        var first = await Api.PlaylistTrack.GetFirstAsync();

        var oldCount = await Api.PlaylistTrack.GetCountAsync();

        var entity = first.Clone();
        entity.ClearKeyValues();
        PlaylistTrackDaoTest.FillForInsert(entity);
        entity = await Api.PlaylistTrack.InsertAsync(entity);

        var newCount = await Api.PlaylistTrack.GetCountAsync();

        newCount.Should().Be(oldCount + 1);
    }

    [TestMethod]
    public async Task Update()
    {
        var entity = await Api.PlaylistTrack.GetFirstAsync();
        object value = PlaylistTrackDaoTest.SetUpdateField(entity);
        await Api.PlaylistTrack.UpdateAsync(entity);

        entity = await Api.PlaylistTrack.GetFirstAsync();

        PlaylistTrackDaoTest.GetUpdateField(entity).Should().Be(value);
    }

    [TestMethod]
    public async Task GetFirst()
    {
        var entity = await Api.PlaylistTrack.GetFirstAsync();
        entity.Should().NotBeNull();
    }

    
	[TestMethod]
    public async Task GetByPlaylistId(int playlistId)
    {
        var list = await Api.PlaylistTrack.GetByPlaylistIdAsync(playlistId);

        foreach (var item in list)
            item.PlaylistId.Should().Be(playlistId);
    }
	
	[TestMethod]
    public async Task GetByTrackId(int trackId)
    {
        var list = await Api.PlaylistTrack.GetByTrackIdAsync(trackId);

        foreach (var item in list)
            item.TrackId.Should().Be(trackId);
    }
	
}

