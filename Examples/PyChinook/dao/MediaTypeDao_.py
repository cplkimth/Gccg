

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.MediaType_ import MediaType_
from models import MediaType
from gccg.MediaTypeDao import MediaTypeDao

# noinspection PyPep8Naming
class MediaTypeDao_(MediaTypeDao):
    def _create_core(self, source: MediaType_) -> None:
        pass


