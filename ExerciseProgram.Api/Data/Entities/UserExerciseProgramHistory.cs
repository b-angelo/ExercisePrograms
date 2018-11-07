using Dapper.Contrib.Extensions;

namespace ExerciseProgram.Api.Data
{
    [Table("UserExerciseProgramHistory")]
    public class UserExerciseProgramHistory
    {
        [Key]
        public int UserExerciseProgramHistory_Pk { get; set; }
        public int UserExerciseProgram_Fk { get; set; }
        public int Exercise_Fk { get; set; }
        public int Set { get; set; }
        public int Repititions { get; set; }
        public int WeightUsed { get; set; }
        public int CardioDuration { get; set; }
    }
}