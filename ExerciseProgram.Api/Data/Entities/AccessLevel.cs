namespace ExerciseProgram.Api.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AccessLevel")]
    public partial class AccessLevel : EntityBase
    {
        public AccessLevel()
        {
            AccountRoles = new HashSet<AccountRole>();
        }

        [Key]
        public int AccessLevel_Pk { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

       public virtual ICollection<AccountRole> AccountRoles { get; set; }
    }
}
