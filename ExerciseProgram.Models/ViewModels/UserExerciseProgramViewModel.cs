using System;
using System.Collections.Generic;

namespace ExerciseProgram.Models.ViewModels
{
    public class UserExerciseProgramViewModel
    {
        public int Id { get; set; }
        public ProgramViewModel Program { get; set; }
        public DateTime WorkoutDate { get; set; }
        public int WorkoutNumber { get; set; }
        public List<UserExerciseHistoryViewModel> ExerciseHistory { get; set; }
    }
}
