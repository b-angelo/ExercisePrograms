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

        public UserProfileViewModel GetUserProfile(int userId, int pageFrom, int pageTo)
        {
            var userProfile = db.Users
                                //.Include(a => a.UserRole)
                                .Include(b => b.UserBodyMasses)
                                .FirstOrDefault(x => x.User_Pk == userId);

            var weightHistory = new List<WeightHistory>();

            foreach (var weight in userProfile.UserBodyMasses.OrderByDescending(x => x.CreateDate))
            {
                var weightInKillograms = weight.WeightInPounds * 0.45;
                var metricHeightConversion = weight.HeightInInches * 0.025;
                var heightSquared = metricHeightConversion * metricHeightConversion;
                var bmi = weightInKillograms / heightSquared;
                string bmiCategory;

                if (bmi < 18.5)
                {
                    bmiCategory = "Underweight Range";
                }
                else if (bmi < 24.9)
                {
                    bmiCategory = "Normal Range";
                }
                else if (bmi < 29.9)
                {
                    bmiCategory = "Overweight Range";
                }
                else
                {
                    bmiCategory = "Obese Range";
                }


                if (!weight.EndDate.HasValue || (weight.EndDate.HasValue && weight.EndDate.Value > DateTime.Now))
                {
                    weightHistory.Add(new WeightHistory
                    {
                        Id = weight.UserBodyMass_Pk,
                        WeightInPounds = weight.WeightInPounds,
                        CreateDate = weight.CreateDate,
                        Bmi = Math.Round(bmi, 2),
                        BmiCategory = bmiCategory
                    });
                }
            }

            if (weightHistory.Count > pageTo)
                weightHistory.RemoveRange(pageTo - 1, (weightHistory.Count - pageTo));

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

        public void UpdateUserProfile(int userId, UserProfileViewModel model)
        {
            db.UserBodyMasses.Add(new UserBodyMass
            {
                User_Fk = userId,
                HeightInInches = model.Height,
                WeightInPounds = model.Weight,
                StartDate = DateTime.Now,
                EndDate = null,
                CreatedBy = Environment.UserName,
                CreateDate = DateTime.Now,
                ModifiedBy = null,
                ModifiedDate = null
            });

            var userProfile = db.Users.Where(x => x.User_Pk == userId).FirstOrDefault();

            userProfile.EmailAddress = model.EmailAddress;
            userProfile.ModifiedBy = Environment.UserName;
            userProfile.ModifiedDate = DateTime.Now;

            db.SaveChanges();
        }

        public void DeleteUserProfile(int userId)
        {
            var userBodyMasses = db.UserBodyMasses.Where(x => x.User_Fk == userId && (x.EndDate == null || x.EndDate > DateTime.Now)).ToList();
            var now = DateTime.Now;

            foreach (var userBodyMass in userBodyMasses)
            {
                userBodyMass.EndDate = now;
                userBodyMass.ModifiedBy = Environment.UserName;
                userBodyMass.ModifiedDate = now;
            }

            // ToDo: add link from excersise program to user

            var user = db.Users.Where(x => x.User_Pk == userId).FirstOrDefault();

            user.EndDate = now;
            user.ModifiedBy = Environment.UserName;
            user.ModifiedDate = now;

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