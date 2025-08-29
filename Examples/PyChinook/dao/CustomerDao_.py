

from gccg.CustomerDao import CustomerDao
from models import Customer


class CustomerDao_(CustomerDao):
    def create(self) -> Customer:
        entity = Customer()
        return entity


