using Dapper.Contrib.Extensions;

namespace ExerciseProgram.Api.Data
{
    [Table("subscriber.ExerciseProgramHistory")]
    public class SubscriberExerciseProgramHistory
    {
        [Key]
        public int ExerciseProgramHistory_Pk { get; set; }
        public int ExerciseProgram_Fk { get; set; }
        public int Exercise_Fk { get; set; }
        public int Set { get; set; }
        public int Repititions { get; set; }
        public int WeightUsed { get; set; }
        public int CardioDuration { get; set; }
    }
}