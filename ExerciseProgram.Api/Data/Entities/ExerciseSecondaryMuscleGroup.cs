namespace ExerciseProgram.Api.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ExerciseSecondaryMuscleGroup")]
    public partial class ExerciseSecondaryMuscleGroup : EntityBase
    {
        [Key]
        public int ExerciseSecondaryMuscleGroup_Pk { get; set; }

        public int? Exercise_Fk { get; set; }

        public int? MuscleGroup_Fk { get; set; }

        public virtual Exercise Exercise { get; set; }

        public virtual MuscleGroup MuscleGroup { get; set; }
    }
}
