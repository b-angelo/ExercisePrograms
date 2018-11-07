using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Api.Data.Repositories.Base;
using ExerciseProgram.Models.ViewModels;
using System.Collections.Generic;

namespace ExerciseProgram.Api.Services
{
    public class ExerciseService
    {
        private IRepository<Exercise> _repository = new Repository<Exercise>();

        public ExerciseViewModel GetExerciseById(int id)
        {
            var exercise = _repository.GetById(id);

            var exerciseViewModel = new ExerciseViewModel
            {
                Id = exercise.Exercise_Pk,
                Name = exercise.Name
            };

            return exerciseViewModel;
        }

        public List<ExerciseViewModel> GetExercises()
        {
            var exercises = _repository.GetAll();

            var exerciseViewModel = new List<ExerciseViewModel>();

            foreach (var exercise in exercises)
            {
                exerciseViewModel.Add(new ExerciseViewModel
                {
                    Id = exercise.Exercise_Pk,
                    Name = exercise.Name
                });
            }

            return exerciseViewModel;
        }
    }
}