USE [master]
GO
/****** Object:  Database [Products]    Script Date: 06.06.2017 8:47:19 ******/
CREATE DATABASE [Products]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Products', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Products.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Products_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Products_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Products] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Products].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Products] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Products] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Products] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Products] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Products] SET ARITHABORT OFF 
GO
ALTER DATABASE [Products] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Products] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Products] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Products] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Products] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Products] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Products] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Products] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Products] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Products] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Products] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Products] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Products] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Products] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Products] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Products] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Products] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Products] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Products] SET  MULTI_USER 
GO
ALTER DATABASE [Products] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Products] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Products] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Products] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Products] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Products]
GO
/****** Object:  Table [dbo].[tblAuthors]    Script Date: 06.06.2017 8:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAuthors](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblBooks]    Script Date: 06.06.2017 8:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBooks](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[Description] [nvarchar](3000) NOT NULL,
	[Category] [nvarchar](100) NOT NULL,
	[Price] [money] NOT NULL,
	[BookTitle] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCustomerAdresses]    Script Date: 06.06.2017 8:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomerAdresses](
	[CustomerAdressId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Country] [nvarchar](100) NOT NULL,
	[CityOrVillage] [nvarchar](100) NOT NULL,
	[Street] [nvarchar](100) NOT NULL,
	[House] [nvarchar](10) NOT NULL,
	[Appartment] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerAdressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCustomerContactData]    Script Date: 06.06.2017 8:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomerContactData](
	[CustomerContactDataId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PhoneNumber] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerContactDataId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCustomerOrders]    Script Date: 06.06.2017 8:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomerOrders](
	[CustomerOrderId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[OrderDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCustomers]    Script Date: 06.06.2017 8:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tblBooks]  WITH CHECK ADD FOREIGN KEY([AuthorId])
REFERENCES [dbo].[tblAuthors] ([AuthorId])
GO
ALTER TABLE [dbo].[tblCustomerAdresses]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[tblCustomers] ([CustomerId])
GO
ALTER TABLE [dbo].[tblCustomerContactData]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[tblCustomers] ([CustomerId])
GO
ALTER TABLE [dbo].[tblCustomerOrders]  WITH CHECK ADD FOREIGN KEY([BookId])
REFERENCES [dbo].[tblBooks] ([BookId])
GO
ALTER TABLE [dbo].[tblCustomerOrders]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[tblCustomers] ([CustomerId])
GO
USE [master]
GO
ALTER DATABASE [Products] SET  READ_WRITE 
GO
