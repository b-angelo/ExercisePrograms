﻿using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Models.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ExerciseProgram.Api.Services
{
    public class ExerciseService
    {
        private ExerciseProgramDataContext db = new ExerciseProgramDataContext();

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
                    ExerciseTypeNickName = exercise.ExerciseType.NickName,
                    MuscleGroupName = exercise.MuscleGroup.Name,
                    MuscleGroupNickName = exercise.MuscleGroup.NickName
                });
            }

            return exerciseViewModel;
        }

    }
}