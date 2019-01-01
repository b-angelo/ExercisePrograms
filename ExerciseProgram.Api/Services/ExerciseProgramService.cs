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
            var exerciseProgram = GetExercisesPrograms(null, null).FirstOrDefault(x => x.Id == id);

            return exerciseProgram;
        }

        public List<ProgramViewModel> GetExercisesPrograms(int? year, int? month)
        {            
            try
            {                
                var exercisePrograms = _exerciseProgramRepository.GetAll();
                var exerciseDetails = _exerciseRepository.GetAll();
                var exerciseProgramExercise = _exerciseProgramExerciseRepository.GetAll();
                var exerciseType = _exerciseTypeRepository.GetAll();
                IEnumerable<WorkoutHistory> workoutHistory = _workoutHistoryRepository.GetAll();
                IEnumerable<Workout> workoutProgram = _workoutRepository.GetAll();
                List<DateTime> monthsYearsWorkedOut = new List<DateTime>();

                foreach (var yearWorkoutOut in workoutProgram.Select(x => x.StartDate.Year).Distinct())
                {
                    foreach (var monthWokout in workoutProgram.Select(x => x.StartDate.Month).Distinct())
                    {
                        monthsYearsWorkedOut.Add(new DateTime(yearWorkoutOut, monthWokout, 01));
                    }
                }

                var lastWorkout = workoutProgram.OrderByDescending(x => x.StartDate).First().StartDate;

                if (year != null && month != null)
                {
                    var startDate = new DateTime(year.Value, month.Value, 1);
                    var endDate = new DateTime(year.Value, month.Value, DateTime.DaysInMonth(year.Value, month.Value), 23, 59, 59);

                    workoutHistory = _workoutHistoryRepository.GetAll().Where(x => x.StartDate > startDate && x.EndDate < endDate);
                    workoutProgram = _workoutRepository.GetAll().Where(x => x.StartDate > startDate && x.EndDate < endDate);
                }      
                                  
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

                var programList = from ep in exercisePrograms
                                  join wp in workoutProgram on ep.ExerciseProgram_Pk equals wp.ExerciseProgram_Fk
                                  select new ProgramViewModel
                                  {
                                      Id = ep.ExerciseProgram_Pk,
                                      IsCurrent = true,
                                      Name = ep.Name,
                                      Description = ep.Description,
                                      LengthInDays = ep.DurationInDays,
                                      StartDate = ep.StartDate,
                                      EndDate = ep.EndDate,
                                      Exercises = exerciseList.Where(x => x.ExerciseProgramFk == ep.ExerciseProgram_Pk).ToList() ?? new List<ProgramExerciseViewModel>(),
                                      SetsReps = setsReps.Where(x => x.ProgramId == ep.ExerciseProgram_Pk).ToList() ?? new List<SetsReps>(),
                                      //WorkoutStarted = workoutProgram.First(x => x.ExerciseProgram_Fk == ep.ExerciseProgram_Pk).,
                                      Complete = wp.Complete,
                                      MonthsYearsWorkedOut = monthsYearsWorkedOut
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
                    CreatedBy = Environment.UserName,
                    CreateDate = DateTime.Now
                };

                var programPk = _exerciseProgramRepository.Insert(program);

                var workout = new Workout
                {
                    Profile_Fk = 1,
                    ExerciseProgram_Fk = (int)programPk,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Today.AddDays(1).AddSeconds(-1),
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

        public ProgramViewModel UpdateExerciseProgram(ProgramInputModel model)
        {
            try
            {
                var program = _exerciseProgramRepository.GetById(model.Id);

                program.Name = model.Name;
                program.Description = model.Description;
                program.DurationInDays = model.LengthInDays;
                program.ModifiedBy = Environment.UserName;
                program.ModifiedDate = DateTime.Now;

                _exerciseProgramRepository.Update(program);

                return GetExerciseProgramById(program.ExerciseProgram_Pk);
            }
            catch (Exception e)
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

        public void CompleteWorkout(int programId)
        {
            try
            {
                var workout = _workoutRepository.GetById(programId);

                workout.Complete = true;
                workout.ModifiedBy = Environment.UserName;
                workout.ModifiedDate = DateTime.Now;

                _workoutRepository.Update(workout);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}