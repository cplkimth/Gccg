

from typing import List, Sequence
from entities.Entity import Entity
from models import Artist

# noinspection PyPep8Naming
class Artist_(Artist, Entity[Artist]):
    def __repr__(self):
        return f"[ArtistId]{self.ArtistId} , [Name]{self.Name} , [TypeCode]{self.TypeCode} "


