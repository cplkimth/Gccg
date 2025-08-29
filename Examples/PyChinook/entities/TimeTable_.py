

from entities.Entity import Entity
from models import TimeTable

class TimeTable_(TimeTable, Entity):
    def __repr__(self):
        return f"[Time]{self.Time} , [TimeNull]{self.TimeNull} "


