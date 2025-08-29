

from gccg.CodeCategoryDao import CodeCategoryDao
from models import CodeCategory


class CodeCategoryDao_(CodeCategoryDao):
    def create(self) -> CodeCategory:
        entity = CodeCategory()
        return entity


