

from entities.Entity import Entity
from models import DateTable

class DateTable_(DateTable, Entity):
    def __repr__(self):
        return f"[Date]{self.Date} , [DateNull]{self.DateNull} "


