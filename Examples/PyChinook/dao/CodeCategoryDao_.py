

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.CodeCategory_ import CodeCategory_
from models import CodeCategory
from gccg.CodeCategoryDao import CodeCategoryDao

# noinspection PyPep8Naming
class CodeCategoryDao_(CodeCategoryDao):
    def _create_core(self, source: CodeCategory_) -> None:
        pass


