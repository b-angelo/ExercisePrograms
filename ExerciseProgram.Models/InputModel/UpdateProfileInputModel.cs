using System;

namespace ExerciseProgram.Models.InputModel
{
    public class UpdateProfileInputModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
