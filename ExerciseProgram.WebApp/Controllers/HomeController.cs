using ExerciseProgram.Models.ViewModels;
using ExerciseProgram.WebApp.Extentions;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ExerciseProgram.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClientBase<UserProfileViewModel> _httpClient = new HttpClientBase<UserProfileViewModel>();
        private readonly HttpClientBase<ExerciseViewModel> _httpClient2 = new HttpClientBase<ExerciseViewModel>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Exercise(string muscleGroupName)
        {
            List<ExerciseViewModel> result;

            if (!string.IsNullOrEmpty(muscleGroupName))
            {
                result = _httpClient2.GetList($"api/Exercise/{muscleGroupName}");
            }
            else
            {
                result = _httpClient2.GetList($"api/Exercise");
            }
                        
            return View(result);
        }

        public ActionResult ExercisesFiltered()
        {
            List<ExerciseViewModel> result;

            result = _httpClient2.GetList($"api/Exercise");
          
            return View(result);
        }

        public ActionResult UserProfile()
        {
            var result = _httpClient.GetSingle("api/UserProfile");

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

        public ActionResult Goals()
        {
            return View();
        }
    }
}