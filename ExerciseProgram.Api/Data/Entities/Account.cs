namespace ExerciseProgram.Api.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Account")]
    public partial class Account : EntityBase
    {
        public Account()
        {
            UserAccounts = new HashSet<UserAccount>();
        }

        [Key]
        public int Account_Pk { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
