USE [master]
GO
/****** Object:  Database [dbcrud]    Script Date: 7/24/2024 3:54:03 PM ******/
CREATE DATABASE [dbcrud]
GO
USE [dbcrud]
GO
/****** Object:  User [publicUser]    Script Date: 7/24/2024 3:54:03 PM ******/
CREATE USER [publicUser] FOR LOGIN [publicUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [JOSEITSD\JM01]    Script Date: 7/24/2024 3:54:04 PM ******/
CREATE USER [JOSEITSD\JM01] FOR LOGIN [JOSEITSD\JM01] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [JOSEITSD\JM01]
GO
/****** Object:  UserDefinedDataType [dbo].[dt_barangayId]    Script Date: 7/24/2024 3:54:04 PM ******/
CREATE TYPE [dbo].[dt_barangayId] FROM [int] NULL
GO
/****** Object:  UserDefinedDataType [dbo].[dt_countryId]    Script Date: 7/24/2024 3:54:04 PM ******/
CREATE TYPE [dbo].[dt_countryId] FROM [tinyint] NULL
GO
/****** Object:  UserDefinedDataType [dbo].[dt_municipalityId]    Script Date: 7/24/2024 3:54:04 PM ******/
CREATE TYPE [dbo].[dt_municipalityId] FROM [smallint] NULL
GO
/****** Object:  UserDefinedDataType [dbo].[dt_provinceId]    Script Date: 7/24/2024 3:54:04 PM ******/
CREATE TYPE [dbo].[dt_provinceId] FROM [tinyint] NULL
GO
/****** Object:  UserDefinedDataType [dbo].[dt_regionId]    Script Date: 7/24/2024 3:54:04 PM ******/
CREATE TYPE [dbo].[dt_regionId] FROM [tinyint] NULL
GO
/****** Object:  UserDefinedDataType [dbo].[dt_zipCode]    Script Date: 7/24/2024 3:54:04 PM ******/
CREATE TYPE [dbo].[dt_zipCode] FROM [smallint] NULL
GO
/****** Object:  UserDefinedTableType [dbo].[philArea]    Script Date: 7/24/2024 3:54:04 PM ******/
CREATE TYPE [dbo].[philArea] AS TABLE(
	[ID] [int] NOT NULL,
	[AreaName] [varchar](max) NULL,
	[BarangayID] [dbo].[dt_barangayId] NULL,
	[MunicipalityID] [dbo].[dt_municipalityId] NULL,
	[ProvinceID] [dbo].[dt_provinceId] NULL,
	[RegionID] [dbo].[dt_regionId] NULL,
	[CountryID] [dbo].[dt_countryId] NULL
)
GO
/****** Object:  StoredProcedure [dbo].[spAddData]    Script Date: 7/24/2024 3:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spAddData]
	-- Add the parameters for the stored procedure here
		-- Add the parameters for the stored procedure here
	@firstname varchar(50),
	@lastname varchar(55)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO CrudTable(firstname,lastname) VALUES (@firstname,@lastname)
END

GO
/****** Object:  StoredProcedure [dbo].[spDeleteData]    Script Date: 7/24/2024 3:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteData]
	-- Add the parameters for the stored procedure here
		-- Add the parameters for the stored procedure here
	@id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM CrudTable WHERE id=@id
END

GO
/****** Object:  StoredProcedure [dbo].[spGetData]    Script Date: 7/24/2024 3:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetData]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM CrudTable;
END

GO
/****** Object:  StoredProcedure [dbo].[spUpdateData]    Script Date: 7/24/2024 3:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateData] 
	-- Add the parameters for the stored procedure here
		-- Add the parameters for the stored procedure here
	@id int,
	@firstname varchar(50),
	@lastname varchar(55)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE CrudTable SET firstname=@firstname, lastname=@lastname WHERE id=@id
END

GO
/****** Object:  Table [dbo].[CrudTable]    Script Date: 7/24/2024 3:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CrudTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sampletable]    Script Date: 7/24/2024 3:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sampletable](
	[id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_proj_mobile]    Script Date: 7/24/2024 3:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_proj_mobile](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[network] [varchar](50) NULL,
	[contactno] [numeric](18, 0) NULL,
 CONSTRAINT [PK_tbl_proj_mobile] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_proj_user]    Script Date: 7/24/2024 3:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_proj_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uname] [varchar](50) NULL,
	[pword] [varchar](50) NULL,
	[fname] [varchar](50) NULL,
	[lname] [varchar](50) NULL,
	[bday] [date] NULL,
	[email] [varchar](50) NULL,
	[dateCreated] [date] NULL,
	[lastLogin] [date] NULL,
 CONSTRAINT [PK_tbl_proj_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_sample]    Script Date: 7/24/2024 3:54:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_sample](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[fname] [varchar](50) NULL,
	[mn] [varchar](50) NULL,
	[lname] [varchar](50) NULL,
	[bday] [date] NULL,
	[salary] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tbl_sample] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CrudTable] ON 

GO
INSERT [dbo].[CrudTable] ([id], [firstname], [lastname]) VALUES (1, N'Ralph', N'Tampoc')
GO
INSERT [dbo].[CrudTable] ([id], [firstname], [lastname]) VALUES (2, N'Luffy', N'Monkey')
GO
INSERT [dbo].[CrudTable] ([id], [firstname], [lastname]) VALUES (3, N'Pedro', N'Penduko')
GO
SET IDENTITY_INSERT [dbo].[CrudTable] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_proj_user] ON 

GO
INSERT [dbo].[tbl_proj_user] ([id], [uname], [pword], [fname], [lname], [bday], [email], [dateCreated], [lastLogin]) VALUES (1, N'rtampoc', N'1234', N'Ralph', N'Tampoc', CAST(N'1993-05-22' AS Date), N'rtampoc@gmail.com', NULL, NULL)
GO
INSERT [dbo].[tbl_proj_user] ([id], [uname], [pword], [fname], [lname], [bday], [email], [dateCreated], [lastLogin]) VALUES (2, N'lmonkey', N'12345', N'Luffy', N'Monkey', CAST(N'2000-01-01' AS Date), N'luffy.monkey@yahoo.com', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[tbl_proj_user] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_sample] ON 

GO
INSERT [dbo].[tbl_sample] ([ID], [fname], [mn], [lname], [bday], [salary]) VALUES (4, N'Joebet', N'Maglanque', N'Dacillo', CAST(N'2005-08-22' AS Date), CAST(20000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tbl_sample] ([ID], [fname], [mn], [lname], [bday], [salary]) VALUES (5, N'Kevin', N'Gomez', N'Costes', CAST(N'2002-01-16' AS Date), CAST(10000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tbl_sample] ([ID], [fname], [mn], [lname], [bday], [salary]) VALUES (18, N'Jomar', N'San Perdro', N'Penduko', CAST(N'2005-01-02' AS Date), CAST(100000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tbl_sample] ([ID], [fname], [mn], [lname], [bday], [salary]) VALUES (19, N'Batman', N'Man', N'Daman', CAST(N'2008-08-15' AS Date), CAST(90000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tbl_sample] ([ID], [fname], [mn], [lname], [bday], [salary]) VALUES (20, N'Donut', N'Dunkin', N'Mister', CAST(N'1999-06-07' AS Date), CAST(50000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tbl_sample] ([ID], [fname], [mn], [lname], [bday], [salary]) VALUES (21, N'Mister', N'Donut', N'Dunkin', CAST(N'1980-09-22' AS Date), CAST(250000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[tbl_sample] OFF
GO
USE [master]
GO
ALTER DATABASE [dbcrud] SET  READ_WRITE 
GO
