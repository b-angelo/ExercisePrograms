using Dapper.Contrib.Extensions;
using ExerciseProgram.Api.Data.Entities.Base;

namespace ExerciseProgram.Api.Data.Entities
{
    [Table("logging.ChangeLog")]
    public partial class ChangeLog : EntityBase
    {
        [Key]
        public int Change_Pk { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public int RecordPk { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
