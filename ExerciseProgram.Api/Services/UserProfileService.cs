using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Api.Data.Repositories.Base;
using ExerciseProgram.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var userBodyMass = _userBodyMassRepository.GetAll().Where(x => x.UserProfile_Fk == 2);

            var weightHistory = new List<WeightHistory>();

            foreach (var entry in userBodyMass)
            {
                weightHistory.Add(new WeightHistory
                {
                    Id = entry.UserBodyMass_Pk,
                    WeightInPounds = entry.WeightInPounds,
                    CreateDate = entry.CreateDate,
                    Bmi = 0,
                    BmiCategory = "fat"
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
    }
}