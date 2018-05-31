namespace ExerciseProgram.Api.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExerciseSecondaryMuscleGroup")]
    public partial class ExerciseSecondaryMuscleGroup
    {
        [Key]
        public int ExerciseSecondaryMuscleGroup_Pk { get; set; }

        public int? Exercise_Fk { get; set; }

        public int? MuscleGroup_Fk { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual Exercise Exercise { get; set; }

        public virtual MuscleGroup MuscleGroup { get; set; }
    }
}
