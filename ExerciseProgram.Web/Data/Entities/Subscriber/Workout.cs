using Dapper.Contrib.Extensions;
using ExerciseProgram.Api.Data.Entities.Base;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("subscriber.Workout")]
    public class Workout : EntityBase
    {
        [Key]
        public int Workout_Pk { get; set; }
        public int Profile_Fk { get; set; }
        public int ExerciseProgram_Fk { get; set; }
        public bool Complete { get; set; }
    }
}