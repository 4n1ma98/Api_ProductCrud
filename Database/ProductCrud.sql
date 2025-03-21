USE [ProductCrudProject]
GO
/****** Object:  User [andres]    Script Date: 17/03/2025 02:32:15 a. m. ******/
CREATE USER [andres] FOR LOGIN [andres] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [andres]
GO
/****** Object:  Table [dbo].[TBL_ErrorLog]    Script Date: 17/03/2025 02:32:15 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_ErrorLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Method] [varchar](50) NOT NULL,
	[Error] [varchar](50) NOT NULL,
	[CreationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_Product]    Script Date: 17/03/2025 02:32:15 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[Price] [int] NOT NULL,
	[Stock] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_Product] ON 

INSERT [dbo].[TBL_Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (2, N'Manzana', N'Manzanas rojas de tamaño grande sin semillas', 4500, 55)
INSERT [dbo].[TBL_Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (3, N'Pera', N'Peras verdes maduras y grandes', 4000, 20)
INSERT [dbo].[TBL_Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (4, N'Aguacate', N'Aguacate grande verde maduro', 3000, 50)
INSERT [dbo].[TBL_Product] ([Id], [Name], [Description], [Price], [Stock]) VALUES (12, N'Sandia', N'Sandia jugosa madura grande sin pepas', 9000, 35)
SET IDENTITY_INSERT [dbo].[TBL_Product] OFF
GO
ALTER TABLE [dbo].[TBL_ErrorLog] ADD  DEFAULT (getdate()) FOR [CreationDate]
GO
/****** Object:  StoredProcedure [dbo].[SP_ProductCRUD]    Script Date: 17/03/2025 02:32:15 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Andres David Peña Velandia>
-- Create date: <Create Date,,2025-03-14>
-- Description:	<Description,,This is the stored procedure responsible for handling the CRUD>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ProductCRUD]
	@Option INT,
	@Id INT = NULL,
	@Name VARCHAR(50) = NULL,
	@Description VARCHAR(100) = NULL,
	@Price INT = NULL,
	@Stock INT = NULL
AS
BEGIN
	IF (@Option = 1) -- CREATE PRODUCT
	BEGIN
		INSERT INTO TBL_Product([Name], [Description], [Price], [Stock]) 
		VALUES(@Name, @Description, @Price, @Stock);
	END
	ELSE IF (@Option = 2) -- READ SPECIFIC PRODUCT
	BEGIN
		SELECT * 
		FROM TBL_Product
		WHERE Id=@Id;
	END
	ELSE IF (@Option = 3) -- UPDATE SPECIFIC PRODUCT
	BEGIN
		UPDATE TBL_Product 
		SET Price=@Price, Stock=@Stock
		WHERE Id=@Id;
	END
	ELSE IF (@Option = 4) -- DELETE SPECIFIC PRODUCT
	BEGIN
		DELETE FROM TBL_Product 
		WHERE Id=@Id;
	END
	ELSE IF (@Option = 5) -- READ PRODUCTS
	BEGIN
		SELECT * 
		FROM TBL_Product;
	END
END
GO
