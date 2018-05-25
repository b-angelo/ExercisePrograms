using System.ComponentModel.DataAnnotations;

namespace ExerciseProgram.Api.Data.Entities
{
    public class UserBodyMass : EntityBase
    {
        [Required]
        public int UserBodyMass_Pk { get; set; }
        [Required]
        public int User_Fk { get; set; }
        [Required]
        public int HeightInInches { get; set; }
        [Required]
        public int WeightInPounds { get; set; }
    }
}