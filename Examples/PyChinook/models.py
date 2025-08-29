from typing import List, Optional

from sqlalchemy import BINARY, BigInteger, Boolean, CHAR, Column, DECIMAL, Date, DateTime, Float, ForeignKeyConstraint, Identity, Index, Integer, LargeBinary, NCHAR, Numeric, PrimaryKeyConstraint, SmallInteger, String, Time, Unicode, Uuid, text
from sqlalchemy.dialects.mssql import SMALLDATETIME, SMALLMONEY, TIMESTAMP, TINYINT
from sqlalchemy.orm import Mapped, declarative_base, mapped_column, relationship
from sqlalchemy.orm.base import Mapped

Base = declarative_base()


class Artist(Base):
    __tablename__ = 'Artist'
    __table_args__ = (
        PrimaryKeyConstraint('ArtistId', name='PK_Artist'),
    )

    ArtistId = mapped_column(Integer, Identity(start=1, increment=1))
    Name = mapped_column(Unicode(120, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    TypeCode = mapped_column(Integer, nullable=False, server_default=text('((0))'), comment='[1]')

    Album: Mapped[List['Album']] = relationship('Album', uselist=True, back_populates='Artist_')


class CodeCategory(Base):
    __tablename__ = 'CodeCategory'
    __table_args__ = (
        PrimaryKeyConstraint('CodeCategoryId', name='PK_CodeCategory'),
    )

    CodeCategoryId = mapped_column(Integer)
    Name = mapped_column(Unicode(50, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))

    Code: Mapped[List['Code']] = relationship('Code', uselist=True, back_populates='CodeCategory_')


class DateTable(Base):
    __tablename__ = 'DateTable'
    __table_args__ = (
        PrimaryKeyConstraint('Date', name='PK_DateTable'),
    )

    Date_ = mapped_column('Date', Date)
    DateNull = mapped_column(Date)


class Employee(Base):
    __tablename__ = 'Employee'
    __table_args__ = (
        ForeignKeyConstraint(['ReportsTo'], ['Employee.EmployeeId'], name='FK_Employee_Employee_ReportsTo'),
        PrimaryKeyConstraint('EmployeeId', name='PK_Employee')
    )

    EmployeeId = mapped_column(Integer, Identity(start=1, increment=1))
    LastName = mapped_column(Unicode(20, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    FirstName = mapped_column(Unicode(20, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    Title = mapped_column(Unicode(30, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    Address = mapped_column(Unicode(70, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    City = mapped_column(Unicode(40, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    State = mapped_column(Unicode(40, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    Country = mapped_column(Unicode(40, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    PostalCode = mapped_column(Unicode(10, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    Phone = mapped_column(Unicode(24, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    Fax = mapped_column(Unicode(24, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    Email = mapped_column(Unicode(60, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    ReportsTo = mapped_column(Integer)
    BirthDate = mapped_column(DateTime, server_default=text('(getdate())'))
    HireDate = mapped_column(DateTime, server_default=text('(getdate())'))

    Employee: Mapped[Optional['Employee']] = relationship('Employee', remote_side=[EmployeeId], back_populates='Employee_reverse')
    Employee_reverse: Mapped[List['Employee']] = relationship('Employee', uselist=True, remote_side=[ReportsTo], back_populates='Employee')
    Customer: Mapped[List['Customer']] = relationship('Customer', uselist=True, back_populates='Employee_')


class Genre(Base):
    __tablename__ = 'Genre'
    __table_args__ = (
        PrimaryKeyConstraint('GenreId', name='PK_Genre'),
    )

    GenreId = mapped_column(Integer, Identity(start=1, increment=1))
    Name = mapped_column(Unicode(120, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))

    Track: Mapped[List['Track']] = relationship('Track', uselist=True, back_populates='Genre_')


class MediaType(Base):
    __tablename__ = 'MediaType'
    __table_args__ = (
        PrimaryKeyConstraint('MediaTypeId', name='PK_MediaType'),
    )

    MediaTypeId = mapped_column(Integer, Identity(start=1, increment=1))
    Name = mapped_column(Unicode(120, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))

    Track: Mapped[List['Track']] = relationship('Track', uselist=True, back_populates='MediaType_')


class Playlist(Base):
    __tablename__ = 'Playlist'
    __table_args__ = (
        PrimaryKeyConstraint('PlaylistId', name='PK_Playlist'),
    )

    PlaylistId = mapped_column(Integer, Identity(start=1, increment=1))
    Name = mapped_column(Unicode(120, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))

    PlaylistTrack: Mapped[List['PlaylistTrack']] = relationship('PlaylistTrack', uselist=True, back_populates='Playlist_')


class TimeTable(Base):
    __tablename__ = 'TimeTable'
    __table_args__ = (
        PrimaryKeyConstraint('Time', name='PK_TimeTable'),
    )

    Time_ = mapped_column('Time', Time)
    TimeNull = mapped_column(Time)


class EFMigrationsHistory(Base):
    __tablename__ = '__EFMigrationsHistory'
    __table_args__ = (
        PrimaryKeyConstraint('MigrationId', name='PK___EFMigrationsHistory'),
    )

    MigrationId = mapped_column(Unicode(150, 'Korean_Wansung_CI_AS'))
    ProductVersion = mapped_column(Unicode(32, 'Korean_Wansung_CI_AS'), nullable=False)


class Sysdiagrams(Base):
    __tablename__ = 'sysdiagrams'
    __table_args__ = (
        PrimaryKeyConstraint('diagram_id', name='PK__sysdiagr__C2B05B619137F714'),
        Index('UK_principal_name', 'principal_id', 'name', unique=True)
    )

    name = mapped_column(Unicode(128, 'Korean_Wansung_CI_AS'), nullable=False)
    principal_id = mapped_column(Integer, nullable=False)
    diagram_id = mapped_column(Integer, Identity(start=1, increment=1))
    version = mapped_column(Integer)
    definition = mapped_column(LargeBinary)


class Album(Base):
    __tablename__ = 'Album'
    __table_args__ = (
        ForeignKeyConstraint(['ArtistId'], ['Artist.ArtistId'], ondelete='CASCADE', name='FK_Album_Artist_ArtistId'),
        PrimaryKeyConstraint('AlbumId', name='PK_Album')
    )

    AlbumId = mapped_column(Integer, Identity(start=1, increment=1))
    Title = mapped_column(Unicode(160, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    ArtistId = mapped_column(Integer, nullable=False)
    TypeCode = mapped_column(Integer, nullable=False, server_default=text('((0))'), comment='[2]')

    Artist_: Mapped['Artist'] = relationship('Artist', back_populates='Album')
    Track: Mapped[List['Track']] = relationship('Track', uselist=True, back_populates='Album_')


class Code(Base):
    __tablename__ = 'Code'
    __table_args__ = (
        ForeignKeyConstraint(['CodeCategoryId'], ['CodeCategory.CodeCategoryId'], ondelete='CASCADE', name='FK_Code_CodeCategory_CodeCategoryId'),
        PrimaryKeyConstraint('CodeId', name='PK_Code')
    )

    CodeId = mapped_column(Integer)
    CodeCategoryId = mapped_column(Integer, nullable=False)
    Text = mapped_column(Unicode(50, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    Memo = mapped_column(Unicode(1000, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))

    CodeCategory_: Mapped['CodeCategory'] = relationship('CodeCategory', back_populates='Code')


class Customer(Base):
    __tablename__ = 'Customer'
    __table_args__ = (
        ForeignKeyConstraint(['SupportRepId'], ['Employee.EmployeeId'], name='FK_Customer_Employee_SupportRepId'),
        PrimaryKeyConstraint('CustomerId', name='PK_Customer')
    )

    CustomerId = mapped_column(Integer, Identity(start=1, increment=1))
    FirstName = mapped_column(Unicode(40, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    LastName = mapped_column(Unicode(20, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    Company = mapped_column(Unicode(80, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    Address = mapped_column(Unicode(70, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    City = mapped_column(Unicode(40, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    State = mapped_column(Unicode(40, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    Country = mapped_column(Unicode(40, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    PostalCode = mapped_column(Unicode(10, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    Phone = mapped_column(Unicode(24, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    Fax = mapped_column(Unicode(24, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    Email = mapped_column(Unicode(60, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    SupportRepId = mapped_column(Integer)

    Employee_: Mapped[Optional['Employee']] = relationship('Employee', back_populates='Customer')
    Invoice: Mapped[List['Invoice']] = relationship('Invoice', uselist=True, back_populates='Customer_')


class Invoice(Base):
    __tablename__ = 'Invoice'
    __table_args__ = (
        ForeignKeyConstraint(['CustomerId'], ['Customer.CustomerId'], ondelete='CASCADE', name='FK_Invoice_Customer_CustomerId'),
        PrimaryKeyConstraint('InvoiceId', name='PK_Invoice')
    )

    InvoiceId = mapped_column(Integer, Identity(start=1, increment=1))
    CustomerId = mapped_column(Integer, nullable=False)
    InvoiceDate = mapped_column(DateTime, nullable=False, server_default=text('(getdate())'))
    BillingAddress = mapped_column(Unicode(70, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    BillingCity = mapped_column(Unicode(40, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    BillingState = mapped_column(Unicode(40, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    BillingCountry = mapped_column(Unicode(40, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    BillingPostalCode = mapped_column(Unicode(10, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    Total = mapped_column(Numeric(10, 2), nullable=False)

    Customer_: Mapped['Customer'] = relationship('Customer', back_populates='Invoice')
    InvoiceLine: Mapped[List['InvoiceLine']] = relationship('InvoiceLine', uselist=True, back_populates='Invoice_')


class Track(Base):
    __tablename__ = 'Track'
    __table_args__ = (
        ForeignKeyConstraint(['AlbumId'], ['Album.AlbumId'], ondelete='CASCADE', name='FK_TrackAlbumId'),
        ForeignKeyConstraint(['GenreId'], ['Genre.GenreId'], ondelete='CASCADE', name='FK_Track_Genre'),
        ForeignKeyConstraint(['MediaTypeId'], ['MediaType.MediaTypeId'], ondelete='CASCADE', name='FK_Track_MediaType'),
        PrimaryKeyConstraint('TrackId', name='PK_Track')
    )

    TrackId = mapped_column(Integer, Identity(start=1, increment=1))
    Name = mapped_column(Unicode(200, 'Korean_Wansung_CI_AS'), nullable=False)
    BitCol = mapped_column(Boolean, nullable=False)
    TinyIntCol = mapped_column(TINYINT, nullable=False)
    SmallIntCol = mapped_column(SmallInteger, nullable=False)
    BigIntCol = mapped_column(BigInteger, nullable=False)
    CharCol = mapped_column(CHAR(10, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    VarCharCol = mapped_column(String(50, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    NcharCol = mapped_column(NCHAR(10, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    NvarCharCol = mapped_column(Unicode(50, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    NvarCharColNull = mapped_column(Unicode(50, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("('')"))
    BinaryCol = mapped_column(BINARY(50), nullable=False, server_default=text('((0))'))
    DateCol = mapped_column(Date, nullable=False, server_default=text('(getdate())'))
    DateTimeCol = mapped_column(DateTime, nullable=False, server_default=text('(getdate())'))
    SmallDateTimeCol = mapped_column(SMALLDATETIME, nullable=False, server_default=text('(getdate())'))
    DecimalCol = mapped_column(DECIMAL(18, 2), nullable=False)
    FloatCol = mapped_column(Float(53), nullable=False)
    RealCol = mapped_column(Float(24), nullable=False)
    SmallMoneyCol = mapped_column(SMALLMONEY, nullable=False)
    TimeCol = mapped_column(Time, nullable=False, server_default=text('(getdate())'))
    GuidCol = mapped_column(Uuid, nullable=False, server_default=text('(newid())'))
    VarBinaryCol = mapped_column(LargeBinary(50), nullable=False, server_default=text('((0))'))
    DateOnlyCol = mapped_column(Date, nullable=False)
    TimeOnlyCol = mapped_column(Time, nullable=False)
    MediaTypeId = mapped_column(Integer, nullable=False, server_default=text('((1))'))
    GenreId = mapped_column(Integer, nullable=False, server_default=text('((1))'))
    AlbumId = mapped_column(Integer)
    BitColNull = mapped_column(Boolean)
    TinyIntColNull = mapped_column(TINYINT)
    SmallIntColNull = mapped_column(SmallInteger)
    BigIntColNull = mapped_column(BigInteger)
    CharColNull = mapped_column(CHAR(10, 'Korean_Wansung_CI_AS'))
    VarCharColNull = mapped_column(String(50, 'Korean_Wansung_CI_AS'))
    NcharColNull = mapped_column(NCHAR(10, 'Korean_Wansung_CI_AS'))
    BinaryColNull = mapped_column(BINARY(50))
    DateColNull = mapped_column(Date)
    DateTimeColNull = mapped_column(DateTime)
    SmallDateTimeColNull = mapped_column(SMALLDATETIME)
    DecimalColNull = mapped_column(DECIMAL(18, 2))
    FloatColNull = mapped_column(Float(53))
    RealColNull = mapped_column(Float(24))
    SmallMoneyColNull = mapped_column(SMALLMONEY)
    TimeColNull = mapped_column(Time)
    GuidColNull = mapped_column(Uuid)
    VarBinaryColNull = mapped_column(LargeBinary(50))
    DateOnlyColNull = mapped_column(Date)
    TimeOnlyColNull = mapped_column(Time)
    TimestampCol = mapped_column(TIMESTAMP)

    Album_: Mapped[Optional['Album']] = relationship('Album', back_populates='Track')
    Genre_: Mapped['Genre'] = relationship('Genre', back_populates='Track')
    MediaType_: Mapped['MediaType'] = relationship('MediaType', back_populates='Track')
    PlaylistTrack: Mapped[List['PlaylistTrack']] = relationship('PlaylistTrack', uselist=True, back_populates='Track_')


class InvoiceLine(Base):
    __tablename__ = 'InvoiceLine'
    __table_args__ = (
        ForeignKeyConstraint(['InvoiceId'], ['Invoice.InvoiceId'], ondelete='CASCADE', name='FK_InvoiceLine_Invoice_InvoiceId'),
        PrimaryKeyConstraint('InvoiceLineId', name='PK_InvoiceLine')
    )

    InvoiceLineId = mapped_column(Integer, Identity(start=1, increment=1))
    InvoiceId = mapped_column(Integer, nullable=False)
    TrackId = mapped_column(Integer, nullable=False)
    UnitPrice = mapped_column(Numeric(10, 2), nullable=False)
    Quantity = mapped_column(Integer, nullable=False)

    Invoice_: Mapped['Invoice'] = relationship('Invoice', back_populates='InvoiceLine')


class PlaylistTrack(Base):
    __tablename__ = 'PlaylistTrack'
    __table_args__ = (
        ForeignKeyConstraint(['PlaylistId'], ['Playlist.PlaylistId'], ondelete='CASCADE', name='FK_PlaylistTrack_Playlist_PlaylistId'),
        ForeignKeyConstraint(['TrackId'], ['Track.TrackId'], ondelete='CASCADE', name='FK_PlaylistTrack_Track'),
        PrimaryKeyConstraint('PlaylistId', 'TrackId', name='PK_PlaylistTrack')
    )

    PlaylistId = mapped_column(Integer, nullable=False)
    TrackId = mapped_column(Integer, nullable=False)
    Dummy = mapped_column(Boolean)

    Playlist_: Mapped['Playlist'] = relationship('Playlist', back_populates='PlaylistTrack')
    Track_: Mapped['Track'] = relationship('Track', back_populates='PlaylistTrack')
    PlaylistTrackHistory: Mapped[List['PlaylistTrackHistory']] = relationship('PlaylistTrackHistory', uselist=True, back_populates='PlaylistTrack_')


class PlaylistTrackHistory(Base):
    __tablename__ = 'PlaylistTrackHistory'
    __table_args__ = (
        ForeignKeyConstraint(['PlaylistId', 'TrackId'], ['PlaylistTrack.PlaylistId', 'PlaylistTrack.TrackId'], ondelete='CASCADE', name='FK_PlaylistTrackHistory_PlaylistTrack'),
        PrimaryKeyConstraint('PlaylistId', 'TrackId', 'WrittenAt', name='PK_PlaylistTrackHistory')
    )

    PlaylistId = mapped_column(Integer, nullable=False)
    TrackId = mapped_column(Integer, nullable=False)
    WrittenAt = mapped_column(DateTime, nullable=False)
    Memo = mapped_column(Unicode(120, 'Korean_Wansung_CI_AS'), nullable=False, server_default=text("(N'')"))

    PlaylistTrack_: Mapped['PlaylistTrack'] = relationship('PlaylistTrack', back_populates='PlaylistTrackHistory')
