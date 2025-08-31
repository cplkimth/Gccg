

from typing import Sequence
from sqlalchemy import select, func, text, Select, TextClause
from gccg.EntityDao import EntityDao
from entities.InvoiceLine_ import InvoiceLine_
from models import InvoiceLine

class InvoiceLineDao(EntityDao[InvoiceLine_]):
    # region override
    def _select(self) -> Select[tuple[InvoiceLine_]]:
        return select(InvoiceLine_)

    def _count(self) -> Select[int]:
        return select(func.count("*")).select_from(InvoiceLine_)

    def _by_key(self, *keys) -> TextClause:
        return text(f"InvoiceLineId = {keys[0]} ")

    def _order_by(self) -> TextClause:
        return text("InvoiceLineId ")

    def _order_by_desc(self) -> TextClause:
        return text("InvoiceLineId desc ")

    def copy(self, source: InvoiceLine_, target: InvoiceLine_) -> None:
        
        # target.InvoiceLineId = source.InvoiceLineId 
        
        target.InvoiceId = source.InvoiceId 
        target.Quantity = source.Quantity 
        target.TrackId = source.TrackId 
        target.UnitPrice = source.UnitPrice 

    def clone(self, source: InvoiceLine_) -> InvoiceLine_:
        target = self.clone()
        self.copy(source, target)

        return target

    # endregion

    def create(self) -> InvoiceLine_:
        entity = InvoiceLine_()
        self._create_core(entity)
        return entity

    # region by foreign key
    
    def get_by_invoiceId(self, invoiceId) -> Sequence[InvoiceLine_]:
        return self.get(InvoiceLine.InvoiceId == invoiceId) 
    # endregion

