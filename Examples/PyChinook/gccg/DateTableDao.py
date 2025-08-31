

from typing import Sequence
from sqlalchemy import select, func, text, Select, TextClause
from gccg.EntityDao import EntityDao
from entities.DateTable_ import DateTable_
from models import DateTable

class DateTableDao(EntityDao[DateTable_]):
    # region override
    def _select(self) -> Select[tuple[DateTable_]]:
        return select(DateTable_)

    def _count(self) -> Select[int]:
        return select(func.count("*")).select_from(DateTable_)

    def _by_key(self, *keys) -> TextClause:
        return text(f"Date = {keys[0]} ")

    def _order_by(self) -> TextClause:
        return text("Date ")

    def _order_by_desc(self) -> TextClause:
        return text("Date desc ")

    def copy(self, source: DateTable_, target: DateTable_) -> None:
        
        # target.Date = source.Date 
        
        target.DateNull = source.DateNull 

    def clone(self, source: DateTable_) -> DateTable_:
        target = self.clone()
        self.copy(source, target)

        return target

    # endregion

    def create(self) -> DateTable_:
        entity = DateTable_()
        self._create_core(entity)
        return entity

    # region by foreign key
    
    # endregion

