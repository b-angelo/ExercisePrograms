using ExerciseProgram.Api.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseProgram.Api.Data.Entities
{

    [Table("logging.AccessLog")]
    public partial class AccessLog : EntityBase
    {
        [Key]
        public int Access_Pk { get; set; }

        public int? User_Fk { get; set; }

        [StringLength(50)]
        public string IPAddress { get; set; }

        [StringLength(50)]
        public string Device { get; set; }

        public virtual User User { get; set; }
    }
}
