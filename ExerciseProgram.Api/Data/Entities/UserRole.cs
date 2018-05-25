namespace ExerciseProgram.Api.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserRole")]
    public partial class UserRole : EntityBase
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int UserRole_Pk { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
