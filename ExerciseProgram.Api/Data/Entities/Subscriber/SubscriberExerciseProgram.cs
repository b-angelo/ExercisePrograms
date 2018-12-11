using Dapper.Contrib.Extensions;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("subscriber.ExerciseProgram")]
    public class SubscriberExerciseProgram
    {
        [Key]
        public int ExerciseProgram_Pk { get; set; }
        public int ExerciseProgram_Fk { get; set; }
        public int Profile_Fk { get; set; }
    }
}