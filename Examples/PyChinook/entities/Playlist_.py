

from entities.Entity import Entity
from models import Playlist

class Playlist_(Playlist, Entity):
    def __repr__(self):
        return f"[PlaylistId]{self.PlaylistId} , [Name]{self.Name} "


