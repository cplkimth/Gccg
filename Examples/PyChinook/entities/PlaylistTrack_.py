

from typing import List, Sequence
from entities.Entity import Entity
from models import PlaylistTrack

# noinspection PyPep8Naming
class PlaylistTrack_(PlaylistTrack, Entity[PlaylistTrack]):
    def __repr__(self):
        return f"[PlaylistId]{self.PlaylistId} , [TrackId]{self.TrackId} , [Dummy]{self.Dummy} "


