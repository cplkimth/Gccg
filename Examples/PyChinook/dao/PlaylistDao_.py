

from gccg.PlaylistDao import PlaylistDao
from models import Playlist


class PlaylistDao_(PlaylistDao):
    def create(self) -> Playlist:
        entity = Playlist()
        return entity


