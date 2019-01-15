using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Api.Data.Repositories.Base;
using ExerciseProgram.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseProgram.Api.Services
{
    public class ExerciseService
    {
        private IRepository<Exercise> _exerciseRepository = new Repository<Exercise>();
        private IRepository<ExerciseType> _exerciseTypeRepository = new Repository<ExerciseType>();
        private IRepository<MuscleGroup> _muscleGroupRepository = new Repository<MuscleGroup>();

        public ExerciseViewModel GetExerciseById(int id)
        {
            var exercise = _exerciseRepository.GetById(id);

            var exerciseViewModel = new ExerciseViewModel
            {
                Id = exercise.Exercise_Pk,
                Name = exercise.Name
            };

            return exerciseViewModel;
        }

        public List<ExerciseViewModel> GetExercises()
        {
            var exercises = _exerciseRepository.GetAll();
            var exerciseTypes = _exerciseTypeRepository.GetAll();

            var exercisesViewModel = new List<ExerciseViewModel>();
            
            foreach (var exercise in exercises)
            {
                var type = exerciseTypes.Where(x => x.ExerciseType_Pk == exercise.ExerciseType_Fk).First();

                exercisesViewModel.Add(new ExerciseViewModel
                {
                    Id = exercise.Exercise_Pk,
                    Name = exercise.Name,
                    Description = exercise.Description,
                    Type = new ExerciseTypeViewModel
                    {
                        Id = type.ExerciseType_Pk,
                        Name = type.Name,
                        Description = type.Description
                    }
                });
            }

            return exercisesViewModel;
        }
    }
}