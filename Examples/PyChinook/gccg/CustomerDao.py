

from typing import Sequence
from sqlalchemy import select, func, text, Select, TextClause
from gccg.EntityDao import EntityDao
from entities.Customer_ import Customer_
from models import Customer

class CustomerDao(EntityDao[Customer_]):
    # region override
    def _select(self) -> Select[tuple[Customer_]]:
        return select(Customer_)

    def _count(self) -> Select[int]:
        return select(func.count("*")).select_from(Customer_)

    def _by_key(self, *keys) -> TextClause:
        return text(f"CustomerId = {keys[0]} ")

    def _order_by(self) -> TextClause:
        return text("CustomerId ")

    def _order_by_desc(self) -> TextClause:
        return text("CustomerId desc ")

    def copy(self, source: Customer_, target: Customer_) -> None:
        
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

    def clone(self, source: Customer_) -> Customer_:
        target = self.clone()
        self.copy(source, target)

        return target

    # endregion

    def create(self) -> Customer_:
        entity = Customer_()
        self._create_core(entity)
        return entity

    # region by foreign key
    
    def get_by_supportRepId(self, supportRepId) -> Sequence[Customer_]:
        return self.get(Customer.SupportRepId == supportRepId) 
    # endregion

