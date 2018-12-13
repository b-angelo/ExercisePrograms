using Dapper.Contrib.Extensions;
using ExerciseProgram.Api.Data.Entities.Base;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("subscriber.WorkoutHistory")]
    public class WorkoutHistory : EntityBase
    {
        [Key]
        public int WorkoutHistory_Pk { get; set; }
        public int Workout_Fk { get; set; }
        public int ExerciseProgramExercise_Fk { get; set; }
        public int Set { get; set; }
        public int Repititions { get; set; }
        public int WeightUsed { get; set; }
        public int Duration { get; set; }
    }
}