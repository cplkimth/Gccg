

from entities.Entity import Entity
from models import Invoice

class Invoice_(Invoice, Entity):
    def __repr__(self):
        return f"[InvoiceId]{self.InvoiceId} , [BillingAddress]{self.BillingAddress} , [BillingCity]{self.BillingCity} , [BillingCountry]{self.BillingCountry} , [BillingPostalCode]{self.BillingPostalCode} , [BillingState]{self.BillingState} , [CustomerId]{self.CustomerId} , [InvoiceDate]{self.InvoiceDate} , [Total]{self.Total} "


