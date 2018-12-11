using Dapper.Contrib.Extensions;
using ExerciseProgram.Api.Data.Entities.Base;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("catalog.MuscleGroup")]
    public partial class MuscleGroup : EntityBase
    {
        [Key]
        public int MuscleGroup_Pk { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
