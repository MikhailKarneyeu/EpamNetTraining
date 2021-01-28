USE [university_TestDB]
GO
/****** Object:  Table [dbo].[ExamResults]    Script Date: 28.01.2021 22:49:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamResults](
	[ExamResultID] [int] IDENTITY(1,1) NOT NULL,
	[ExamID] [int] NULL,
	[StudentID] [int] NULL,
	[Grade] [nvarchar](50) NULL,
 CONSTRAINT [PK_ExamResults] PRIMARY KEY CLUSTERED 
(
	[ExamResultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exams]    Script Date: 28.01.2021 22:49:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exams](
	[ExamID] [int] IDENTITY(1,1) NOT NULL,
	[SessionID] [int] NULL,
	[SubjectID] [int] NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Exams] PRIMARY KEY CLUSTERED 
(
	[ExamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 28.01.2021 22:49:26 ******/
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
/****** Object:  Table [dbo].[Sessions]    Script Date: 28.01.2021 22:49:26 ******/
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
/****** Object:  Table [dbo].[Students]    Script Date: 28.01.2021 22:49:26 ******/
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
/****** Object:  Table [dbo].[Subjects]    Script Date: 28.01.2021 22:49:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ExamResults] ON 

INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (1, 1, 1, N'2')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (2, 1, 2, N'7')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (3, 1, 3, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (4, 1, 4, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (5, 1, 5, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (6, 1, 6, N'2')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (7, 2, 1, N'2')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (8, 2, 2, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (9, 2, 3, N'2')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (10, 2, 4, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (11, 2, 5, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (12, 2, 6, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (13, 3, 1, N'2')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (14, 3, 2, N'2')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (15, 3, 3, N'2')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (16, 3, 4, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (17, 3, 5, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (18, 3, 6, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (19, 4, 1, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (20, 4, 2, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (21, 4, 3, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (22, 4, 4, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (23, 4, 5, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (24, 4, 6, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (25, 5, 1, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (26, 5, 2, N'2')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (27, 5, 3, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (28, 5, 4, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (29, 5, 5, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (30, 5, 6, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (31, 6, 1, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (32, 6, 2, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (33, 6, 3, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (34, 6, 4, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (35, 6, 5, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (36, 6, 6, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (37, 7, 1, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (38, 7, 2, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (39, 7, 3, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (40, 7, 4, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (41, 7, 5, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (42, 7, 6, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (43, 8, 1, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (44, 8, 2, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (45, 8, 3, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (46, 8, 4, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (47, 8, 5, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (48, 8, 6, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (49, 9, 1, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (50, 9, 2, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (51, 9, 3, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (52, 9, 4, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (53, 9, 5, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (54, 9, 6, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (55, 10, 1, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (56, 10, 2, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (57, 10, 3, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (58, 10, 4, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (59, 10, 5, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (60, 10, 6, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (61, 11, 1, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (62, 11, 2, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (63, 11, 3, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (64, 11, 4, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (65, 11, 5, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (66, 11, 6, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (67, 12, 1, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (68, 12, 2, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (69, 12, 3, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (70, 12, 4, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (71, 12, 5, N'8')
INSERT [dbo].[ExamResults] ([ExamResultID], [ExamID], [StudentID], [Grade]) VALUES (72, 12, 6, N'8')
SET IDENTITY_INSERT [dbo].[ExamResults] OFF
GO
SET IDENTITY_INSERT [dbo].[Exams] ON 

INSERT [dbo].[Exams] ([ExamID], [SessionID], [SubjectID], [Date]) VALUES (1, 1, 1, CAST(N'2019-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Exams] ([ExamID], [SessionID], [SubjectID], [Date]) VALUES (2, 1, 2, CAST(N'2019-05-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Exams] ([ExamID], [SessionID], [SubjectID], [Date]) VALUES (3, 1, 3, CAST(N'2019-05-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Exams] ([ExamID], [SessionID], [SubjectID], [Date]) VALUES (4, 2, 4, CAST(N'2019-12-24T00:00:00.000' AS DateTime))
INSERT [dbo].[Exams] ([ExamID], [SessionID], [SubjectID], [Date]) VALUES (5, 2, 5, CAST(N'2019-12-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Exams] ([ExamID], [SessionID], [SubjectID], [Date]) VALUES (6, 2, 6, CAST(N'2019-12-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Exams] ([ExamID], [SessionID], [SubjectID], [Date]) VALUES (7, 3, 1, CAST(N'2020-05-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Exams] ([ExamID], [SessionID], [SubjectID], [Date]) VALUES (8, 3, 2, CAST(N'2020-05-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Exams] ([ExamID], [SessionID], [SubjectID], [Date]) VALUES (9, 3, 3, CAST(N'2020-05-29T00:00:00.000' AS DateTime))
INSERT [dbo].[Exams] ([ExamID], [SessionID], [SubjectID], [Date]) VALUES (10, 4, 4, CAST(N'2020-12-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Exams] ([ExamID], [SessionID], [SubjectID], [Date]) VALUES (11, 4, 5, CAST(N'2020-12-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Exams] ([ExamID], [SessionID], [SubjectID], [Date]) VALUES (12, 4, 6, CAST(N'2020-12-30T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Exams] OFF
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([GroupID], [Name]) VALUES (1, N'Group1    ')
INSERT [dbo].[Groups] ([GroupID], [Name]) VALUES (2, N'Group2    ')
INSERT [dbo].[Groups] ([GroupID], [Name]) VALUES (3, N'Group3    ')
INSERT [dbo].[Groups] ([GroupID], [Name]) VALUES (4, N'Group4    ')
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[Sessions] ON 

INSERT [dbo].[Sessions] ([SessionID], [Name], [StartDate], [EndDate]) VALUES (1, N'Session1', CAST(N'2019-05-24T00:00:00.000' AS DateTime), CAST(N'2019-06-07T00:00:00.000' AS DateTime))
INSERT [dbo].[Sessions] ([SessionID], [Name], [StartDate], [EndDate]) VALUES (2, N'Session2', CAST(N'2019-12-23T00:00:00.000' AS DateTime), CAST(N'2020-01-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Sessions] ([SessionID], [Name], [StartDate], [EndDate]) VALUES (3, N'Session3', CAST(N'2020-05-22T00:00:00.000' AS DateTime), CAST(N'2020-06-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Sessions] ([SessionID], [Name], [StartDate], [EndDate]) VALUES (4, N'Session4', CAST(N'2020-12-24T00:00:00.000' AS DateTime), CAST(N'2021-01-07T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sessions] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentID], [GroupID], [FullName], [Gender], [BirthDate]) VALUES (1, 1, N'StudentName1', N'Male      ', CAST(N'2001-03-08' AS Date))
INSERT [dbo].[Students] ([StudentID], [GroupID], [FullName], [Gender], [BirthDate]) VALUES (2, 1, N'StudentName2', N'Female    ', CAST(N'2001-05-12' AS Date))
INSERT [dbo].[Students] ([StudentID], [GroupID], [FullName], [Gender], [BirthDate]) VALUES (3, 2, N'StudentName3', N'Male      ', CAST(N'2000-02-21' AS Date))
INSERT [dbo].[Students] ([StudentID], [GroupID], [FullName], [Gender], [BirthDate]) VALUES (4, 2, N'StudentName4', N'Male      ', CAST(N'2000-05-12' AS Date))
INSERT [dbo].[Students] ([StudentID], [GroupID], [FullName], [Gender], [BirthDate]) VALUES (5, 3, N'StudentName5', N'Female    ', CAST(N'2001-07-01' AS Date))
INSERT [dbo].[Students] ([StudentID], [GroupID], [FullName], [Gender], [BirthDate]) VALUES (6, 3, N'StudentName6', N'Male      ', CAST(N'2000-11-15' AS Date))
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([SubjectID], [Name]) VALUES (1, N'Subject1')
INSERT [dbo].[Subjects] ([SubjectID], [Name]) VALUES (2, N'Subject2')
INSERT [dbo].[Subjects] ([SubjectID], [Name]) VALUES (3, N'Subject3')
INSERT [dbo].[Subjects] ([SubjectID], [Name]) VALUES (4, N'Subject4')
INSERT [dbo].[Subjects] ([SubjectID], [Name]) VALUES (5, N'Subject5')
INSERT [dbo].[Subjects] ([SubjectID], [Name]) VALUES (6, N'Subject6')
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
ALTER TABLE [dbo].[ExamResults]  WITH CHECK ADD  CONSTRAINT [FK_ExamResults_Exams] FOREIGN KEY([ExamID])
REFERENCES [dbo].[Exams] ([ExamID])
GO
ALTER TABLE [dbo].[ExamResults] CHECK CONSTRAINT [FK_ExamResults_Exams]
GO
ALTER TABLE [dbo].[ExamResults]  WITH CHECK ADD  CONSTRAINT [FK_ExamResults_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[ExamResults] CHECK CONSTRAINT [FK_ExamResults_Students]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Sessions] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Sessions] ([SessionID])
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Sessions]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Subjects] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subjects] ([SubjectID])
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Subjects]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Groups]
GO
