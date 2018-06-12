using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ExerciseProgram.Api.Services
{
    public class ExerciseProgramService
    {
        private ExerciseProgramDataContext db = new ExerciseProgramDataContext();

        public List<ExerciseProgramViewModel> GetExercisesPrograms()
        {
            var exerciseProgramViewModels = new List<ExerciseProgramViewModel>();

            var exercisePrograms = db.ExercisePrograms
                                     .ToList();

            foreach (var program in exercisePrograms)
            {
                exerciseProgramViewModels.Add(new ExerciseProgramViewModel
                {
                    Id = program.ExerciseProgram_Pk,
                    Name = program.Name,
                    Description = program.Description,
                    DaysPerWeek = program.DaysPerWeek,
                    DurationInDays = program.DurationInDays,
                    StartDate = program.StartDate,
                    EndDate = program.EndDate,
                    CreatedBy = program.CreatedBy
                });
            }

            return exerciseProgramViewModels;
        }

        public void CreateExerciseProgram(ExerciseProgramViewModel model)
        {
            var program = new Data.Entities.ExerciseProgram
            {
                Name = model.Name,
                Description = model.Description,
                Notes = "test",
                ExternalUrl = "test",
                DaysPerWeek = model.DaysPerWeek,
                DurationInDays = model.DurationInDays,
                StartDate = model.StartDate,
                EndDate = model.StartDate.AddDays(model.DurationInDays),
                CreatedBy = Environment.UserName,
                CreateDate = DateTime.Now
            };

            db.ExercisePrograms.Add(program);
            db.SaveChanges();
        }
    }
}