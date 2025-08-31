

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.Album_ import Album_
from models import Album
from gccg.AlbumDao import AlbumDao

# noinspection PyPep8Naming
class AlbumDao_(AlbumDao):
    def _create_core(self, source: Album_) -> None:
        pass


