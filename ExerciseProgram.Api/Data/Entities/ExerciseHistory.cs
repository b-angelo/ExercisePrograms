namespace ExerciseProgram.Api.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExerciseHistory")]
    public partial class ExerciseHistory
    {
        [Key]
        public int ExerciseHistory_Pk { get; set; }

        public int? ExerciseProgram_Fk { get; set; }

        public int? Exercise_Fk { get; set; }

        public int? SetNumber { get; set; }

        public int? Repitions { get; set; }

        public int? WeightUsed { get; set; }

        public int? Duration { get; set; }

        public int? Intensity { get; set; }

        [Required]
        [StringLength(250)]
        public string Notes { get; set; }

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
