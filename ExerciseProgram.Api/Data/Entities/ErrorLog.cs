using ExerciseProgram.Api.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("logging.ErrorLog")]
    public partial class ErrorLog : EntityBase
    {
        [Key]
        public int ErrorLog_Pk { get; set; }

        public int ErrorCode { get; set; }

        [Required]
        [StringLength(500)]
        public string ErrorDescription { get; set; }
    }
}
