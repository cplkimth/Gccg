

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.TimeTable_ import TimeTable_
from models import TimeTable
from gccg.TimeTableDao import TimeTableDao

# noinspection PyPep8Naming
class TimeTableDao_(TimeTableDao):
    def _create_core(self, source: TimeTable_) -> None:
        pass


