using ExerciseProgram.Models.ViewModels;
using ExerciseProgram.WebApp.Extentions;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ExerciseProgram.WebApp.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly HttpClientBase<ExerciseViewModel> _httpClient = new HttpClientBase<ExerciseViewModel>();

        [HttpGet]
        public ActionResult Exercise(string muscleGroupName)
        {
            List<ExerciseViewModel> result;

            if (!string.IsNullOrEmpty(muscleGroupName))
            {
                result = _httpClient.GetList($"api/Exercise/{muscleGroupName}");
            }
            else
            {
                result = _httpClient.GetList($"api/Exercise");
            }

            return View(result);
        }
    }
}