namespace ExerciseProgram.Api.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserAccount")]
    public partial class UserAccount : EntityBase
    {
        [Key]
        public int UserAccount_Pk { get; set; }

        public int Account_Fk { get; set; }

        public int AccountRole_Fk { get; set; }

        public int User_Fk { get; set; }

        public virtual Account Account { get; set; }

        public virtual AccountRole AccountRole { get; set; }

        public virtual User User { get; set; }
    }
}
