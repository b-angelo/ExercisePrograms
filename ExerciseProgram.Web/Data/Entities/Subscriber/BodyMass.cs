using Dapper.Contrib.Extensions;
using ExerciseProgram.Api.Data.Entities.Base;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("subscriber.BodyMass")]
    public partial class BodyMass : EntityBase
    {
        [Key]
        public int BodyMass_Pk { get; set; }
        public int Profile_Fk { get; set; }
        public int HeightInInches { get; set; }
        public int WeightInPounds { get; set; }
    }
}
