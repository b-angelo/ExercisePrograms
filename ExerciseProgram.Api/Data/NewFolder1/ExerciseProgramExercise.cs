namespace ExerciseProgram.Api.Data.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExerciseProgramExercise")]
    public partial class ExerciseProgramExercise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExerciseProgramExercise()
        {
            ExerciseHistories = new HashSet<ExerciseHistory>();
        }

        [Key]
        public int ExerciseProgramExercise_Pk { get; set; }

        public int? ExerciseProgram_Fk { get; set; }

        public int? Exercise_Fk { get; set; }

        public int ExerciseDay { get; set; }

        public int ExerciseMinRepitions { get; set; }

        public int ExerciseMaxRepitions { get; set; }

        public int ExerciseSets { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExerciseHistory> ExerciseHistories { get; set; }

        public virtual ExerciseProgram ExerciseProgram { get; set; }
    }
}
