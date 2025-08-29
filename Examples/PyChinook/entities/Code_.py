

from entities.Entity import Entity
from models import Code

class Code_(Code, Entity[Code]):
    def __repr__(self):
        return f"[CodeId]{self.CodeId} , [CodeCategoryId]{self.CodeCategoryId} , [Memo]{self.Memo} , [Text]{self.Text} "


