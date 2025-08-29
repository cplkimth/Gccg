

from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import TimeTable


class TimeTableDao(EntityDao):
    # region override
    def _select(self):
        return select(TimeTable)

    def _count(self):
        return select(func.count("*")).select_from(TimeTable)

    def _by_key(self, *keys):
        return text(f"Time = {keys[0]} ")

    def _order_by(self):
        return text("Time ")

    def _order_by_desc(self):
        return text("Time desc ")

    def copy(self, source: TimeTable, target: TimeTable) -> None:
        
        # target.Time = source.Time 
        
        target.TimeNull = source.TimeNull 

    def clone(self, source: TimeTable) -> TimeTable:
        target = TimeTable()
        self.copy(source, target)

        return target
    # endregion

    


