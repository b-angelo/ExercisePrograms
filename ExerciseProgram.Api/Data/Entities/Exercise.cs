using ExerciseProgram.Api.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseProgram.Api.Data.Entities
{    
    [Table("Exercise")]
    public partial class Exercise : EntityBase
    {
        public Exercise()
        {
            ExerciseHistories = new HashSet<ExerciseHistory>();
            ExerciseProgramExercises = new HashSet<ExerciseProgramExercise>();
        }

        [Key]
        public int Exercise_Pk { get; set; }

        public int? ExerciseType_Fk { get; set; }

        public int? MuscleGroup_Fk { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }


        public virtual ExerciseType ExerciseType { get; set; }

        public virtual MuscleGroup MuscleGroup { get; set; }

        public virtual ICollection<ExerciseHistory> ExerciseHistories { get; set; }

        public virtual ICollection<ExerciseProgramExercise> ExerciseProgramExercises { get; set; }
    }
}
