

from typing import Sequence
from sqlalchemy import select, func, text, Select, TextClause
from gccg.EntityDao import EntityDao
from entities.TimeTable_ import TimeTable_
from models import TimeTable

class TimeTableDao(EntityDao[TimeTable_]):
    # region override
    def _select(self) -> Select[tuple[TimeTable_]]:
        return select(TimeTable_)

    def _count(self) -> Select[int]:
        return select(func.count("*")).select_from(TimeTable_)

    def _by_key(self, *keys) -> TextClause:
        return text(f"Time = {keys[0]} ")

    def _order_by(self) -> TextClause:
        return text("Time ")

    def _order_by_desc(self) -> TextClause:
        return text("Time desc ")

    def copy(self, source: TimeTable_, target: TimeTable_) -> None:
        
        # target.Time = source.Time 
        
        target.TimeNull = source.TimeNull 

    def clone(self, source: TimeTable_) -> TimeTable_:
        target = self.clone()
        self.copy(source, target)

        return target

    # endregion

    def create(self) -> TimeTable_:
        entity = TimeTable_()
        self._create_core(entity)
        return entity

    # region by foreign key
    
    # endregion

