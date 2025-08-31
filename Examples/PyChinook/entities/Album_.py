

from typing import List, Sequence
from entities.Entity import Entity
from models import Album

# noinspection PyPep8Naming
class Album_(Album, Entity[Album]):
    def __repr__(self):
        return f"[AlbumId]{self.AlbumId} , [ArtistId]{self.ArtistId} , [Title]{self.Title} , [TypeCode]{self.TypeCode} "


