

from typing import List, Sequence
from entities.Entity import Entity
from models import Playlist

# noinspection PyPep8Naming
class Playlist_(Playlist, Entity[Playlist]):
    def __repr__(self):
        return f"[PlaylistId]{self.PlaylistId} , [Name]{self.Name} "


