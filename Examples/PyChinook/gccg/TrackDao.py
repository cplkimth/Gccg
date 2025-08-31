

from typing import Sequence
from sqlalchemy import select, func, text, Select, TextClause
from gccg.EntityDao import EntityDao
from entities.Track_ import Track_
from models import Track

class TrackDao(EntityDao[Track_]):
    # region override
    def _select(self) -> Select[tuple[Track_]]:
        return select(Track_)

    def _count(self) -> Select[int]:
        return select(func.count("*")).select_from(Track_)

    def _by_key(self, *keys) -> TextClause:
        return text(f"TrackId = {keys[0]} ")

    def _order_by(self) -> TextClause:
        return text("TrackId ")

    def _order_by_desc(self) -> TextClause:
        return text("TrackId desc ")

    def copy(self, source: Track_, target: Track_) -> None:
        
        # target.TrackId = source.TrackId 
        
        target.AlbumId = source.AlbumId 
        target.BigIntCol = source.BigIntCol 
        target.BigIntColNull = source.BigIntColNull 
        target.BinaryCol = source.BinaryCol 
        target.BinaryColNull = source.BinaryColNull 
        target.BitCol = source.BitCol 
        target.BitColNull = source.BitColNull 
        target.CharCol = source.CharCol 
        target.CharColNull = source.CharColNull 
        target.DateCol = source.DateCol 
        target.DateColNull = source.DateColNull 
        target.DateOnlyCol = source.DateOnlyCol 
        target.DateOnlyColNull = source.DateOnlyColNull 
        target.DateTimeCol = source.DateTimeCol 
        target.DateTimeColNull = source.DateTimeColNull 
        target.DecimalCol = source.DecimalCol 
        target.DecimalColNull = source.DecimalColNull 
        target.FloatCol = source.FloatCol 
        target.FloatColNull = source.FloatColNull 
        target.GenreId = source.GenreId 
        target.GuidCol = source.GuidCol 
        target.GuidColNull = source.GuidColNull 
        target.MediaTypeId = source.MediaTypeId 
        target.Name = source.Name 
        target.NcharCol = source.NcharCol 
        target.NcharColNull = source.NcharColNull 
        target.NvarCharCol = source.NvarCharCol 
        target.NvarCharColNull = source.NvarCharColNull 
        target.RealCol = source.RealCol 
        target.RealColNull = source.RealColNull 
        target.SmallDateTimeCol = source.SmallDateTimeCol 
        target.SmallDateTimeColNull = source.SmallDateTimeColNull 
        target.SmallIntCol = source.SmallIntCol 
        target.SmallIntColNull = source.SmallIntColNull 
        target.SmallMoneyCol = source.SmallMoneyCol 
        target.SmallMoneyColNull = source.SmallMoneyColNull 
        target.TimeCol = source.TimeCol 
        target.TimeColNull = source.TimeColNull 
        target.TimeOnlyCol = source.TimeOnlyCol 
        target.TimeOnlyColNull = source.TimeOnlyColNull 
        target.TimestampCol = source.TimestampCol 
        target.TinyIntCol = source.TinyIntCol 
        target.TinyIntColNull = source.TinyIntColNull 
        target.VarBinaryCol = source.VarBinaryCol 
        target.VarBinaryColNull = source.VarBinaryColNull 
        target.VarCharCol = source.VarCharCol 
        target.VarCharColNull = source.VarCharColNull 

    def clone(self, source: Track_) -> Track_:
        target = self.clone()
        self.copy(source, target)

        return target

    # endregion

    def create(self) -> Track_:
        entity = Track_()
        self._create_core(entity)
        return entity

    # region by foreign key
    
    def get_by_albumId(self, albumId) -> Sequence[Track_]:
        return self.get(Track.AlbumId == albumId) 

    def get_by_genreId(self, genreId) -> Sequence[Track_]:
        return self.get(Track.GenreId == genreId) 

    def get_by_mediaTypeId(self, mediaTypeId) -> Sequence[Track_]:
        return self.get(Track.MediaTypeId == mediaTypeId) 
    # endregion

