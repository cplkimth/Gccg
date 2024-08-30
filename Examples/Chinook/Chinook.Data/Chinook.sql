USE [master]
GO
/****** Object:  Database [ChinookMP]    Script Date: 2024-08-30 오전 12:47:01 ******/
CREATE DATABASE [ChinookMP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChinookOriginal', FILENAME = N'h:\MSSQL15.MSSQLSERVER\MSSQL\DATA\ChinookMP.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChinookOriginal_log', FILENAME = N'h:\MSSQL15.MSSQLSERVER\MSSQL\DATA\ChinookMP_log.ldf' , SIZE = 991232KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ChinookMP] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChinookMP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChinookMP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChinookMP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChinookMP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChinookMP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChinookMP] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChinookMP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChinookMP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChinookMP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChinookMP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChinookMP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChinookMP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChinookMP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChinookMP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChinookMP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChinookMP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChinookMP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChinookMP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChinookMP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChinookMP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChinookMP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChinookMP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChinookMP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChinookMP] SET RECOVERY FULL 
GO
ALTER DATABASE [ChinookMP] SET  MULTI_USER 
GO
ALTER DATABASE [ChinookMP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChinookMP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChinookMP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChinookMP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ChinookMP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ChinookMP] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ChinookMP', N'ON'
GO
ALTER DATABASE [ChinookMP] SET QUERY_STORE = OFF
GO
USE [ChinookMP]
GO
/****** Object:  User [me]    Script Date: 2024-08-30 오전 12:47:01 ******/
CREATE USER [me] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [Chinook]    Script Date: 2024-08-30 오전 12:47:01 ******/
CREATE USER [Chinook] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [me]
GO
ALTER ROLE [db_owner] ADD MEMBER [Chinook]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](160) NOT NULL,
	[ArtistId] [int] NOT NULL,
	[TypeCode] [int] NOT NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](120) NOT NULL,
	[TypeCode] [int] NOT NULL,
 CONSTRAINT [PK_Artist] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Code]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Code](
	[CodeId] [int] NOT NULL,
	[CodeCategoryId] [int] NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Code] PRIMARY KEY CLUSTERED 
(
	[CodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CodeCategory]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CodeCategory](
	[CodeCategoryId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CodeCategory] PRIMARY KEY CLUSTERED 
(
	[CodeCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](40) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Company] [nvarchar](80) NOT NULL,
	[Address] [nvarchar](70) NOT NULL,
	[City] [nvarchar](40) NOT NULL,
	[State] [nvarchar](40) NOT NULL,
	[Country] [nvarchar](40) NOT NULL,
	[PostalCode] [nvarchar](10) NOT NULL,
	[Phone] [nvarchar](24) NOT NULL,
	[Fax] [nvarchar](24) NOT NULL,
	[Email] [nvarchar](60) NOT NULL,
	[SupportRepId] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DateTable]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DateTable](
	[Date] [date] NOT NULL,
	[DateNull] [date] NULL,
 CONSTRAINT [PK_DateTable] PRIMARY KEY CLUSTERED 
(
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[Title] [nvarchar](30) NOT NULL,
	[ReportsTo] [int] NULL,
	[BirthDate] [datetime] NULL,
	[HireDate] [datetime] NULL,
	[Address] [nvarchar](70) NOT NULL,
	[City] [nvarchar](40) NOT NULL,
	[State] [nvarchar](40) NOT NULL,
	[Country] [nvarchar](40) NOT NULL,
	[PostalCode] [nvarchar](10) NOT NULL,
	[Phone] [nvarchar](24) NOT NULL,
	[Fax] [nvarchar](24) NOT NULL,
	[Email] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](120) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[BillingAddress] [nvarchar](70) NOT NULL,
	[BillingCity] [nvarchar](40) NOT NULL,
	[BillingState] [nvarchar](40) NOT NULL,
	[BillingCountry] [nvarchar](40) NOT NULL,
	[BillingPostalCode] [nvarchar](10) NOT NULL,
	[Total] [numeric](10, 2) NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceLine]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceLine](
	[InvoiceLineId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[TrackId] [int] NOT NULL,
	[UnitPrice] [numeric](10, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceLine] PRIMARY KEY CLUSTERED 
(
	[InvoiceLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MediaType]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaType](
	[MediaTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](120) NOT NULL,
 CONSTRAINT [PK_MediaType] PRIMARY KEY CLUSTERED 
(
	[MediaTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlist](
	[PlaylistId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](120) NOT NULL,
 CONSTRAINT [PK_Playlist] PRIMARY KEY CLUSTERED 
(
	[PlaylistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaylistTrack]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaylistTrack](
	[PlaylistId] [int] NOT NULL,
	[TrackId] [int] NOT NULL,
 CONSTRAINT [PK_PlaylistTrack] PRIMARY KEY CLUSTERED 
(
	[PlaylistId] ASC,
	[TrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaylistTrackHistory]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaylistTrackHistory](
	[PlaylistId] [int] NOT NULL,
	[TrackId] [int] NOT NULL,
	[WrittenAt] [datetime] NOT NULL,
	[Memo] [nvarchar](120) NOT NULL,
 CONSTRAINT [PK_PlaylistTrackHistory] PRIMARY KEY CLUSTERED 
(
	[PlaylistId] ASC,
	[TrackId] ASC,
	[WrittenAt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeTable]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTable](
	[Time] [time](7) NOT NULL,
	[TimeNull] [time](7) NULL,
 CONSTRAINT [PK_TimeTable] PRIMARY KEY CLUSTERED 
(
	[Time] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Track]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track](
	[TrackId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[AlbumId] [int] NULL,
	[BitCol] [bit] NOT NULL,
	[BitColNull] [bit] NULL,
	[TinyIntCol] [tinyint] NOT NULL,
	[TinyIntColNull] [tinyint] NULL,
	[SmallIntCol] [smallint] NOT NULL,
	[SmallIntColNull] [smallint] NULL,
	[BigIntCol] [bigint] NOT NULL,
	[BigIntColNull] [bigint] NULL,
	[CharCol] [char](10) NOT NULL,
	[CharColNull] [char](10) NULL,
	[VarCharCol] [varchar](50) NOT NULL,
	[VarCharColNull] [varchar](50) NULL,
	[NcharCol] [nchar](10) NOT NULL,
	[NcharColNull] [nchar](10) NULL,
	[NvarCharCol] [nvarchar](50) NOT NULL,
	[NvarCharColNull] [nvarchar](50) NOT NULL,
	[BinaryCol] [binary](50) NOT NULL,
	[BinaryColNull] [binary](50) NULL,
	[DateCol] [date] NOT NULL,
	[DateColNull] [date] NULL,
	[DateTimeCol] [datetime] NOT NULL,
	[DateTimeColNull] [datetime] NULL,
	[SmallDateTimeCol] [smalldatetime] NOT NULL,
	[SmallDateTimeColNull] [smalldatetime] NULL,
	[DecimalCol] [decimal](18, 2) NOT NULL,
	[DecimalColNull] [decimal](18, 2) NULL,
	[FloatCol] [float] NOT NULL,
	[FloatColNull] [float] NULL,
	[RealCol] [real] NOT NULL,
	[RealColNull] [real] NULL,
	[SmallMoneyCol] [smallmoney] NOT NULL,
	[SmallMoneyColNull] [smallmoney] NULL,
	[TimeCol] [time](7) NOT NULL,
	[TimeColNull] [time](7) NULL,
	[GuidCol] [uniqueidentifier] NOT NULL,
	[GuidColNull] [uniqueidentifier] NULL,
	[VarBinaryCol] [varbinary](50) NOT NULL,
	[VarBinaryColNull] [varbinary](50) NULL,
	[DateOnlyCol] [date] NOT NULL,
	[TimeOnlyCol] [time](7) NOT NULL,
	[DateOnlyColNull] [date] NULL,
	[TimeOnlyColNull] [time](7) NULL,
	[MediaTypeId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
	[TimestampCol] [timestamp] NULL,
 CONSTRAINT [PK_Track] PRIMARY KEY CLUSTERED 
(
	[TrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240615133416_1', N'8.0.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240615133522_2', N'8.0.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240615134149_3', N'8.0.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240615134909_4', N'8.0.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240615140849_5', N'8.0.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240615141802_6', N'8.0.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240615143111_7', N'8.0.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240615143416_8', N'8.0.6')
GO
SET IDENTITY_INSERT [dbo].[Album] ON 
GO
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (2, N'Money', 2, 20000)
GO
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (3, N'The Wall', 2, 20001)
GO
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (4, N'Let It Be', 1, 20002)
GO
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (5, N'The White Album', 1, 20000)
GO
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (6, N'Sgt. Pepper''s Lonely Hearts Club', 1, 20000)
GO
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (7, N'Rubber Soul', 1, 20000)
GO
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (8, N'Help!', 1, 20000)
GO
INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (9, N'Yellow Submarine', 1, 20000)
GO
SET IDENTITY_INSERT [dbo].[Album] OFF
GO
SET IDENTITY_INSERT [dbo].[Artist] ON 
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [TypeCode]) VALUES (1, N'Beatles', 10000)
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [TypeCode]) VALUES (2, N'Pink Floyd', 10001)
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [TypeCode]) VALUES (3, N'Beatles', 10002)
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [TypeCode]) VALUES (4, N'AC/DC', 10000)
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [TypeCode]) VALUES (5, N'New Trolls', 10000)
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [TypeCode]) VALUES (6, N'Led zeppelin', 10000)
GO
SET IDENTITY_INSERT [dbo].[Artist] OFF
GO
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (10000, 1, N'솔로', N'1')
GO
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (10001, 1, N'아이돌', N'1')
GO
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (10002, 1, N'밴드', N'1')
GO
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (10003, 1, N'인디', N'1')
GO
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (10004, 1, N'퓨전', N'1')
GO
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (20000, 2, N'Rock', N'')
GO
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (20001, 2, N'Jazz', N'')
GO
INSERT [dbo].[Code] ([CodeId], [CodeCategoryId], [Text], [Memo]) VALUES (20002, 2, N'Metal', N'')
GO
INSERT [dbo].[CodeCategory] ([CodeCategoryId], [Name]) VALUES (1, N'Artist Type')
GO
INSERT [dbo].[CodeCategory] ([CodeCategoryId], [Name]) VALUES (2, N'Album Type')
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId]) VALUES (3, N'Luís', N'nçalves', N'Embraer - Empresa Brasileira de Aeronáutica S.A.', N'Av. Brigadeiro Faria Lima, 2170', N'São José dos Campos', N'SP', N'Brazil', N'12227-000', N'+55 (12) 3923-5555', N'+55 (12) 3923-5566', N'luisg@embraer.com.br', NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId]) VALUES (4, N'Leonie', N'Köhler', N'1', N'Theodor-Heuss-Straße 34', N'Stuttgart', N'1', N'Germany', N'70174', N'+49 0711 2842222', N'1', N'leonekohler@surfeu.de', NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId]) VALUES (5, N'François', N'Tremblay', N'1', N'1498 rue Bélanger', N'Montréal', N'QC', N'Canada', N'H2G 1A7', N'+1 (514) 721-4711', N'1', N'ftremblay@gmail.com', NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId]) VALUES (6, N'Bjørn', N'Hansen', N'1', N'Ullevålsveien 14', N'Oslo', N'1', N'Norway', N'0171', N'+47 22 44 22 22', N'1', N'bjorn.hansen@yahoo.no', NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId]) VALUES (7, N'František', N'Wichterlová', N'JetBrains s.r.o.', N'Klanova 9/506', N'Prague', N'1', N'Czech Republic', N'14700', N'+420 2 4172 5555', N'+420 2 4172 5555', N'frantisekw@jetbrains.com', NULL)
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
INSERT [dbo].[DateTable] ([Date], [DateNull]) VALUES (CAST(N'2024-06-16' AS Date), NULL)
GO
INSERT [dbo].[DateTable] ([Date], [DateNull]) VALUES (CAST(N'2024-06-17' AS Date), CAST(N'2024-06-18' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email]) VALUES (1, N'Adams', N'Andrew', N'General Manager', NULL, CAST(N'1962-02-18T00:00:00.000' AS DateTime), CAST(N'2002-08-14T00:00:00.000' AS DateTime), N'11120 Jasper Ave NW', N'Edmonton', N'AB', N'Canada', N'T5K 2N1', N'+1 (780) 428-9482', N'+1 (780) 428-3457', N'andrew@chinookcorp.com')
GO
INSERT [dbo].[Employee] ([EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email]) VALUES (2, N'Edwards', N'Nancy', N'Sales Manager', 1, CAST(N'1958-12-08T00:00:00.000' AS DateTime), CAST(N'2002-05-01T00:00:00.000' AS DateTime), N'825 8 Ave SW', N'Calgary', N'AB', N'Canada', N'T2P 2T3', N'+1 (403) 262-3443', N'+1 (403) 262-3322', N'nancy@chinookcorp.com')
GO
INSERT [dbo].[Employee] ([EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email]) VALUES (3, N'Peacock', N'Jane', N'Sales Support Agent', 2, CAST(N'1973-08-29T00:00:00.000' AS DateTime), CAST(N'2002-04-01T00:00:00.000' AS DateTime), N'1111 6 Ave SW', N'Calgary', N'AB', N'Canada', N'T2P 5M5', N'+1 (403) 262-3443', N'+1 (403) 262-6712', N'jane@chinookcorp.com')
GO
INSERT [dbo].[Employee] ([EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email]) VALUES (4, N'Park', N'Margaret', N'Sales Support Agent', 2, CAST(N'1947-09-19T00:00:00.000' AS DateTime), CAST(N'2003-05-03T00:00:00.000' AS DateTime), N'683 10 Street SW', N'Calgary', N'AB', N'Canada', N'T2P 5G3', N'+1 (403) 263-4423', N'+1 (403) 263-4289', N'margaret@chinookcorp.com')
GO
INSERT [dbo].[Employee] ([EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email]) VALUES (5, N'Johnson', N'Steve', N'Sales Support Agent', 2, CAST(N'1965-03-03T00:00:00.000' AS DateTime), CAST(N'2003-10-17T00:00:00.000' AS DateTime), N'7727B 41 Ave', N'Calgary', N'AB', N'Canada', N'T3B 1Y7', N'1 (780) 836-9987', N'1 (780) 836-9543', N'steve@chinookcorp.com')
GO
INSERT [dbo].[Employee] ([EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email]) VALUES (6, N'Mitchell', N'Michael', N'IT Manager', 3, CAST(N'1973-07-01T00:00:00.000' AS DateTime), CAST(N'2003-10-17T00:00:00.000' AS DateTime), N'5827 Bowness Road NW', N'Calgary', N'AB', N'Canada', N'T3B 0C5', N'+1 (403) 246-9887', N'+1 (403) 246-9899', N'michael@chinookcorp.com')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Genre] ON 
GO
INSERT [dbo].[Genre] ([GenreId], [Name]) VALUES (1, N'Rock')
GO
INSERT [dbo].[Genre] ([GenreId], [Name]) VALUES (2, N'Jazz')
GO
INSERT [dbo].[Genre] ([GenreId], [Name]) VALUES (3, N'Metal')
GO
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 
GO
INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total]) VALUES (4, 3, CAST(N'2021-01-01T00:00:00.000' AS DateTime), N'Theodor-Heuss-Straße 34', N'Stuttgart', N'1', N'Germany', N'70174', CAST(1.98 AS Numeric(10, 2)))
GO
INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total]) VALUES (5, 3, CAST(N'2021-01-02T00:00:00.000' AS DateTime), N'Ullevålsveien 14', N'Oslo', N'1', N'Norway', N'0171', CAST(3.96 AS Numeric(10, 2)))
GO
INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total]) VALUES (6, 3, CAST(N'2021-01-03T00:00:00.000' AS DateTime), N'Grétrystraat 63', N'Brussels', N'1', N'Belgium', N'1000', CAST(5.94 AS Numeric(10, 2)))
GO
INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total]) VALUES (7, 4, CAST(N'2021-01-06T00:00:00.000' AS DateTime), N'8210 111 ST NW', N'Edmonton', N'AB', N'Canada', N'T6G 2C7', CAST(8.91 AS Numeric(10, 2)))
GO
INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total]) VALUES (8, 4, CAST(N'2021-01-11T00:00:00.000' AS DateTime), N'69 Salem Street', N'Boston', N'MA', N'USA', N'2113', CAST(13.86 AS Numeric(10, 2)))
GO
SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceLine] ON 
GO
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2241, 4, 68, CAST(0.99 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2242, 4, 69, CAST(0.99 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2243, 5, 70, CAST(0.99 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2244, 5, 71, CAST(0.99 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2245, 5, 72, CAST(0.99 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2246, 6, 73, CAST(0.99 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2247, 6, 74, CAST(0.99 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (2248, 7, 75, CAST(0.99 AS Numeric(10, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[InvoiceLine] OFF
GO
SET IDENTITY_INSERT [dbo].[MediaType] ON 
GO
INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (1, N'MPEG audio file')
GO
INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (2, N'Protected AAC audio file')
GO
INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (3, N'Protected MPEG-4 video file')
GO
INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (4, N'Purchased AAC audio file')
GO
INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (5, N'AAC audio file')
GO
SET IDENTITY_INSERT [dbo].[MediaType] OFF
GO
SET IDENTITY_INSERT [dbo].[Playlist] ON 
GO
INSERT [dbo].[Playlist] ([PlaylistId], [Name]) VALUES (1, N'Music')
GO
INSERT [dbo].[Playlist] ([PlaylistId], [Name]) VALUES (2, N'Movies')
GO
INSERT [dbo].[Playlist] ([PlaylistId], [Name]) VALUES (3, N'TV Shows')
GO
SET IDENTITY_INSERT [dbo].[Playlist] OFF
GO
INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (1, 4)
GO
INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (1, 5)
GO
INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (2, 4)
GO
INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (2, 5)
GO
INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (2, 6)
GO
INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (2, 7)
GO
INSERT [dbo].[PlaylistTrackHistory] ([PlaylistId], [TrackId], [WrittenAt], [Memo]) VALUES (1, 4, CAST(N'2024-06-16T16:34:36.000' AS DateTime), N'1')
GO
INSERT [dbo].[PlaylistTrackHistory] ([PlaylistId], [TrackId], [WrittenAt], [Memo]) VALUES (1, 5, CAST(N'2024-06-17T16:34:36.000' AS DateTime), N'2')
GO
INSERT [dbo].[PlaylistTrackHistory] ([PlaylistId], [TrackId], [WrittenAt], [Memo]) VALUES (2, 4, CAST(N'2024-06-16T16:34:36.000' AS DateTime), N'1')
GO
INSERT [dbo].[PlaylistTrackHistory] ([PlaylistId], [TrackId], [WrittenAt], [Memo]) VALUES (2, 5, CAST(N'2024-06-17T16:34:36.000' AS DateTime), N'2')
GO
INSERT [dbo].[TimeTable] ([Time], [TimeNull]) VALUES (CAST(N'16:33:11' AS Time), NULL)
GO
INSERT [dbo].[TimeTable] ([Time], [TimeNull]) VALUES (CAST(N'17:33:11' AS Time), CAST(N'18:33:11' AS Time))
GO
SET IDENTITY_INSERT [dbo].[Track] ON 
GO
INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull], [DateOnlyCol], [TimeOnlyCol], [DateOnlyColNull], [TimeOnlyColNull], [MediaTypeId], [GenreId]) VALUES (4, N'Hey You', 3, 1, NULL, 1, NULL, 2, NULL, 3, NULL, N'4         ', NULL, N'5', NULL, N'6         ', NULL, N'7', N'', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, NULL, CAST(N'2024-06-16' AS Date), NULL, CAST(N'2024-06-16T18:19:35.147' AS DateTime), NULL, CAST(N'2024-06-16T18:20:00' AS SmallDateTime), NULL, CAST(8.00 AS Decimal(18, 2)), NULL, 9.1, NULL, 10.1, NULL, 11.1000, NULL, CAST(N'18:19:35.1466667' AS Time), NULL, N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', NULL, 0x00000000, NULL, CAST(N'2024-06-16' AS Date), CAST(N'12:12:11' AS Time), NULL, NULL, 1, 1)
GO
INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull], [DateOnlyCol], [TimeOnlyCol], [DateOnlyColNull], [TimeOnlyColNull], [MediaTypeId], [GenreId]) VALUES (5, N'In The Fresh?', 3, 1, 1, 1, 10, 2, 20, 3, 30, N'4         ', N'40        ', N'5', N'50', N'6         ', N'60        ', N'7', N'70', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, CAST(N'2024-06-16' AS Date), CAST(N'2024-06-17' AS Date), CAST(N'2024-06-16T18:19:35.147' AS DateTime), CAST(N'2024-06-17T00:00:00.000' AS DateTime), CAST(N'2024-06-16T18:20:00' AS SmallDateTime), CAST(N'2024-06-17T00:00:00' AS SmallDateTime), CAST(8.00 AS Decimal(18, 2)), CAST(80.00 AS Decimal(18, 2)), 9.1, 9.2, 10.1, 10.2, 11.1000, 11.2000, CAST(N'18:19:35' AS Time), CAST(N'18:19:36' AS Time), N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', 0x00000000, 0x00000000, CAST(N'2024-06-16' AS Date), CAST(N'12:12:11' AS Time), CAST(N'2024-06-17' AS Date), CAST(N'12:12:12' AS Time), 1, 1)
GO
INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull], [DateOnlyCol], [TimeOnlyCol], [DateOnlyColNull], [TimeOnlyColNull], [MediaTypeId], [GenreId]) VALUES (6, N'Across The Universe', 4, 1, NULL, 1, NULL, 2, NULL, 3, NULL, N'4         ', NULL, N'5', NULL, N'6         ', NULL, N'7', N'', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, NULL, CAST(N'2024-06-16' AS Date), NULL, CAST(N'2024-06-16T18:19:35.147' AS DateTime), NULL, CAST(N'2024-06-16T18:20:00' AS SmallDateTime), NULL, CAST(8.00 AS Decimal(18, 2)), NULL, 9.1, NULL, 10.1, NULL, 11.1000, NULL, CAST(N'18:19:35' AS Time), NULL, N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', NULL, 0x00000000, NULL, CAST(N'2024-06-16' AS Date), CAST(N'12:12:11' AS Time), NULL, NULL, 1, 1)
GO
INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull], [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull], [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull], [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull], [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol], [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol], [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull], [DateOnlyCol], [TimeOnlyCol], [DateOnlyColNull], [TimeOnlyColNull], [MediaTypeId], [GenreId]) VALUES (7, N'I Me Mine', 4, 1, NULL, 1, NULL, 2, NULL, 3, NULL, N'4         ', NULL, N'5', NULL, N'6         ', NULL, N'7', N'', 0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, NULL, CAST(N'2024-06-16' AS Date), NULL, CAST(N'2024-06-16T18:19:35.147' AS DateTime), NULL, CAST(N'2024-06-16T18:20:00' AS SmallDateTime), NULL, CAST(8.00 AS Decimal(18, 2)), NULL, 9.1, NULL, 10.1, NULL, 11.1000, NULL, CAST(N'18:19:35' AS Time), NULL, N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', NULL, 0x00000000, NULL, CAST(N'2024-06-16' AS Date), CAST(N'12:12:11' AS Time), NULL, NULL, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Track] OFF
GO
ALTER TABLE [dbo].[Album] ADD  DEFAULT ('') FOR [Title]
GO
ALTER TABLE [dbo].[Album] ADD  DEFAULT ((0)) FOR [TypeCode]
GO
ALTER TABLE [dbo].[Artist] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Artist] ADD  DEFAULT ((0)) FOR [TypeCode]
GO
ALTER TABLE [dbo].[Code] ADD  DEFAULT ('') FOR [Text]
GO
ALTER TABLE [dbo].[Code] ADD  DEFAULT ('') FOR [Memo]
GO
ALTER TABLE [dbo].[CodeCategory] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('') FOR [FirstName]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('') FOR [LastName]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('') FOR [Company]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('') FOR [Address]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('') FOR [City]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('') FOR [State]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('') FOR [Country]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('') FOR [PostalCode]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('') FOR [Phone]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('') FOR [Fax]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('') FOR [LastName]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('') FOR [FirstName]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('') FOR [Title]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT (getdate()) FOR [BirthDate]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT (getdate()) FOR [HireDate]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('') FOR [Address]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('') FOR [City]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('') FOR [State]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('') FOR [Country]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('') FOR [PostalCode]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('') FOR [Phone]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('') FOR [Fax]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[Genre] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT (getdate()) FOR [InvoiceDate]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ('') FOR [BillingAddress]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ('') FOR [BillingCity]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ('') FOR [BillingState]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ('') FOR [BillingCountry]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ('') FOR [BillingPostalCode]
GO
ALTER TABLE [dbo].[MediaType] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Playlist] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[PlaylistTrackHistory] ADD  DEFAULT (N'') FOR [Memo]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT ('') FOR [CharCol]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT ('') FOR [VarCharCol]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT ('') FOR [NcharCol]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT ('') FOR [NvarCharCol]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT ('') FOR [NvarCharColNull]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT ((0)) FOR [BinaryCol]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT (getdate()) FOR [DateCol]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT (getdate()) FOR [DateTimeCol]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT (getdate()) FOR [SmallDateTimeCol]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT (getdate()) FOR [TimeCol]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT (newid()) FOR [GuidCol]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT ((0)) FOR [VarBinaryCol]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT ((1)) FOR [MediaTypeId]
GO
ALTER TABLE [dbo].[Track] ADD  DEFAULT ((1)) FOR [GenreId]
GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_Artist_ArtistId] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artist] ([ArtistId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_Artist_ArtistId]
GO
ALTER TABLE [dbo].[Code]  WITH CHECK ADD  CONSTRAINT [FK_Code_CodeCategory_CodeCategoryId] FOREIGN KEY([CodeCategoryId])
REFERENCES [dbo].[CodeCategory] ([CodeCategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Code] CHECK CONSTRAINT [FK_Code_CodeCategory_CodeCategoryId]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Employee_SupportRepId] FOREIGN KEY([SupportRepId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Employee_SupportRepId]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee_ReportsTo] FOREIGN KEY([ReportsTo])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Employee_ReportsTo]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Customer_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Customer_CustomerId]
GO
ALTER TABLE [dbo].[InvoiceLine]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceLine_Invoice_InvoiceId] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoice] ([InvoiceId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceLine] CHECK CONSTRAINT [FK_InvoiceLine_Invoice_InvoiceId]
GO
ALTER TABLE [dbo].[PlaylistTrack]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistTrack_Playlist_PlaylistId] FOREIGN KEY([PlaylistId])
REFERENCES [dbo].[Playlist] ([PlaylistId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaylistTrack] CHECK CONSTRAINT [FK_PlaylistTrack_Playlist_PlaylistId]
GO
ALTER TABLE [dbo].[PlaylistTrack]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistTrack_Track] FOREIGN KEY([TrackId])
REFERENCES [dbo].[Track] ([TrackId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaylistTrack] CHECK CONSTRAINT [FK_PlaylistTrack_Track]
GO
ALTER TABLE [dbo].[PlaylistTrackHistory]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistTrackHistory_PlaylistTrack] FOREIGN KEY([PlaylistId], [TrackId])
REFERENCES [dbo].[PlaylistTrack] ([PlaylistId], [TrackId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaylistTrackHistory] CHECK CONSTRAINT [FK_PlaylistTrackHistory_PlaylistTrack]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([GenreId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Genre]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_MediaType] FOREIGN KEY([MediaTypeId])
REFERENCES [dbo].[MediaType] ([MediaTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_MediaType]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_TrackAlbumId] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([AlbumId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_TrackAlbumId]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetMaxId]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_GetMaxId](@Entity nvarchar(100))
as

declare @sql nvarchar(1000)
set @sql = 'select top 1 [' + @Entity + 'Id] from [' + @Entity + '] order by ' + @Entity + 'Id desc'

--select @sql

EXEC(@sql)
GO
/****** Object:  StoredProcedure [dbo].[usp_GetSystemTime]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_GetSystemTime]
as
SELECT CURRENT_TIMESTAMP
GO
/****** Object:  StoredProcedure [dbo].[usp_Initialize]    Script Date: 2024-08-30 오전 12:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Initialize]
AS
BEGIN
    delete PlaylistTrackHistory
    delete PlaylistTrack
    delete Playlist
    delete InvoiceLine
    delete Invoice
    delete Customer
    delete Employee
    delete Code
    delete CodeCategory
    delete Track
    delete MediaType
    delete Genre
    delete Album
    delete Artist
    delete DateTable
    delete TimeTable

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

    INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode])
    VALUES (6, N'Sgt. Pepper''s Lonely Hearts Club', 1, 20000)

    INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (7, N'Rubber Soul', 1, 20000)

    INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (8, N'Help!', 1, 20000)

    INSERT [dbo].[Album] ([AlbumId], [Title], [ArtistId], [TypeCode]) VALUES (9, N'Yellow Submarine', 1, 20000)

    SET IDENTITY_INSERT [dbo].[Album] OFF

    SET IDENTITY_INSERT [dbo].[Genre] ON

    INSERT [dbo].[Genre] ([GenreId], [Name]) VALUES (1, N'Rock')

    INSERT [dbo].[Genre] ([GenreId], [Name]) VALUES (2, N'Jazz')

    INSERT [dbo].[Genre] ([GenreId], [Name]) VALUES (3, N'Metal')

    SET IDENTITY_INSERT [dbo].[Genre] OFF

    SET IDENTITY_INSERT [dbo].[MediaType] ON

    INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (1, N'MPEG audio file')

    INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (2, N'Protected AAC audio file')

    INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (3, N'Protected MPEG-4 video file')

    INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (4, N'Purchased AAC audio file')

    INSERT [dbo].[MediaType] ([MediaTypeId], [Name]) VALUES (5, N'AAC audio file')

    SET IDENTITY_INSERT [dbo].[MediaType] OFF

    SET IDENTITY_INSERT [dbo].[Track] ON

    INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull],
                          [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull],
                          [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull],
                          [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull],
                          [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol],
                          [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol],
                          [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull], [DateOnlyCol],
                          [TimeOnlyCol], [DateOnlyColNull], [TimeOnlyColNull], [MediaTypeId], [GenreId])
    VALUES (4, N'Hey You', 3, 1, NULL, 1, NULL, 2, NULL, 3, NULL, N'4         ', NULL, N'5', NULL, N'6         ', NULL,
            N'7', N'',
            0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000,
            NULL, CAST(N'2024-06-16' AS Date), NULL, CAST(N'2024-06-16T18:19:35.147' AS DateTime), NULL,
            CAST(N'2024-06-16T18:20:00' AS SmallDateTime), NULL, CAST(8.00 AS Decimal(18, 2)), NULL, 9.1, NULL, 10.1,
            NULL, 11.1000, NULL, CAST(N'18:19:35.1466667' AS Time), NULL, N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', NULL,
            0x00000000, NULL, CAST(N'2024-06-16' AS Date), CAST(N'12:12:11' AS Time), NULL, NULL, 1, 1)

    INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull],
                          [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull],
                          [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull],
                          [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull],
                          [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol],
                          [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol],
                          [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull], [DateOnlyCol],
                          [TimeOnlyCol], [DateOnlyColNull], [TimeOnlyColNull], [MediaTypeId], [GenreId])
    VALUES (5, N'In The Fresh?', 3, 1, 1, 1, 10, 2, 20, 3, 30, N'4         ', N'40        ', N'5', N'50', N'6         ',
            N'60        ', N'7', N'70',
            0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000,
            0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000,
            CAST(N'2024-06-16' AS Date), CAST(N'2024-06-17' AS Date), CAST(N'2024-06-16T18:19:35.147' AS DateTime),
            CAST(N'2024-06-17T00:00:00.000' AS DateTime), CAST(N'2024-06-16T18:20:00' AS SmallDateTime),
            CAST(N'2024-06-17T00:00:00' AS SmallDateTime), CAST(8.00 AS Decimal(18, 2)), CAST(80.00 AS Decimal(18, 2)),
            9.1, 9.2, 10.1, 10.2, 11.1000, 11.2000, CAST(N'18:19:35' AS Time), CAST(N'18:19:36' AS Time),
            N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', 0x00000000, 0x00000000,
            CAST(N'2024-06-16' AS Date), CAST(N'12:12:11' AS Time), CAST(N'2024-06-17' AS Date),
            CAST(N'12:12:12' AS Time), 1, 1)

    INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull],
                          [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull],
                          [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull],
                          [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull],
                          [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol],
                          [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol],
                          [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull], [DateOnlyCol],
                          [TimeOnlyCol], [DateOnlyColNull], [TimeOnlyColNull], [MediaTypeId], [GenreId])
    VALUES (6, N'Across The Universe', 4, 1, NULL, 1, NULL, 2, NULL, 3, NULL, N'4         ', NULL, N'5', NULL,
            N'6         ', NULL, N'7', N'',
            0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000,
            NULL, CAST(N'2024-06-16' AS Date), NULL, CAST(N'2024-06-16T18:19:35.147' AS DateTime), NULL,
            CAST(N'2024-06-16T18:20:00' AS SmallDateTime), NULL, CAST(8.00 AS Decimal(18, 2)), NULL, 9.1, NULL, 10.1,
            NULL, 11.1000, NULL, CAST(N'18:19:35' AS Time), NULL, N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', NULL,
            0x00000000, NULL, CAST(N'2024-06-16' AS Date), CAST(N'12:12:11' AS Time), NULL, NULL, 1, 1)

    INSERT [dbo].[Track] ([TrackId], [Name], [AlbumId], [BitCol], [BitColNull], [TinyIntCol], [TinyIntColNull],
                          [SmallIntCol], [SmallIntColNull], [BigIntCol], [BigIntColNull], [CharCol], [CharColNull],
                          [VarCharCol], [VarCharColNull], [NcharCol], [NcharColNull], [NvarCharCol], [NvarCharColNull],
                          [BinaryCol], [BinaryColNull], [DateCol], [DateColNull], [DateTimeCol], [DateTimeColNull],
                          [SmallDateTimeCol], [SmallDateTimeColNull], [DecimalCol], [DecimalColNull], [FloatCol],
                          [FloatColNull], [RealCol], [RealColNull], [SmallMoneyCol], [SmallMoneyColNull], [TimeCol],
                          [TimeColNull], [GuidCol], [GuidColNull], [VarBinaryCol], [VarBinaryColNull], [DateOnlyCol],
                          [TimeOnlyCol], [DateOnlyColNull], [TimeOnlyColNull], [MediaTypeId], [GenreId])
    VALUES (7, N'I Me Mine', 4, 1, NULL, 1, NULL, 2, NULL, 3, NULL, N'4         ', NULL, N'5', NULL, N'6         ',
            NULL, N'7', N'',
            0x0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000,
            NULL, CAST(N'2024-06-16' AS Date), NULL, CAST(N'2024-06-16T18:19:35.147' AS DateTime), NULL,
            CAST(N'2024-06-16T18:20:00' AS SmallDateTime), NULL, CAST(8.00 AS Decimal(18, 2)), NULL, 9.1, NULL, 10.1,
            NULL, 11.1000, NULL, CAST(N'18:19:35' AS Time), NULL, N'dde8a31a-678d-4a9a-b758-72cf9a2032fd', NULL,
            0x00000000, NULL, CAST(N'2024-06-16' AS Date), CAST(N'12:12:11' AS Time), NULL, NULL, 1, 1)

    SET IDENTITY_INSERT [dbo].[Track] OFF

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

    SET IDENTITY_INSERT [dbo].[Employee] ON

    INSERT [dbo].[Employee] ([EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate],
                             [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email])
    VALUES (1, N'Adams', N'Andrew', N'General Manager', NULL, CAST(N'1962-02-18T00:00:00.000' AS DateTime),
            CAST(N'2002-08-14T00:00:00.000' AS DateTime), N'11120 Jasper Ave NW', N'Edmonton', N'AB', N'Canada',
            N'T5K 2N1', N'+1 (780) 428-9482', N'+1 (780) 428-3457', N'andrew@chinookcorp.com')

    INSERT [dbo].[Employee] ([EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate],
                             [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email])
    VALUES (2, N'Edwards', N'Nancy', N'Sales Manager', 1, CAST(N'1958-12-08T00:00:00.000' AS DateTime),
            CAST(N'2002-05-01T00:00:00.000' AS DateTime), N'825 8 Ave SW', N'Calgary', N'AB', N'Canada', N'T2P 2T3',
            N'+1 (403) 262-3443', N'+1 (403) 262-3322', N'nancy@chinookcorp.com')

    INSERT [dbo].[Employee] ([EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate],
                             [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email])
    VALUES (3, N'Peacock', N'Jane', N'Sales Support Agent', 2, CAST(N'1973-08-29T00:00:00.000' AS DateTime),
            CAST(N'2002-04-01T00:00:00.000' AS DateTime), N'1111 6 Ave SW', N'Calgary', N'AB', N'Canada', N'T2P 5M5',
            N'+1 (403) 262-3443', N'+1 (403) 262-6712', N'jane@chinookcorp.com')

    INSERT [dbo].[Employee] ([EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate],
                             [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email])
    VALUES (4, N'Park', N'Margaret', N'Sales Support Agent', 2, CAST(N'1947-09-19T00:00:00.000' AS DateTime),
            CAST(N'2003-05-03T00:00:00.000' AS DateTime), N'683 10 Street SW', N'Calgary', N'AB', N'Canada', N'T2P 5G3',
            N'+1 (403) 263-4423', N'+1 (403) 263-4289', N'margaret@chinookcorp.com')

    INSERT [dbo].[Employee] ([EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate],
                             [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email])
    VALUES (5, N'Johnson', N'Steve', N'Sales Support Agent', 2, CAST(N'1965-03-03T00:00:00.000' AS DateTime),
            CAST(N'2003-10-17T00:00:00.000' AS DateTime), N'7727B 41 Ave', N'Calgary', N'AB', N'Canada', N'T3B 1Y7',
            N'1 (780) 836-9987', N'1 (780) 836-9543', N'steve@chinookcorp.com')

    INSERT [dbo].[Employee] ([EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate],
                             [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email])
    VALUES (6, N'Mitchell', N'Michael', N'IT Manager', 3, CAST(N'1973-07-01T00:00:00.000' AS DateTime),
            CAST(N'2003-10-17T00:00:00.000' AS DateTime), N'5827 Bowness Road NW', N'Calgary', N'AB', N'Canada',
            N'T3B 0C5', N'+1 (403) 246-9887', N'+1 (403) 246-9899', N'michael@chinookcorp.com')

    SET IDENTITY_INSERT [dbo].[Employee] OFF

    SET IDENTITY_INSERT [dbo].[Customer] ON

    INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country],
                             [PostalCode], [Phone], [Fax], [Email], [SupportRepId])
    VALUES (3, N'Luís', N'nçalves', N'Embraer - Empresa Brasileira de Aeronáutica S.A.',
            N'Av. Brigadeiro Faria Lima, 2170', N'São José dos Campos', N'SP', N'Brazil', N'12227-000',
            N'+55 (12) 3923-5555', N'+55 (12) 3923-5566', N'luisg@embraer.com.br', NULL)

    INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country],
                             [PostalCode], [Phone], [Fax], [Email], [SupportRepId])
    VALUES (4, N'Leonie', N'Köhler', N'1', N'Theodor-Heuss-Straße 34', N'Stuttgart', N'1', N'Germany', N'70174',
            N'+49 0711 2842222', N'1', N'leonekohler@surfeu.de', NULL)

    INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country],
                             [PostalCode], [Phone], [Fax], [Email], [SupportRepId])
    VALUES (5, N'François', N'Tremblay', N'1', N'1498 rue Bélanger', N'Montréal', N'QC', N'Canada', N'H2G 1A7',
            N'+1 (514) 721-4711', N'1', N'ftremblay@gmail.com', NULL)

    INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country],
                             [PostalCode], [Phone], [Fax], [Email], [SupportRepId])
    VALUES (6, N'Bjørn', N'Hansen', N'1', N'Ullevålsveien 14', N'Oslo', N'1', N'Norway', N'0171', N'+47 22 44 22 22',
            N'1', N'bjorn.hansen@yahoo.no', NULL)

    INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country],
                             [PostalCode], [Phone], [Fax], [Email], [SupportRepId])
    VALUES (7, N'František', N'Wichterlová', N'JetBrains s.r.o.', N'Klanova 9/506', N'Prague', N'1', N'Czech Republic',
            N'14700', N'+420 2 4172 5555', N'+420 2 4172 5555', N'frantisekw@jetbrains.com', NULL)

    SET IDENTITY_INSERT [dbo].[Customer] OFF

    SET IDENTITY_INSERT [dbo].[Invoice] ON

    INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState],
                            [BillingCountry], [BillingPostalCode], [Total])
    VALUES (4, 3, CAST(N'2021-01-01T00:00:00.000' AS DateTime), N'Theodor-Heuss-Straße 34', N'Stuttgart', N'1',
            N'Germany', N'70174', CAST(1.98 AS Numeric(10, 2)))

    INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState],
                            [BillingCountry], [BillingPostalCode], [Total])
    VALUES (5, 3, CAST(N'2021-01-02T00:00:00.000' AS DateTime), N'Ullevålsveien 14', N'Oslo', N'1', N'Norway', N'0171',
            CAST(3.96 AS Numeric(10, 2)))

    INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState],
                            [BillingCountry], [BillingPostalCode], [Total])
    VALUES (6, 3, CAST(N'2021-01-03T00:00:00.000' AS DateTime), N'Grétrystraat 63', N'Brussels', N'1', N'Belgium',
            N'1000', CAST(5.94 AS Numeric(10, 2)))

    INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState],
                            [BillingCountry], [BillingPostalCode], [Total])
    VALUES (7, 4, CAST(N'2021-01-06T00:00:00.000' AS DateTime), N'8210 111 ST NW', N'Edmonton', N'AB', N'Canada',
            N'T6G 2C7', CAST(8.91 AS Numeric(10, 2)))

    INSERT [dbo].[Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState],
                            [BillingCountry], [BillingPostalCode], [Total])
    VALUES (8, 4, CAST(N'2021-01-11T00:00:00.000' AS DateTime), N'69 Salem Street', N'Boston', N'MA', N'USA', N'2113',
            CAST(13.86 AS Numeric(10, 2)))

    SET IDENTITY_INSERT [dbo].[Invoice] OFF

    SET IDENTITY_INSERT [dbo].[InvoiceLine] ON

    INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity])
    VALUES (2241, 4, 68, CAST(0.99 AS Numeric(10, 2)), 1)

    INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity])
    VALUES (2242, 4, 69, CAST(0.99 AS Numeric(10, 2)), 1)

    INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity])
    VALUES (2243, 5, 70, CAST(0.99 AS Numeric(10, 2)), 1)

    INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity])
    VALUES (2244, 5, 71, CAST(0.99 AS Numeric(10, 2)), 1)

    INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity])
    VALUES (2245, 5, 72, CAST(0.99 AS Numeric(10, 2)), 1)

    INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity])
    VALUES (2246, 6, 73, CAST(0.99 AS Numeric(10, 2)), 1)

    INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity])
    VALUES (2247, 6, 74, CAST(0.99 AS Numeric(10, 2)), 1)

    INSERT [dbo].[InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity])
    VALUES (2248, 7, 75, CAST(0.99 AS Numeric(10, 2)), 1)

    SET IDENTITY_INSERT [dbo].[InvoiceLine] OFF

    SET IDENTITY_INSERT [dbo].[Playlist] ON

    INSERT [dbo].[Playlist] ([PlaylistId], [Name]) VALUES (1, N'Music')

    INSERT [dbo].[Playlist] ([PlaylistId], [Name]) VALUES (2, N'Movies')

    INSERT [dbo].[Playlist] ([PlaylistId], [Name]) VALUES (3, N'TV Shows')

    SET IDENTITY_INSERT [dbo].[Playlist] OFF

    INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (1, 4)
    INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (1, 5)
    INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (2, 4)
    INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (2, 5)
    INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (2, 6)
    INSERT [dbo].[PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (2, 7)

    INSERT [dbo].[PlaylistTrackHistory] ([PlaylistId], [TrackId], [WrittenAt], [Memo])
    VALUES (1, 4, CAST(N'2024-06-16T16:34:36.000' AS DateTime), N'1')
    INSERT [dbo].[PlaylistTrackHistory] ([PlaylistId], [TrackId], [WrittenAt], [Memo])
    VALUES (1, 5, CAST(N'2024-06-17T16:34:36.000' AS DateTime), N'2')
    INSERT [dbo].[PlaylistTrackHistory] ([PlaylistId], [TrackId], [WrittenAt], [Memo])
    VALUES (2, 4, CAST(N'2024-06-16T16:34:36.000' AS DateTime), N'1')
    INSERT [dbo].[PlaylistTrackHistory] ([PlaylistId], [TrackId], [WrittenAt], [Memo])
    VALUES (2, 5, CAST(N'2024-06-17T16:34:36.000' AS DateTime), N'2')


    INSERT [dbo].[DateTable] ([Date], [DateNull]) VALUES (CAST(N'2024-06-16' AS Date), NULL)
    INSERT [dbo].[DateTable] ([Date], [DateNull]) VALUES (CAST(N'2024-06-17' AS Date), CAST(N'2024-06-18' AS Date))

    INSERT [dbo].[TimeTable] ([Time], [TimeNull]) VALUES (CAST(N'16:33:11' AS Time), NULL)
    INSERT [dbo].[TimeTable] ([Time], [TimeNull]) VALUES (CAST(N'17:33:11' AS Time), CAST(N'18:33:11' AS Time))

END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'[2]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Album', @level2type=N'COLUMN',@level2name=N'TypeCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'[1]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Artist', @level2type=N'COLUMN',@level2name=N'TypeCode'
GO
USE [master]
GO
ALTER DATABASE [ChinookMP] SET  READ_WRITE 
GO
