USE [SmartTech]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/23/2019 2:31:14 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/23/2019 2:31:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Photo] [nvarchar](50) NULL,
	[Price] [float] NOT NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191121012031_InitialMigration', N'3.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191121225514_PhotoColumnUpdate', N'3.0.0')
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (2, N'Laptop', N'Laptop.jpg', 15, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (3, N'Keyboard', N'keyboard.jpg', 15, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (4, N'Mouse', N'Mouse.jpg', 15, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (5, N'Headphone', N'HeadPhone.jpg', 15, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (7, N'Lcd', N'', 15, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (8, N'Scanner', N'', 15, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (9, N'Printer', N'', 15, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (10, N'Camera', N'', 15, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (11, N'Radio', N'', 15, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (12, N'Rfid', N'', 15, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (13, N'Microcontroller', N'', 15, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (14, N'DVD', N'', 15, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (20, N'nimo', N'', 515, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (24, N'mhbhk', N'', 65165, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (25, N'hjvbhj', N'ggg.jpg', 5, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Photo], [Price], [LastUpdated]) VALUES (33, N'Ahmed', N'CD-ROM.png', 62, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
/****** Object:  StoredProcedure [dbo].[GetProducts]    Script Date: 11/23/2019 2:31:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[GetProducts]  
(  
 @PageIndex INT,  
 @pageSize INT ,
 @search NVARCHAR(100)=''  
)   
AS  
 BEGIN  
 SELECT s.Id ,s.Name,s.Photo ,s.Price,s.LastUpdated 
 FROM [dbo].[Product] s 

 WHERE s.Name like '%'+@search+'%'
 
 ORDER BY s.Id  OFFSET @PageSize*(@PageIndex-1) ROWS FETCH NEXT @PageSize ROWS ONLY;  
  
 SELECT COUNT(*) AS totalCount FROM [dbo].[Product]s WHERE  s.Name LIKE '%'+@search+'%';  
 END 


GO
