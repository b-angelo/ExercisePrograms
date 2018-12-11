using ExerciseProgram.Api.Data.Entities.Base;
using Dapper.Contrib.Extensions;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("logging.ErrorLog")]
    public partial class ErrorLog : EntityBase
    {
        [Key]
        public int ErrorLog_Pk { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public int User_Fk { get; set; }
    }
}
