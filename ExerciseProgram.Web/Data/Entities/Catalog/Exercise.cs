using ExerciseProgram.Api.Data.Entities.Base;
using Dapper.Contrib.Extensions;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("catalog.Exercise")]
    public partial class Exercise : EntityBase
    {
        [Key]
        public int Exercise_Pk { get; set; }
        public int? ExerciseType_Fk { get; set; }
        public int? MuscleGroup_Fk { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
