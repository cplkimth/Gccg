

from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import PlaylistTrack


class PlaylistTrackDao(EntityDao):
    # region override
    def _select(self):
        return select(PlaylistTrack)

    def _count(self):
        return select(func.count("*")).select_from(PlaylistTrack)

    def _by_key(self, *keys):
        return text(f"PlaylistId = {keys[0]}  and TrackId = {keys[1]} ")

    def _order_by(self):
        return text("PlaylistId , TrackId ")

    def _order_by_desc(self):
        return text("PlaylistId desc , TrackId desc ")

    def copy(self, source: PlaylistTrack, target: PlaylistTrack) -> None:
        
        # target.PlaylistId = source.PlaylistId 
        # target.TrackId = source.TrackId 
        
        target.Dummy = source.Dummy 

    def clone(self, source: PlaylistTrack) -> PlaylistTrack:
        target = PlaylistTrack()
        self.copy(source, target)

        return target
    # endregion

    
    def get_by_playlistId(self, playlistId):
        return self.get(PlaylistTrack.PlaylistId == playlistId)
    

    def get_by_trackId(self, trackId):
        return self.get(PlaylistTrack.TrackId == trackId)
    


