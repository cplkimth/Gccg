

from typing import Sequence
from sqlalchemy import select, func, text, Select, TextClause
from gccg.EntityDao import EntityDao
from entities.PlaylistTrack_ import PlaylistTrack_
from models import PlaylistTrack

class PlaylistTrackDao(EntityDao[PlaylistTrack_]):
    # region override
    def _select(self) -> Select[tuple[PlaylistTrack_]]:
        return select(PlaylistTrack_)

    def _count(self) -> Select[int]:
        return select(func.count("*")).select_from(PlaylistTrack_)

    def _by_key(self, *keys) -> TextClause:
        return text(f"PlaylistId = {keys[0]}  and TrackId = {keys[1]} ")

    def _order_by(self) -> TextClause:
        return text("PlaylistId , TrackId ")

    def _order_by_desc(self) -> TextClause:
        return text("PlaylistId desc , TrackId desc ")

    def copy(self, source: PlaylistTrack_, target: PlaylistTrack_) -> None:
        
        # target.PlaylistId = source.PlaylistId 
        # target.TrackId = source.TrackId 
        
        target.Dummy = source.Dummy 

    def clone(self, source: PlaylistTrack_) -> PlaylistTrack_:
        target = self.clone()
        self.copy(source, target)

        return target

    # endregion

    def create(self) -> PlaylistTrack_:
        entity = PlaylistTrack_()
        self._create_core(entity)
        return entity

    # region by foreign key
    
    def get_by_playlistId(self, playlistId) -> Sequence[PlaylistTrack_]:
        return self.get(PlaylistTrack.PlaylistId == playlistId) 

    def get_by_trackId(self, trackId) -> Sequence[PlaylistTrack_]:
        return self.get(PlaylistTrack.TrackId == trackId) 
    # endregion

