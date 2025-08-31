

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.PlaylistTrackHistory_ import PlaylistTrackHistory_
from models import PlaylistTrackHistory
from gccg.PlaylistTrackHistoryDao import PlaylistTrackHistoryDao

# noinspection PyPep8Naming
class PlaylistTrackHistoryDao_(PlaylistTrackHistoryDao):
    def _create_core(self, source: PlaylistTrackHistory_) -> None:
        pass


