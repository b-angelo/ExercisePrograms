using ExerciseProgram.Api.Services;
using ExerciseProgram.Models.InputModel;
using ExerciseProgram.Models.ViewModels;
using System;
using System.Web.Mvc;

namespace ExerciseProgram.WebApp.Controllers
{
    [Authorize]
    public class SubscriberProfileController : Controller
    {
        private SubscriberProfileService _subscriberProfileService = new SubscriberProfileService();

        [HttpGet]
        public ActionResult SubscriberProfile()
        {
            var profile = _subscriberProfileService.GetUserProfile();

            return View(profile);
        }

        [HttpPost]
        public ActionResult UpdateProfile(SubscriberProfileViewModel model)
        {
            UpdateProfileInputModel inputModel = new UpdateProfileInputModel
            {
                Id = 2,
                Weight = model.Weight,
                Height = model.Height,
                EmailAddress = model.EmailAddress,
                DateOfBirth = model.DateOfBirth.HasValue ? model.DateOfBirth.Value : DateTime.MinValue
            };

            _subscriberProfileService.UpdateUserProfile(inputModel);

            TempData["Saved"] = $"Profile Saved @ {DateTime.Now.ToLongTimeString()}";

            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPost]
        public ActionResult DeleteUserWeightEntry(int id)
        {
            _subscriberProfileService.DeleteUserWeight(id);

            TempData["Saved"] = $"Weight Deleted @ {DateTime.Now.ToLongTimeString()}";

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}