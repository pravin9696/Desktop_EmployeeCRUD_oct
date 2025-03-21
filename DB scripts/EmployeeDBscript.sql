USE [Shopping]
GO
/****** Object:  Table [dbo].[tblDepartment]    Script Date: 18.3.25 16:14:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDepartment](
	[dept_id] [int] IDENTITY(1,1) NOT NULL,
	[DeptName] [varchar](50) NULL,
 CONSTRAINT [PK_tblDepartment] PRIMARY KEY CLUSTERED 
(
	[dept_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 18.3.25 16:14:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[empID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [varchar](max) NULL,
	[Dept] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 
(
	[empID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblDepartment] ON 

INSERT [dbo].[tblDepartment] ([dept_id], [DeptName]) VALUES (1, N'Sales')
INSERT [dbo].[tblDepartment] ([dept_id], [DeptName]) VALUES (2, N'Account')
INSERT [dbo].[tblDepartment] ([dept_id], [DeptName]) VALUES (3, N'HR')
INSERT [dbo].[tblDepartment] ([dept_id], [DeptName]) VALUES (4, N'Development')
SET IDENTITY_INSERT [dbo].[tblDepartment] OFF
GO
SET IDENTITY_INSERT [dbo].[tblEmployee] ON 

INSERT [dbo].[tblEmployee] ([empID], [Name], [Address], [Dept], [Gender], [Email]) VALUES (1, N'vijay', N'nagar', N'', N'Male', N'vijay@gmail.com')
INSERT [dbo].[tblEmployee] ([empID], [Name], [Address], [Dept], [Gender], [Email]) VALUES (2, N'rajesh', N'pune', N'Development', N'Male', N'rajesh@gmail.com')
INSERT [dbo].[tblEmployee] ([empID], [Name], [Address], [Dept], [Gender], [Email]) VALUES (3, N'dinesh', N'mumbai', N'Sales', N'Male', N'diensh@gmail.com')
INSERT [dbo].[tblEmployee] ([empID], [Name], [Address], [Dept], [Gender], [Email]) VALUES (4, N'abcd', N'pune', N'Sales', N'Female', N'abcd@gmail.com')
INSERT [dbo].[tblEmployee] ([empID], [Name], [Address], [Dept], [Gender], [Email]) VALUES (5, N'vinod', N'nagar', N'Account', N'Male', N'vinod@gmai.ocm')
SET IDENTITY_INSERT [dbo].[tblEmployee] OFF
GO
