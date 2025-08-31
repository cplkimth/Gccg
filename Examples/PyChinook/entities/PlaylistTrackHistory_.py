

from typing import List, Sequence
from entities.Entity import Entity
from models import PlaylistTrackHistory

# noinspection PyPep8Naming
class PlaylistTrackHistory_(PlaylistTrackHistory, Entity[PlaylistTrackHistory]):
    def __repr__(self):
        return f"[PlaylistId]{self.PlaylistId} , [TrackId]{self.TrackId} , [WrittenAt]{self.WrittenAt} , [Memo]{self.Memo} "


