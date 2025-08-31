

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.Track_ import Track_
from models import Track
from gccg.TrackDao import TrackDao

# noinspection PyPep8Naming
class TrackDao_(TrackDao):
    def _create_core(self, source: Track_) -> None:
        pass


