using ExerciseProgram.Api.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("ExerciseHistory")]
    public partial class ExerciseHistory : EntityBase
    {
        [Key]
        public int ExerciseHistory_Pk { get; set; }

        public int ExerciseProgramExercise_Fk { get; set; }

        public int? SetNumber { get; set; }

        public int? Repitions { get; set; }

        public int? WeightUsed { get; set; }

        public int? Duration { get; set; }

        public virtual Exercise Exercise { get; set; }

        public virtual ExerciseProgram ExerciseProgram { get; set; }
    }
}
