

from gccg.TrackDao import TrackDao
from models import Track


class TrackDao_(TrackDao):
    def create(self) -> Track:
        entity = Track()
        return entity


