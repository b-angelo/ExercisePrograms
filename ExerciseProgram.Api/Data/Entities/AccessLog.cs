using Dapper.Contrib.Extensions;
using ExerciseProgram.Api.Data.Entities.Base;

[Table("logging.AccessLog")]
public partial class AccessLog : EntityBase
{
    [Key]
    public int Access_Pk { get; set; }
    public int? UserProfile_Fk { get; set; }
    public string IPAddress { get; set; }
    public string Device { get; set; }
}
