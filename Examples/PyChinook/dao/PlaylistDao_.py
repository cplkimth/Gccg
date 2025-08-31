

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.Playlist_ import Playlist_
from models import Playlist
from gccg.PlaylistDao import PlaylistDao

# noinspection PyPep8Naming
class PlaylistDao_(PlaylistDao):
    def _create_core(self, source: Playlist_) -> None:
        pass


