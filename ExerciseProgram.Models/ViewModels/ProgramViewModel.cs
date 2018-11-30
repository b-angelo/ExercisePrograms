using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProgram.Models.ViewModels
{
    public class ProgramViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int DaysPerWeek { get; set; }
        public int LengthInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<ProgramExerciseViewModel> Exercises { get; set; }        
    }
}
