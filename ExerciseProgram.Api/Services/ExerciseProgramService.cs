using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Models.ViewModels;
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
    }
}