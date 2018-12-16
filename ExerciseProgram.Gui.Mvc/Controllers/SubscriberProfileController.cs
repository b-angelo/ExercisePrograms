using ExerciseProgram.Models.InputModel;
using ExerciseProgram.Models.ViewModels;
using ExerciseProgram.WebApp.Extentions;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Mvc;

namespace ExerciseProgram.WebApp.Controllers
{
    public class SubscriberProfileController : Controller
    {
        private readonly HttpClientBase<SubscriberProfileViewModel> _httpClient = new HttpClientBase<SubscriberProfileViewModel>();

        [HttpGet]
        public ActionResult SubscriberProfile()
        {
            var result = _httpClient.GetSingle("api/SubscriberProfile");

            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateProfile(SubscriberProfileViewModel model)
        {
            UpdateProfileInputModel inputModel = new UpdateProfileInputModel
            {
                Id = 2,
                Weight = model.Weight,
                Height = model.Height,
                EmailAddress = model.EmailAddress
            };

            var content = new ObjectContent(typeof(UpdateProfileInputModel), inputModel, new JsonMediaTypeFormatter());

            _httpClient.Post($"api/UserProfile/", content);

            TempData["Saved"] = "Saved";
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