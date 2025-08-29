

from entities.Entity import Entity
from models import Genre

class Genre_(Genre, Entity):
    def __repr__(self):
        return f"[GenreId]{self.GenreId} , [Name]{self.Name} "


