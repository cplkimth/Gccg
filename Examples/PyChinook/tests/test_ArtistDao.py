from datetime import datetime

from gccg.Dao import Dao
from models import Album


class TestAlbumDao:
    def test_selectin(self):
        result = Dao.artist().selectin('the')
        assert result[0].ArtistId > 0
        assert result[0].Album[0].AlbumId > 0

    def test_join(self):
        result = Dao.artist().join()
        assert len(result) > 0

    def test_column_clause(self):
        result = Dao.artist().column_clause()
        assert result[0].AlbumId > 0
        assert result[0].Title == "Money"

