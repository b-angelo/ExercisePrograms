using ExerciseProgram.Api.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("UserBodyMass")]
    public partial class UserBodyMass : EntityBase
    {
        [Key]
        public int UserBodyMass_Pk { get; set; }

        public int User_Fk { get; set; }

        public int HeightInInches { get; set; }

        public int WeightInPounds { get; set; }

        public virtual User User { get; set; }
    }
}
