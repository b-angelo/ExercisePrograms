using ExerciseProgram.Api.Services;
using ExerciseProgram.Models.ViewModels;
using System.Web.Mvc;

namespace ExerciseProgram.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private SubscriberProfileService _subscriberProfileService = new SubscriberProfileService();

        public ActionResult Index()
        {
            var profile = _subscriberProfileService.GetUserProfile();

            if (profile == null)
            {
                profile = new SubscriberProfileViewModel();
            }

            return View(profile);
        }
    }
}