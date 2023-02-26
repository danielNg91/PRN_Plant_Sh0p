USE [master]
GO
/****** Object:  Database [FlowerShopPRN]    Script Date: 2/26/2023 2:20:05 PM ******/
CREATE DATABASE [FlowerShopPRN]
GO
ALTER DATABASE [FlowerShopPRN] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET ARITHABORT OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FlowerShopPRN] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FlowerShopPRN] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FlowerShopPRN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FlowerShopPRN] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET RECOVERY FULL 
GO
ALTER DATABASE [FlowerShopPRN] SET  MULTI_USER 
GO
ALTER DATABASE [FlowerShopPRN] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FlowerShopPRN] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FlowerShopPRN] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FlowerShopPRN] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FlowerShopPRN] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FlowerShopPRN] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FlowerShopPRN', N'ON'
GO
ALTER DATABASE [FlowerShopPRN] SET QUERY_STORE = ON
GO
ALTER DATABASE [FlowerShopPRN] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FlowerShopPRN]
GO
/****** Object:  Table [dbo].[cart_item]    Script Date: 2/26/2023 2:20:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cart_item](
	[id] [int] NOT NULL,
	[cart_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_cart_item] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 2/26/2023 2:20:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[total] [decimal](18, 0) NOT NULL,
	[payment_status] [bit] NOT NULL,
	[delivery_status] [nchar](10) NOT NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_item]    Script Date: 2/26/2023 2:20:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_item](
	[id] [int] NOT NULL,
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_order_item] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 2/26/2023 2:20:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](200) NOT NULL,
	[category_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [decimal](18, 0) NOT NULL,
	[discount_id] [int] NULL,
	[created_at] [datetime] NULL,
	[modified_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_category]    Script Date: 2/26/2023 2:20:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_category](
	[id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](200) NOT NULL,
	[created_at] [datetime] NULL,
	[modified_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_product_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_discount]    Script Date: 2/26/2023 2:20:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_discount](
	[id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](200) NULL,
	[discount_percent] [decimal](18, 0) NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_product_discount] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 2/26/2023 2:20:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] NOT NULL,
	[username] [nchar](50) NOT NULL,
	[password] [nchar](50) NOT NULL,
	[fullname] [nchar](10) NOT NULL,
	[telephone] [char](15) NOT NULL,
	[email] [nchar](100) NOT NULL,
	[created_at] [datetime] NULL,
	[modified_at] [datetime] NULL,
	[role_id] [int] NOT NULL,
	[address] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_cart]    Script Date: 2/26/2023 2:20:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_cart](
	[id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[total] [decimal](18, 0) NOT NULL,
	[created_at] [datetime] NULL,
	[modified_at] [datetime] NULL,
 CONSTRAINT [PK_user_cart] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_role]    Script Date: 2/26/2023 2:20:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_role](
	[id] [int] NOT NULL,
	[role] [nchar](20) NOT NULL,
 CONSTRAINT [PK_user_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cart_item]  WITH CHECK ADD  CONSTRAINT [FK_cart_item_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[cart_item] CHECK CONSTRAINT [FK_cart_item_product]
GO
ALTER TABLE [dbo].[cart_item]  WITH CHECK ADD  CONSTRAINT [FK_cart_item_user_cart] FOREIGN KEY([cart_id])
REFERENCES [dbo].[user_cart] ([id])
GO
ALTER TABLE [dbo].[cart_item] CHECK CONSTRAINT [FK_cart_item_user_cart]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_user]
GO
ALTER TABLE [dbo].[order_item]  WITH CHECK ADD  CONSTRAINT [FK_order_item_order] FOREIGN KEY([order_id])
REFERENCES [dbo].[order] ([id])
GO
ALTER TABLE [dbo].[order_item] CHECK CONSTRAINT [FK_order_item_order]
GO
ALTER TABLE [dbo].[order_item]  WITH CHECK ADD  CONSTRAINT [FK_order_item_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[order_item] CHECK CONSTRAINT [FK_order_item_product]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_product_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[product_category] ([id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_product_category]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_product_discount] FOREIGN KEY([discount_id])
REFERENCES [dbo].[product_discount] ([id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_product_discount]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_user_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[user_role] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_user_role]
GO
ALTER TABLE [dbo].[user_cart]  WITH CHECK ADD  CONSTRAINT [FK_user_cart_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[user_cart] CHECK CONSTRAINT [FK_user_cart_user]
GO
USE [master]
GO
ALTER DATABASE [FlowerShopPRN] SET  READ_WRITE 
GO
