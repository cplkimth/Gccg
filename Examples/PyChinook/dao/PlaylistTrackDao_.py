

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.PlaylistTrack_ import PlaylistTrack_
from models import PlaylistTrack
from gccg.PlaylistTrackDao import PlaylistTrackDao

# noinspection PyPep8Naming
class PlaylistTrackDao_(PlaylistTrackDao):
    def _create_core(self, source: PlaylistTrack_) -> None:
        pass


