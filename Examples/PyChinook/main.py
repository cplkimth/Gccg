#  sqlacodegen_v2 "mssql+pyodbc://.,3433/ChinookMP?driver=ODBC+Driver+17+for+SQL+Server&Trusted_Connection=yes" --outfile models.py
from gccg.AlbumDao import AlbumDao
from gccg.Dao import Dao
from models import Album

print(Dao.album().count())