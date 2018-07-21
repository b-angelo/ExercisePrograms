USE [master]
GO
/****** Object:  Database [ExercisePrograms]    Script Date: 7/21/2018 2:13:01 AM ******/
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
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [ExercisePrograms]
GO
/****** Object:  Schema [logging]    Script Date: 7/21/2018 2:13:02 AM ******/
CREATE SCHEMA [logging]
GO
/****** Object:  Table [dbo].[Exercise]    Script Date: 7/21/2018 2:13:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exercise](
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
/****** Object:  Table [dbo].[ExerciseHistory]    Script Date: 7/21/2018 2:13:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseHistory](
	[ExerciseHistory_Pk] [int] IDENTITY(1,1) NOT NULL,
	[ExerciseProgramExercise_Fk] [int] NOT NULL,
	[SetNumber] [int] NULL,
	[Repitions] [int] NULL,
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
	[ExerciseHistory_Pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExerciseProgram]    Script Date: 7/21/2018 2:14:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseProgram](
	[ExerciseProgram_Pk] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](250) NOT NULL,
	[DurationInDays] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ExerciseProgram_Pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExerciseProgramExercise]    Script Date: 7/21/2018 2:14:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseProgramExercise](
	[ExerciseProgramExercise_Pk] [int] IDENTITY(1,1) NOT NULL,
	[ExerciseProgram_Fk] [int] NULL,
	[Exercise_Fk] [int] NULL,
	[ExerciseDay] [int] NOT NULL,
	[ExerciseMinRepitions] [int] NOT NULL,
	[ExerciseMaxRepitions] [int] NOT NULL,
	[ExerciseSets] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ExerciseProgramExercise_Pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExerciseType]    Script Date: 7/21/2018 2:14:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseType](
	[ExerciseType_Pk] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ExerciseType_Pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MuscleGroup]    Script Date: 7/21/2018 2:14:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MuscleGroup](
	[MuscleGroup_Pk] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MuscleGroup_Pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/21/2018 2:14:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[User_Pk] [int] IDENTITY(1,1) NOT NULL,
	[UserRole_Fk] [int] NOT NULL,
	[UserName] [varchar](20) NOT NULL,
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
	[DateOfBirth] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[User_Pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserBodyMass]    Script Date: 7/21/2018 2:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserBodyMass](
	[UserBodyMass_Pk] [int] IDENTITY(1,1) NOT NULL,
	[User_Fk] [int] NOT NULL,
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
	[UserBodyMass_Pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 7/21/2018 2:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRole_Pk] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRole_Pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [logging].[AccessLog]    Script Date: 7/21/2018 2:14:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [logging].[AccessLog](
	[Access_Pk] [int] IDENTITY(1,1) NOT NULL,
	[User_Fk] [int] NULL,
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
/****** Object:  Table [logging].[ChangeLog]    Script Date: 7/21/2018 2:14:19 AM ******/
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
/****** Object:  Table [logging].[ErrorLog]    Script Date: 7/21/2018 2:14:19 AM ******/
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
SET IDENTITY_INSERT [dbo].[Exercise] ON 
GO
INSERT [dbo].[Exercise] ([Exercise_Pk], [ExerciseType_Fk], [MuscleGroup_Fk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 2, 1, N'MilitaryPress', N'Military Press', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Exercise] ([Exercise_Pk], [ExerciseType_Fk], [MuscleGroup_Fk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, 2, 2, N'BarbellMediumBenchPress', N'Barbell Medium Bench Press', CAST(N'2018-01-01T00:00:00.000' AS DateTime), NULL, N'bangelo', CAST(N'2018-05-23T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Exercise] ([Exercise_Pk], [ExerciseType_Fk], [MuscleGroup_Fk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (4, 2, 3, N'T-BarRow', N'T-Bar Row', CAST(N'2018-01-01T00:00:00.000' AS DateTime), NULL, N'bangelo', CAST(N'2018-05-23T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Exercise] ([Exercise_Pk], [ExerciseType_Fk], [MuscleGroup_Fk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (5, 2, 4, N'EzBarCurl', N'EZ-Bar Curl', CAST(N'2018-01-01T00:00:00.000' AS DateTime), NULL, N'bangelo', CAST(N'2018-05-23T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Exercise] ([Exercise_Pk], [ExerciseType_Fk], [MuscleGroup_Fk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (6, 2, 5, N'DumbellSkullCrushers', N'Dumbell Skull Crushers', CAST(N'2018-01-01T00:00:00.000' AS DateTime), NULL, N'bangelo', CAST(N'2018-05-23T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Exercise] ([Exercise_Pk], [ExerciseType_Fk], [MuscleGroup_Fk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (7, 2, 8, N'LowBarBackSquat', N'Low Bar Back Squat', CAST(N'2018-01-01T00:00:00.000' AS DateTime), NULL, N'bangelo', CAST(N'2018-05-23T00:00:00.000' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Exercise] OFF
GO
SET IDENTITY_INSERT [dbo].[ExerciseProgram] ON 
GO
INSERT [dbo].[ExerciseProgram] ([ExerciseProgram_Pk], [Name], [Description], [DurationInDays], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'4 Day Per Week - No Nonsense4-Day per Week Workout', N'Complete Workout in 60 Minutes', 180, CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime))
GO
INSERT [dbo].[ExerciseProgram] ([ExerciseProgram_Pk], [Name], [Description], [DurationInDays], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'test', N'test', 0, CAST(N'2018-06-11T00:00:00.000' AS DateTime), CAST(N'2018-06-11T00:00:00.000' AS DateTime), N'Ben Angelo', CAST(N'2018-06-10T22:47:13.883' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[ExerciseProgram] ([ExerciseProgram_Pk], [Name], [Description], [DurationInDays], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'test', N'test', 1, CAST(N'2018-06-18T00:00:00.000' AS DateTime), CAST(N'2018-06-19T00:00:00.000' AS DateTime), N'Ben Angelo', CAST(N'2018-06-12T00:17:43.203' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[ExerciseProgram] ([ExerciseProgram_Pk], [Name], [Description], [DurationInDays], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'test 3', N'test 3', 56, CAST(N'2018-06-18T00:00:00.000' AS DateTime), CAST(N'2018-08-13T00:00:00.000' AS DateTime), N'Ben Angelo', CAST(N'2018-06-12T00:21:25.537' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[ExerciseProgram] ([ExerciseProgram_Pk], [Name], [Description], [DurationInDays], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (6, N'test 3', N'test 3', 112, CAST(N'2018-06-11T00:00:00.000' AS DateTime), CAST(N'2018-10-01T00:00:00.000' AS DateTime), N'Ben Angelo', CAST(N'2018-06-12T00:22:39.323' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[ExerciseProgram] OFF
GO
SET IDENTITY_INSERT [dbo].[ExerciseProgramExercise] ON 
GO
INSERT [dbo].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk], [ExerciseProgram_Fk], [Exercise_Fk], [ExerciseDay], [ExerciseMinRepitions], [ExerciseMaxRepitions], [ExerciseSets], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 1, 1, 1, 8, 12, 3, CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ExerciseProgramExercise] OFF
GO
SET IDENTITY_INSERT [dbo].[ExerciseType] ON 
GO
INSERT [dbo].[ExerciseType] ([ExerciseType_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Cardiovascular', N'Cardio', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[ExerciseType] ([ExerciseType_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'Resistence Training', N'Resistence', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[ExerciseType] ([ExerciseType_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'Total Body', N'Complete', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[ExerciseType] ([ExerciseType_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Balance', N'Balance', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[ExerciseType] ([ExerciseType_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'Stretching', N'Stretching', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[ExerciseType] OFF
GO
SET IDENTITY_INSERT [dbo].[MuscleGroup] ON 
GO
INSERT [dbo].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Deltoid', N'Shoulder', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'Pectoral', N'Chest', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'Back', N'Back', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Bicep', N'Bicep', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'Tricep', N'Tricep', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (6, N'Forearm', N'Forearm', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (7, N'Core', N'Core', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (8, N'Quadracep', N'Quads', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (9, N'Hamstrings', N'Hamstring', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (10, N'Gastrocnemius', N'Calf', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[MuscleGroup] ([MuscleGroup_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (11, N'Trapezius', N'Traps', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[MuscleGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([User_Pk], [UserRole_Fk], [UserName], [PasswordHash], [Salt], [ResetPasswordGuid], [ResetPasswordExpirationDate], [LogInAttempts], [FirstName], [LastName], [EmailAddress], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [DateOfBirth]) VALUES (1, 1, N'siteAdmin', 0xCDE17E0B107F855C5680A357C8A4857E8CAD175C79E7A2D5F660D6B3F858AC4B3DE6F0D3636F30074BCC79B806FD59E3EF345372E653F0F29C946B61F56B0A8E, N'cb9df779-114a-4df1-885b-631e486e3792', NULL, NULL, NULL, N'Ben', N'Angelo', N'ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL, CAST(N'1980-02-18T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[User] ([User_Pk], [UserRole_Fk], [UserName], [PasswordHash], [Salt], [ResetPasswordGuid], [ResetPasswordExpirationDate], [LogInAttempts], [FirstName], [LastName], [EmailAddress], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate], [DateOfBirth]) VALUES (2, 2, N'bangelo', 0xDF138783A2E67BF1EADD311C1F1BD1A3AA3B88BC3E0E459388BECCA2CB6E9DE944A643F7DA8779F4BEE76CBA8C088A712B6532C9F43AB258D9DB1EFC05575320, N'50e10779-b7c0-4361-8f43-d71c19ce5ccd', NULL, NULL, NULL, N'Ben', N'Angelo', N'test@test.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:47:36.113' AS DateTime), CAST(N'1980-02-18T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserBodyMass] ON 
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 2, 74, 228, CAST(N'2018-05-27T00:04:35.077' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-05-27T00:04:35.077' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, 2, 74, 224, CAST(N'2018-05-20T00:05:19.490' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-05-20T00:05:19.490' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1002, 2, 74, 232, CAST(N'2018-05-28T00:25:20.487' AS DateTime), CAST(N'2018-05-28T03:07:54.610' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:25:20.487' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:07:54.610' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1003, 2, 74, 231, CAST(N'2018-05-28T00:28:41.757' AS DateTime), CAST(N'2018-05-28T03:05:16.170' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:28:41.757' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:05:16.170' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1004, 2, 74, 231, CAST(N'2018-05-28T00:33:07.757' AS DateTime), CAST(N'2018-05-28T03:05:14.977' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:33:07.760' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:05:14.977' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1005, 2, 74, 231, CAST(N'2018-05-28T00:35:03.307' AS DateTime), CAST(N'2018-05-28T03:05:13.777' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:35:03.307' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:05:13.777' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1006, 2, 74, 231, CAST(N'2018-05-28T00:35:12.200' AS DateTime), CAST(N'2018-05-28T03:05:12.627' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:35:12.200' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:05:12.627' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1007, 2, 74, 231, CAST(N'2018-05-28T00:35:13.710' AS DateTime), CAST(N'2018-05-28T03:05:11.223' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:35:13.710' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:05:11.223' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1008, 2, 74, 231, CAST(N'2018-05-28T00:35:14.470' AS DateTime), CAST(N'2018-05-28T03:05:09.893' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:35:14.470' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:05:09.893' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1009, 2, 74, 231, CAST(N'2018-05-28T00:35:15.057' AS DateTime), CAST(N'2018-05-28T03:05:08.663' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:35:15.057' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:05:08.663' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1010, 2, 74, 231, CAST(N'2018-05-28T00:35:15.450' AS DateTime), CAST(N'2018-05-28T03:05:05.380' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:35:15.450' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:05:05.380' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1011, 2, 74, 231, CAST(N'2018-05-28T00:35:15.563' AS DateTime), CAST(N'2018-05-28T03:05:03.367' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:35:15.563' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:05:03.367' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1012, 2, 74, 231, CAST(N'2018-05-28T00:35:15.977' AS DateTime), CAST(N'2018-05-28T03:05:01.813' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:35:15.977' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:05:01.813' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1013, 2, 74, 231, CAST(N'2018-05-28T00:35:16.307' AS DateTime), CAST(N'2018-05-28T03:04:59.863' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:35:16.307' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:04:59.863' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1014, 2, 74, 231, CAST(N'2018-05-28T00:35:16.380' AS DateTime), CAST(N'2018-05-28T03:04:57.560' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:35:16.383' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:04:57.560' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1015, 2, 74, 231, CAST(N'2018-05-28T00:35:16.513' AS DateTime), CAST(N'2018-05-28T03:04:55.910' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:35:16.513' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:04:55.910' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1016, 2, 74, 231, CAST(N'2018-05-28T00:35:16.927' AS DateTime), CAST(N'2018-05-28T03:04:54.477' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:35:16.927' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:04:54.477' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1017, 2, 74, 231, CAST(N'2018-05-28T00:35:17.057' AS DateTime), CAST(N'2018-05-28T03:04:51.030' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T00:35:17.057' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:04:51.030' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1018, 2, 74, 12, CAST(N'2018-05-28T01:25:24.680' AS DateTime), CAST(N'2018-05-28T02:55:25.153' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T01:25:24.680' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T02:55:25.153' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1019, 2, 74, 230, CAST(N'2018-05-28T01:44:11.123' AS DateTime), CAST(N'2018-05-28T03:05:06.877' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T01:44:11.123' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:05:06.877' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1020, 2, 74, 230, CAST(N'2018-05-28T03:05:20.043' AS DateTime), CAST(N'2018-05-28T03:07:43.587' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:05:20.043' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:07:43.587' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1021, 2, 74, 2305, CAST(N'2018-05-28T03:05:29.433' AS DateTime), CAST(N'2018-05-28T03:05:32.110' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:05:29.437' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:05:32.110' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1022, 2, 74, 185, CAST(N'2018-05-28T03:07:35.567' AS DateTime), CAST(N'2018-05-28T03:07:46.417' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:07:35.567' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:07:46.417' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1023, 2, 74, 232, CAST(N'2018-05-28T03:08:05.393' AS DateTime), CAST(N'2018-05-28T03:32:19.223' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:08:05.397' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T03:32:19.223' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1024, 2, 74, 232, CAST(N'2018-05-28T03:32:39.643' AS DateTime), NULL, N'Ben Angelo', CAST(N'2018-05-28T03:32:39.647' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1025, 2, 74, 244, CAST(N'2018-05-28T03:33:42.420' AS DateTime), NULL, N'Ben Angelo', CAST(N'2018-05-28T03:33:42.420' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1026, 2, 74, 244, CAST(N'2018-05-28T04:12:20.673' AS DateTime), CAST(N'2018-05-28T22:02:20.353' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T04:12:20.673' AS DateTime), N'Ben Angelo', CAST(N'2018-05-28T22:02:20.353' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1027, 2, 74, 230, CAST(N'2018-05-31T01:48:19.897' AS DateTime), CAST(N'2018-05-31T01:57:55.480' AS DateTime), N'Ben Angelo', CAST(N'2018-05-31T01:48:19.897' AS DateTime), N'Ben Angelo', CAST(N'2018-05-31T01:57:55.480' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1028, 2, 74, 230, CAST(N'2018-05-31T01:58:18.687' AS DateTime), CAST(N'2018-05-31T03:36:19.490' AS DateTime), N'Ben Angelo', CAST(N'2018-05-31T01:58:18.687' AS DateTime), N'Ben Angelo', CAST(N'2018-05-31T03:36:19.490' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1029, 2, 85, 230, CAST(N'2018-05-31T03:35:29.313' AS DateTime), CAST(N'2018-05-31T03:35:39.720' AS DateTime), N'Ben Angelo', CAST(N'2018-05-31T03:35:29.317' AS DateTime), N'Ben Angelo', CAST(N'2018-05-31T03:35:39.720' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1030, 2, 74, 230, CAST(N'2018-05-31T03:36:10.587' AS DateTime), NULL, N'Ben Angelo', CAST(N'2018-05-31T03:36:10.587' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1031, 2, 74, 226, CAST(N'2018-06-02T01:33:49.043' AS DateTime), NULL, N'Ben Angelo', CAST(N'2018-06-02T01:33:49.043' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1032, 2, 74, 226, CAST(N'2018-06-02T01:36:16.477' AS DateTime), CAST(N'2018-06-03T14:04:49.390' AS DateTime), N'Ben Angelo', CAST(N'2018-06-02T01:36:16.477' AS DateTime), N'Ben Angelo', CAST(N'2018-06-03T14:04:49.390' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1033, 2, 74, 226, CAST(N'2018-06-02T01:36:47.150' AS DateTime), CAST(N'2018-06-03T14:04:44.937' AS DateTime), N'Ben Angelo', CAST(N'2018-06-02T01:36:47.150' AS DateTime), N'Ben Angelo', CAST(N'2018-06-03T14:04:44.937' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1034, 2, 74, 226, CAST(N'2018-06-02T01:36:56.990' AS DateTime), CAST(N'2018-06-03T14:04:38.647' AS DateTime), N'Ben Angelo', CAST(N'2018-06-02T01:36:56.990' AS DateTime), N'Ben Angelo', CAST(N'2018-06-03T14:04:38.647' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1035, 2, 74, 226, CAST(N'2018-06-02T01:39:56.357' AS DateTime), CAST(N'2018-06-03T14:04:32.357' AS DateTime), N'Ben Angelo', CAST(N'2018-06-02T01:39:56.357' AS DateTime), N'Ben Angelo', CAST(N'2018-06-03T14:04:32.357' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1036, 2, 74, 226, CAST(N'2018-06-02T02:53:58.727' AS DateTime), CAST(N'2018-06-02T02:54:47.027' AS DateTime), N'Ben Angelo', CAST(N'2018-06-02T02:53:58.753' AS DateTime), N'Ben Angelo', CAST(N'2018-06-02T02:54:47.027' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1037, 2, 74, 228, CAST(N'2018-06-02T02:54:54.723' AS DateTime), CAST(N'2018-06-04T01:48:28.470' AS DateTime), N'Ben Angelo', CAST(N'2018-06-02T02:54:54.723' AS DateTime), N'Ben Angelo', CAST(N'2018-06-04T01:48:28.470' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1038, 2, 74, 230, CAST(N'2018-06-03T20:29:42.380' AS DateTime), CAST(N'2018-06-14T00:08:30.257' AS DateTime), N'Ben Angelo', CAST(N'2018-06-03T20:29:42.380' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:08:30.257' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1039, 2, 74, 231, CAST(N'2018-06-04T01:35:11.930' AS DateTime), CAST(N'2018-06-04T01:48:25.337' AS DateTime), N'Ben Angelo', CAST(N'2018-06-04T01:35:11.930' AS DateTime), N'Ben Angelo', CAST(N'2018-06-04T01:48:25.337' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1040, 2, 74, 215, CAST(N'2018-06-04T01:35:21.510' AS DateTime), CAST(N'2018-06-14T00:02:21.667' AS DateTime), N'Ben Angelo', CAST(N'2018-06-04T01:35:21.510' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:02:21.667' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1041, 2, 74, 200, CAST(N'2018-06-04T01:35:28.273' AS DateTime), CAST(N'2018-06-04T01:48:22.360' AS DateTime), N'Ben Angelo', CAST(N'2018-06-04T01:35:28.277' AS DateTime), N'Ben Angelo', CAST(N'2018-06-04T01:48:22.360' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1042, 2, 74, 195, CAST(N'2018-06-04T01:47:58.000' AS DateTime), CAST(N'2018-06-04T01:48:19.523' AS DateTime), N'Ben Angelo', CAST(N'2018-06-04T01:47:58.000' AS DateTime), N'Ben Angelo', CAST(N'2018-06-04T01:48:19.523' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1043, 2, 74, 190, CAST(N'2018-06-04T01:48:03.847' AS DateTime), CAST(N'2018-06-04T01:48:17.570' AS DateTime), N'Ben Angelo', CAST(N'2018-06-04T01:48:03.847' AS DateTime), N'Ben Angelo', CAST(N'2018-06-04T01:48:17.570' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1044, 2, 74, 185, CAST(N'2018-06-04T01:48:12.353' AS DateTime), CAST(N'2018-06-14T00:02:15.693' AS DateTime), N'Ben Angelo', CAST(N'2018-06-04T01:48:12.353' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:02:15.693' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1045, 2, 74, 110, CAST(N'2018-06-04T01:49:35.653' AS DateTime), CAST(N'2018-06-14T00:01:53.007' AS DateTime), N'Ben Angelo', CAST(N'2018-06-04T01:49:35.653' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:01:53.007' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1046, 2, 74, 226, CAST(N'2018-06-14T00:43:40.337' AS DateTime), NULL, N'Ben Angelo', CAST(N'2018-06-14T00:43:40.337' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1047, 2, 74, 231, CAST(N'2018-06-14T00:44:33.147' AS DateTime), CAST(N'2018-06-14T00:50:43.213' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:44:33.150' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:50:43.213' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1048, 2, 74, 231, CAST(N'2018-06-14T00:45:06.383' AS DateTime), CAST(N'2018-06-14T00:47:37.637' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:45:06.383' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:47:37.637' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1049, 2, 74, 231, CAST(N'2018-06-14T00:45:22.807' AS DateTime), CAST(N'2018-06-14T00:47:30.260' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:45:22.807' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:47:30.260' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1050, 2, 74, 231, CAST(N'2018-06-14T00:45:52.933' AS DateTime), CAST(N'2018-06-14T00:47:29.270' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:45:52.933' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:47:29.270' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1051, 2, 74, 230, CAST(N'2018-06-14T00:46:43.513' AS DateTime), CAST(N'2018-06-14T00:47:27.447' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:46:43.513' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:47:27.447' AS DateTime))
GO
INSERT [dbo].[UserBodyMass] ([UserBodyMass_Pk], [User_Fk], [HeightInInches], [WeightInPounds], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1052, 2, 74, 44, CAST(N'2018-06-14T00:47:36.090' AS DateTime), CAST(N'2018-06-14T00:50:40.783' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:47:36.090' AS DateTime), N'Ben Angelo', CAST(N'2018-06-14T00:50:40.783' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserBodyMass] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 
GO
INSERT [dbo].[UserRole] ([UserRole_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Admin', N'Site Administrator', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[UserRole] ([UserRole_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'RegisteredUser', N'Registerd User', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[UserRole] ([UserRole_Pk], [Name], [Description], [StartDate], [EndDate], [CreatedBy], [CreateDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'AnonymousUser', N'Anonymous User', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, N'MicrosoftAccount\ben.t.angelo@gmail.com', CAST(N'2018-04-25T23:40:45.927' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__49A1474086160591]    Script Date: 7/21/2018 2:14:19 AM ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__C9F28456AF967A65]    Script Date: 7/21/2018 2:14:19 AM ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [LogInAttempts]
GO
ALTER TABLE [dbo].[Exercise]  WITH CHECK ADD FOREIGN KEY([ExerciseType_Fk])
REFERENCES [dbo].[ExerciseType] ([ExerciseType_Pk])
GO
ALTER TABLE [dbo].[Exercise]  WITH CHECK ADD FOREIGN KEY([MuscleGroup_Fk])
REFERENCES [dbo].[MuscleGroup] ([MuscleGroup_Pk])
GO
ALTER TABLE [dbo].[ExerciseHistory]  WITH CHECK ADD FOREIGN KEY([ExerciseProgramExercise_Fk])
REFERENCES [dbo].[ExerciseProgramExercise] ([ExerciseProgramExercise_Pk])
GO
ALTER TABLE [dbo].[ExerciseProgramExercise]  WITH CHECK ADD FOREIGN KEY([ExerciseProgram_Fk])
REFERENCES [dbo].[ExerciseProgram] ([ExerciseProgram_Pk])
GO
ALTER TABLE [dbo].[ExerciseProgramExercise]  WITH CHECK ADD FOREIGN KEY([Exercise_Fk])
REFERENCES [dbo].[Exercise] ([Exercise_Pk])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([UserRole_Fk])
REFERENCES [dbo].[UserRole] ([UserRole_Pk])
GO
ALTER TABLE [dbo].[UserBodyMass]  WITH CHECK ADD FOREIGN KEY([User_Fk])
REFERENCES [dbo].[User] ([User_Pk])
GO
ALTER TABLE [logging].[AccessLog]  WITH CHECK ADD FOREIGN KEY([User_Fk])
REFERENCES [dbo].[User] ([User_Pk])
GO
USE [master]
GO
ALTER DATABASE [ExercisePrograms] SET  READ_WRITE 
GO
