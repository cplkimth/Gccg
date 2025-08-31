

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.DateTable_ import DateTable_
from models import DateTable
from gccg.DateTableDao import DateTableDao

# noinspection PyPep8Naming
class DateTableDao_(DateTableDao):
    def _create_core(self, source: DateTable_) -> None:
        pass


