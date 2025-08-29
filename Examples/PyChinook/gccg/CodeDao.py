

from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import Code


class CodeDao(EntityDao):
    # region override
    def _select(self):
        return select(Code)

    def _count(self):
        return select(func.count("*")).select_from(Code)

    def _by_key(self, *keys):
        return text(f"CodeId = {keys[0]} ")

    def _order_by(self):
        return text("CodeId ")

    def _order_by_desc(self):
        return text("CodeId desc ")

    def copy(self, source: Code, target: Code) -> None:
        
        # target.CodeId = source.CodeId 
        
        target.CodeCategoryId = source.CodeCategoryId 
        target.Memo = source.Memo 
        target.Text = source.Text 

    def clone(self, source: Code) -> Code:
        target = Code()
        self.copy(source, target)

        return target
    # endregion

    
    def get_by_codeCategoryId(self, codeCategoryId):
        return self.get(Code.CodeCategoryId == codeCategoryId)
    


