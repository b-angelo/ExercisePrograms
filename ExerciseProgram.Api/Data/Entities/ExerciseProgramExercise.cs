namespace ExerciseProgram.Api.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExerciseProgramExercise")]
    public partial class ExerciseProgramExercise
    {
        [Key]
        public int ExerciseProgramExercise_Pk { get; set; }

        public int? ExerciseProgram_Fk { get; set; }

        public int? Exercise_Fk { get; set; }

        public int ExerciseDay { get; set; }

        public int ExerciseMinRepitions { get; set; }

        public int ExerciseMaxRepitions { get; set; }

        public int ExerciseMinSets { get; set; }

        public int ExerciseMaxSets { get; set; }

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

        public virtual ExerciseProgram ExerciseProgram { get; set; }
    }
}
