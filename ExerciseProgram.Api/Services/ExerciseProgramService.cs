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
                var workoutHistory = _workoutHistoryRepository.GetAll();
                var workoutProgram = _workoutRepository.GetAll();
    
                var setsReps = new List<SetsReps>();

                foreach (var workout in workoutHistory)
                {
                    setsReps.Add(new SetsReps
                    {
                        ProgramId = workout.Workout_Fk,
                        ExerciseId = workout.ExerciseProgramExercise_Fk,
                        Set = workout.SetNumber,
                        Reps = workout.Repititions,
                        Weight = workout.WeightUsed
                    });
                }

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
                                           Type = new ExerciseTypeViewModel(),
                                       },
                                       Sets = epe.ExerciseSets,
                                       Reps = epe.ExerciseRepitions
                                   };

                var programList =
                                from ep in exercisePrograms
                                select new ProgramViewModel
                                {
                                    Id = ep.ExerciseProgram_Pk,
                                    IsCurrent = true,
                                    Name = ep?.Name ?? string.Empty,
                                    Description = ep?.Description ?? string.Empty,
                                    LengthInDays = ep?.DurationInDays ?? 0,
                                    StartDate = workoutProgram?.FirstOrDefault(x => x.ExerciseProgram_Fk == ep.ExerciseProgram_Pk)?.StartDate ?? DateTime.MinValue,
                                    EndDate = workoutProgram?.FirstOrDefault(x => x.ExerciseProgram_Fk == ep.ExerciseProgram_Pk)?.EndDate ?? DateTime.MaxValue,
                                    Exercises = exerciseList.Where(x => x.ExerciseProgramFk == ep.ExerciseProgram_Pk).ToList() ?? new List<ProgramExerciseViewModel>(),
                                    SetsReps = setsReps.Where(x => x.ProgramId == ep.ExerciseProgram_Pk).ToList() ?? new List<SetsReps>(),
                                    WorkoutStarted = workoutProgram?.FirstOrDefault(x => x.ExerciseProgram_Fk == ep.ExerciseProgram_Pk) != null
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
                    StartDate = DateTime.Today.Date,
                    EndDate = DateTime.Today.AddDays(1).AddSeconds(-1),
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

        public void SaveWorkout(SaveWorkoutInputModel model)
        {
            var recordedSet = _workoutHistoryRepository.GetAll()
                                                       .Where(x => x.Workout_Fk == model.ProgramId &&
                                                                   x.ExerciseProgramExercise_Fk == model.ExerciseId &&
                                                                   x.SetNumber == model.Set)
                                                        .FirstOrDefault();
            if (recordedSet != null)
            {
                recordedSet.Repititions = model.Reps;
                recordedSet.WeightUsed = model.Weight;
                recordedSet.ModifiedBy = Environment.UserName;
                recordedSet.ModifiedDate = DateTime.Now;

                _workoutHistoryRepository.Update(recordedSet);
            }
            else
            {
                var workout = new WorkoutHistory
                {
                    Workout_Fk = model.ProgramId,
                    ExerciseProgramExercise_Fk = model.ExerciseId,
                    SetNumber = model.Set,
                    Repititions = model.Reps,
                    WeightUsed = model.Weight,
                    StartDate = DateTime.Now,
                    CreatedBy = Environment.UserName,
                    CreateDate = DateTime.Now
                };

                _workoutHistoryRepository.Insert(workout);
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