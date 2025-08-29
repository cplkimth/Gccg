

from gccg.CodeDao import CodeDao
from models import Code


class CodeDao_(CodeDao):
    def create(self) -> Code:
        entity = Code()
        return entity


