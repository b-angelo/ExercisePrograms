using ExerciseProgram.Models.ViewModels;
using ExerciseProgram.WebApp.Extentions;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ExerciseProgram.WebApp.Controllers
{
    public class ExerciseProgramController : Controller
    {
        private readonly HttpClientBase<ExerciseProgramViewModel> _httpClient = new HttpClientBase<ExerciseProgramViewModel>();

        [HttpGet]
        public ActionResult ExerciseProgram()
        {
            List<ExerciseProgramViewModel> result;

            result = _httpClient.GetList($"api/ExercisePrograms/");
          
            return View(result);
        }
    }
}