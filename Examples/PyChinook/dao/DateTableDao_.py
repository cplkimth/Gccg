

from gccg.DateTableDao import DateTableDao
from models import DateTable


class DateTableDao_(DateTableDao):
    def create(self) -> DateTable:
        entity = DateTable()
        return entity


