USE [university_TestDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamResults](
	[ExamResultID] [int] IDENTITY(1,1) NOT NULL,
	[ExamID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[Grade] [nchar](10) NULL,
 CONSTRAINT [PK_ExamResults] PRIMARY KEY CLUSTERED 
(
	[ExamResultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exams](
	[ExamID] [int] IDENTITY(1,1) NOT NULL,
	[SessionID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Exams] PRIMARY KEY CLUSTERED 
(
	[ExamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[SessionID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Gender] [nchar](10) NULL,
	[BirthDate] [date] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ExamResults] ON 

INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (1, 1, 1, N'8         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (2, 1, 2, N'3         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (3, 1, 3, N'2         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (4, 1, 4, N'7         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (5, 1, 5, N'9         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (6, 2, 1, N'7         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (7, 2, 2, N'2         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (8, 2, 3, N'3         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (9, 2, 4, N'7         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (10, 2, 5, N'9         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (11, 3, 1, N'7         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (12, 3, 2, N'3         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (13, 3, 3, N'3         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (14, 3, 4, N'2         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (15, 3, 5, N'9         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (16, 4, 1, N'7         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (17, 4, 2, N'9         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (18, 4, 3, N'2         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (19, 4, 4, N'7         ')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (20, 4, 5, N'8         ')
SET IDENTITY_INSERT [dbo].[ExamResults] OFF
GO
SET IDENTITY_INSERT [dbo].[Exams] ON 

INSERT [dbo].[Exams] ([ExamID], [SessionID], [Name], [Date]) VALUES (1, 1, N'ExamName1', CAST(N'2020-12-24T08:00:00.000' AS DateTime))
INSERT [dbo].[Exams] ([ExamID], [SessionID], [Name], [Date]) VALUES (2, 1, N'ExamName2', CAST(N'2020-12-27T08:00:00.000' AS DateTime))
INSERT [dbo].[Exams] ([ExamID], [SessionID], [Name], [Date]) VALUES (3, 1, N'ExamName3', CAST(N'2020-12-30T08:00:00.000' AS DateTime))
INSERT [dbo].[Exams] ([ExamID], [SessionID], [Name], [Date]) VALUES (4, 2, N'ExamName4', CAST(N'2020-05-28T08:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Exams] OFF
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([GroupID], [Name]) VALUES (1, N'Group1    ')
INSERT [dbo].[Groups] ([GroupID], [Name]) VALUES (2, N'Group2    ')
INSERT [dbo].[Groups] ([GroupID], [Name]) VALUES (3, N'Group3    ')
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[Sessions] ON 

INSERT [dbo].[Sessions] ([SessionID], [Name], [StartDate], [EndDate]) VALUES (1, N'Session1', CAST(N'2020-12-24T00:00:00.000' AS DateTime), CAST(N'2021-01-07T00:00:00.000' AS DateTime))
INSERT [dbo].[Sessions] ([SessionID], [Name], [StartDate], [EndDate]) VALUES (2, N'Session2', CAST(N'2020-05-24T00:00:00.000' AS DateTime), CAST(N'2020-06-07T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sessions] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentID], [GroupID], [FullName], [Gender], [BirthDate]) VALUES (1, 1, N'FullName1', N'Female    ', CAST(N'2000-02-12' AS Date))
INSERT [dbo].[Students] ([StudentID], [GroupID], [FullName], [Gender], [BirthDate]) VALUES (2, 1, N'FullName2', N'Male      ', CAST(N'2000-08-14' AS Date))
INSERT [dbo].[Students] ([StudentID], [GroupID], [FullName], [Gender], [BirthDate]) VALUES (3, 2, N'FullName3', N'FMale     ', CAST(N'2000-03-09' AS Date))
INSERT [dbo].[Students] ([StudentID], [GroupID], [FullName], [Gender], [BirthDate]) VALUES (4, 2, N'FullName4', N'Male      ', CAST(N'2001-04-15' AS Date))
INSERT [dbo].[Students] ([StudentID], [GroupID], [FullName], [Gender], [BirthDate]) VALUES (5, 3, N'FullName5', N'Male      ', CAST(N'2000-03-03' AS Date))
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
ALTER TABLE [dbo].[ExamResults]  WITH CHECK ADD  CONSTRAINT [FK_ExamResults_Exams] FOREIGN KEY([ExamID])
REFERENCES [dbo].[Exams] ([ExamID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExamResults] CHECK CONSTRAINT [FK_ExamResults_Exams]
GO
ALTER TABLE [dbo].[ExamResults]  WITH CHECK ADD  CONSTRAINT [FK_ExamResults_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExamResults] CHECK CONSTRAINT [FK_ExamResults_Students]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Sessions] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Sessions] ([SessionID])
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Sessions]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Groups]
GO
