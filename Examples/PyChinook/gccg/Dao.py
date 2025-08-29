
import os

from dotenv import load_dotenv
from sqlalchemy import create_engine, text
from sqlalchemy.engine import Connection
from sqlalchemy.orm import Session, sessionmaker

class Dao:
    _engine = None
    _local_session = None

    _connection_string = None
    @classmethod
    def connection_string(cls):
        if cls._connection_string is None:
            load_dotenv()
            cls._connection_string = os.environ.get('CONNECTION_STRING')

        return cls._connection_string

    @classmethod
    def _get_engine(cls):
        if cls._engine is None:
            cls._engine = create_engine(cls.connection_string(), echo=True)
            # cls._engine = create_engine(config.connection_string)
            cls._local_session = sessionmaker(bind=cls._engine)

        return cls._engine

    @classmethod
    def get_session(cls) -> Session:
        if cls._local_session is None:
            cls._local_session = sessionmaker(bind=cls._get_engine())

        return cls._local_session(expire_on_commit=False)

    @classmethod
    def get_connection(cls) -> Connection:
        return cls._get_engine().connect()

    @classmethod
    def usp_initialize(cls):
        with cls.get_session() as session:
            session.execute(text("exec usp_Initialize"))
            session.commit()


    @classmethod
    def album(cls):
        from dao.AlbumDao_ import AlbumDao_
        return AlbumDao_()


    @classmethod
    def artist(cls):
        from dao.ArtistDao_ import ArtistDao_
        return ArtistDao_()


    @classmethod
    def code(cls):
        from dao.CodeDao_ import CodeDao_
        return CodeDao_()


    @classmethod
    def codeCategory(cls):
        from dao.CodeCategoryDao_ import CodeCategoryDao_
        return CodeCategoryDao_()


    @classmethod
    def customer(cls):
        from dao.CustomerDao_ import CustomerDao_
        return CustomerDao_()


    @classmethod
    def dateTable(cls):
        from dao.DateTableDao_ import DateTableDao_
        return DateTableDao_()


    @classmethod
    def employee(cls):
        from dao.EmployeeDao_ import EmployeeDao_
        return EmployeeDao_()


    @classmethod
    def genre(cls):
        from dao.GenreDao_ import GenreDao_
        return GenreDao_()


    @classmethod
    def invoice(cls):
        from dao.InvoiceDao_ import InvoiceDao_
        return InvoiceDao_()


    @classmethod
    def invoiceLine(cls):
        from dao.InvoiceLineDao_ import InvoiceLineDao_
        return InvoiceLineDao_()


    @classmethod
    def mediaType(cls):
        from dao.MediaTypeDao_ import MediaTypeDao_
        return MediaTypeDao_()


    @classmethod
    def playlist(cls):
        from dao.PlaylistDao_ import PlaylistDao_
        return PlaylistDao_()


    @classmethod
    def playlistTrack(cls):
        from dao.PlaylistTrackDao_ import PlaylistTrackDao_
        return PlaylistTrackDao_()


    @classmethod
    def playlistTrackHistory(cls):
        from dao.PlaylistTrackHistoryDao_ import PlaylistTrackHistoryDao_
        return PlaylistTrackHistoryDao_()


    @classmethod
    def timeTable(cls):
        from dao.TimeTableDao_ import TimeTableDao_
        return TimeTableDao_()


    @classmethod
    def track(cls):
        from dao.TrackDao_ import TrackDao_
        return TrackDao_()

