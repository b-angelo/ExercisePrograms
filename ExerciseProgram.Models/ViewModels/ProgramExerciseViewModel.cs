using ExerciseProgram.Models.Enums;
using System.Collections.Generic;

namespace ExerciseProgram.Models.ViewModels
{
    public class ProgramExerciseViewModel
    {
        public int Id { get; set; }
        public DayOfWeekEnum WorkoutDay { get; set; }
        public int ExerciseProgramFk { get; set; }
        public ExerciseViewModel Exercise { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }        
    }
}
