

from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import Track


class TrackDao(EntityDao):
    # region override
    def _select(self):
        return select(Track)

    def _count(self):
        return select(func.count("*")).select_from(Track)

    def _by_key(self, *keys):
        return text(f"TrackId = {keys[0]} ")

    def _order_by(self):
        return text("TrackId ")

    def _order_by_desc(self):
        return text("TrackId desc ")

    def copy(self, source: Track, target: Track) -> None:
        
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

    def clone(self, source: Track) -> Track:
        target = Track()
        self.copy(source, target)

        return target
    # endregion

    
    def get_by_albumId(self, albumId):
        return self.get(Track.AlbumId == albumId)
    

    def get_by_genreId(self, genreId):
        return self.get(Track.GenreId == genreId)
    

    def get_by_mediaTypeId(self, mediaTypeId):
        return self.get(Track.MediaTypeId == mediaTypeId)
    


