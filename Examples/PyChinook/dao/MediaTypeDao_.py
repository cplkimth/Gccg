

from gccg.MediaTypeDao import MediaTypeDao
from models import MediaType


class MediaTypeDao_(MediaTypeDao):
    def create(self) -> MediaType:
        entity = MediaType()
        return entity


