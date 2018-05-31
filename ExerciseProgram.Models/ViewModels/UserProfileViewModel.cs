using System;
using System.Collections.Generic;

namespace ExerciseProgram.Models.ViewModels
{
    public class UserProfileViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public decimal BodyMassIndex { get; set; }
        public List<WeightHistory> WeightHistory { get; set; }
        public DateTime DateJoined { get; set; }
    }

    public class WeightHistory
    {
        public int Id { get; set; }
        public int WeightInPounds { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
