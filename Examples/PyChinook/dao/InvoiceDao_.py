

from gccg.InvoiceDao import InvoiceDao
from models import Invoice


class InvoiceDao_(InvoiceDao):
    def create(self) -> Invoice:
        entity = Invoice()
        return entity


