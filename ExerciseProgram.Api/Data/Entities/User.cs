namespace ExerciseProgram.Api.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public partial class User : EntityBase
    {
        public User()
        {
            AccessLogs = new HashSet<AccessLog>();
            UserAccounts = new HashSet<UserAccount>();
        }

        [Key]
        public int User_Pk { get; set; }

        public int UserRole_Fk { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(64)]
        public byte[] PasswordHash { get; set; }

        public Guid Salt { get; set; }

        public Guid? ResetPasswordGuid { get; set; }

        public DateTime? ResetPasswordExpirationDate { get; set; }

        public int? LogInAttempts { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<AccessLog> AccessLogs { get; set; }

        public virtual UserRole UserRole { get; set; }

        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
