

from typing import Sequence
from sqlalchemy import select, func, text, Select, TextClause
from gccg.EntityDao import EntityDao
from entities.CodeCategory_ import CodeCategory_
from models import CodeCategory

class CodeCategoryDao(EntityDao[CodeCategory_]):
    # region override
    def _select(self) -> Select[tuple[CodeCategory_]]:
        return select(CodeCategory_)

    def _count(self) -> Select[int]:
        return select(func.count("*")).select_from(CodeCategory_)

    def _by_key(self, *keys) -> TextClause:
        return text(f"CodeCategoryId = {keys[0]} ")

    def _order_by(self) -> TextClause:
        return text("CodeCategoryId ")

    def _order_by_desc(self) -> TextClause:
        return text("CodeCategoryId desc ")

    def copy(self, source: CodeCategory_, target: CodeCategory_) -> None:
        
        # target.CodeCategoryId = source.CodeCategoryId 
        
        target.Name = source.Name 

    def clone(self, source: CodeCategory_) -> CodeCategory_:
        target = self.clone()
        self.copy(source, target)

        return target

    # endregion

    def create(self) -> CodeCategory_:
        entity = CodeCategory_()
        self._create_core(entity)
        return entity

    # region by foreign key
    
    # endregion

