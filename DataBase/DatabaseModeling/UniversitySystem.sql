USE [UniversitySystem]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 14.7.2013 г. 15:46:37 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[DepartmentsID] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CoursesSelected]    Script Date: 14.7.2013 г. 15:46:37 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoursesSelected](
	[CoursesID] [int] NOT NULL,
	[StudentsID] [int] NOT NULL,
 CONSTRAINT [PK_CoursesSelected] PRIMARY KEY CLUSTERED 
(
	[CoursesID] ASC,
	[StudentsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 14.7.2013 г. 15:46:37 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[FacultiesID] [int] NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 14.7.2013 г. 15:46:37 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 14.7.2013 г. 15:46:37 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](15) NULL,
	[LastName] [nvarchar](15) NULL,
	[CoursesID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Srudents]    Script Date: 14.7.2013 г. 15:46:37 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Srudents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](15) NULL,
	[LastName] [nvarchar](15) NULL,
	[FacultiesID] [int] NOT NULL,
 CONSTRAINT [PK_Srudents] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Titles]    Script Date: 14.7.2013 г. 15:46:37 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](15) NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TitlesRelatios]    Script Date: 14.7.2013 г. 15:46:37 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TitlesRelatios](
	[TitlesID] [int] NOT NULL,
	[ProfessorsID] [int] NOT NULL,
 CONSTRAINT [PK_TitlesRelatios] PRIMARY KEY CLUSTERED 
(
	[TitlesID] ASC,
	[ProfessorsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments] FOREIGN KEY([DepartmentsID])
REFERENCES [dbo].[Departments] ([ID])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments]
GO
ALTER TABLE [dbo].[CoursesSelected]  WITH CHECK ADD  CONSTRAINT [FK_CoursesSelected_Courses] FOREIGN KEY([CoursesID])
REFERENCES [dbo].[Courses] ([ID])
GO
ALTER TABLE [dbo].[CoursesSelected] CHECK CONSTRAINT [FK_CoursesSelected_Courses]
GO
ALTER TABLE [dbo].[CoursesSelected]  WITH CHECK ADD  CONSTRAINT [FK_CoursesSelected_Srudents] FOREIGN KEY([StudentsID])
REFERENCES [dbo].[Srudents] ([ID])
GO
ALTER TABLE [dbo].[CoursesSelected] CHECK CONSTRAINT [FK_CoursesSelected_Srudents]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Faculties] FOREIGN KEY([FacultiesID])
REFERENCES [dbo].[Faculties] ([ID])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Faculties]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_Prpfessors_Courses] FOREIGN KEY([CoursesID])
REFERENCES [dbo].[Courses] ([ID])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_Prpfessors_Courses]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_Prpfessors_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([ID])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_Prpfessors_Departments]
GO
ALTER TABLE [dbo].[Srudents]  WITH CHECK ADD  CONSTRAINT [FK_Srudents_Faculties1] FOREIGN KEY([FacultiesID])
REFERENCES [dbo].[Faculties] ([ID])
GO
ALTER TABLE [dbo].[Srudents] CHECK CONSTRAINT [FK_Srudents_Faculties1]
GO
ALTER TABLE [dbo].[TitlesRelatios]  WITH CHECK ADD  CONSTRAINT [FK_TitlesRelatios_Professors] FOREIGN KEY([ProfessorsID])
REFERENCES [dbo].[Professors] ([ID])
GO
ALTER TABLE [dbo].[TitlesRelatios] CHECK CONSTRAINT [FK_TitlesRelatios_Professors]
GO
ALTER TABLE [dbo].[TitlesRelatios]  WITH CHECK ADD  CONSTRAINT [FK_TitlesRelatios_Titles] FOREIGN KEY([TitlesID])
REFERENCES [dbo].[Titles] ([ID])
GO
ALTER TABLE [dbo].[TitlesRelatios] CHECK CONSTRAINT [FK_TitlesRelatios_Titles]
GO
