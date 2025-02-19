USE [ShoppingCart]
GO
/****** Object:  UserDefinedTableType [dbo].[typeCart]    Script Date: 8/5/2024 6:25:59 PM ******/
CREATE TYPE [dbo].[typeCart] AS TABLE(
	[Id] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL,
	[active] [bit] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[typeCartItem]    Script Date: 8/5/2024 6:25:59 PM ******/
CREATE TYPE [dbo].[typeCartItem] AS TABLE(
	[Id] [nvarchar](max) NULL,
	[Qty] [int] NULL,
	[ProductId] [nvarchar](max) NULL,
	[CartId] [nvarchar](max) NULL,
	[active] [bit] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[typeProduct]    Script Date: 8/5/2024 6:25:59 PM ******/
CREATE TYPE [dbo].[typeProduct] AS TABLE(
	[Id] [nvarchar](max) NULL,
	[ProductCode] [nvarchar](50) NULL,
	[ProductDescription] [nvarchar](max) NULL,
	[price] [numeric](18, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[typeUser]    Script Date: 8/5/2024 6:25:59 PM ******/
CREATE TYPE [dbo].[typeUser] AS TABLE(
	[Id] [nvarchar](max) NULL,
	[name] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL
)
GO
/****** Object:  Table [dbo].[ShoppingCart]    Script Date: 8/5/2024 6:25:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCart](
	[Id] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL,
	[active] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCartItem]    Script Date: 8/5/2024 6:25:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCartItem](
	[Id] [nvarchar](max) NULL,
	[Qty] [int] NULL,
	[ProductId] [nvarchar](max) NULL,
	[CartId] [nvarchar](max) NULL,
	[active] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingOrder]    Script Date: 8/5/2024 6:25:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingOrder](
	[Id] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL,
	[CartId] [nvarchar](max) NULL,
	[createdDate] [datetime] NULL,
	[active] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingProduct]    Script Date: 8/5/2024 6:25:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingProduct](
	[Id] [nvarchar](max) NULL,
	[ProductCode] [nvarchar](50) NULL,
	[ProductDescription] [nvarchar](max) NULL,
	[Price] [numeric](18, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingUser]    Script Date: 8/5/2024 6:25:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingUser](
	[Id] [nvarchar](max) NULL,
	[name] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[ShoppingProduct] ([Id], [ProductCode], [ProductDescription], [Price]) VALUES (N'5cfc8617-e523-4263-9234-a15ea50abe4ep1', N'001', N'Pencil', CAST(1500.00 AS Numeric(18, 2)))
INSERT [dbo].[ShoppingProduct] ([Id], [ProductCode], [ProductDescription], [Price]) VALUES (N'5cfc8617-e523-4263-9234-a15ea50abe4ep2', N'002', N'Laptop', CAST(1150000.00 AS Numeric(18, 2)))
INSERT [dbo].[ShoppingProduct] ([Id], [ProductCode], [ProductDescription], [Price]) VALUES (N'5cfc8617-e523-4263-9234-a15ea50abe4ep3', N'003', N'Shancall', CAST(50000.00 AS Numeric(18, 2)))
INSERT [dbo].[ShoppingProduct] ([Id], [ProductCode], [ProductDescription], [Price]) VALUES (N'5cfc8617-e523-4263-9234-a15ea50abe4ep4', N'004', N'HeadPhone', CAST(50000.00 AS Numeric(18, 2)))
INSERT [dbo].[ShoppingUser] ([Id], [name], [phone], [address]) VALUES (N'5cfc8617-e523-4263-9234-a15ea50abe4eu1', N'Nwe Yin Aye', N'09977722802', N'Pyay')
INSERT [dbo].[ShoppingUser] ([Id], [name], [phone], [address]) VALUES (N'5cfc8617-e523-4263-9234-a15ea50abe4eu2', N'Thu Zar Aye', N'09977722801', N'Yangon')
INSERT [dbo].[ShoppingUser] ([Id], [name], [phone], [address]) VALUES (N'5cfc8617-e523-4263-9234-a15ea50abe4eu3', N'Phu Kyaw Win', N'09977722801', N'Yangon')
INSERT [dbo].[ShoppingUser] ([Id], [name], [phone], [address]) VALUES (N'5cfc8617-e523-4263-9234-a15ea50abe4eu4', N'Si Thu Naing', N'09977722801', N'Yangon')
ALTER TABLE [dbo].[ShoppingOrder] ADD  DEFAULT (getdate()) FOR [createdDate]
GO
/****** Object:  StoredProcedure [dbo].[spCreateNewShoppingCart]    Script Date: 8/5/2024 6:25:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






cREATE PROCEDURE [dbo].[spCreateNewShoppingCart]
	@cart AS typeCart READONLY

AS
	BEGIN


	INSERT INTO [dbo].[ShoppingCart]
           ([Id]
           ,[UserId]
           ,[active])
     
	 select * From @cart


	
	 select '001' as code,'Success' as Message

	END



GO
/****** Object:  StoredProcedure [dbo].[spRemoveItem]    Script Date: 8/5/2024 6:25:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spRemoveItem]
@userId nvarchar(max),
@cartId nvarchar(max),
@productId nvarchar(max)
AS 
BEGIN
update [ShoppingCartItem] set active = 0 where cartId=(select Id from [ShoppingCart]
where userId=@userId and Id=@cartId)
and ProductId=@productId

select '001' as code,'Success' as Message
END

GO
/****** Object:  StoredProcedure [dbo].[spSelectUserShoppingCart2]    Script Date: 8/5/2024 6:25:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--EXEC spSelectUserShoppingCart2 @userId = '5cfc8617-e523-4263-9234-a15ea50abe4eu2'; 



CREATE PROCEDURE [dbo].[spSelectUserShoppingCart2]
@userId nvarchar(max)
AS 
BEGIN

select * from [dbo].[ShoppingUser]
where id =@userId

declare @cartId nvarchar(50);

select @cartId = Id from [ShoppingCart] where userId=@userId;



select * from [ShoppingCart]
where Id =@cartId

select item.cartId as cartId,Qty,ProductCode,ProductDescription,Price from [ShoppingCartItem] item
LEFT JOIN [ShoppingProduct] product on item.ProductId = product.Id
where active=1 and cartId In (@cartId) 

END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateShoppingCart]    Script Date: 8/5/2024 6:25:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






cREATE PROCEDURE [dbo].[spUpdateShoppingCart]
	@cartItem AS typeCartItem READONLY

AS
	BEGIN

	 INSERT INTO [dbo].[ShoppingCartItem]
           ([Id]
           ,[Qty]
           ,[ProductId]
		   ,[CartId]
		   ,[active])
     
	 select * From @cartItem

	
	 select '001' as code,'Success' as Message

	END



GO
