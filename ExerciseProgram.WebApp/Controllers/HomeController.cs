using ExerciseProgram.Models.ViewModels;
using ExerciseProgram.WebApp.Extentions;
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
    }
}