using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Api.Data.Repositories.Base;
using ExerciseProgram.Models.Enums;
using ExerciseProgram.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseProgram.Api.Services
{
    public class ExerciseProgramService
    {
        private IRepository<Data.Entities.ExerciseProgram> _exerciseProgramRepository = new Repository<Data.Entities.ExerciseProgram>();
        private IRepository<Exercise> _exerciseRepository = new Repository<Exercise>();
        private IRepository<ExerciseProgramExercise> _exerciseProgramExerciseRepository = new Repository<ExerciseProgramExercise>();
        private IRepository<ExerciseType> _exerciseTypeRepository = new Repository<ExerciseType>();

        public ProgramViewModel GetActiveExerciseProgramByUserId(int userId)
        {
            var exerciseProgram = _exerciseProgramRepository.GetAll()
                                                            .Where(x => x.StartDate > DateTime.Now && (x.EndDate == null || x.EndDate > DateTime.Now))
                                                            .FirstOrDefault();

            var exerciseProgramViewModel = new ProgramViewModel
            {
                    Id = exerciseProgram.ExerciseProgram_Pk,
                    Name = exerciseProgram.Name,
                    LengthInDays = exerciseProgram.DurationInDays
            };
            
            return exerciseProgramViewModel;
        }

        public List<ProgramViewModel> GetExercisesPrograms()
        {
            try
            {
                var exercisePrograms = _exerciseProgramRepository.GetAll();
                var exerciseDetails = _exerciseRepository.GetAll();
                var exerciseProgramExercise = _exerciseProgramExerciseRepository.GetAll();
                var exerciseType = _exerciseTypeRepository.GetAll();

                var exerciseList = from ed in exerciseDetails
                                   join et in exerciseType on ed.ExerciseType_Fk equals et.ExerciseType_Pk
                                   join epe in exerciseProgramExercise on ed.Exercise_Pk equals epe.Exercise_Fk
                                   select new ProgramExerciseViewModel
                                   {
                                       Id = epe.ExerciseProgramExercise_Pk,
                                       WorkoutDay = (DayOfWeekEnum)epe.ExerciseDay,
                                       ExerciseProgramFk = epe.ExerciseProgram_Fk,
                                       Exercise = new ExerciseViewModel
                                       {
                                           Id = ed.Exercise_Pk,
                                           Name = ed.Name,
                                           Description = ed.Description,
                                           Type = et.Name
                                       },
                                       Sets = epe.ExerciseSets,
                                       Reps = epe.Repitions,
                                       Duration = epe.CardioDuration
                                   };



                var programList =
                                from ep in exercisePrograms
                                select new ProgramViewModel
                                {
                                    Id = ep?.ExerciseProgram_Pk ?? 0,
                                    Name = ep?.Name ?? string.Empty,
                                    Description = ep?.Description ?? string.Empty,
                                    DaysPerWeek = ep?.DaysPerWeek ?? 0,
                                    LengthInDays = ep?.DurationInDays ?? 0,
                                    StartDate = ep?.StartDate ?? DateTime.MinValue,
                                    EndDate = ep?.EndDate ?? DateTime.MaxValue,
                                    Exercises = exerciseList.Where(x => x.ExerciseProgramFk == ep.ExerciseProgram_Pk).ToList() ?? new List<ProgramExerciseViewModel>()
                                };


                return programList.ToList();
            }
            catch (Exception e)
            {
                var repo = new Repository<ErrorLog>();

                var errorLog = new ErrorLog
                {
                    ErrorCode = 1,
                    ErrorDescription = e.Message,
                    CreatedBy = Environment.UserName,
                    CreateDate = DateTime.Now,
                    ModifiedBy = null,
                    ModifiedDate = null,
                    StartDate = DateTime.Now,
                    EndDate = null
                };

                repo.Insert(errorLog);

                throw new Exception();

            }
        }

        public bool CreateExerciseProgram(ProgramViewModel model)
        {
            try
            {
                var program = new Data.Entities.ExerciseProgram
                {
                    Name = model.Name,
                    DurationInDays = model.LengthInDays,
                    CreatedBy = Environment.UserName,
                    CreateDate = DateTime.Now
                };

                _exerciseProgramRepository.Insert(program);
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }
    }
}