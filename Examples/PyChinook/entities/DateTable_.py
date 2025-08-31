

from typing import List, Sequence
from entities.Entity import Entity
from models import DateTable

# noinspection PyPep8Naming
class DateTable_(DateTable, Entity[DateTable]):
    def __repr__(self):
        return f"[Date]{self.Date} , [DateNull]{self.DateNull} "


