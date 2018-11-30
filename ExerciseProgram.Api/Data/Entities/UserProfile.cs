using Dapper.Contrib.Extensions;
using ExerciseProgram.Api.Data.Entities.Base;
using System;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("UserProfile")]
    public partial class UserProfile : EntityBase
    {
        [Key]
        public int UserProfile_Pk { get; set; }
        public int UserRole_Fk { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public Guid Salt { get; set; }
        public Guid? ResetPasswordGuid { get; set; }
        public DateTime? ResetPasswordExpirationDate { get; set; }
        public int? LogInAttempts { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
