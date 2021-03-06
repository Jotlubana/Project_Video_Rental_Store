USE [master]
GO
/****** Object:  Database [VRS_DB]    Script Date: 3/09/2020 10:49:59 am ******/
CREATE DATABASE [VRS_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VRS_DB', FILENAME = N'C:\Users\User\Desktop\MSSQL15.SQLEXPRESS\MSSQL\DATA\VRS_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VRS_DB_log', FILENAME = N'C:\Users\User\Desktop\MSSQL15.SQLEXPRESS\MSSQL\DATA\VRS_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [VRS_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VRS_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VRS_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VRS_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VRS_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VRS_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VRS_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [VRS_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VRS_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VRS_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VRS_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VRS_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VRS_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VRS_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VRS_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VRS_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VRS_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VRS_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VRS_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VRS_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VRS_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VRS_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VRS_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VRS_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VRS_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VRS_DB] SET  MULTI_USER 
GO
ALTER DATABASE [VRS_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VRS_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VRS_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VRS_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VRS_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VRS_DB] SET QUERY_STORE = OFF
GO
USE [VRS_DB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 3/09/2020 10:50:00 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[Phone] [nvarchar](255) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 3/09/2020 10:50:00 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieID] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [nvarchar](50) NULL,
	[Title] [nvarchar](255) NULL,
	[Year] [nvarchar](255) NULL,
	[Rental_Cost] [money] NULL,
	[Copies] [nvarchar](50) NULL,
	[Plot] [ntext] NULL,
	[Genre] [nvarchar](50) NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentedMovies]    Script Date: 3/09/2020 10:50:00 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentedMovies](
	[RMID] [int] IDENTITY(1,1) NOT NULL,
	[MovieIDFK] [int] NULL,
	[CustIDFK] [int] NULL,
	[DateRented] [datetime] NULL,
	[DateReturned] [datetime] NULL,
	[Rented] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 3/09/2020 10:50:00 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_name] [varchar](15) NULL,
	[password] [varchar](15) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1, N'navjot', N'singh', N'!454', N'098765456789')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (2, N'NAV ', N'singh', N'raipur bet', N'78623636')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (3, N'anmol', N'preet', N'kotala', N'7087616271')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (4, N'angrej', N'singh', N'hamilton', N'226270748')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (5, N'yugyugu', N'oihioh', N'chgffuy', N'9798789797')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (6, N'rambo', N'preet', N'chartwell', N'8977437')
INSERT [dbo].[Customer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (7, N'happy', N'jojoio', N'punjab', N'78675777999')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (1, N'9', N'student of the year', N'2016', 5.0000, N'4', N'life of three college students', N'drama')
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (2, N'7', N'putt jattan de ', N'2020', 5.0000, N'2', N'6', N'fight')
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (3, N'8', N'fight', N'6766', 5.0000, N'3', N'no', N'music')
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (4, N'9', N'kijkih', N'2002', 2.0000, N'7', N'uichih', N'jbbjk')
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (5, N'9', N'gsgyu', N'2090', 5.0000, N'2', N'jhh,m ,k', N'huihi')
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (6, N'4', N'babbu mann', N'2010', 2.0000, N'9', N'iohjioio', N'romantic')
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Copies], [Plot], [Genre]) VALUES (7, N'0', N'iyiyjhbgyugu', N'8900', 5.0000, N'0', N'uihhhiohhio', N'hio')
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[RentedMovies] ON 

INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [Rented]) VALUES (1, 1, 1, CAST(N'2020-09-03T10:22:11.297' AS DateTime), CAST(N'2020-09-03T10:22:21.783' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[RentedMovies] OFF
GO
INSERT [dbo].[users] ([user_name], [password]) VALUES (N'A', N'A')
GO
ALTER TABLE [dbo].[RentedMovies]  WITH CHECK ADD  CONSTRAINT [FK1] FOREIGN KEY([MovieIDFK])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[RentedMovies] CHECK CONSTRAINT [FK1]
GO
ALTER TABLE [dbo].[RentedMovies]  WITH CHECK ADD  CONSTRAINT [FK2] FOREIGN KEY([CustIDFK])
REFERENCES [dbo].[Customer] ([CustID])
GO
ALTER TABLE [dbo].[RentedMovies] CHECK CONSTRAINT [FK2]
GO
USE [master]
GO
ALTER DATABASE [VRS_DB] SET  READ_WRITE 
GO
