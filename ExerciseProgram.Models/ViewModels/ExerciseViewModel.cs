﻿namespace ExerciseProgram.Models.ViewModels
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ExerciseTypeViewModel Type { get; set; }
        public MuscleGroupViewModel MuscleGroup { get; set; }
    }
}