USE [master]
GO
/****** Object:  Database [haha2]    Script Date: 2018/5/17 17:18:59 ******/
CREATE DATABASE [haha2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'haha2', FILENAME = N'D:\software\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\haha2.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'haha2_log', FILENAME = N'D:\software\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\haha2_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [haha2] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [haha2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [haha2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [haha2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [haha2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [haha2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [haha2] SET ARITHABORT OFF 
GO
ALTER DATABASE [haha2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [haha2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [haha2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [haha2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [haha2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [haha2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [haha2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [haha2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [haha2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [haha2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [haha2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [haha2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [haha2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [haha2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [haha2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [haha2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [haha2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [haha2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [haha2] SET  MULTI_USER 
GO
ALTER DATABASE [haha2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [haha2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [haha2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [haha2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [haha2] SET DELAYED_DURABILITY = DISABLED 
GO
USE [haha2]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 2018/5/17 17:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Attendance](
	[AID] [varchar](50) NOT NULL,
	[UserID] [varchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Time] [datetime] NOT NULL,
	[Photo] [varchar](128) NULL,
	[Lat] [float] NOT NULL,
	[Lng] [float] NOT NULL,
 CONSTRAINT [PK_ATTENDANCE] PRIMARY KEY CLUSTERED 
(
	[AID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LeaderShip]    Script Date: 2018/5/17 17:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LeaderShip](
	[UserID] [varchar](50) NOT NULL,
	[LeaderID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LEADERSHIP] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[LeaderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonPosition]    Script Date: 2018/5/17 17:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonPosition](
	[PositionID] [varchar](50) NOT NULL,
	[UserID] [varchar](50) NOT NULL,
	[PositionDate] [date] NOT NULL,
	[PositionTime] [datetime] NOT NULL,
	[Lat] [float] NOT NULL,
	[Lng] [float] NOT NULL,
 CONSTRAINT [PK_PERSONPOSITION] PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Problem]    Script Date: 2018/5/17 17:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Problem](
	[ProblemID] [varchar](50) NOT NULL,
	[BigClass] [varchar](16) NOT NULL,
	[SmallClass] [varchar](16) NOT NULL,
	[Title] [varchar](32) NOT NULL,
	[AuthorID] [varchar](50) NOT NULL,
	[Address] [varchar](64) NOT NULL,
	[Description] [varchar](128) NULL,
	[ProblemShot] [varchar](128) NULL,
	[UploadDate] [date] NOT NULL,
	[UploadTime] [datetime] NOT NULL,
	[Road] [varchar](32) NOT NULL,
	[Lat] [float] NOT NULL,
	[Lng] [float] NOT NULL,
	[IsHandled] [bit] NOT NULL,
	[IsReviewed] [bit] NOT NULL,
	[ReviewShot] [varchar](128) NULL,
	[HandleDate] [date] NULL,
	[HandleTime] [datetime] NULL,
	[ReviewDate] [date] NULL,
	[ReviewTime] [datetime] NULL,
 CONSTRAINT [PK_PROBLEM] PRIMARY KEY CLUSTERED 
(
	[ProblemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 2018/5/17 17:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [varchar](50) NOT NULL,
	[TypeID] [varchar](50) NOT NULL,
	[Username] [varchar](16) NOT NULL,
	[Password] [varchar](64) NOT NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Userinfo]    Script Date: 2018/5/17 17:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Userinfo](
	[UserID] [varchar](50) NOT NULL,
	[Department] [varchar](32) NULL,
	[Road] [varchar](32) NULL,
	[Name] [varchar](16) NULL,
	[Gender] [varchar](8) NULL,
	[Photo] [varchar](128) NULL,
	[Age] [int] NULL,
	[WorkID] [varchar](32) NULL,
 CONSTRAINT [PK_USERINFO] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usertype]    Script Date: 2018/5/17 17:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usertype](
	[TypeID] [varchar](50) NOT NULL,
	[TypeName] [varchar](16) NOT NULL,
 CONSTRAINT [PK_USERTYPE] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_ATTENDAN_REFERENCE_USER] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_ATTENDAN_REFERENCE_USER]
GO
ALTER TABLE [dbo].[LeaderShip]  WITH CHECK ADD  CONSTRAINT [FK_LEADERSH_REFERENCE_USER] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[LeaderShip] CHECK CONSTRAINT [FK_LEADERSH_REFERENCE_USER]
GO
ALTER TABLE [dbo].[PersonPosition]  WITH CHECK ADD  CONSTRAINT [FK_PERSONPO_REFERENCE_USER] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[PersonPosition] CHECK CONSTRAINT [FK_PERSONPO_REFERENCE_USER]
GO
ALTER TABLE [dbo].[Problem]  WITH CHECK ADD  CONSTRAINT [FK_PROBLEM_REFERENCE_USER] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Problem] CHECK CONSTRAINT [FK_PROBLEM_REFERENCE_USER]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_USER_REFERENCE_USERTYPE] FOREIGN KEY([TypeID])
REFERENCES [dbo].[Usertype] ([TypeID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_USER_REFERENCE_USERTYPE]
GO
ALTER TABLE [dbo].[Userinfo]  WITH CHECK ADD  CONSTRAINT [FK_USERINFO_REFERENCE_USER] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Userinfo] CHECK CONSTRAINT [FK_USERINFO_REFERENCE_USER]
GO
USE [master]
GO
ALTER DATABASE [haha2] SET  READ_WRITE 
GO
