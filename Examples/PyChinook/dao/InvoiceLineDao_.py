

from gccg.InvoiceLineDao import InvoiceLineDao
from models import InvoiceLine


class InvoiceLineDao_(InvoiceLineDao):
    def create(self) -> InvoiceLine:
        entity = InvoiceLine()
        return entity


