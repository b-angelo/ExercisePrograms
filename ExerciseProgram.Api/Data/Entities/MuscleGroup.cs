namespace ExerciseProgram.Api.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MuscleGroup")]
    public partial class MuscleGroup : EntityBase
    {
        public MuscleGroup()
        {
            Exercises = new HashSet<Exercise>();
            ExerciseSecondaryMuscleGroups = new HashSet<ExerciseSecondaryMuscleGroup>();
        }

        [Key]
        public int MuscleGroup_Pk { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string NickName { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }

        public virtual ICollection<ExerciseSecondaryMuscleGroup> ExerciseSecondaryMuscleGroups { get; set; }
    }
}
