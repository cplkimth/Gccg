

from typing import Sequence
from sqlalchemy import select, func, text, Select, TextClause
from gccg.EntityDao import EntityDao
from entities.PlaylistTrackHistory_ import PlaylistTrackHistory_
from models import PlaylistTrackHistory

class PlaylistTrackHistoryDao(EntityDao[PlaylistTrackHistory_]):
    # region override
    def _select(self) -> Select[tuple[PlaylistTrackHistory_]]:
        return select(PlaylistTrackHistory_)

    def _count(self) -> Select[int]:
        return select(func.count("*")).select_from(PlaylistTrackHistory_)

    def _by_key(self, *keys) -> TextClause:
        return text(f"PlaylistId = {keys[0]}  and TrackId = {keys[1]}  and WrittenAt = {keys[2]} ")

    def _order_by(self) -> TextClause:
        return text("PlaylistId , TrackId , WrittenAt ")

    def _order_by_desc(self) -> TextClause:
        return text("PlaylistId desc , TrackId desc , WrittenAt desc ")

    def copy(self, source: PlaylistTrackHistory_, target: PlaylistTrackHistory_) -> None:
        
        # target.PlaylistId = source.PlaylistId 
        # target.TrackId = source.TrackId 
        # target.WrittenAt = source.WrittenAt 
        
        target.Memo = source.Memo 

    def clone(self, source: PlaylistTrackHistory_) -> PlaylistTrackHistory_:
        target = self.clone()
        self.copy(source, target)

        return target

    # endregion

    def create(self) -> PlaylistTrackHistory_:
        entity = PlaylistTrackHistory_()
        self._create_core(entity)
        return entity

    # region by foreign key
    
    def get_by_playlistId(self, playlistId) -> Sequence[PlaylistTrackHistory_]:
        return self.get(PlaylistTrackHistory.PlaylistId == playlistId) 

    def get_by_trackId(self, trackId) -> Sequence[PlaylistTrackHistory_]:
        return self.get(PlaylistTrackHistory.TrackId == trackId) 
    # endregion

