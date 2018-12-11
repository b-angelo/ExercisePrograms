using ExerciseProgram.Api.Data.Entities.Base;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("catalog.ExerciseType")]
    public partial class ExerciseType : EntityBase
    {
        [Key]
        public int ExerciseType_Pk { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
