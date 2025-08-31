

from typing import List, Sequence
from entities.Entity import Entity
from models import Track

# noinspection PyPep8Naming
class Track_(Track, Entity[Track]):
    def __repr__(self):
        return f"[TrackId]{self.TrackId} , [AlbumId]{self.AlbumId} , [BigIntCol]{self.BigIntCol} , [BigIntColNull]{self.BigIntColNull} , [BinaryCol]{self.BinaryCol} , [BinaryColNull]{self.BinaryColNull} , [BitCol]{self.BitCol} , [BitColNull]{self.BitColNull} , [CharCol]{self.CharCol} , [CharColNull]{self.CharColNull} , [DateCol]{self.DateCol} , [DateColNull]{self.DateColNull} , [DateOnlyCol]{self.DateOnlyCol} , [DateOnlyColNull]{self.DateOnlyColNull} , [DateTimeCol]{self.DateTimeCol} , [DateTimeColNull]{self.DateTimeColNull} , [DecimalCol]{self.DecimalCol} , [DecimalColNull]{self.DecimalColNull} , [FloatCol]{self.FloatCol} , [FloatColNull]{self.FloatColNull} , [GenreId]{self.GenreId} , [GuidCol]{self.GuidCol} , [GuidColNull]{self.GuidColNull} , [MediaTypeId]{self.MediaTypeId} , [Name]{self.Name} , [NcharCol]{self.NcharCol} , [NcharColNull]{self.NcharColNull} , [NvarCharCol]{self.NvarCharCol} , [NvarCharColNull]{self.NvarCharColNull} , [RealCol]{self.RealCol} , [RealColNull]{self.RealColNull} , [SmallDateTimeCol]{self.SmallDateTimeCol} , [SmallDateTimeColNull]{self.SmallDateTimeColNull} , [SmallIntCol]{self.SmallIntCol} , [SmallIntColNull]{self.SmallIntColNull} , [SmallMoneyCol]{self.SmallMoneyCol} , [SmallMoneyColNull]{self.SmallMoneyColNull} , [TimeCol]{self.TimeCol} , [TimeColNull]{self.TimeColNull} , [TimeOnlyCol]{self.TimeOnlyCol} , [TimeOnlyColNull]{self.TimeOnlyColNull} , [TimestampCol]{self.TimestampCol} , [TinyIntCol]{self.TinyIntCol} , [TinyIntColNull]{self.TinyIntColNull} , [VarBinaryCol]{self.VarBinaryCol} , [VarBinaryColNull]{self.VarBinaryColNull} , [VarCharCol]{self.VarCharCol} , [VarCharColNull]{self.VarCharColNull} "


