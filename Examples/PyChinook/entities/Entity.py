
from typing import TypeVar, Generic

T = TypeVar('T', bound='Entity[T]')

class Entity(Generic[T]):
    pass