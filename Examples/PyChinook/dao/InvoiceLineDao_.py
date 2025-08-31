

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.InvoiceLine_ import InvoiceLine_
from models import InvoiceLine
from gccg.InvoiceLineDao import InvoiceLineDao

# noinspection PyPep8Naming
class InvoiceLineDao_(InvoiceLineDao):
    def _create_core(self, source: InvoiceLine_) -> None:
        pass


