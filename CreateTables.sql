USE [master]
GO
/****** Object:  Database [ExercisePrograms]    Script Date: 12/19/2018 12:24:00 AM ******/
CREATE DATABASE [ExercisePrograms]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExercisePrograms', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ExercisePrograms.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ExercisePrograms_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ExercisePrograms_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ExercisePrograms] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExercisePrograms].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExercisePrograms] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExercisePrograms] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExercisePrograms] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExercisePrograms] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExercisePrograms] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExercisePrograms] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ExercisePrograms] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExercisePrograms] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExercisePrograms] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExercisePrograms] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExercisePrograms] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExercisePrograms] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExercisePrograms] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExercisePrograms] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExercisePrograms] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ExercisePrograms] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExercisePrograms] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExercisePrograms] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExercisePrograms] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExercisePrograms] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExercisePrograms] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExercisePrograms] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExercisePrograms] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ExercisePrograms] SET  MULTI_USER 
GO
ALTER DATABASE [ExercisePrograms] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExercisePrograms] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExercisePrograms] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExercisePrograms] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ExercisePrograms] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ExercisePrograms] SET QUERY_STORE = OFF
GO
USE [ExercisePrograms]
GO
/****** Object:  Schema [catalog]    Script Date: 12/19/2018 12:24:00 AM ******/
CREATE SCHEMA [catalog]
GO
/****** Object:  Schema [logging]    Script Date: 12/19/2018 12:24:00 AM ******/
CREATE SCHEMA [logging]
GO
/****** Object:  Schema [subscriber]    Script Date: 12/19/2018 12:24:00 AM ******/
CREATE SCHEMA [subscriber]
GO
/****** Object:  Schema [user]    Script Date: 12/19/2018 12:24:00 AM ******/
CREATE SCHEMA [user]
GO
/****** Object:  Table [catalog].[Exercise]    Script Date: 12/19/2018 12:24:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [catalog].[Exercise](
	[Exercise_Pk] [int] IDENTITY(1,1) NOT NULL,
	[ExerciseType_Fk] [int] NULL,
	[MuscleGroup_Fk] [int] NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Exercise_Pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [catalog].[ExerciseProgram]    Script Date: 12/19/2018 12:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [catalog].[ExerciseProgram](
	[ExerciseProgram_Pk] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](250) NOT NULL,
	[DurationInDays] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [catalog].[ExerciseProgramExercise]    Script Date: 12/19/2018 12:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [catalog].[ExerciseProgramExercise](
	[ExerciseProgramExercise_Pk] [int] IDENTITY(1,1) NOT NULL,
	[ExerciseProgram_Fk] [int] NULL,
	[Exercise_Fk] [int] NULL,
	[ExerciseDay] [int] NOT NULL,
	[ExerciseRepitions] [int] NOT NULL,
	[ExerciseSets] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [catalog].[ExerciseType]    Script Date: 12/19/2018 12:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [catalog].[ExerciseType](
	[ExerciseType_Pk] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [catalog].[MuscleGroup]    Script Date: 12/19/2018 12:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [catalog].[MuscleGroup](
	[MuscleGroup_Pk] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [catalog].[Role]    Script Date: 12/19/2018 12:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [catalog].[Role](
	[Role_Pk] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [logging].[AccessLog]    Script Date: 12/19/2018 12:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [logging].[AccessLog](
	[Access_Pk] [int] IDENTITY(1,1) NOT NULL,
	[UserProfile_Fk] [int] NULL,
	[IPAddress] [varchar](50) NULL,
	[Device] [varchar](50) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Access_Pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [logging].[ChangeLog]    Script Date: 12/19/2018 12:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [logging].[ChangeLog](
	[Change_Pk] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [varchar](50) NOT NULL,
	[ColumnName] [varchar](50) NOT NULL,
	[RecordPk] [int] NOT NULL,
	[OldValue] [varchar](1000) NOT NULL,
	[NewValue] [varchar](1000) NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Change_Pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [logging].[ErrorLog]    Script Date: 12/19/2018 12:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [logging].[ErrorLog](
	[ErrorLog_Pk] [int] IDENTITY(1,1) NOT NULL,
	[ErrorCode] [int] NOT NULL,
	[ErrorDescription] [varchar](500) NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ErrorLog_Pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [subscriber].[BodyMass]    Script Date: 12/19/2018 12:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [subscriber].[BodyMass](
	[BodyMass_Pk] [int] IDENTITY(1,1) NOT NULL,
	[Profile_Fk] [int] NOT NULL,
	[HeightInInches] [int] NOT NULL,
	[WeightInPounds] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[BodyMass_Pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [subscriber].[Profile]    Script Date: 12/19/2018 12:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [subscriber].[Profile](
	[Profile_Pk] [int] IDENTITY(1,1) NOT NULL,
	[Role_Fk] [int] NOT NULL,
	[DisplayName] [varchar](20) NOT NULL,
	[PasswordHash] [binary](64) NOT NULL,
	[Salt] [uniqueidentifier] NOT NULL,
	[ResetPasswordGuid] [uniqueidentifier] NULL,
	[ResetPasswordExpirationDate] [datetime] NULL,
	[LogInAttempts] [int] NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[EmailAddress] [varchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[DateOfBirth] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [subscriber].[Workout]    Script Date: 12/19/2018 12:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [subscriber].[Workout](
	[Workout_Pk] [int] IDENTITY(1,1) NOT NULL,
	[Profile_Fk] [int] NOT NULL,
	[ExerciseProgram_Fk] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[Complete] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [subscriber].[WorkoutHistory]    Script Date: 12/19/2018 12:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [subscriber].[WorkoutHistory](
	[WorkoutHistory_Pk] [int] IDENTITY(1,1) NOT NULL,
	[Workout_Fk] [int] NOT NULL,
	[ExerciseProgramExercise_Fk] [int] NOT NULL,
	[SetNumber] [int] NULL,
	[Repititions] [int] NULL,
	[WeightUsed] [int] NULL,
	[Duration] [int] NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[WorkoutHistory_Pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [catalog].[Exercise] ON 

INSERT [catalog].[Exercise] ([Exercise_Pk], [ExerciseType_Fk], [MuscleGroup_Fk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 2, 1, N'Squats', N'Squats', CAST(N'2018-12-10T22:16:30.187' AS DateTime), NULL, N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-10T22:16:30.187' AS DateTime), N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-10T22:16:30.187' AS DateTime))
INSERT [catalog].[Exercise] ([Exercise_Pk], [ExerciseType_Fk], [MuscleGroup_Fk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, 2, 2, N'Bench Press', N'Bench Press', CAST(N'2018-12-10T22:16:30.187' AS DateTime), NULL, N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-10T22:16:30.187' AS DateTime), N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-10T22:16:30.187' AS DateTime))
INSERT [catalog].[Exercise] ([Exercise_Pk], [ExerciseType_Fk], [MuscleGroup_Fk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, 2, 3, N'Military Press', N'Military Press', CAST(N'2018-12-12T23:14:07.517' AS DateTime), NULL, N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-12T23:14:07.517' AS DateTime), NULL, NULL)
INSERT [catalog].[Exercise] ([Exercise_Pk], [ExerciseType_Fk], [MuscleGroup_Fk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (4, 2, 4, N'Dead Lift', N'Dead Lift', CAST(N'2018-12-12T23:14:07.517' AS DateTime), NULL, N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-12T23:14:07.517' AS DateTime), NULL, NULL)
INSERT [catalog].[Exercise] ([Exercise_Pk], [ExerciseType_Fk], [MuscleGroup_Fk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (5, 2, 5, N'Barbell Curls', N'Barbell Curls', CAST(N'2018-12-12T23:14:07.517' AS DateTime), NULL, N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-12T23:14:07.517' AS DateTime), NULL, NULL)
INSERT [catalog].[Exercise] ([Exercise_Pk], [ExerciseType_Fk], [MuscleGroup_Fk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (6, 2, 6, N'Tricep Pressdowns', N'Tricep Pressdowns', CAST(N'2018-12-12T23:14:07.517' AS DateTime), NULL, N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-12T23:14:07.517' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [catalog].[Exercise] OFF
SET IDENTITY_INSERT [catalog].[ExerciseProgram] ON 

INSERT [catalog].[ExerciseProgram] ([ExerciseProgram_Pk], [Name], [Description], [DurationInDays], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'bangelo - 12/12/2018', N'Workout for 12/12/2018', 1, CAST(N'2018-12-12T23:43:40.273' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-12T23:43:40.273' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgram] ([ExerciseProgram_Pk], [Name], [Description], [DurationInDays], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'bangelo - 12/13/2018', N'Workout for 12/13/2018', 1, CAST(N'2018-12-13T00:58:08.660' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T00:58:08.660' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgram] ([ExerciseProgram_Pk], [Name], [Description], [DurationInDays], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'bangelo - 12/14/2018', N'Workout for 12/14/2018', 1, CAST(N'2018-12-14T17:26:56.413' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-14T17:26:56.413' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgram] ([ExerciseProgram_Pk], [Name], [Description], [DurationInDays], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (6, N'bangelo - 12/15/2018', N'Workout for 12/15/2018', 1, CAST(N'2018-12-15T00:00:00.000' AS DateTime), CAST(N'2018-12-15T23:59:59.000' AS DateTime), N'bangelo', CAST(N'2018-12-15T00:59:51.600' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgram] ([ExerciseProgram_Pk], [Name], [Description], [DurationInDays], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (7, N'bangelo - 12/16/2018', N'Workout for 12/16/2018', 1, CAST(N'2018-12-16T00:00:00.000' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-16T01:42:25.010' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgram] ([ExerciseProgram_Pk], [Name], [Description], [DurationInDays], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (8, N'bangelo - 12/18/2018', N'Workout for 12/18/2018', 1, CAST(N'2018-12-18T00:00:00.000' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-18T23:21:36.877' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgram] ([ExerciseProgram_Pk], [Name], [Description], [DurationInDays], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (9, N'bangelo - 12/19/2018', N'Workout for 12/19/2018', 1, CAST(N'2018-12-19T00:00:00.000' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-19T00:18:23.917' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [catalog].[ExerciseProgram] OFF
SET IDENTITY_INSERT [catalog].[ExerciseProgramExercise] ON 

INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 1, 1, 0, 0, 3, CAST(N'2018-12-12T23:45:01.927' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-12T23:45:01.927' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, 1, 2, 0, 0, 3, CAST(N'2018-12-12T23:50:29.787' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-12T23:50:29.787' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, 2, 4, 0, 0, 1, CAST(N'2018-12-13T01:24:01.437' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T01:24:01.437' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (4, 2, 6, 0, 0, 5, CAST(N'2018-12-13T01:26:47.520' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T01:26:47.520' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (5, 2, 2, 0, 0, 0, CAST(N'2018-12-13T19:06:20.650' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T19:06:20.650' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (6, 2, 5, 0, 0, 3, CAST(N'2018-12-13T19:06:37.050' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T19:06:37.050' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (7, 3, 1, 0, 0, 5, CAST(N'2018-12-14T22:29:24.473' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-14T22:29:24.473' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (8, 3, 2, 0, 0, 5, CAST(N'2018-12-14T23:22:08.223' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-14T23:22:08.223' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (9, 3, 4, 0, 0, 10, CAST(N'2018-12-14T23:58:47.777' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-14T23:58:47.777' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (13, 7, 1, 0, 0, 5, CAST(N'2018-12-16T01:42:32.317' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-16T01:42:32.317' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10, 4, 1, 0, 0, 5, CAST(N'2018-12-15T00:53:15.587' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-15T00:53:15.587' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (11, 6, 1, 0, 0, 5, CAST(N'2018-12-15T01:09:57.910' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-15T01:09:57.910' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (12, 6, 6, 0, 0, 2, CAST(N'2018-12-15T03:27:52.333' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-15T03:27:52.333' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (14, 8, 1, 0, 0, 5, CAST(N'2018-12-18T23:21:50.713' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-18T23:21:50.713' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (15, 8, 2, 0, 0, 3, CAST(N'2018-12-18T23:22:01.413' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-18T23:22:01.413' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (16, 9, 1, 0, 0, 10, CAST(N'2018-12-19T00:20:35.393' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-19T00:20:35.393' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (17, 9, 2, 0, 0, 10, CAST(N'2018-12-19T00:20:42.227' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-19T00:20:42.227' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (18, 9, 4, 0, 0, 99, CAST(N'2018-12-19T00:21:07.683' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-19T00:21:07.683' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [catalog].[ExerciseProgramExercise] OFF
SET IDENTITY_INSERT [catalog].[ExerciseType] ON 

INSERT [catalog].[ExerciseType] ([ExerciseType_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Cardio', N'Cardio', CAST(N'2018-12-10T22:14:42.377' AS DateTime), NULL, N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-10T22:14:42.377' AS DateTime), NULL, NULL)
INSERT [catalog].[ExerciseType] ([ExerciseType_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'Resistance', N'Resistance', CAST(N'2018-12-10T22:14:42.377' AS DateTime), NULL, N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-10T22:14:42.377' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [catalog].[ExerciseType] OFF
SET IDENTITY_INSERT [catalog].[MuscleGroup] ON 

INSERT [catalog].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Legs', N'Legs', CAST(N'2018-12-10T22:14:01.747' AS DateTime), NULL, N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-10T22:14:01.747' AS DateTime), NULL, NULL)
INSERT [catalog].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'Chest', N'Chest', CAST(N'2018-12-10T22:14:01.747' AS DateTime), NULL, N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-10T22:14:01.747' AS DateTime), NULL, NULL)
INSERT [catalog].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'Shoulders', N'Shoulders', CAST(N'2018-12-12T23:10:01.440' AS DateTime), NULL, N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-12T23:10:01.440' AS DateTime), NULL, NULL)
INSERT [catalog].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Back', N'Back', CAST(N'2018-12-12T23:10:01.440' AS DateTime), NULL, N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-12T23:10:01.440' AS DateTime), NULL, NULL)
INSERT [catalog].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'Biceps', N'Biceps', CAST(N'2018-12-12T23:10:01.440' AS DateTime), NULL, N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-12T23:10:01.440' AS DateTime), NULL, NULL)
INSERT [catalog].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (6, N'Triceps', N'Triceps', CAST(N'2018-12-12T23:10:01.440' AS DateTime), NULL, N'LAPTOP-RVSGHA90\bangelo', CAST(N'2018-12-12T23:10:01.440' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [catalog].[MuscleGroup] OFF
SET IDENTITY_INSERT [subscriber].[Workout] ON 

INSERT [subscriber].[Workout] ([Workout_Pk], [Profile_Fk], [ExerciseProgram_Fk], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Complete]) VALUES (1, 1, 1, CAST(N'2018-12-12T00:00:00.000' AS DateTime), CAST(N'2018-12-12T23:59:59.000' AS DateTime), N'bangelo', CAST(N'2018-12-12T23:43:40.303' AS DateTime), N'bangelo', CAST(N'2018-12-15T23:58:08.430' AS DateTime), 1)
INSERT [subscriber].[Workout] ([Workout_Pk], [Profile_Fk], [ExerciseProgram_Fk], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Complete]) VALUES (2, 1, 2, CAST(N'2018-12-13T00:00:00.000' AS DateTime), CAST(N'2018-12-13T23:59:59.000' AS DateTime), N'bangelo', CAST(N'2018-12-13T00:58:08.667' AS DateTime), N'bangelo', CAST(N'2018-12-16T00:50:16.707' AS DateTime), 1)
INSERT [subscriber].[Workout] ([Workout_Pk], [Profile_Fk], [ExerciseProgram_Fk], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Complete]) VALUES (3, 1, 3, CAST(N'2018-12-14T00:00:00.000' AS DateTime), CAST(N'2018-12-14T23:59:59.000' AS DateTime), N'bangelo', CAST(N'2018-12-14T17:26:56.447' AS DateTime), N'bangelo', CAST(N'2018-12-16T01:36:34.693' AS DateTime), 1)
INSERT [subscriber].[Workout] ([Workout_Pk], [Profile_Fk], [ExerciseProgram_Fk], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Complete]) VALUES (6, 1, 6, CAST(N'2018-12-15T00:59:51.600' AS DateTime), CAST(N'2018-12-15T23:59:59.000' AS DateTime), N'bangelo', CAST(N'2018-12-15T00:59:51.600' AS DateTime), N'bangelo', CAST(N'2018-12-16T01:36:47.600' AS DateTime), 1)
INSERT [subscriber].[Workout] ([Workout_Pk], [Profile_Fk], [ExerciseProgram_Fk], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Complete]) VALUES (7, 1, 7, CAST(N'2018-12-16T01:42:25.040' AS DateTime), CAST(N'2018-12-16T23:59:59.000' AS DateTime), N'bangelo', CAST(N'2018-12-16T01:42:25.040' AS DateTime), N'bangelo', CAST(N'2018-12-16T03:06:06.527' AS DateTime), 1)
INSERT [subscriber].[Workout] ([Workout_Pk], [Profile_Fk], [ExerciseProgram_Fk], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Complete]) VALUES (8, 1, 8, CAST(N'2018-12-18T23:21:36.903' AS DateTime), CAST(N'2018-12-18T23:59:59.000' AS DateTime), N'bangelo', CAST(N'2018-12-18T23:21:36.903' AS DateTime), NULL, NULL, 0)
INSERT [subscriber].[Workout] ([Workout_Pk], [Profile_Fk], [ExerciseProgram_Fk], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [Complete]) VALUES (9, 1, 9, CAST(N'2018-12-19T00:18:23.923' AS DateTime), CAST(N'2018-12-19T23:59:59.000' AS DateTime), N'bangelo', CAST(N'2018-12-19T00:18:23.923' AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [subscriber].[Workout] OFF
SET IDENTITY_INSERT [subscriber].[WorkoutHistory] ON 

INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 2, 3, 1, 5, 225, 0, CAST(N'2018-12-13T23:22:49.407' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T23:22:49.407' AS DateTime), N'bangelo', CAST(N'2018-12-14T00:43:37.247' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, 2, 6, 1, 10, 95, 0, CAST(N'2018-12-13T23:25:14.007' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T23:25:14.007' AS DateTime), NULL, NULL)
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, 2, 6, 2, 8, 95, 0, CAST(N'2018-12-13T23:25:28.057' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T23:25:28.057' AS DateTime), NULL, NULL)
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (4, 2, 6, 3, 8, 95, 0, CAST(N'2018-12-13T23:25:30.673' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T23:25:30.673' AS DateTime), N'bangelo', CAST(N'2018-12-13T23:25:35.357' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (5, 2, 4, 1, 12, 120, 0, CAST(N'2018-12-13T23:27:15.043' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T23:27:15.043' AS DateTime), NULL, NULL)
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (6, 1, 1, 1, 5, 225, 0, CAST(N'2018-12-13T23:49:29.997' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T23:49:29.997' AS DateTime), NULL, NULL)
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (7, 1, 1, 2, 5, 225, 0, CAST(N'2018-12-13T23:49:31.553' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T23:49:31.553' AS DateTime), NULL, NULL)
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (8, 1, 1, 3, 5, 225, 0, CAST(N'2018-12-13T23:49:32.287' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T23:49:32.287' AS DateTime), N'bangelo', CAST(N'2018-12-15T03:36:31.913' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (9, 1, 2, 1, 5, 185, 0, CAST(N'2018-12-13T23:50:35.480' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T23:50:35.480' AS DateTime), NULL, NULL)
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10, 1, 2, 2, 5, 185, 0, CAST(N'2018-12-13T23:50:36.450' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T23:50:36.450' AS DateTime), NULL, NULL)
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (11, 1, 2, 3, 5, 185, 0, CAST(N'2018-12-13T23:50:37.220' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-13T23:50:37.220' AS DateTime), N'bangelo', CAST(N'2018-12-15T03:37:04.273' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (12, 2, 0, 0, 0, 0, 0, CAST(N'2018-12-14T00:22:11.527' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-14T00:22:11.527' AS DateTime), N'bangelo', CAST(N'2018-12-14T00:23:38.130' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (13, 3, 7, 1, 6, 250, 0, CAST(N'2018-12-14T22:29:43.493' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-14T22:29:43.493' AS DateTime), N'bangelo', CAST(N'2018-12-14T23:50:58.467' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (14, 3, 7, 2, 4, 255, 0, CAST(N'2018-12-14T23:21:42.147' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-14T23:21:42.147' AS DateTime), N'bangelo', CAST(N'2018-12-15T00:03:17.947' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (15, 3, 7, 0, 7, 250, 0, CAST(N'2018-12-14T23:54:11.923' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-14T23:54:11.923' AS DateTime), NULL, NULL)
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (16, 4, 10, 1, 0, 0, 0, CAST(N'2018-12-15T00:56:16.487' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-15T00:56:16.487' AS DateTime), NULL, NULL)
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (17, 6, 11, 2, 3, 9, 0, CAST(N'2018-12-15T01:28:14.503' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-15T01:28:14.503' AS DateTime), N'bangelo', CAST(N'2018-12-15T23:18:35.517' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (18, 6, 11, 1, 25, 308, 0, CAST(N'2018-12-15T01:28:29.627' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-15T01:28:29.627' AS DateTime), N'bangelo', CAST(N'2018-12-16T00:12:57.273' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (19, 6, 11, 5, 4, 3, 0, CAST(N'2018-12-15T02:02:15.293' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-15T02:02:15.293' AS DateTime), N'bangelo', CAST(N'2018-12-15T15:17:32.090' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (20, 6, 11, 4, 2, 5, 0, CAST(N'2018-12-15T02:08:15.473' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-15T02:08:15.473' AS DateTime), N'bangelo', CAST(N'2018-12-15T15:09:01.210' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (21, 6, 11, 3, 3, 700, 0, CAST(N'2018-12-15T03:03:55.210' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-15T03:03:55.210' AS DateTime), N'bangelo', CAST(N'2018-12-15T03:35:03.257' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (22, 6, 12, 1, 1, 1, 0, CAST(N'2018-12-16T00:54:37.077' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-16T00:54:37.077' AS DateTime), NULL, NULL)
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (23, 7, 13, 1, 6, 226, 0, CAST(N'2018-12-16T02:13:54.293' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-16T02:13:54.293' AS DateTime), N'bangelo', CAST(N'2018-12-16T02:57:11.443' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (24, 7, 13, 2, 5, 225, 0, CAST(N'2018-12-16T02:14:01.893' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-16T02:14:01.893' AS DateTime), N'bangelo', CAST(N'2018-12-16T02:57:10.563' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (25, 7, 13, 3, 5, 226, 0, CAST(N'2018-12-16T02:14:09.593' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-16T02:14:09.593' AS DateTime), N'bangelo', CAST(N'2018-12-16T02:38:00.833' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (26, 7, 13, 4, 6, 225, 0, CAST(N'2018-12-16T02:18:55.043' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-16T02:18:55.043' AS DateTime), N'bangelo', CAST(N'2018-12-16T02:57:20.550' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (27, 7, 13, 5, 5, 226, 0, CAST(N'2018-12-16T02:21:29.247' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-16T02:21:29.247' AS DateTime), N'bangelo', CAST(N'2018-12-16T02:38:09.040' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (28, 8, 14, 1, 5, 225, 0, CAST(N'2018-12-18T23:27:55.847' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-18T23:27:55.847' AS DateTime), N'bangelo', CAST(N'2018-12-19T00:19:07.517' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (29, 8, 14, 2, 5, 225, 0, CAST(N'2018-12-18T23:49:52.930' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-18T23:49:52.930' AS DateTime), N'bangelo', CAST(N'2018-12-18T23:50:42.433' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (30, 8, 14, 3, 5, 225, 0, CAST(N'2018-12-18T23:50:42.880' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-18T23:50:42.880' AS DateTime), NULL, NULL)
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (31, 8, 15, 1, 8, 185, 0, CAST(N'2018-12-18T23:50:44.343' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-18T23:50:44.343' AS DateTime), N'bangelo', CAST(N'2018-12-18T23:51:10.097' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (32, 8, 15, 2, 8, 185, 0, CAST(N'2018-12-18T23:50:44.823' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-18T23:50:44.823' AS DateTime), N'bangelo', CAST(N'2018-12-18T23:51:10.780' AS DateTime))
INSERT [subscriber].[WorkoutHistory] ([WorkoutHistory_Pk], [Workout_Fk], [ExerciseProgramExercise_Fk], [SetNumber], [Repititions], [WeightUsed], [Duration], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (33, 8, 15, 3, 8, 185, 0, CAST(N'2018-12-18T23:50:45.290' AS DateTime), NULL, N'bangelo', CAST(N'2018-12-18T23:50:45.290' AS DateTime), N'bangelo', CAST(N'2018-12-18T23:51:11.230' AS DateTime))
SET IDENTITY_INSERT [subscriber].[WorkoutHistory] OFF
ALTER TABLE [subscriber].[Workout] ADD  DEFAULT ((0)) FOR [Complete]
GO
USE [master]
GO
ALTER DATABASE [ExercisePrograms] SET  READ_WRITE 
GO
