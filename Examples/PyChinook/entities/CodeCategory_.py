

from typing import List, Sequence
from entities.Entity import Entity
from models import CodeCategory

# noinspection PyPep8Naming
class CodeCategory_(CodeCategory, Entity[CodeCategory]):
    def __repr__(self):
        return f"[CodeCategoryId]{self.CodeCategoryId} , [Name]{self.Name} "


