using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Api.Data.Repositories.Base;
using ExerciseProgram.Models.Enums;
using ExerciseProgram.Models.InputModel;
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
        private IRepository<Workout> _workoutRepository = new Repository<Workout>();
        private IRepository<WorkoutHistory> _workoutHistoryRepository = new Repository<WorkoutHistory>();

        public ProgramViewModel GetExerciseProgramById(int id)
        {
            var exerciseProgram = GetExercisesPrograms().FirstOrDefault(x => x.Id == id);

            return exerciseProgram;
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
                                           Type = new ExerciseTypeViewModel()
                                       },
                                       Sets = epe.ExerciseSets,
                                       Reps = epe.ExerciseRepitions
                                   };



                var programList =
                                from ep in exercisePrograms
                                select new ProgramViewModel
                                {
                                    Id = ep?.ExerciseProgram_Pk ?? 0,
                                    IsCurrent = true,
                                    Name = ep?.Name ?? string.Empty,
                                    Description = ep?.Description ?? string.Empty,
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

        public long CreateExerciseProgram(ProgramInputModel model)
        {
            try
            {
                var program = new Data.Entities.ExerciseProgram
                {
                    Name = model.Name,
                    Description = model.Description,
                    DurationInDays = model.LengthInDays,
                    StartDate = DateTime.Now,
                    CreatedBy = Environment.UserName,
                    CreateDate = DateTime.Now
                };

                var programPk = _exerciseProgramRepository.Insert(program);

                var workout = new Workout
                {
                    Profile_Fk = 1,
                    ExerciseProgram_Fk = (int)programPk,
                    StartDate = DateTime.Now,
                    CreatedBy = Environment.UserName,
                    CreateDate = DateTime.Now
                };

                _workoutRepository.Insert(workout);

                return programPk;
            }
            catch(Exception e)
            {
                throw new Exception();
            }
        }

        public long AddExerciseToProgram(int programId, AddExerciseToProgramInputModel model)
        {
            try
            {
                var exercise = new ExerciseProgramExercise
                {
                    ExerciseProgram_Fk = programId,
                    Exercise_Fk = model.ExerciseId,
                    ExerciseDay = 0,
                    ExerciseSets = model.Sets,
                    ExerciseRepitions = 0,
                    StartDate = DateTime.Now,
                    CreatedBy = Environment.UserName,
                    CreateDate = DateTime.Now
                };

                return _exerciseProgramExerciseRepository.Insert(exercise);
            }
            catch(Exception e)
            {
                throw new Exception();
            }
        }
    }
}