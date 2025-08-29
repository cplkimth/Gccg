

from typing import List
from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import MediaType

class MediaTypeDao(EntityDao[MediaType]):
    # region override
    def _select(self):
        return select(MediaType)

    def _count(self):
        return select(func.count("*")).select_from(MediaType)

    def _by_key(self, *keys):
        return text(f"MediaTypeId = {keys[0]} ")

    def _order_by(self):
        return text("MediaTypeId ")

    def _order_by_desc(self):
        return text("MediaTypeId desc ")

    def copy(self, source: MediaType, target: MediaType) -> None:
        
        # target.MediaTypeId = source.MediaTypeId 
        
        target.Name = source.Name 

    def clone(self, source: MediaType) -> MediaType:
        target = MediaType()
        self.copy(source, target)

        return target
    # endregion

    

