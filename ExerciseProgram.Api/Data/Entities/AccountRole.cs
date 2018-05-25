namespace ExerciseProgram.Api.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AccountRole")]
    public partial class AccountRole : EntityBase
    {
        public AccountRole()
        {
            UserAccounts = new HashSet<UserAccount>();
        }

        [Key]
        public int AccountRole_Pk { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public int AccessLevel_Fk { get; set; }

        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
