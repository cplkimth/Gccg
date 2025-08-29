

from entities.Entity import Entity
from models import InvoiceLine

class InvoiceLine_(InvoiceLine, Entity):
    def __repr__(self):
        return f"[InvoiceLineId]{self.InvoiceLineId} , [InvoiceId]{self.InvoiceId} , [Quantity]{self.Quantity} , [TrackId]{self.TrackId} , [UnitPrice]{self.UnitPrice} "


