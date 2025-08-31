

from typing import Sequence
from sqlalchemy import select, func, text, Select, TextClause
from gccg.EntityDao import EntityDao
from entities.Code_ import Code_
from models import Code

class CodeDao(EntityDao[Code_]):
    # region override
    def _select(self) -> Select[tuple[Code_]]:
        return select(Code_)

    def _count(self) -> Select[int]:
        return select(func.count("*")).select_from(Code_)

    def _by_key(self, *keys) -> TextClause:
        return text(f"CodeId = {keys[0]} ")

    def _order_by(self) -> TextClause:
        return text("CodeId ")

    def _order_by_desc(self) -> TextClause:
        return text("CodeId desc ")

    def copy(self, source: Code_, target: Code_) -> None:
        
        # target.CodeId = source.CodeId 
        
        target.CodeCategoryId = source.CodeCategoryId 
        target.Memo = source.Memo 
        target.Text = source.Text 

    def clone(self, source: Code_) -> Code_:
        target = self.clone()
        self.copy(source, target)

        return target

    # endregion

    def create(self) -> Code_:
        entity = Code_()
        self._create_core(entity)
        return entity

    # region by foreign key
    
    def get_by_codeCategoryId(self, codeCategoryId) -> Sequence[Code_]:
        return self.get(Code.CodeCategoryId == codeCategoryId) 
    # endregion

