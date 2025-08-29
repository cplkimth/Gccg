

from gccg.EmployeeDao import EmployeeDao
from models import Employee


class EmployeeDao_(EmployeeDao):
    def create(self) -> Employee:
        entity = Employee()
        return entity


