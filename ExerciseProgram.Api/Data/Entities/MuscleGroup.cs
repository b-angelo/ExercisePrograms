namespace ExerciseProgram.Api.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MuscleGroup")]
    public partial class MuscleGroup : EntityBase
    {
        public MuscleGroup()
        {
            Exercises = new HashSet<Exercise>();
        }

        [Key]
        public int MuscleGroup_Pk { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
