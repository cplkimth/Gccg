

from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import Album


class AlbumDao(EntityDao):
    # region override
    def _select(self):
        return select(Album)

    def _count(self):
        return select(func.count("*")).select_from(Album)

    def _by_key(self, *keys):
        return text(f"AlbumId = {keys[0]} ")

    def _order_by(self):
        return text("AlbumId ")

    def _order_by_desc(self):
        return text("AlbumId desc ")

    def copy(self, source: Album, target: Album) -> None:
        
        # target.AlbumId = source.AlbumId 
        
        target.ArtistId = source.ArtistId 
        target.Title = source.Title 
        target.TypeCode = source.TypeCode 

    def clone(self, source: Album) -> Album:
        target = Album()
        self.copy(source, target)

        return target
    # endregion

    
    def get_by_artistId(self, artistId):
        return self.get(Album.ArtistId == artistId)
    


