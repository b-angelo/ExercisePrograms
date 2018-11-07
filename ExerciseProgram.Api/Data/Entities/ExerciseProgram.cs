using ExerciseProgram.Api.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("ExerciseProgram")]
    public class ExerciseProgram : EntityBase
    {        
        [Dapper.Contrib.Extensions.Key]
        public int ExerciseProgram_Pk { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        public int DurationInDays { get; set; }
        public int DaysPerWeek { get; set; }
    }
}
