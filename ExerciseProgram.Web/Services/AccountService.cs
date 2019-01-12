using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Api.Data.Repositories.Base;
using ExerciseProgram.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExerciseProgram.Gui.Mvc.Services
{
    public class AccountService
    {
        private IRepository<SubscriberProfile> _subscriberProfile = new Repository<SubscriberProfile>();

        public void RegisterUser(RegisterInputModel model)
        {
            if (model.FirstName != null)
            {
                var profiles = _subscriberProfile.GetAll().Where(x => x.EmailAddress == model.EmailAddress);

                if (profiles.Any())
                    throw new Exception();

                var salt = Guid.NewGuid();
                var saltBytes = Encoding.ASCII.GetBytes(salt.ToString());
                var passwordBytes = Encoding.ASCII.GetBytes(model.Password);
                var hashedPasswordBytes = new List<byte>();

                hashedPasswordBytes.AddRange(saltBytes);
                hashedPasswordBytes.AddRange(passwordBytes);

                //var passwordHash = Convert.ToBase64String(hashedPasswordBytes.ToArray());

                var profile = new SubscriberProfile
                {
                    Role_Fk = 1,
                    DisplayName = model.FirstName,
                    PasswordHash = hashedPasswordBytes.ToArray(),
                    Salt = salt,
                    ResetPasswordGuid = null,
                    ResetPasswordExpirationDate = null,
                    LogInAttempts = null,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.EmailAddress,
                    DateOfBirth = null,
                    StartDate = DateTime.Today,
                    CreateDate = DateTime.Now,
                    CreatedBy = Environment.UserName
                };

                _subscriberProfile.Insert(profile);
            }           
        }
    }
}