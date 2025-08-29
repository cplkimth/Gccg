

from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import DateTable


class DateTableDao(EntityDao):
    # region override
    def _select(self):
        return select(DateTable)

    def _count(self):
        return select(func.count("*")).select_from(DateTable)

    def _by_key(self, *keys):
        return text(f"Date = {keys[0]} ")

    def _order_by(self):
        return text("Date ")

    def _order_by_desc(self):
        return text("Date desc ")

    def copy(self, source: DateTable, target: DateTable) -> None:
        
        # target.Date = source.Date 
        
        target.DateNull = source.DateNull 

    def clone(self, source: DateTable) -> DateTable:
        target = DateTable()
        self.copy(source, target)

        return target
    # endregion

    


