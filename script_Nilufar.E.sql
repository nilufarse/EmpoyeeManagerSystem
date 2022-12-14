USE [WorkMS]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 8/6/2022 5:49:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeNumber] [int] NOT NULL,
	[Pasition] [nvarchar](50) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
	[DateOfEmployment] [datetime2](7) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeBackUp]    Script Date: 8/6/2022 5:49:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeBackUp](
	[Id] [int] NULL,
	[EmployeeNumber] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Pasition] [nvarchar](50) NOT NULL,
	[Phone] [int] NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
	[DateOfEmployment] [datetime2](7) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkTime]    Script Date: 8/6/2022 5:49:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkTime](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeNumber] [int] NOT NULL,
	[WorkDay] [int] NOT NULL,
	[EntryTime] [int] NOT NULL,
	[EntryMinutes] [int] NOT NULL,
	[EntrySeconds] [int] NOT NULL,
	[OutputTime] [int] NULL,
	[OutputMinutes] [int] NULL,
	[OutputSeconds] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Name], [Surname], [Id], [EmployeeNumber], [Pasition], [Phone], [Address], [Salary], [DateOfEmployment]) VALUES (N'Ceyhun', N'Bahmanli', 11, 3, N'Baytar', N'3456789', N'Baki', CAST(500.00 AS Decimal(18, 2)), CAST(N'2021-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employee] ([Name], [Surname], [Id], [EmployeeNumber], [Pasition], [Phone], [Address], [Salary], [DateOfEmployment]) VALUES (N'Nilufar', N'Eyvazova', 9, 1, N'Student', N'23456789', N'Baki', CAST(700.00 AS Decimal(18, 2)), CAST(N'2020-01-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employee] ([Name], [Surname], [Id], [EmployeeNumber], [Pasition], [Phone], [Address], [Salary], [DateOfEmployment]) VALUES (N'Aytac', N'Valehqizi', 10, 2, N'Student', N'3456789', N'Baki', CAST(800.00 AS Decimal(18, 2)), CAST(N'2019-05-08T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkTime] ON 

INSERT [dbo].[WorkTime] ([Id], [EmployeeNumber], [WorkDay], [EntryTime], [EntryMinutes], [EntrySeconds], [OutputTime], [OutputMinutes], [OutputSeconds]) VALUES (11, 2, 2, 23, 47, 43, 23, 47, 54)
INSERT [dbo].[WorkTime] ([Id], [EmployeeNumber], [WorkDay], [EntryTime], [EntryMinutes], [EntrySeconds], [OutputTime], [OutputMinutes], [OutputSeconds]) VALUES (12, 3, 2, 23, 49, 53, 23, 50, 1)
INSERT [dbo].[WorkTime] ([Id], [EmployeeNumber], [WorkDay], [EntryTime], [EntryMinutes], [EntrySeconds], [OutputTime], [OutputMinutes], [OutputSeconds]) VALUES (10, 1, 2, 23, 46, 3, 23, 47, 25)
SET IDENTITY_INSERT [dbo].[WorkTime] OFF
GO
