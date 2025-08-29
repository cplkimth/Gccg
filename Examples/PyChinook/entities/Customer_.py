

from entities.Entity import Entity
from models import Customer


class Customer_(Customer, Entity):
    def __repr__(self):
        return f"[CustomerId]{self.CustomerId} , [Address]{self.Address} , [City]{self.City} , [Company]{self.Company} , [Country]{self.Country} , [Email]{self.Email} , [Fax]{self.Fax} , [FirstName]{self.FirstName} , [LastName]{self.LastName} , [Phone]{self.Phone} , [PostalCode]{self.PostalCode} , [State]{self.State} , [SupportRepId]{self.SupportRepId} "


