

from typing import List, Sequence
from sqlalchemy.orm import contains_eager, selectinload, joinedload
from gccg.Dao import Dao
from entities.Employee_ import Employee_
from models import Employee
from gccg.EmployeeDao import EmployeeDao

# noinspection PyPep8Naming
class EmployeeDao_(EmployeeDao):
    def _create_core(self, source: Employee_) -> None:
        pass


