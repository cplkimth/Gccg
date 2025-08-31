

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.Invoice_ import Invoice_
from models import Invoice
from gccg.InvoiceDao import InvoiceDao

# noinspection PyPep8Naming
class InvoiceDao_(InvoiceDao):
    def _create_core(self, source: Invoice_) -> None:
        pass


