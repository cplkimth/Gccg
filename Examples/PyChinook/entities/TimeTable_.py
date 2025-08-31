

from typing import List, Sequence
from entities.Entity import Entity
from models import TimeTable

# noinspection PyPep8Naming
class TimeTable_(TimeTable, Entity[TimeTable]):
    def __repr__(self):
        return f"[Time]{self.Time} , [TimeNull]{self.TimeNull} "


