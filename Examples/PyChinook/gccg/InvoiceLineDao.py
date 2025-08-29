

from typing import List
from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import InvoiceLine

class InvoiceLineDao(EntityDao[InvoiceLine]):
    # region override
    def _select(self):
        return select(InvoiceLine)

    def _count(self):
        return select(func.count("*")).select_from(InvoiceLine)

    def _by_key(self, *keys):
        return text(f"InvoiceLineId = {keys[0]} ")

    def _order_by(self):
        return text("InvoiceLineId ")

    def _order_by_desc(self):
        return text("InvoiceLineId desc ")

    def copy(self, source: InvoiceLine, target: InvoiceLine) -> None:
        
        # target.InvoiceLineId = source.InvoiceLineId 
        
        target.InvoiceId = source.InvoiceId 
        target.Quantity = source.Quantity 
        target.TrackId = source.TrackId 
        target.UnitPrice = source.UnitPrice 

    def clone(self, source: InvoiceLine) -> InvoiceLine:
        target = InvoiceLine()
        self.copy(source, target)

        return target
    # endregion

    
    def get_by_invoiceId(self, invoiceId) -> List[InvoiceLine]:
        return self.get(InvoiceLine.InvoiceId == invoiceId)
    

