

from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import Playlist


class PlaylistDao(EntityDao):
    # region override
    def _select(self):
        return select(Playlist)

    def _count(self):
        return select(func.count("*")).select_from(Playlist)

    def _by_key(self, *keys):
        return text(f"PlaylistId = {keys[0]} ")

    def _order_by(self):
        return text("PlaylistId ")

    def _order_by_desc(self):
        return text("PlaylistId desc ")

    def copy(self, source: Playlist, target: Playlist) -> None:
        
        # target.PlaylistId = source.PlaylistId 
        
        target.Name = source.Name 

    def clone(self, source: Playlist) -> Playlist:
        target = Playlist()
        self.copy(source, target)

        return target
    # endregion

    


