using ExerciseProgram.Models.ViewModels;
using ExerciseProgram.WebApp.Extentions;
using System.Net.Http;
using System.Net.Http.Formatting;
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
        public ActionResult UpdateProfile(UserProfileViewModel model, int userId = 2)
        {
            var content = new ObjectContent(typeof(UserProfileViewModel), model, new JsonMediaTypeFormatter());
            
            _httpClient.Post($"api/UserProfile/{userId}", content);

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