using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ExerciseProgram.Api.Services
{
    public class UserProfileService
    {
        private ExerciseProgramDataContext db = new ExerciseProgramDataContext();

        public UserProfileViewModel GetUserProfile(int userPk)
        {
            var userProfile = db.Users
                                .Include(a => a.UserRole)
                                .Include(b => b.UserBodyMasses)
                                .FirstOrDefault(x => x.User_Pk == userPk);

            var weightHistory = new List<WeightHistory>();

            foreach (var weight in userProfile.UserBodyMasses.OrderByDescending(x => x.CreateDate))
            {
                var weightInKillograms = weight.WeightInPounds * 0.45;
                var metricHeightConversion = weight.HeightInInches * 0.025;
                var heightSquared = metricHeightConversion * metricHeightConversion;
                var bmi = weightInKillograms / heightSquared;

                if (!weight.EndDate.HasValue || (weight.EndDate.HasValue && weight.EndDate.Value > DateTime.Now))
                {
                    weightHistory.Add(new WeightHistory
                    {
                        Id = weight.UserBodyMass_Pk,
                        WeightInPounds = weight.WeightInPounds,
                        CreateDate = weight.CreateDate,
                        Bmi = Math.Round(bmi, 2)
                    });
                }
            }
                      

            var userProfileViewModel = new UserProfileViewModel
            {
                UserName = userProfile.UserName,
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                EmailAddress = userProfile.EmailAddress,
                DateOfBirth = userProfile.DateOfBirth.Value,
                Height = userProfile.UserBodyMasses.OrderByDescending(x => x.CreateDate).FirstOrDefault().HeightInInches,
                Weight = weightHistory.OrderByDescending(x => x.CreateDate).FirstOrDefault().WeightInPounds,
                BodyMassIndex = weightHistory.OrderByDescending(x => x.CreateDate).FirstOrDefault().Bmi,
                WeightHistory = weightHistory,
                DateJoined = userProfile.CreateDate
            };

            return userProfileViewModel;
        }

        public void UpdateUserProfile(int userPk, int weight, int height, string emailAddress)
        {
            db.UserBodyMasses.Add(new UserBodyMass
            {
                User_Fk = userPk,
                HeightInInches = height,
                WeightInPounds = weight,
                StartDate = DateTime.Now,
                EndDate = null,
                CreatedBy = Environment.UserName,
                CreateDate = DateTime.Now,
                ModifiedBy = null,
                ModifiedDate = null
            });

            var userProfile = db.Users.Where(x => x.User_Pk == userPk).FirstOrDefault();
                        
            userProfile.EmailAddress = emailAddress;

          

            db.SaveChanges();
        }

        public void DeleteUserWeightEntry(int weightPk)
        {
            var entry = db.UserBodyMasses.FirstOrDefault(x => x.UserBodyMass_Pk == weightPk);

            var now = DateTime.Now;
        
            entry.EndDate = now;
            entry.ModifiedDate = now;
            entry.ModifiedBy = Environment.UserName;

            db.SaveChanges();
        }
    }
}