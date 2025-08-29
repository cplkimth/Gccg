

from typing import List
from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import PlaylistTrackHistory

class PlaylistTrackHistoryDao(EntityDao[PlaylistTrackHistory]):
    # region override
    def _select(self):
        return select(PlaylistTrackHistory)

    def _count(self):
        return select(func.count("*")).select_from(PlaylistTrackHistory)

    def _by_key(self, *keys):
        return text(f"PlaylistId = {keys[0]}  and TrackId = {keys[1]}  and WrittenAt = {keys[2]} ")

    def _order_by(self):
        return text("PlaylistId , TrackId , WrittenAt ")

    def _order_by_desc(self):
        return text("PlaylistId desc , TrackId desc , WrittenAt desc ")

    def copy(self, source: PlaylistTrackHistory, target: PlaylistTrackHistory) -> None:
        
        # target.PlaylistId = source.PlaylistId 
        # target.TrackId = source.TrackId 
        # target.WrittenAt = source.WrittenAt 
        
        target.Memo = source.Memo 

    def clone(self, source: PlaylistTrackHistory) -> PlaylistTrackHistory:
        target = PlaylistTrackHistory()
        self.copy(source, target)

        return target
    # endregion

    
    def get_by_playlistId(self, playlistId) -> List[PlaylistTrackHistory]:
        return self.get(PlaylistTrackHistory.PlaylistId == playlistId)
    

    def get_by_trackId(self, trackId) -> List[PlaylistTrackHistory]:
        return self.get(PlaylistTrackHistory.TrackId == trackId)
    

