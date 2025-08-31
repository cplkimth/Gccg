

from typing import Sequence
from sqlalchemy import select, func, text, Select, TextClause
from gccg.EntityDao import EntityDao
from entities.Genre_ import Genre_
from models import Genre

class GenreDao(EntityDao[Genre_]):
    # region override
    def _select(self) -> Select[tuple[Genre_]]:
        return select(Genre_)

    def _count(self) -> Select[int]:
        return select(func.count("*")).select_from(Genre_)

    def _by_key(self, *keys) -> TextClause:
        return text(f"GenreId = {keys[0]} ")

    def _order_by(self) -> TextClause:
        return text("GenreId ")

    def _order_by_desc(self) -> TextClause:
        return text("GenreId desc ")

    def copy(self, source: Genre_, target: Genre_) -> None:
        
        # target.GenreId = source.GenreId 
        
        target.Name = source.Name 

    def clone(self, source: Genre_) -> Genre_:
        target = self.clone()
        self.copy(source, target)

        return target

    # endregion

    def create(self) -> Genre_:
        entity = Genre_()
        self._create_core(entity)
        return entity

    # region by foreign key
    
    # endregion

