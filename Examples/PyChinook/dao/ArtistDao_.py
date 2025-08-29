

from gccg.ArtistDao import ArtistDao
from models import Artist


class ArtistDao_(ArtistDao):
    def create(self) -> Artist:
        entity = Artist()
        return entity


