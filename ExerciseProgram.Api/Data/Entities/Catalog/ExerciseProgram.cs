using ExerciseProgram.Api.Data.Entities.Base;
using Dapper.Contrib.Extensions;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("catalog.ExerciseProgram")]
    public class ExerciseProgram : EntityBase
    {        
        [Key]
        public int ExerciseProgram_Pk { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationInDays { get; set; }
    }
}
