using Dapper.Contrib.Extensions;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("UserExerciseProgram")]
    public class UserExerciseProgram
    {
        [Key]
        public int UserExerciseProgram_Pk { get; set; }
        public int ExerciseProgram_Fk { get; set; }
        public int UserProfile_Fk { get; set; }
    }
}