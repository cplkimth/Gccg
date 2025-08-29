

from gccg.PlaylistTrackHistoryDao import PlaylistTrackHistoryDao
from models import PlaylistTrackHistory


class PlaylistTrackHistoryDao_(PlaylistTrackHistoryDao):
    def create(self) -> PlaylistTrackHistory:
        entity = PlaylistTrackHistory()
        return entity


