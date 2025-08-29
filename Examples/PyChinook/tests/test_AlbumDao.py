from datetime import datetime

from gccg.Dao import Dao
from models import Album


class TestAlbumDao:
    def test_exists(self):
        assert Dao.album().exists(Album.AlbumId == 2)
        assert not Dao.album().exists(Album.AlbumId == 100)

    def test_exists_by_key(self):
        assert Dao.album().exists_by_key(2)
        assert not Dao.album().exists_by_key(100)

    def test_count__all(self):
        assert Dao.album().count() > 0

    def test_count__criteria1(self):
        assert Dao.album().count(Album.AlbumId <= 3) == 2

    def test_count__criteria2(self):
        assert Dao.album().count(Album.AlbumId >= 3, Album.AlbumId <= 5) == 3

    def test_count_by_key(self):
        assert Dao.album().count_by_key(2)
        assert not Dao.album().count_by_key(100)

    def test_get_by_key(self):
        assert Dao.album().get_by_key(5).AlbumId == 5

    def test_get_by_key__none(self):
        assert Dao.album().get_by_key(100) is None

    def test_get_first(self):
        assert Dao.album().get_first().AlbumId == 2

    def test_get_first__criteria(self):
        assert Dao.album().get_first(Album.AlbumId > 2).AlbumId == 3

    def test_get_last(self):
        assert Dao.album().get_last().AlbumId == 9

    def test_get_last__criteria(self):
        assert Dao.album().get_last(Album.AlbumId < 5).AlbumId == 4

    def test_get(self):
        assert len(Dao.album().get()) == 8

    def test_get__with_1_criteria(self):
        assert len(Dao.album().get(Album.AlbumId < 5)) == 3

    def test_get__with_2_criteria(self):
        assert len(Dao.album().get(Album.AlbumId > 5, Album.AlbumId < 9)) == 3

    def test_upsert__insert(self):
        old_count = Dao.album().count()

        entity = Dao.album().create()
        entity.ArtistId = 1
        entity.TypeCode = 20000
        entity = Dao.album().upsert(entity)

        assert entity.AlbumId > 0

        new_count = Dao.album().count()
        assert new_count == old_count + 1

    def test_upsert__update(self):
        text = datetime.today().strftime("%c")

        first = Dao.album().get_first()
        first.Title = text
        Dao.album().upsert(first)

        first = Dao.album().get_first()
        assert first.Title == text

    def test_delete(self):
        old_count = Dao.album().count()

        entity = Dao.album().get_first()
        Dao.album().delete(entity)

        new_count = Dao.album().count()
        assert new_count == old_count - 1

    def test_delete_by_key(self):
        old_count = Dao.album().count()

        key = Dao.album().get_first().AlbumId
        Dao.album().delete_by_key(key)

        new_count = Dao.album().count()
        assert new_count == old_count - 1

    def test_get_by_artist_Id(self):
        list = Dao.album().get_by_artistId(2)
        assert len(list) == 2
        assert all(x.ArtistId == 2 for x in list)

