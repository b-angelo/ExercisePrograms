using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProgram.Models.ViewModels
{
    public class ProgramViewModel
    {
        public int Id { get; set; }
        public bool IsCurrent { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int DaysPerWeek { get; set; }
        public int LengthInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<ProgramExerciseViewModel> Exercises { get; set; }
        public List<SetsReps> SetsReps { get; set; }
        public bool WorkoutStarted { get; set; }
        public bool Complete { get; set; }
    }

    public class SetsReps
    {
        public int ProgramId { get; set; }
        public int ExerciseId { get; set; }
        public int Set { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
    }
}
