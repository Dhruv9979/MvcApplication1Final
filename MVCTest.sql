USE [master]
GO
/****** Object:  Database [MVCTest]    Script Date: 12/10/2016 2:28:39 AM ******/
CREATE DATABASE [MVCTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MVCTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.UATSQLSERVER\MSSQL\DATA\MVCTest.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MVCTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.UATSQLSERVER\MSSQL\DATA\MVCTest_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MVCTest] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MVCTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MVCTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MVCTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MVCTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MVCTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MVCTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [MVCTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MVCTest] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MVCTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MVCTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MVCTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MVCTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MVCTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MVCTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MVCTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MVCTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MVCTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MVCTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MVCTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MVCTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MVCTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MVCTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MVCTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MVCTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MVCTest] SET RECOVERY FULL 
GO
ALTER DATABASE [MVCTest] SET  MULTI_USER 
GO
ALTER DATABASE [MVCTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MVCTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MVCTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MVCTest] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MVCTest', N'ON'
GO
USE [MVCTest]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 12/10/2016 2:28:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CartID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[UserID] [int] NULL,
	[ProductQnt] [int] NULL,
	[TotalPrice] [int] NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/10/2016 2:28:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/10/2016 2:28:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[Details] [nvarchar](250) NULL,
	[Price] [int] NULL,
	[ImagePath] [nvarchar](500) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/10/2016 2:28:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Pws] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [Name]) VALUES (1, N'Bags')
INSERT [dbo].[Categories] ([CategoryID], [Name]) VALUES (2, N'Watches')
INSERT [dbo].[Categories] ([CategoryID], [Name]) VALUES (3, N'Other')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [CategoryID], [Name], [Details], [Price], [ImagePath]) VALUES (2, 1, N'Fostelo Women''s Handbag Maroon (FSB-391)', N'Combining rich polyurethane like finishes with fine attention ', 875, N'pic13.jpg')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [Name], [Details], [Price], [ImagePath]) VALUES (3, 1, N'Glory Fashion Women''s Stylish Handbag Mustard-AK-005', N'Match your style be it casual or formal with this Criss Cross Handbag. A perfect companion for Office or College', 452, N'pic6.jpg')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [Name], [Details], [Price], [ImagePath]) VALUES (4, 2, N'Ferry Rozer Analog Round Shape Metal Belt Black Dial Watch For Men & Boys', N'Please note that orders which exceed the quantity limit will be auto-canceled. This is applicable across sellers', 1124, N'wat.jpg')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [Name], [Details], [Price], [ImagePath]) VALUES (5, 2, N'Geneva Analog RoseGold Dial Women''s', N'This is an analog watch where the smaller dials and pushers are for beautifying purposes only and are non-functional.', 1245, N'pic11.jpg')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [Name], [Details], [Price], [ImagePath]) VALUES (6, 3, N'Yahe Women''s Casual Faux Leather Wedges', N'IMPORTANT NOTE:Yahe runs a size smaller and these size are fit for slim foot so if your foots are broad then choose one bigger size and in case more broad then choose 2 bigger size', 564, N'pic12.jpg')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [Name], [Details], [Price], [ImagePath]) VALUES (7, 3, N'Bello Pede Women''s', N'Care Instructions: Rotate your pair of shoes once every other day', 442, N'pic3.jpg')
INSERT [dbo].[Products] ([ProductID], [CategoryID], [Name], [Details], [Price], [ImagePath]) VALUES (8, 3, N'Layer''r Wottagirl Body Spray, Secret Crush', N'Body Splash for Female & Body Spray for Men.', 421, N'pic4.jpg')
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Pws]) VALUES (1, N'T', N'1', N'test1@gmail.com', N'1')
SET IDENTITY_INSERT [dbo].[Users] OFF
USE [master]
GO
ALTER DATABASE [MVCTest] SET  READ_WRITE 
GO
