using ExerciseProgram.Api.Data.Entities.Base;
using Dapper.Contrib.Extensions;
using System;
using ExerciseProgram.Models.Enums;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("ExerciseProgramExercise")]
    public partial class ExerciseProgramExercise : EntityBase
    {
        [Key]
        public int ExerciseProgramExercise_Pk { get; set; }

        public int ExerciseProgram_Fk { get; set; }

        public int Exercise_Fk { get; set; }

        public int WorkoutDate { get; set; }

        public int Sets { get; set; }

        public int Repitions { get; set; }

        public int CardioDuration { get; set; }
    }
}
