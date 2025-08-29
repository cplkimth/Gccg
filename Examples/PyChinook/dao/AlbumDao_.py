from gccg.AlbumDao import AlbumDao
from models import Album


class AlbumDao_(AlbumDao):
    def create(self) -> Album:
        entity = Album()
        return entity
