

from typing import Sequence
from sqlalchemy import select, func, text, Select, TextClause
from gccg.EntityDao import EntityDao
from entities.Album_ import Album_
from models import Album

class AlbumDao(EntityDao[Album_]):
    # region override
    def _select(self) -> Select[tuple[Album_]]:
        return select(Album_)

    def _count(self) -> Select[int]:
        return select(func.count("*")).select_from(Album_)

    def _by_key(self, *keys) -> TextClause:
        return text(f"AlbumId = {keys[0]} ")

    def _order_by(self) -> TextClause:
        return text("AlbumId ")

    def _order_by_desc(self) -> TextClause:
        return text("AlbumId desc ")

    def copy(self, source: Album_, target: Album_) -> None:
        
        # target.AlbumId = source.AlbumId 
        
        target.ArtistId = source.ArtistId 
        target.Title = source.Title 
        target.TypeCode = source.TypeCode 

    def clone(self, source: Album_) -> Album_:
        target = self.clone()
        self.copy(source, target)

        return target

    # endregion

    def create(self) -> Album_:
        entity = Album_()
        self._create_core(entity)
        return entity

    # region by foreign key
    
    def get_by_artistId(self, artistId) -> Sequence[Album_]:
        return self.get(Album.ArtistId == artistId) 
    # endregion

