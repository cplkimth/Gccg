

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.Customer_ import Customer_
from models import Customer
from gccg.CustomerDao import CustomerDao

# noinspection PyPep8Naming
class CustomerDao_(CustomerDao):
    def _create_core(self, source: Customer_) -> None:
        pass


