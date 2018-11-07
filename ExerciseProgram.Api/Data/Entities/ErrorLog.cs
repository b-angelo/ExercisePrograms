using ExerciseProgram.Api.Data.Entities.Base;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("logging.ErrorLog")]
    public partial class ErrorLog : EntityBase
    {
        [Dapper.Contrib.Extensions.Key]
        public int ErrorLog_Pk { get; set; }

        public int ErrorCode { get; set; }

        [Required]
        [StringLength(500)]
        public string ErrorDescription { get; set; }

        public int User_Fk { get; set; }
    }
}
