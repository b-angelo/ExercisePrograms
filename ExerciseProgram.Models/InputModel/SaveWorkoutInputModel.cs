namespace ExerciseProgram.Models.InputModel
{
    public class SaveWorkoutInputModel
    {
        public int ProgramId { get; set; }
        public int ExerciseId { get; set; }
        public int Set { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
    }
}
