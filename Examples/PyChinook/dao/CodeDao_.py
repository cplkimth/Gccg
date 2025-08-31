

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.Code_ import Code_
from models import Code
from gccg.CodeDao import CodeDao

# noinspection PyPep8Naming
class CodeDao_(CodeDao):
    def _create_core(self, source: Code_) -> None:
        pass


