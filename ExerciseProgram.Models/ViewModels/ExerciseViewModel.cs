namespace ExerciseProgram.Models.ViewModels
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } // ToDo: Change to use exercisetype
    }
}
