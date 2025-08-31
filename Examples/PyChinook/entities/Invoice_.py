

from typing import List, Sequence
from entities.Entity import Entity
from models import Invoice

# noinspection PyPep8Naming
class Invoice_(Invoice, Entity[Invoice]):
    def __repr__(self):
        return f"[InvoiceId]{self.InvoiceId} , [BillingAddress]{self.BillingAddress} , [BillingCity]{self.BillingCity} , [BillingCountry]{self.BillingCountry} , [BillingPostalCode]{self.BillingPostalCode} , [BillingState]{self.BillingState} , [CustomerId]{self.CustomerId} , [InvoiceDate]{self.InvoiceDate} , [Total]{self.Total} "


