

from typing import Sequence
from sqlalchemy import select, func, text, Select, TextClause
from gccg.EntityDao import EntityDao
from entities.Employee_ import Employee_
from models import Employee

class EmployeeDao(EntityDao[Employee_]):
    # region override
    def _select(self) -> Select[tuple[Employee_]]:
        return select(Employee_)

    def _count(self) -> Select[int]:
        return select(func.count("*")).select_from(Employee_)

    def _by_key(self, *keys) -> TextClause:
        return text(f"EmployeeId = {keys[0]} ")

    def _order_by(self) -> TextClause:
        return text("EmployeeId ")

    def _order_by_desc(self) -> TextClause:
        return text("EmployeeId desc ")

    def copy(self, source: Employee_, target: Employee_) -> None:
        
        # target.EmployeeId = source.EmployeeId 
        
        target.Address = source.Address 
        target.BirthDate = source.BirthDate 
        target.City = source.City 
        target.Country = source.Country 
        target.Email = source.Email 
        target.Fax = source.Fax 
        target.FirstName = source.FirstName 
        target.HireDate = source.HireDate 
        target.LastName = source.LastName 
        target.Phone = source.Phone 
        target.PostalCode = source.PostalCode 
        target.ReportsTo = source.ReportsTo 
        target.State = source.State 
        target.Title = source.Title 

    def clone(self, source: Employee_) -> Employee_:
        target = self.clone()
        self.copy(source, target)

        return target

    # endregion

    def create(self) -> Employee_:
        entity = Employee_()
        self._create_core(entity)
        return entity

    # region by foreign key
    
    def get_by_reportsTo(self, reportsTo) -> Sequence[Employee_]:
        return self.get(Employee.ReportsTo == reportsTo) 
    # endregion

