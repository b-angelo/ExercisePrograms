namespace ExerciseProgram.Models.ViewModels
{

    public class UserExerciseHistoryViewModel
    {
        public int Id { get; set; }
        public ExerciseViewModel Exercise { get; set; }
        public int Set { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
        public int Duration { get; set; }
    }
}
