

from entities.Entity import Entity
from models import PlaylistTrackHistory

class PlaylistTrackHistory_(PlaylistTrackHistory, Entity[PlaylistTrackHistory]):
    def __repr__(self):
        return f"[PlaylistId]{self.PlaylistId} , [TrackId]{self.TrackId} , [WrittenAt]{self.WrittenAt} , [Memo]{self.Memo} "


