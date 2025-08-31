

from typing import List, Sequence
from entities.Entity import Entity
from models import InvoiceLine

# noinspection PyPep8Naming
class InvoiceLine_(InvoiceLine, Entity[InvoiceLine]):
    def __repr__(self):
        return f"[InvoiceLineId]{self.InvoiceLineId} , [InvoiceId]{self.InvoiceId} , [Quantity]{self.Quantity} , [TrackId]{self.TrackId} , [UnitPrice]{self.UnitPrice} "


