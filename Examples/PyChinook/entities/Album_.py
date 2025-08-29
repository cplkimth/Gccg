from entities.Entity import Entity
from models import Album


class Album_(Album, Entity):
    def __repr__(self):
        return f"[AlbumId]:{self.AlbumId}, [Title]:{self.Title}, [ArtistId]:{self.ArtistId}, [TypeCode]:{self.TypeCode}"