import pytest

from gccg.Dao import Dao


@pytest.fixture(scope="function", autouse=True)
# @pytest.fixture(scope="function")
def initialize():
    Dao.usp_initialize()