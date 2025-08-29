

from entities.Entity import Entity
from models import Album

class Album_(Album, Entity[Album]):
    def __repr__(self):
        return f"[AlbumId]{self.AlbumId} , [ArtistId]{self.ArtistId} , [Title]{self.Title} , [TypeCode]{self.TypeCode} "


