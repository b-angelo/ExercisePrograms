using ExerciseProgram.Api.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("Exercise")]
    public partial class Exercise : EntityBase
    {
        [Dapper.Contrib.Extensions.Key]
        public int Exercise_Pk { get; set; }

        public int? ExerciseType_Fk { get; set; }

        public int? MuscleGroup_Fk { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
