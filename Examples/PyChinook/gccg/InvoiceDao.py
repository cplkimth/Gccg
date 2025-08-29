

from typing import List
from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import Invoice

class InvoiceDao(EntityDao[Invoice]):
    # region override
    def _select(self):
        return select(Invoice)

    def _count(self):
        return select(func.count("*")).select_from(Invoice)

    def _by_key(self, *keys):
        return text(f"InvoiceId = {keys[0]} ")

    def _order_by(self):
        return text("InvoiceId ")

    def _order_by_desc(self):
        return text("InvoiceId desc ")

    def copy(self, source: Invoice, target: Invoice) -> None:
        
        # target.InvoiceId = source.InvoiceId 
        
        target.BillingAddress = source.BillingAddress 
        target.BillingCity = source.BillingCity 
        target.BillingCountry = source.BillingCountry 
        target.BillingPostalCode = source.BillingPostalCode 
        target.BillingState = source.BillingState 
        target.CustomerId = source.CustomerId 
        target.InvoiceDate = source.InvoiceDate 
        target.Total = source.Total 

    def clone(self, source: Invoice) -> Invoice:
        target = Invoice()
        self.copy(source, target)

        return target
    # endregion

    
    def get_by_customerId(self, customerId) -> List[Invoice]:
        return self.get(Invoice.CustomerId == customerId)
    

