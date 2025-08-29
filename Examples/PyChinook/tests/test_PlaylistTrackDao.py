from datetime import datetime

from gccg.Dao import Dao
from models import PlaylistTrack


class TestAlbumDao:
    def test_exists(self):
        assert Dao.playlistTrack().exists(PlaylistTrack.PlaylistId == 1, PlaylistTrack.TrackId == 5)
        assert not Dao.playlistTrack().exists(PlaylistTrack.PlaylistId == 1, PlaylistTrack.TrackId == 0)

    def test_exists_by_key(self):
        assert Dao.playlistTrack().exists_by_key(1,5)
        assert not Dao.playlistTrack().exists_by_key(1,0)

    def test_count__all(self):
        assert Dao.playlistTrack().count() > 0

    def test_count__criteria1(self):
        assert Dao.playlistTrack().count(PlaylistTrack.PlaylistId == 2) == 4

    def test_count__criteria2(self):
        assert Dao.playlistTrack().count(PlaylistTrack.PlaylistId == 2, PlaylistTrack.TrackId < 5) == 1

    def test_count_by_key(self):
        assert Dao.playlistTrack().count_by_key(1, 5)
        # assert not Dao.playlistTrack().count_by_key(1, 0)

    def test_get_by_key(self):
        entity = Dao.playlistTrack().get_by_key(1, 5)
        assert  entity.PlaylistId == 1
        assert  entity.TrackId == 5

    def test_get_by_key__none(self):
        assert Dao.playlistTrack().get_by_key(1, 0) is None

    def test_get_first(self):
        entity = Dao.playlistTrack().get_first()
        assert entity.PlaylistId == 1
        assert entity.TrackId == 4

    def test_get_first__criteria(self):
        entity = Dao.playlistTrack().get_first(PlaylistTrack.PlaylistId > 1)
        assert entity.PlaylistId == 2
        assert entity.TrackId == 4

    def test_get_last(self):
        entity = Dao.playlistTrack().get_last()
        assert entity.PlaylistId == 2
        assert entity.TrackId == 7

    def test_get_last__criteria(self):
        entity = Dao.playlistTrack().get_last(PlaylistTrack.PlaylistId < 2)
        assert entity.PlaylistId == 1
        assert entity.TrackId == 5

    def test_get(self):
        assert len(Dao.playlistTrack().get()) == 6

    def test_get__with_1_criteria(self):
        assert len(Dao.playlistTrack().get(PlaylistTrack.TrackId == 4)) == 2

    def test_get__with_2_criteria(self):
        assert len(Dao.playlistTrack().get(PlaylistTrack.TrackId == 4, PlaylistTrack.PlaylistId == 3)) == 0

    def test_upsert__insert(self):
        old_count = Dao.playlistTrack().count()

        entity = Dao.playlistTrack().create()
        entity.PlaylistId = 1
        entity.TrackId = 7
        entity = Dao.playlistTrack().upsert(entity)

        new_count = Dao.playlistTrack().count()
        assert new_count == old_count + 1

    def test_upsert__update(self):
        first = Dao.playlistTrack().get_first()
        first.Dummy = True
        Dao.playlistTrack().upsert(first)

        first = Dao.playlistTrack().get_first()
        assert first.Dummy == True

    def test_delete(self):
        old_count = Dao.playlistTrack().count()

        entity = Dao.playlistTrack().get_by_key(2,6)
        Dao.playlistTrack().delete(entity)

        new_count = Dao.playlistTrack().count()
        assert new_count == old_count - 1

    def test_delete_by_key(self):
        old_count = Dao.playlistTrack().count()

        Dao.playlistTrack().delete_by_key(2,6)

        new_count = Dao.playlistTrack().count()
        assert new_count == old_count - 1
