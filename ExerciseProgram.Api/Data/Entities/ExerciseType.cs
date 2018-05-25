namespace ExerciseProgram.Api.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ExerciseType")]
    public partial class ExerciseType : EntityBase
    {
        public ExerciseType()
        {
            Exercises = new HashSet<Exercise>();
        }

        [Key]
        public int ExerciseType_Pk { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string NickName { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
