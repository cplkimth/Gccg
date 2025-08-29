

from gccg.TimeTableDao import TimeTableDao
from models import TimeTable


class TimeTableDao_(TimeTableDao):
    def create(self) -> TimeTable:
        entity = TimeTable()
        return entity


