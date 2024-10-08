// <auto-generated> This file has been generated by Gccg</auto-generated>
#region
using Chinook.Data;
#endregion

namespace Chinook.DataUnitTest.ApiTests;


[TestClass]
public partial class TrackApiTest
{
    [TestInitialize]
    public void Initialize()
    {
        Api.Initialize().Wait();
    }

    [TestMethod]
    public async Task GetCount()
    {
        var count = await Api.Track.GetCountAsync();

        count.Should().BeGreaterThan(0);
    }

    [TestMethod]
    public async Task GetByKey()
    {
        var first = await Api.Track.GetFirstAsync();
        var entity = await Api.Track.GetByKeyAsync(first.TrackId );

        entity.PrimaryKeyValues.Should().Be(first.PrimaryKeyValues);
    }

    [TestMethod]
    public async Task ExistsByKey()
    {
        var first = await Api.Track.GetFirstAsync();

        (await Dao.Track.ExistsByKeyAsync(first.TrackId )).Should().BeTrue();
    }

    [TestMethod]
    public async Task Exists()
    {
        var first = await Api.Track.GetFirstAsync();

        (await Api.Track.ExistsByKeyAsync(first.TrackId )).Should().BeTrue();
    }

    [TestMethod]
    public async Task DeleteByKey()
    {
        var first = await Api.Track.GetFirstAsync();
        await Api.Track.DeleteByKeyAsync(first.TrackId );

        (await Api.Track.ExistsByKeyAsync(first.TrackId )).Should().BeFalse();
    }

    [TestMethod]
    public async Task Insert()
    {
        var first = await Api.Track.GetFirstAsync();

        var oldCount = await Api.Track.GetCountAsync();

        var entity = first.Clone();
        entity.ClearKeyValues();
        TrackDaoTest.FillForInsert(entity);
        entity = await Api.Track.InsertAsync(entity);

        var newCount = await Api.Track.GetCountAsync();

        newCount.Should().Be(oldCount + 1);
    }

    [TestMethod]
    public async Task Update()
    {
        var entity = await Api.Track.GetFirstAsync();
        object value = TrackDaoTest.SetUpdateField(entity);
        await Api.Track.UpdateAsync(entity);

        entity = await Api.Track.GetFirstAsync();

        TrackDaoTest.GetUpdateField(entity).Should().Be(value);
    }

    [TestMethod]
    public async Task GetFirst()
    {
        var entity = await Api.Track.GetFirstAsync();
        entity.Should().NotBeNull();
    }

    
	[TestMethod]
    public async Task GetByAlbumId()
    {
        var list = await Api.Track.GetByAlbumIdAsync(2);

        foreach (var item in list)
            item.AlbumId.Should().Be(2);
    }
	
	[TestMethod]
    public async Task GetByGenreId()
    {
        var list = await Api.Track.GetByGenreIdAsync(1);

        foreach (var item in list)
            item.GenreId.Should().Be(1);
    }
	
	[TestMethod]
    public async Task GetByMediaTypeId()
    {
        var list = await Api.Track.GetByMediaTypeIdAsync(1);

        foreach (var item in list)
            item.MediaTypeId.Should().Be(1);
    }
	
}

