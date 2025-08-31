

from typing import Sequence
from sqlalchemy import select, func, text, Select, TextClause
from gccg.EntityDao import EntityDao
from entities.Invoice_ import Invoice_
from models import Invoice

class InvoiceDao(EntityDao[Invoice_]):
    # region override
    def _select(self) -> Select[tuple[Invoice_]]:
        return select(Invoice_)

    def _count(self) -> Select[int]:
        return select(func.count("*")).select_from(Invoice_)

    def _by_key(self, *keys) -> TextClause:
        return text(f"InvoiceId = {keys[0]} ")

    def _order_by(self) -> TextClause:
        return text("InvoiceId ")

    def _order_by_desc(self) -> TextClause:
        return text("InvoiceId desc ")

    def copy(self, source: Invoice_, target: Invoice_) -> None:
        
        # target.InvoiceId = source.InvoiceId 
        
        target.BillingAddress = source.BillingAddress 
        target.BillingCity = source.BillingCity 
        target.BillingCountry = source.BillingCountry 
        target.BillingPostalCode = source.BillingPostalCode 
        target.BillingState = source.BillingState 
        target.CustomerId = source.CustomerId 
        target.InvoiceDate = source.InvoiceDate 
        target.Total = source.Total 

    def clone(self, source: Invoice_) -> Invoice_:
        target = self.clone()
        self.copy(source, target)

        return target

    # endregion

    def create(self) -> Invoice_:
        entity = Invoice_()
        self._create_core(entity)
        return entity

    # region by foreign key
    
    def get_by_customerId(self, customerId) -> Sequence[Invoice_]:
        return self.get(Invoice.CustomerId == customerId) 
    # endregion

