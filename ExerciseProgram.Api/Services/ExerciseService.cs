using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Models.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ExerciseProgram.Api.Services
{
    public class ExerciseService
    {
        private ExerciseProgramDataContext db = new ExerciseProgramDataContext();

        public ExerciseViewModel GetExerciseById(int id)
        {
            var exercise = db.Exercises
                              .Include(a => a.ExerciseType)
                              .Include(b => b.MuscleGroup)
                              .Where(x => x.Exercise_Pk == id)
                              .FirstOrDefault();

            var exerciseViewModel = new ExerciseViewModel
            {
                Id = exercise.Exercise_Pk,
                ExerciseName = exercise.Name,
                ExerciseDescription = exercise.Description,
                ExerciseTypeName = exercise.ExerciseType.Name,
                ExerciseTypeDescription = exercise.ExerciseType.Description,
                MuscleGroupName = exercise.MuscleGroup.Name,
                MuscleGroupDescription = exercise.MuscleGroup.Description
            };
            
            return exerciseViewModel;
        }

        public List<ExerciseViewModel> GetExercises()
        {
            var exerciseViewModel = new List<ExerciseViewModel>();

            var exercises = db.Exercises
                              .Include(a => a.ExerciseType)
                              .Include(b => b.MuscleGroup)                              
                              .ToList();

            foreach (var exercise in exercises)
            {
                exerciseViewModel.Add(new ExerciseViewModel
                {
                    Id = exercise.Exercise_Pk,
                    ExerciseName = exercise.Name,
                    ExerciseDescription = exercise.Description,
                    ExerciseTypeName = exercise.ExerciseType.Name,
                    ExerciseTypeDescription = exercise.ExerciseType.Description,
                    MuscleGroupName = exercise.MuscleGroup.Name,
                    MuscleGroupDescription = exercise.MuscleGroup.Description
                });
            }

            return exerciseViewModel;
        }

        public List<ExerciseViewModel> GetExercises(string muscleGroupName)
        {
            var muscleGroupId = db.MuscleGroups
                                  .Where(x => x.Name == muscleGroupName)
                                  .FirstOrDefault()
                                  .MuscleGroup_Pk;

            var exerciseViewModel = new List<ExerciseViewModel>();

            var exercises = db.Exercises
                              .Where(x => x.MuscleGroup_Fk == muscleGroupId)
                              .Include(a => a.ExerciseType)
                              .Include(b => b.MuscleGroup)
                              .ToList();
            
            foreach (var exercise in exercises)
            {
                exerciseViewModel.Add(new ExerciseViewModel
                {
                    Id = exercise.Exercise_Pk,
                    ExerciseName = exercise.Name,
                    ExerciseDescription = exercise.Description,
                    ExerciseTypeName = exercise.ExerciseType.Name,
                    ExerciseTypeDescription = exercise.ExerciseType.Description,
                    MuscleGroupName = exercise.MuscleGroup.Name,
                    MuscleGroupDescription = exercise.MuscleGroup.Description
                });
            }

            return exerciseViewModel;
        }

    }
}