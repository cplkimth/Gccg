

from gccg.GenreDao import GenreDao
from models import Genre


class GenreDao_(GenreDao):
    def create(self) -> Genre:
        entity = Genre()
        return entity


