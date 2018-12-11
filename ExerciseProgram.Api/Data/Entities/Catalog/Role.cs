using Dapper.Contrib.Extensions;
using ExerciseProgram.Api.Data.Entities.Base;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("catalog.Role")]
    public partial class Role : EntityBase
    {
        [Key]
        public int Role_Pk { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
