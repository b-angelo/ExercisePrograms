using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Api.Data.Repositories.Base;
using ExerciseProgram.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseProgram.Api.Services
{
    public class UserProfileService
    {
        private readonly IRepository<UserProfile> _userRepository = new Repository<UserProfile>();
        private readonly IRepository<UserBodyMass> _userBodyMassRepository = new Repository<UserBodyMass>();

        public UserProfileViewModel GetUserProfile()
        {
            var user = _userRepository.GetById(2);
            var userBodyMass = _userBodyMassRepository.GetAll()
                                                      .Where(x => x.UserProfile_Fk == 2 && (x.EndDate > DateTime.Now || x.EndDate == null))
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
                    Id = entry.UserBodyMass_Pk,
                    WeightInPounds = entry.WeightInPounds,
                    CreateDate = entry.CreateDate,
                    Bmi = bmi,
                    BmiCategory = bmiCategory
                });
            }

            var profile = new UserProfileViewModel
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                DateOfBirth = user.DateOfBirth.Value,
                Height = 74,
                BodyMassIndex = 0,
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
    }
}