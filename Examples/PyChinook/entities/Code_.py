

from typing import List, Sequence
from entities.Entity import Entity
from models import Code

# noinspection PyPep8Naming
class Code_(Code, Entity[Code]):
    def __repr__(self):
        return f"[CodeId]{self.CodeId} , [CodeCategoryId]{self.CodeCategoryId} , [Memo]{self.Memo} , [Text]{self.Text} "


