

from entities.Entity import Entity
from models import Artist

class Artist_(Artist, Entity[Artist]):
    def __repr__(self):
        return f"[ArtistId]{self.ArtistId} , [Name]{self.Name} , [TypeCode]{self.TypeCode} "


