using Microsoft.Data.SqlClient;

namespace Chinook.Data;

public partial class Dao
{
    public static int Initialize()
    {
        using SqlConnection connection = new(DbContextFactory.ConnectionString);
        SqlCommand command = new(
"""
SET ANSI_NULLS ON


delete PlaylistTrackHistory
delete PlaylistTrack
delete Playlist
delete TimeTable
delete DateTable
delete Code
delete CodeCategory
delete InvoiceLine
delete Invoice
delete Customer
delete Track
delete Album
delete Artist
delete MediaType
delete Genre


SET IDENTITY_INSERT [dbo].[Artist] ON 
INSERT [dbo].[Artist] ([ArtistId], [Name], [TypeCode]) VALUES (1, N'Beatles', 10000)
INSERT [dbo].[Artist] ([ArtistId], [Name], [TypeCode]) VALUES (2, N'Pink Floyd', 10001)
INSERT [dbo].[Artist] ([ArtistId], [Name], [TypeCode]) VALUES (3, N'Beatles', 10002)
INSERT [dbo].[Artist] ([ArtistId], [Name], [TypeCode]) VALUES (4, N'AC/DC', 10000)
INSERT [dbo].[Artist] ([ArtistId], [Name], [TypeCode]) VALUES (5, N'New Trolls', 10000)
INSERT [dbo].[Artist] ([ArtistId], [Name], [TypeCode]) VALUES (6, N'Led zeppelin', 10000)
SET IDENTITY_INSERT [dbo].[Artist] OFF

SET IDENTITY_INSERT [dbo].[Album] ON 
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (2, N'Money', 2, 20000)
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (3, N'The Wall', 2, 20001)
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (4, N'Let It Be', 1, 20002)
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (5, N'The White Album', 1, 20000)
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (6, N'Sgt. Pepper''s Lonely Hearts Club', 1, 20000)
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (7, N'Rubber Soul', 1, 20000)
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (8, N'Help!', 1, 20000)
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (9, N'Yellow Submarine', 1, 20000)
SET IDENTITY_INSERT [dbo].[Album] OFF

INSERT [dbo].[CodeCategory] ([CodeCategoryId], [Name]) VALUES (1, N'Artist Type')
INSERT [dbo].[CodeCategory] ([CodeCategoryId], [Name]) VALUES (2, N'Album Type')

INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (10000, 1, N'솔로', N'1')
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (10001, 1, N'아이돌', N'1')
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (10002, 1, N'밴드', N'1')
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (10003, 1, N'인디', N'1')
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (10004, 1, N'퓨전', N'1')
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (20000, 2, N'Rock', N'')
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (20001, 2, N'Jazz', N'')
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (20002, 2, N'Metal', N'')

SET IDENTITY_INSERT [dbo].[Customer] ON 
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId]) VALUES (3, N'Luís', N'nçalves', N'Embraer - Empresa Brasileira de Aeronáutica S.A.', N'Av. Brigadeiro Faria Lima, 2170', N'São José dos Campos', N'SP', N'Brazil', N'12227-000', N'+55 (12) 3923-5555', N'+55 (12) 3923-5566', N'luisg@embraer.com.br', NULL)
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId]) VALUES (4, N'Leonie', N'Köhler', N'1', N'Theodor-Heuss-Straße 34', N'Stuttgart', N'1', N'Germany', N'70174', N'+49 0711 2842222', N'1', N'leonekohler@surfeu.de', NULL)
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId]) VALUES (5, N'François', N'Tremblay', N'1', N'1498 rue Bélanger', N'Montréal', N'QC', N'Canada', N'H2G 1A7', N'+1 (514) 721-4711', N'1', N'ftremblay@gmail.com', NULL)
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId]) VALUES (6, N'Bjørn', N'Hansen', N'1', N'Ullevålsveien 14', N'Oslo', N'1', N'Norway', N'0171', N'+47 22 44 22 22', N'1', N'bjorn.hansen@yahoo.no', NULL)
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId]) VALUES (7, N'František', N'Wichterlová', N'JetBrains s.r.o.', N'Klanova 9/506', N'Prague', N'1', N'Czech Republic', N'14700', N'+420 2 4172 5555', N'+420 2 4172 5555', N'frantisekw@jetbrains.com', NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF

INSERT [dbo].[DateTable] ([Date], [DateNull]) VALUES (CAST(N'2024-06-16' AS Date), NULL)
INSERT [dbo].[DateTable] ([Date], [DateNull]) VALUES (CAST(N'2024-06-17' AS Date), CAST(N'2024-06-18' AS Date))

SET IDENTITY_INSERT [dbo].[Genre] ON 
INSERT [dbo].[Genre] ([GenreId], [Name]) VALUES (1, N'Rock')
INSERT [dbo].[Genre] ([GenreId], [Name]) VALUES (2, N'Jazz')
INSERT [dbo].[Genre] ([GenreId], [Name]) VALUES (3, N'Metal')
SET IDENTITY_INSERT [dbo].[Genre] OFF

SET IDENTITY_INSERT [dbo].[Invoice] ON 
INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total]) VALUES (4, 3, CAST(N'2021-01-01T00:00:00.000' AS DateTime), N'Theodor-Heuss-Straße 34', N'Stuttgart', N'1', N'Germany', N'70174', CAST(1.98 AS Numeric(10, 2)))
INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total]) VALUES (5, 3, CAST(N'2021-01-02T00:00:00.000' AS DateTime), N'Ullevålsveien 14', N'Oslo', N'1', N'Norway', N'0171', CAST(3.96 AS Numeric(10, 2)))
INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total]) VALUES (6, 3, CAST(N'2021-01-03T00:00:00.000' AS DateTime), N'Grétrystraat 63', N'Brussels', N'1', N'Belgium', N'1000', CAST(5.94 AS Numeric(10, 2)))
INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total]) VALUES (7, 4, CAST(N'2021-01-06T00:00:00.000' AS DateTime), N'8210 111 ST NW', N'Edmonton', N'AB', N'Canada', N'T6G 2C7', CAST(8.91 AS Numeric(10, 2)))
INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total]) VALUES (8, 4, CAST(N'2021-01-11T00:00:00.000' AS DateTime), N'69 Salem Street', N'Boston', N'MA', N'USA', N'2113', CAST(13.86 AS Numeric(10, 2)))
SET IDENTITY_INSERT [dbo].[Invoice] OFF

SET IDENTITY_INSERT [dbo].[InvoiceLine] ON 
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2241, 4, 68, CAST(0.99 AS Numeric(10, 2)), 1)
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2242, 4, 69, CAST(0.99 AS Numeric(10, 2)), 1)
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2243, 5, 70, CAST(0.99 AS Numeric(10, 2)), 1)
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2244, 5, 71, CAST(0.99 AS Numeric(10, 2)), 1)
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2245, 5, 72, CAST(0.99 AS Numeric(10, 2)), 1)
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2246, 6, 73, CAST(0.99 AS Numeric(10, 2)), 1)
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2247, 6, 74, CAST(0.99 AS Numeric(10, 2)), 1)
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2248, 7, 75, CAST(0.99 AS Numeric(10, 2)), 1)
SET IDENTITY_INSERT [dbo].[InvoiceLine] OFF

SET IDENTITY_INSERT [dbo].[MediaType] ON 
INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (1, N'MPEG audio file')
INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (2, N'Protected AAC audio file')
INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (3, N'Protected MPEG-4 video file')
INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (4, N'Purchased AAC audio file')
INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (5, N'AAC audio file')
SET IDENTITY_INSERT [dbo].[MediaType] OFF

SET IDENTITY_INSERT [dbo].[Playlist] ON 
INSERT [dbo].[Playlist] ([PlaylistId], [Name]) VALUES (1, N'Music')
INSERT [dbo].[Playlist] ([PlaylistId], [Name]) VALUES (2, N'Movies')
INSERT [dbo].[Playlist] ([PlaylistId], [Name]) VALUES (3, N'TV Shows')
SET IDENTITY_INSERT [dbo].[Playlist] OFF

INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (1, 68)
INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (1, 69)
INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (2, 2)
INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (2, 68)
INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (2, 70)
INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (2, 71)

INSERT [dbo].[PlaylistTrackHistory] ([PlaylistId], [TrackId], [WrittenAt], [Memo]) VALUES (1, 68, CAST(N'2024-06-16T16:34:36.000' AS DateTime), N'1')
INSERT [dbo].[PlaylistTrackHistory] ([PlaylistId], [TrackId], [WrittenAt], [Memo]) VALUES (1, 68, CAST(N'2024-06-17T16:34:36.000' AS DateTime), N'2')

INSERT [dbo].[TimeTable] ([Time], [TimeNull]) VALUES (CAST(N'16:33:11' AS Time), NULL)
INSERT [dbo].[TimeTable] ([Time], [TimeNull]) VALUES (CAST(N'17:33:11' AS Time), CAST(N'18:33:11' AS Time))

SET IDENTITY_INSERT [dbo].[Track] ON 
INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull], [DateOnlyCol], [TimeOnlyCol], [DateOnlyColNull], [TimeOnlyColNull], [MediaTypeId], [GenreId]) VALUES (4, N'Hey You', 3, 1, NULL, 1, NULL, 2, NULL, 3, NULL, N'4         ', NULL, N'5', NULL, N'6         ', NULL, N'7', N'', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, NULL, CAST(N'2024-06-16' AS Date), NULL, CAST(N'2024-06-16T18:19:35.147' AS DateTime), NULL, CAST(N'2024-06-16T18:20:00' AS SmallDateTime), NULL, CAST(8.00 AS Decimal(18, 2)), NULL, 9.1, NULL, 10.1, NULL, 11.1000, NULL, CAST(N'18:19:35.1466667' AS Time), NULL, N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', NULL, 0x00000000, NULL, CAST(N'2024-06-16' AS Date), CAST(N'12:12:11' AS Time), NULL, NULL, 1, 1)
INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull], [DateOnlyCol], [TimeOnlyCol], [DateOnlyColNull], [TimeOnlyColNull], [MediaTypeId], [GenreId]) VALUES (5, N'In The Fresh?', 3, 1, 1, 1, 10, 2, 20, 3, 30, N'4         ', N'40        ', N'5', N'50', N'6         ', N'60        ', N'7', N'70', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, CAST(N'2024-06-16' AS Date), CAST(N'2024-06-17' AS Date), CAST(N'2024-06-16T18:19:35.147' AS DateTime), CAST(N'2024-06-17T00:00:00.000' AS DateTime), CAST(N'2024-06-16T18:20:00' AS SmallDateTime), CAST(N'2024-06-17T00:00:00' AS SmallDateTime), CAST(8.00 AS Decimal(18, 2)), CAST(80.00 AS Decimal(18, 2)), 9.1, 9.2, 10.1, 10.2, 11.1000, 11.2000, CAST(N'18:19:35' AS Time), CAST(N'18:19:36' AS Time), N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', 0x00000000, 0x00000000, CAST(N'2024-06-16' AS Date), CAST(N'12:12:11' AS Time), CAST(N'2024-06-17' AS Date), CAST(N'12:12:12' AS Time), 1, 1)
INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull], [DateOnlyCol], [TimeOnlyCol], [DateOnlyColNull], [TimeOnlyColNull], [MediaTypeId], [GenreId]) VALUES (6, N'Across The Universe', 4, 1, NULL, 1, NULL, 2, NULL, 3, NULL, N'4         ', NULL, N'5', NULL, N'6         ', NULL, N'7', N'', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, NULL, CAST(N'2024-06-16' AS Date), NULL, CAST(N'2024-06-16T18:19:35.147' AS DateTime), NULL, CAST(N'2024-06-16T18:20:00' AS SmallDateTime), NULL, CAST(8.00 AS Decimal(18, 2)), NULL, 9.1, NULL, 10.1, NULL, 11.1000, NULL, CAST(N'18:19:35' AS Time), NULL, N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', NULL, 0x00000000, NULL, CAST(N'2024-06-16' AS Date), CAST(N'12:12:11' AS Time), NULL, NULL, 1, 1)
INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull], [DateOnlyCol], [TimeOnlyCol], [DateOnlyColNull], [TimeOnlyColNull], [MediaTypeId], [GenreId]) VALUES (7, N'I Me Mine', 4, 1, NULL, 1, NULL, 2, NULL, 3, NULL, N'4         ', NULL, N'5', NULL, N'6         ', NULL, N'7', N'', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, NULL, CAST(N'2024-06-16' AS Date), NULL, CAST(N'2024-06-16T18:19:35.147' AS DateTime), NULL, CAST(N'2024-06-16T18:20:00' AS SmallDateTime), NULL, CAST(8.00 AS Decimal(18, 2)), NULL, 9.1, NULL, 10.1, NULL, 11.1000, NULL, CAST(N'18:19:35' AS Time), NULL, N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', NULL, 0x00000000, NULL, CAST(N'2024-06-16' AS Date), CAST(N'12:12:11' AS Time), NULL, NULL, 1, 1)
SET IDENTITY_INSERT [dbo].[Track] OFF

""");
        command.Connection = connection;

        connection.Open();
        int count = command.ExecuteNonQuery();
        connection.Close();

        return count;
    }
}