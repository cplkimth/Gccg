

from typing import List
from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import CodeCategory

class CodeCategoryDao(EntityDao[CodeCategory]):
    # region override
    def _select(self):
        return select(CodeCategory)

    def _count(self):
        return select(func.count("*")).select_from(CodeCategory)

    def _by_key(self, *keys):
        return text(f"CodeCategoryId = {keys[0]} ")

    def _order_by(self):
        return text("CodeCategoryId ")

    def _order_by_desc(self):
        return text("CodeCategoryId desc ")

    def copy(self, source: CodeCategory, target: CodeCategory) -> None:
        
        # target.CodeCategoryId = source.CodeCategoryId 
        
        target.Name = source.Name 

    def clone(self, source: CodeCategory) -> CodeCategory:
        target = CodeCategory()
        self.copy(source, target)

        return target
    # endregion

    

