

from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import Artist


class ArtistDao(EntityDao):
    # region override
    def _select(self):
        return select(Artist)

    def _count(self):
        return select(func.count("*")).select_from(Artist)

    def _by_key(self, *keys):
        return text(f"ArtistId = {keys[0]} ")

    def _order_by(self):
        return text("ArtistId ")

    def _order_by_desc(self):
        return text("ArtistId desc ")

    def copy(self, source: Artist, target: Artist) -> None:
        
        # target.ArtistId = source.ArtistId 
        
        target.Name = source.Name 
        target.TypeCode = source.TypeCode 

    def clone(self, source: Artist) -> Artist:
        target = Artist()
        self.copy(source, target)

        return target
    # endregion

    


