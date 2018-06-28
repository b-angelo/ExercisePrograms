using ExerciseProgram.Api.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("ExerciseProgram")]
    public partial class ExerciseProgram : EntityBase
    {
        public ExerciseProgram()
        {
            ExerciseHistories = new HashSet<ExerciseHistory>();
            ExerciseProgramExercises = new HashSet<ExerciseProgramExercise>();
        }

        [Key]
        public int ExerciseProgram_Pk { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        public int DurationInDays { get; set; }

        public virtual ICollection<ExerciseHistory> ExerciseHistories { get; set; }

        public virtual ICollection<ExerciseProgramExercise> ExerciseProgramExercises { get; set; }
    }
}
