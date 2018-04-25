Use ExercisePrograms

--create schema logging--

Begin Tran

declare @date datetime = getdate()
declare @user varchar(50) = system_user

Create Table UserRole
(
	UserRole_Pk int identity primary key not null,
	Name varchar(20) not null, -- Admin, General Users, etc.
	Description varchar(50) not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into UserRole
Values ('Admin', 'Site Administrator', @date, null, @user, @date,null, null),
       ('RegisteredUser', 'Registerd User', @date, null, @user, @date,null, null),
	   ('AnonymousUser', 'Anonymous User', @date, null, @user, @date,null, null)

Select *
From UserRole

Create Table [User]
(
	User_Pk int identity primary key not null,
	UserRole_Fk int foreign key references UserRole(UserRole_Pk) not null,
	UserName varchar(20) unique not null,
	PasswordHash binary(64) not null,
	Salt uniqueidentifier not null,
	ResetPasswordGuid uniqueidentifier null,
	ResetPasswordExpirationDate datetime null,
	LogInAttempts int null default 0,
	FirstName varchar(50) not null,
	LastName varchar(100) not null,
	EmailAddress varchar(50) unique not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

declare @salt1 as uniqueidentifier = newid()
declare @salt2 as uniqueidentifier = newid()

Insert Into [User]
Values (1, 'siteAdmin', HASHBYTES('SHA2_512', 'test123'+CAST(@salt1 AS NVARCHAR(36))), @salt1, null, null, null, 'Ben', 'Angelo', 'ben.t.angelo@gmail.com', @date, null, @user, @date,null, null),
       (2, 'bangelo', HASHBYTES('SHA2_512', 'test1234'+CAST(@salt2 AS NVARCHAR(36))), @salt2, null, null, null, 'Ben', 'Angelo', 'testEmail@example.com', @date, null, @user, @date,null, null)

Select *
From [User]

Create Table AccessLevel
(
	AccessLevel_Pk int identity primary key not null,
	Name varchar(20) not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into AccessLevel
Values ('Write', @date, null, @user, @date,null, null),
	   ('Read', @date, null, @user, @date,null, null)

Select *
From AccessLevel

Create Table AccountRole
(
	AccountRole_Pk int identity primary key not null,
	Name varchar(20) not null,
	AccessLevel_Fk int foreign key references AccessLevel(AccessLevel_Pk) not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into AccountRole
Values ('AccountPrimary', 1, @date, null, @user, @date,null, null),
	   ('AccountSecondary', 2, @date, null, @user, @date,null, null)

Select *
From AccountRole

Create Table Account
(
	Account_Pk int identity primary key not null,
	Name varchar(50) not null,
	Description varchar(50) null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into Account
Values ('Test Account', null, @date, null, @user, @date,null, null)

Select *
From Account

Create Table UserAccount
(
	UserAccount_Pk int identity primary key not null,
	Account_Fk int foreign key references Account(Account_Pk) not null,
	AccountRole_Fk int foreign key references AccountRole(AccountRole_Pk) not null,
	User_Fk int foreign key references [User](User_Pk) not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into UserAccount
Values (1, 1, 2, @date, null, @user, @date,null, null)

Select *
From UserAccount

Create Table logging.ErrorLog
(
	ErrorLog_Pk int identity primary key not null,	
	ErrorCode int not null,
	ErrorDescription varchar(500) not null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Select *
From logging.ErrorLog

Create Table logging.AccessLog
(
	Access_Pk int identity primary key not null,	
	User_Fk int foreign key references [User](User_Pk) null,
	IPAddress varchar(50) null,
	Device varchar(50) null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Select *
From logging.AccessLog

Create Table logging.ChangeLog
(
	Change_Pk int identity primary key not null,	
	TableName varchar(50) not null,	
	ColumnName varchar(50) not null,
	RecordPk int not null,
	OldValue varchar(1000) not null,
	NewValue varchar(1000) not null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Select *
From logging.ChangeLog

Create Table ExerciseType
(
	ExerciseType_Pk int identity primary key not null,
	Name varchar(100) not null,
	NickName varchar(50) not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

insert into ExerciseType
values ('Cardiovascular', 'Cardio', @date, null, @user, @date, null, null),
	   ('Resistence Training', 'Resistence', @date, null, @user, @date, null, null),
	   ('Total Body', 'Complete', @date, null, @user, @date, null, null),
	   ('Balance', 'Balance', @date, null, @user, @date, null, null),
	   ('Stretching', 'Stretching', @date, null, @user, @date, null, null)

select *
from ExerciseType

Create Table MuscleGroup
(
	MuscleGroup_Pk int identity primary key not null,
	Name varchar(100) not null,
	NickName varchar(50) not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

insert into MuscleGroup
values ('Deltoid', 'Shoulder', @date, null, @user, @date, null, null),
	   ('Pectoral', 'Chest', @date, null, @user, @date, null, null),
	   ('Back', 'Back', @date, null, @user, @date, null, null),
	   ('Bicep', 'Bicep', @date, null, @user, @date, null, null),
	   ('Tricep', 'Tricep', @date, null, @user, @date, null, null),
	   ('Forearm', 'Forearm', @date, null, @user, @date, null, null),
	   ('Core', 'Core', @date, null, @user, @date, null, null),
	   ('Quadracep', 'Quads', @date, null, @user, @date, null, null),
	   ('Hamstrings', 'Hamstring', @date, null, @user, @date, null, null),
	   ('Gastrocnemius', 'Calf', @date, null, @user, @date, null, null),
	   ('Trapezius', 'Traps', @date, null, @user, @date, null, null)

select *
from MuscleGroup

Create Table Exercise
(
	Exercise_Pk int identity primary key not null,
	ExerciseType_Fk int foreign key references ExerciseType(ExerciseType_Pk) null,
	MuscleGroup_Fk int foreign key references MuscleGroup(MuscleGroup_Pk) null,
	Name varchar(50) not null,
	Description varchar(100) not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

insert into Exercise
values (2, 1, 'MilitaryPress', 'Military Press', @date, null, @user, @date, null, null)

select *
from Exercise

Create Table ExerciseSecondaryMuscleGroup
(
	ExerciseSecondaryMuscleGroup_Pk int identity primary key not null,
	Exercise_Fk int foreign key references Exercise(Exercise_Pk) null,
	MuscleGroup_Fk int foreign key references MuscleGroup(MuscleGroup_Pk) null,	
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

insert into ExerciseSecondaryMuscleGroup
values (1, 1, @date, null, @user, @date, null, null)

select *
from ExerciseSecondaryMuscleGroup

Create Table ExerciseProgram
(
	ExerciseProgram_Pk int identity primary key not null,
	Name varchar(50),
	Description varchar(250) not null,
	Notes varchar(1000) not null,
	ExternalUrl varchar(1000) not null,
	DaysPerWeek int not null,
	DurationInDays int not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

insert into ExerciseProgram
values ('4 Day Per Week - No Nonsense4-Day per Week Workout', 
'Complete Workout in 60 Minutes',
'Here is a sample program you can try where you’ll work each body part twice per week, but you’ll 
keep your total number of workouts to just 4 per week. Each workout should take 60 minutes or less 
(including warm-ups).',
'www.bodybuilding.com',
4,
180,
@date,
null,
@user,
@date,
@user,
@date)

select *
from ExerciseProgram

Create Table ExerciseProgramExercise
(
	ExerciseProgramExercise_Pk int identity primary key not null,
	ExerciseProgram_Fk int foreign key references ExerciseProgram(ExerciseProgram_Pk) null,
	Exercise_Fk int foreign key references Exercise(Exercise_Pk) null,	
	ExerciseDay int not null,
	ExerciseMinRepitions int not null,
	ExerciseMaxRepitions int not null,
	ExerciseMinSets int not null,
	ExerciseMaxSets int not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

insert into ExerciseProgramExercise
values (1, 1, 1, 8, 12, 3, 5, @date, null, @user, @date, @user, @date)

select *
from ExerciseProgramExercise

rollback Tran
