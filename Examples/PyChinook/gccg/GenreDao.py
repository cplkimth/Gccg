

from typing import List
from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import Genre

class GenreDao(EntityDao[Genre]):
    # region override
    def _select(self):
        return select(Genre)

    def _count(self):
        return select(func.count("*")).select_from(Genre)

    def _by_key(self, *keys):
        return text(f"GenreId = {keys[0]} ")

    def _order_by(self):
        return text("GenreId ")

    def _order_by_desc(self):
        return text("GenreId desc ")

    def copy(self, source: Genre, target: Genre) -> None:
        
        # target.GenreId = source.GenreId 
        
        target.Name = source.Name 

    def clone(self, source: Genre) -> Genre:
        target = Genre()
        self.copy(source, target)

        return target
    # endregion

    

