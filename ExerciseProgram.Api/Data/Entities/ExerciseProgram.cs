namespace ExerciseProgram.Api.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ExerciseProgram")]
    public partial class ExerciseProgram : EntityBase
    {
        public ExerciseProgram()
        {
            ExerciseProgramExercises = new HashSet<ExerciseProgramExercise>();
        }

        [Key]
        public int ExerciseProgram_Pk { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(1000)]
        public string Notes { get; set; }

        [Required]
        [StringLength(1000)]
        public string ExternalUrl { get; set; }

        public int DaysPerWeek { get; set; }

        public int DurationInDays { get; set; }

        public virtual ICollection<ExerciseProgramExercise> ExerciseProgramExercises { get; set; }
    }
}
