

from sqlalchemy import select, func, text
from gccg.EntityDao import EntityDao
from models import Customer


class CustomerDao(EntityDao):
    # region override
    def _select(self):
        return select(Customer)

    def _count(self):
        return select(func.count("*")).select_from(Customer)

    def _by_key(self, *keys):
        return text(f"CustomerId = {keys[0]} ")

    def _order_by(self):
        return text("CustomerId ")

    def _order_by_desc(self):
        return text("CustomerId desc ")

    def copy(self, source: Customer, target: Customer) -> None:
        
        # target.CustomerId = source.CustomerId 
        
        target.Address = source.Address 
        target.City = source.City 
        target.Company = source.Company 
        target.Country = source.Country 
        target.Email = source.Email 
        target.Fax = source.Fax 
        target.FirstName = source.FirstName 
        target.LastName = source.LastName 
        target.Phone = source.Phone 
        target.PostalCode = source.PostalCode 
        target.State = source.State 
        target.SupportRepId = source.SupportRepId 

    def clone(self, source: Customer) -> Customer:
        target = Customer()
        self.copy(source, target)

        return target
    # endregion

    
    def get_by_supportRepId(self, supportRepId):
        return self.get(Customer.SupportRepId == supportRepId)
    


