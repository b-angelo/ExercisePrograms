using Dapper.Contrib.Extensions;
using ExerciseProgram.Api.Data.Entities.Base;
using System;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("subscriber.Profile")]
    public partial class SubscriberProfile : EntityBase
    {
        [Key]
        public int Profile_Pk { get; set; }
        public int Role_Fk { get; set; }
        public string DisplayName { get; set; }
        public byte[] PasswordHash { get; set; }
        public Guid Salt { get; set; }
        public Guid? ResetPasswordGuid { get; set; }
        public DateTime? ResetPasswordExpirationDate { get; set; }
        public int? LogInAttempts { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
