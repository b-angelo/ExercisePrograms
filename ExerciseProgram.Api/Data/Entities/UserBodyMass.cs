using Dapper.Contrib.Extensions;
using ExerciseProgram.Api.Data.Entities.Base;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("UserBodyMass")]
    public partial class UserBodyMass : EntityBase
    {
        [Key]
        public int UserBodyMass_Pk { get; set; }
        public int UserProfile_Fk { get; set; }
        public int HeightInInches { get; set; }
        public int WeightInPounds { get; set; }
    }
}
