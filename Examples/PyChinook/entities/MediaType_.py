

from typing import List, Sequence
from entities.Entity import Entity
from models import MediaType

# noinspection PyPep8Naming
class MediaType_(MediaType, Entity[MediaType]):
    def __repr__(self):
        return f"[MediaTypeId]{self.MediaTypeId} , [Name]{self.Name} "


