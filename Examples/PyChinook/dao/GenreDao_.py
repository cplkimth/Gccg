

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.Genre_ import Genre_
from models import Genre
from gccg.GenreDao import GenreDao

# noinspection PyPep8Naming
class GenreDao_(GenreDao):
    def _create_core(self, source: Genre_) -> None:
        pass


