namespace ExerciseProgram.Api.Data.Entities
{
    using System.Data.Entity;

    public partial class ExerciseProgramDataContext : DbContext
    {
        public ExerciseProgramDataContext()
            : base("name=ExerciseProgramDbConnection")
        {
        }

        public virtual DbSet<AccessLevel> AccessLevels { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountRole> AccountRoles { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<ExerciseHistory> ExerciseHistories { get; set; }
        public virtual DbSet<ExerciseProgram> ExercisePrograms { get; set; }
        public virtual DbSet<ExerciseProgramExercise> ExerciseProgramExercises { get; set; }
        public virtual DbSet<ExerciseSecondaryMuscleGroup> ExerciseSecondaryMuscleGroups { get; set; }
        public virtual DbSet<ExerciseType> ExerciseTypes { get; set; }
        public virtual DbSet<MuscleGroup> MuscleGroups { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserBodyMass> UserBodyMasses { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<AccessLog> AccessLogs { get; set; }
        public virtual DbSet<ChangeLog> ChangeLogs { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessLevel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AccessLevel>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<AccessLevel>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<AccessLevel>()
                .HasMany(e => e.AccountRoles)
                .WithRequired(e => e.AccessLevel)
                .HasForeignKey(e => e.AccessLevel_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.UserAccounts)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.Account_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccountRole>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AccountRole>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<AccountRole>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<AccountRole>()
                .HasMany(e => e.UserAccounts)
                .WithRequired(e => e.AccountRole)
                .HasForeignKey(e => e.AccountRole_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Exercise>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Exercise>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Exercise>()
                .HasMany(e => e.ExerciseHistories)
                .WithOptional(e => e.Exercise)
                .HasForeignKey(e => e.Exercise_Fk);

            modelBuilder.Entity<Exercise>()
                .HasMany(e => e.ExerciseProgramExercises)
                .WithOptional(e => e.Exercise)
                .HasForeignKey(e => e.Exercise_Fk);

            modelBuilder.Entity<Exercise>()
                .HasMany(e => e.ExerciseSecondaryMuscleGroups)
                .WithOptional(e => e.Exercise)
                .HasForeignKey(e => e.Exercise_Fk);

            modelBuilder.Entity<ExerciseHistory>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseHistory>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseHistory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseProgram>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseProgram>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseProgram>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseProgram>()
                .Property(e => e.ExternalUrl)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseProgram>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseProgram>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseProgram>()
                .HasMany(e => e.ExerciseHistories)
                .WithOptional(e => e.ExerciseProgram)
                .HasForeignKey(e => e.ExerciseProgram_Fk);

            modelBuilder.Entity<ExerciseProgram>()
                .HasMany(e => e.ExerciseProgramExercises)
                .WithOptional(e => e.ExerciseProgram)
                .HasForeignKey(e => e.ExerciseProgram_Fk);

            modelBuilder.Entity<ExerciseProgramExercise>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseProgramExercise>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseSecondaryMuscleGroup>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseSecondaryMuscleGroup>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseType>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseType>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseType>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ExerciseType>()
                .HasMany(e => e.Exercises)
                .WithOptional(e => e.ExerciseType)
                .HasForeignKey(e => e.ExerciseType_Fk);

            modelBuilder.Entity<MuscleGroup>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MuscleGroup>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<MuscleGroup>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MuscleGroup>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MuscleGroup>()
                .HasMany(e => e.Exercises)
                .WithOptional(e => e.MuscleGroup)
                .HasForeignKey(e => e.MuscleGroup_Fk);

            modelBuilder.Entity<MuscleGroup>()
                .HasMany(e => e.ExerciseSecondaryMuscleGroups)
                .WithOptional(e => e.MuscleGroup)
                .HasForeignKey(e => e.MuscleGroup_Fk);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PasswordHash)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.AccessLogs)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_Fk);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserAccounts)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserBodyMasses)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UserBodyMass>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UserBodyMass>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.UserRole)
                .HasForeignKey(e => e.UserRole_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccessLog>()
                .Property(e => e.IPAddress)
                .IsUnicode(false);

            modelBuilder.Entity<AccessLog>()
                .Property(e => e.Device)
                .IsUnicode(false);

            modelBuilder.Entity<AccessLog>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<AccessLog>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.ColumnName)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.OldValue)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.NewValue)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLog>()
                .Property(e => e.ErrorDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLog>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLog>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);
        }
    }
}