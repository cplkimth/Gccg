

from typing import List
from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import Employee

class EmployeeDao(EntityDao[Employee]):
    # region override
    def _select(self):
        return select(Employee)

    def _count(self):
        return select(func.count("*")).select_from(Employee)

    def _by_key(self, *keys):
        return text(f"EmployeeId = {keys[0]} ")

    def _order_by(self):
        return text("EmployeeId ")

    def _order_by_desc(self):
        return text("EmployeeId desc ")

    def copy(self, source: Employee, target: Employee) -> None:
        
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

    def clone(self, source: Employee) -> Employee:
        target = Employee()
        self.copy(source, target)

        return target
    # endregion

    
    def get_by_reportsTo(self, reportsTo) -> List[Employee]:
        return self.get(Employee.ReportsTo == reportsTo)
    

