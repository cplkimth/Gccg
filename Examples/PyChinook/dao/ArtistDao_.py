

from typing import List, Sequence, Any

from sqlalchemy import text, select
from sqlalchemy.orm import contains_eager, selectinload, joinedload, aliased
from gccg.Dao import Dao
from entities.Artist_ import Artist_
from models import Artist, Album
from gccg.ArtistDao import ArtistDao

# noinspection PyPep8Naming
class ArtistDao_(ArtistDao):
    def _create_core(self, source: Artist_) -> None:
        pass

    def selectin(self, keyword: str) -> list[type[Artist]]:
        with (Dao.get_session() as session):
            query = (
                session.query(Artist)
                .options(selectinload(Artist.Album))
                .where(Artist.Album.any(
                    Album.Title.like(F'%{keyword}%')
                ))
            )

            return query.all()

    def join(self) -> list[type[(int, int)]]:
        with (Dao.get_session() as session):
            query = (
                session.query(Artist.ArtistId, Album.AlbumId)
                .join(Artist.Album)
                .where((Artist.ArtistId + Album.AlbumId) < 5)
            )

            return query.all()

    def column_clause(self) -> list[type[(int, str)]]:
        with (Dao.get_session() as session):
            textual_sql = text("select AlbumId, Title from dbo.Album order by AlbumId")
            textual_sql = textual_sql.columns(Album.AlbumId, Album.Title)
            orm_sql = select(Album).from_statement(textual_sql)
            return session.execute(orm_sql).scalars().all()

