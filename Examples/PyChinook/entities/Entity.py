
from typing import TypeVar, Generic

T = TypeVar('T', bound='Entity[T]')

# noinspection PyPep8Naming
class Entity(Generic[T]):
    pass