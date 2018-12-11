using ExerciseProgram.Models.ViewModels;
using ExerciseProgram.WebApp.Extentions;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ExerciseProgram.Gui.Mvc.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly HttpClientBase<ExerciseViewModel> _httpClient = new HttpClientBase<ExerciseViewModel>();

        [HttpGet]
        public ActionResult Exercise()
        {
            List<ExerciseViewModel> result;

            result = _httpClient.GetList($"api/Exercises/");

            return View(result);
        }
    }
}