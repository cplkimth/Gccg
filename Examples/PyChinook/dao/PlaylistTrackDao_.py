from gccg.PlaylistTrackDao import PlaylistTrackDao
from models import PlaylistTrack


class PlaylistTrackDao_(PlaylistTrackDao):
    def create(self) -> PlaylistTrack:
        entity = PlaylistTrack()
        return entity
