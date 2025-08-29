from entities.Entity import Entity
from models import PlaylistTrack


class PlaylistTrack_(PlaylistTrack, Entity):
    def __repr__(self):
        return f"[PlaylistId]:{self.PlaylistId}, [TrackId]:{self.TrackId}, [Dummy]:{self.Dummy}"