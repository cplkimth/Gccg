

from entities.Entity import Entity
from models import Employee

class Employee_(Employee, Entity):
    def __repr__(self):
        return f"[EmployeeId]{self.EmployeeId} , [Address]{self.Address} , [BirthDate]{self.BirthDate} , [City]{self.City} , [Country]{self.Country} , [Email]{self.Email} , [Fax]{self.Fax} , [FirstName]{self.FirstName} , [HireDate]{self.HireDate} , [LastName]{self.LastName} , [Phone]{self.Phone} , [PostalCode]{self.PostalCode} , [ReportsTo]{self.ReportsTo} , [State]{self.State} , [Title]{self.Title} "


