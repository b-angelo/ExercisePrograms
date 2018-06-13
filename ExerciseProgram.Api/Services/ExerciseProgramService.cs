using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseProgram.Api.Services
{
    public class ExerciseProgramService
    {
        private ExerciseProgramDataContext db = new ExerciseProgramDataContext();

        public ExerciseProgramViewModel GetActiveExerciseProgramByUserId(int userId)
        {
            var exerciseProgram = db.ExercisePrograms
                                     .FirstOrDefault(); //ToDO: restructure db to support adding userid in where clause

            var exerciseProgramViewModel = new ExerciseProgramViewModel
            {
                    Id = exerciseProgram.ExerciseProgram_Pk,
                    Name = exerciseProgram.Name,
                    Description = exerciseProgram.Description,
                    DaysPerWeek = exerciseProgram.DaysPerWeek,
                    DurationInDays = exerciseProgram.DurationInDays,
                    StartDate = exerciseProgram.StartDate,
                    EndDate = exerciseProgram.EndDate,
                    CreatedBy = exerciseProgram.CreatedBy
            };
            
            return exerciseProgramViewModel;
        }

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