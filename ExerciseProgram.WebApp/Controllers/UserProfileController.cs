using ExerciseProgram.Models.ViewModels;
using ExerciseProgram.WebApp.Extentions;
using System.Web.Mvc;

namespace ExerciseProgram.WebApp.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly HttpClientBase<UserProfileViewModel> _httpClient = new HttpClientBase<UserProfileViewModel>();

        [HttpGet]
        public ActionResult UserProfile()
        {
            var result = _httpClient.GetSingle("api/UserProfile?pageFrom=1&pageTo=5");

            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateProfile(int weight, int height, string emailAddress)
        {
            _httpClient.Post($"api/UserProfile/2/{weight}/{height}/{emailAddress}");

            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPost]
        public ActionResult DeleteUserWeightEntry(int id)
        {
            _httpClient.Delete($"api/UserProfile/weight/{id}");

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}