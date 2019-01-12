using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProgram.Api.Data.Entities.Base
{
    public abstract class EntityBase
    {
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}