using ExerciseProgram.Api.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("UserRole")]
    public partial class UserRole : EntityBase
    {
        public UserRole()
        {
            Users = new HashSet<UserProfile>();
        }

        [Key]
        public int UserRole_Pk { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<UserProfile> Users { get; set; }
    }
}
