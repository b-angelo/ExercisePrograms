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

        public int ExerciseDay { get; set; }

        public int ExerciseSets { get; set; }

        public int ExerciseRepitions { get; set; }

        public int CardioDuration { get; set; }
    }
}
