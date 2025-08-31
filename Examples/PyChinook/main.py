#  sqlacodegen_v2 "mssql+pyodbc://.,3433/ChinookMP?driver=ODBC+Driver+17+for+SQL+Server&Trusted_Connection=yes" --outfile models.py
from typing import List, cast

from entities.Album_ import Album_
from gccg.AlbumDao import AlbumDao
from gccg.Dao import Dao
from models import Album

# list = Dao.artist().search()
# for x in list:
#     print(x)
#     for y in x.Album:
#         print('\t' + repr(y))

list2 = Dao.artist().join()
for x in list2:
    print(x)