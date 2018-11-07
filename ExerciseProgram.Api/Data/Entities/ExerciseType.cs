using ExerciseProgram.Api.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("ExerciseType")]
    public partial class ExerciseType : EntityBase
    {
        public ExerciseType()
        {
            Exercises = new HashSet<Exercise>();
        }

        [Dapper.Contrib.Extensions.Key]
        public int ExerciseType_Pk { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
