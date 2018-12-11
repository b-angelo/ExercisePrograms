using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Api.Data.Repositories.Base;
using ExerciseProgram.Models.InputModel;
using ExerciseProgram.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseProgram.Api.Services
{
    public class UserProfileService
    {
        private readonly IRepository<SubscriberProfile> _userRepository = new Repository<SubscriberProfile>();
        private readonly IRepository<BodyMass> _userBodyMassRepository = new Repository<BodyMass>();

        public UserProfileViewModel GetUserProfile()
        {
            var user = _userRepository.GetById(2);
            var userBodyMass = _userBodyMassRepository.GetAll()
                                                      .Where(x => x.Profile_Fk == 2 && (x.EndDate > DateTime.Now || x.EndDate == null))
                                                      .OrderByDescending(x => x.CreateDate);

            var weightHistory = new List<WeightHistory>();

            foreach (var entry in userBodyMass)
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

            var profile = new UserProfileViewModel
            {
                UserName = user.DisplayName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                DateOfBirth = user.DateOfBirth.Value,
                Height = 74,
                BodyMassIndex = weightHistory.OrderByDescending(x => x.CreateDate).FirstOrDefault().Bmi,
                Weight = weightHistory.OrderByDescending(x => x.CreateDate).FirstOrDefault().WeightInPounds,
                WeightHistory = weightHistory,
                DateJoined = user.CreateDate
            };

            return profile;

        }

        public void DeleteUserWeight(int id)
        {
            var userBodyMass = _userBodyMassRepository.GetById(id);

            userBodyMass.EndDate = DateTime.Now;
            userBodyMass.ModifiedDate = DateTime.Now;
            userBodyMass.ModifiedBy = Environment.UserName;

            _userBodyMassRepository.Update(userBodyMass);
        }

        public void UpdateUserProfile(UpdateProfileInputModel model)
        {
            var userProfile = _userRepository.GetById(model.Id);
            
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

            var bmis = _userBodyMassRepository.GetAll().Any(x => x.WeightInPounds == model.Weight &&
                                                            x.HeightInInches == model.Height  &&
                                                            x.CreateDate.Date == DateTime.Today);
    
            if (userProfile.EmailAddress == model.EmailAddress && bmis)
            {
                return;
            }

            _userRepository.Update(userProfile);
            _userBodyMassRepository.Insert(userBodyMass);
        }
    }
}