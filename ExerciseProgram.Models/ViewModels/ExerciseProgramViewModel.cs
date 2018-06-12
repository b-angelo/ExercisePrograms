using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProgram.Models.ViewModels
{
    public class ExerciseProgramViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }        
        public int DaysPerWeek { get; set; }
        public int DurationInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
