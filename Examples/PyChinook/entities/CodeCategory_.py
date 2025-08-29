

from entities.Entity import Entity
from models import CodeCategory

class CodeCategory_(CodeCategory, Entity[CodeCategory]):
    def __repr__(self):
        return f"[CodeCategoryId]{self.CodeCategoryId} , [Name]{self.Name} "


