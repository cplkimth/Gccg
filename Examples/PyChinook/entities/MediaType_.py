

from entities.Entity import Entity
from models import MediaType

class MediaType_(MediaType, Entity):
    def __repr__(self):
        return f"[MediaTypeId]{self.MediaTypeId} , [Name]{self.Name} "


