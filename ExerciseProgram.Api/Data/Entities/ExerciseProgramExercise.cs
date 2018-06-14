namespace ExerciseProgram.Api.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ExerciseProgramExercise")]
    public partial class ExerciseProgramExercise : EntityBase
    {
        [Key]
        public int ExerciseProgramExercise_Pk { get; set; }

        public int? ExerciseProgram_Fk { get; set; }

        public int? Exercise_Fk { get; set; }

        public int ExerciseDay { get; set; } // Enum representing day of week (ex: 1 = Sunday, 2 = Monday, etc)

        public int ExerciseMinRepitions { get; set; }

        public int ExerciseMaxRepitions { get; set; }

        public int ExerciseSets { get; set; }

        public virtual Exercise Exercise { get; set; }

        public virtual ICollection<ExerciseHistory> ExerciseHistories { get; set; }

        public virtual ExerciseProgram ExerciseProgram { get; set; }
    }
}
