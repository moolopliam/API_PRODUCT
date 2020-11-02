USE [master]
GO
/****** Object:  Database [SHOP]    Script Date: 2/11/2563 9:04:43 ******/
CREATE DATABASE [SHOP]

GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SHOP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SHOP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SHOP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SHOP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SHOP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SHOP] SET ARITHABORT OFF 
GO
ALTER DATABASE [SHOP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SHOP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SHOP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SHOP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SHOP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SHOP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SHOP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SHOP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SHOP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SHOP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SHOP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SHOP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SHOP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SHOP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SHOP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SHOP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SHOP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SHOP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SHOP] SET  MULTI_USER 
GO
ALTER DATABASE [SHOP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SHOP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SHOP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SHOP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SHOP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SHOP] SET QUERY_STORE = OFF
GO
USE [SHOP]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [SHOP]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2/11/2563 9:04:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[categoryCode] [int] IDENTITY(1,1) NOT NULL,
	[categoryName] [varchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[categoryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/11/2563 9:04:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[productCode] [int] IDENTITY(1,1) NOT NULL,
	[productName] [varchar](50) NULL,
	[sellPrice] [decimal](10, 2) NULL,
	[buyPrice] [decimal](10, 2) NULL,
	[img] [varchar](50) NULL,
	[categoryCode] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[productCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([categoryCode], [categoryName]) VALUES (1, N'ขนม')
GO
INSERT [dbo].[Category] ([categoryCode], [categoryName]) VALUES (2, N'เครื่องดืม')
GO
INSERT [dbo].[Category] ([categoryCode], [categoryName]) VALUES (3, N'อาหารสด')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([productCode], [productName], [sellPrice], [buyPrice], [img], [categoryCode]) VALUES (1, N'โค้ก', CAST(200.00 AS Decimal(10, 2)), CAST(150.00 AS Decimal(10, 2)), NULL, 1)
GO
INSERT [dbo].[Products] ([productCode], [productName], [sellPrice], [buyPrice], [img], [categoryCode]) VALUES (2, N'มาม่่า', CAST(100.00 AS Decimal(10, 2)), CAST(50.00 AS Decimal(10, 2)), NULL, 2)
GO
INSERT [dbo].[Products] ([productCode], [productName], [sellPrice], [buyPrice], [img], [categoryCode]) VALUES (3, N'ปลา', CAST(100.00 AS Decimal(10, 2)), CAST(60.00 AS Decimal(10, 2)), NULL, 3)
GO
INSERT [dbo].[Products] ([productCode], [productName], [sellPrice], [buyPrice], [img], [categoryCode]) VALUES (4, N'ช้าง', CAST(200.00 AS Decimal(10, 2)), CAST(150.00 AS Decimal(10, 2)), NULL, 1)
GO
INSERT [dbo].[Products] ([productCode], [productName], [sellPrice], [buyPrice], [img], [categoryCode]) VALUES (5, N'ช้าง', CAST(200.00 AS Decimal(10, 2)), CAST(150.00 AS Decimal(10, 2)), NULL, 1)
GO
INSERT [dbo].[Products] ([productCode], [productName], [sellPrice], [buyPrice], [img], [categoryCode]) VALUES (6, N'ช้าง', CAST(200.00 AS Decimal(10, 2)), CAST(150.00 AS Decimal(10, 2)), NULL, 1)
GO
INSERT [dbo].[Products] ([productCode], [productName], [sellPrice], [buyPrice], [img], [categoryCode]) VALUES (7, N'ช้าง', CAST(200.00 AS Decimal(10, 2)), CAST(150.00 AS Decimal(10, 2)), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
USE [master]
GO
ALTER DATABASE [SHOP] SET  READ_WRITE 
GO
