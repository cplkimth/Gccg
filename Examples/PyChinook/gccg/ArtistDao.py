

from typing import Sequence
from sqlalchemy import select, func, text, Select, TextClause
from gccg.EntityDao import EntityDao
from entities.Artist_ import Artist_
from models import Artist

class ArtistDao(EntityDao[Artist_]):
    # region override
    def _select(self) -> Select[tuple[Artist_]]:
        return select(Artist_)

    def _count(self) -> Select[int]:
        return select(func.count("*")).select_from(Artist_)

    def _by_key(self, *keys) -> TextClause:
        return text(f"ArtistId = {keys[0]} ")

    def _order_by(self) -> TextClause:
        return text("ArtistId ")

    def _order_by_desc(self) -> TextClause:
        return text("ArtistId desc ")

    def copy(self, source: Artist_, target: Artist_) -> None:
        
        # target.ArtistId = source.ArtistId 
        
        target.Name = source.Name 
        target.TypeCode = source.TypeCode 

    def clone(self, source: Artist_) -> Artist_:
        target = self.clone()
        self.copy(source, target)

        return target

    # endregion

    def create(self) -> Artist_:
        entity = Artist_()
        self._create_core(entity)
        return entity

    # region by foreign key
    
    # endregion

