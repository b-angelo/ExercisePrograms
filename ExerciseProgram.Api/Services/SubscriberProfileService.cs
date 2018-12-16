using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Api.Data.Repositories.Base;
using ExerciseProgram.Models.InputModel;
using ExerciseProgram.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseProgram.Api.Services
{
    public class SubscriberProfileService
    {
        private readonly IRepository<SubscriberProfile> _subscriberRepository = new Repository<SubscriberProfile>();
        private readonly IRepository<BodyMass> _subscriberBodyMassRepository = new Repository<BodyMass>();
        private IRepository<Workout> _workoutRepository = new Repository<Workout>();
        private IRepository<WorkoutHistory> _workoutHistoryRepository = new Repository<WorkoutHistory>();
        private IRepository<ExerciseProgramExercise> _exerciseProgramExerciseRepository = new Repository<ExerciseProgramExercise>();
        private IRepository<Data.Entities.ExerciseProgram> _exerciseProgramRepository = new Repository<Data.Entities.ExerciseProgram>();

        public SubscriberProfileViewModel GetUserProfile()
        {  
            var subscriber = _subscriberRepository.GetById(2);
            var subscriberBodyMass = _subscriberBodyMassRepository.GetAll()
                                                      .Where(x => x.Profile_Fk == 2 && (x.EndDate > DateTime.Now || x.EndDate == null))
                                                      .OrderByDescending(x => x.CreateDate);

            var weightHistory = new List<WeightHistory>();

            foreach (var entry in subscriberBodyMass)
            {
                var bmi = Math.Round((703 * (double)entry.WeightInPounds) / ((double) entry.HeightInInches * (double)entry.HeightInInches), 2);
                var bmiCategory = string.Empty;

                if (bmi < 18.5)
                {
                    bmiCategory = "Underweight";
                }
                else if (bmi < 24.9)
                {
                    bmiCategory = "Normal";
                }
                else if (bmi < 29.9)
                {
                    bmiCategory = "Overweight";
                }
                else
                {
                    bmiCategory = "Obese";
                }

                weightHistory.Add(new WeightHistory
                {
                    Id = entry.BodyMass_Pk,
                    WeightInPounds = entry.WeightInPounds,
                    CreateDate = entry.CreateDate,
                    Bmi = bmi,
                    BmiCategory = bmiCategory
                });
            }

            var dayOfWeek = (int)DateTime.Today.DayOfWeek;
            var currentWeek = DateTime.Today.AddDays(-dayOfWeek);
            var currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var currentYear = new DateTime(DateTime.Today.Year, 1, 1);

            var workoutsCompleted = _workoutRepository.GetAll().Where(x => x.Complete);
            var workoutsCompletedWeek = workoutsCompleted.Where(x => x.StartDate > currentWeek).Count();
            var workoutsCompletedMonth = workoutsCompleted.Where(x => x.StartDate > currentMonth).Count();
            var workoutsCompletedYear = workoutsCompleted.Where(x => x.StartDate > currentYear).Count();

            var currentWorkout = _workoutRepository.GetAll()
                                                   .Where(x => x.Complete == false && 
                                                               x.StartDate < DateTime.Now && 
                                                               x.EndDate > DateTime.Now)
                                                   .FirstOrDefault();

            var currentExerciseProgram = new Data.Entities.ExerciseProgram();
            var excerciseCount = 0;
            if (currentWorkout != null)
            {
                currentExerciseProgram = _exerciseProgramRepository.GetAll()
                                                                   .Where(x => x.ExerciseProgram_Pk == currentWorkout.ExerciseProgram_Fk)
                                                                   .FirstOrDefault();

                if (currentExerciseProgram != null)
                excerciseCount = _exerciseProgramExerciseRepository.GetAll()
                                                                   .Where(x => x.ExerciseProgram_Fk == currentExerciseProgram.ExerciseProgram_Pk)
                                                                   .Count();
            }

            var profile = new SubscriberProfileViewModel
            {
                SubscriberName = subscriber?.DisplayName ?? string.Empty,
                FirstName = subscriber?.FirstName ?? string.Empty,
                LastName = subscriber?.LastName ?? string.Empty,
                EmailAddress = subscriber?.EmailAddress ?? string.Empty,
                DateOfBirth = subscriber?.DateOfBirth.Value ?? DateTime.MinValue,
                Height = 74,
                BodyMassIndex = weightHistory?.OrderByDescending(x => x.CreateDate)?.FirstOrDefault()?.Bmi ?? 0,
                Weight = weightHistory?.OrderByDescending(x => x.CreateDate)?.FirstOrDefault()?.WeightInPounds ?? 0,
                WeightHistory = weightHistory ?? new List<WeightHistory>(),
                DateJoined = subscriber?.CreateDate ?? DateTime.MinValue,
                CurrentProgramId = currentExerciseProgram?.ExerciseProgram_Pk ?? 0, 
                CurrentWorkoutName = currentExerciseProgram?.Name ?? string.Empty,
                WorkoutsCompletedWeek = workoutsCompletedWeek,
                WorkoutsCompletedMonth = workoutsCompletedMonth,
                WorkoutCompletedYear = workoutsCompletedYear,
                CurrentWorkoutExerciseCount = excerciseCount
            };

            return profile;

        }

        public void DeleteUserWeight(int id)
        {
            var userBodyMass = _subscriberBodyMassRepository.GetById(id);

            userBodyMass.EndDate = DateTime.Now;
            userBodyMass.ModifiedDate = DateTime.Now;
            userBodyMass.ModifiedBy = Environment.UserName;

            _subscriberBodyMassRepository.Update(userBodyMass);
        }

        public void UpdateUserProfile(UpdateProfileInputModel model)
        {
            var userProfile = _subscriberRepository.GetById(model.Id);
            
            userProfile.EmailAddress = model.EmailAddress;
            userProfile.ModifiedBy = Environment.UserName;
            userProfile.ModifiedDate = DateTime.Now;                 

            var userBodyMass = new BodyMass
            {
                Profile_Fk = userProfile.Profile_Pk,
                HeightInInches = model.Height,
                WeightInPounds = model.Weight,
                CreateDate = DateTime.Now,
                CreatedBy = Environment.UserName,
                StartDate = DateTime.Now
            };

            var bmis = _subscriberBodyMassRepository.GetAll().Any(x => x.WeightInPounds == model.Weight &&
                                                            x.HeightInInches == model.Height  &&
                                                            x.CreateDate.Date == DateTime.Today);
    
            if (userProfile.EmailAddress == model.EmailAddress && bmis)
            {
                return;
            }

            _subscriberRepository.Update(userProfile);
            _subscriberBodyMassRepository.Insert(userBodyMass);
        }
    }
}