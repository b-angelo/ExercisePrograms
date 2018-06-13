using ExerciseProgram.Models.ViewModels;
using ExerciseProgram.WebApp.Extentions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Mvc;

namespace ExerciseProgram.WebApp.Controllers
{
    public class ExerciseProgramController : Controller
    {
        private readonly HttpClientBase<ExerciseProgramViewModel> _httpClient = new HttpClientBase<ExerciseProgramViewModel>();
        private readonly HttpClientBase<ExerciseViewModel> _httpClient2 = new HttpClientBase<ExerciseViewModel>();

        [HttpGet]
        public ActionResult ExerciseProgram()
        {
            List<ExerciseProgramViewModel> result;

            result = _httpClient.GetList($"api/ExercisePrograms/");
          
            foreach (var program in result)
            {
                program.DurationInDays = program.DurationInDays / 7;
            }

            return View(result);
        }

        [HttpGet]
        public ActionResult GetExerciseList()
        {
            List<ExerciseViewModel> result;

            result = _httpClient2.GetList($"api/Exercise/");

            return View(result);
        }

        [HttpPost]
        public void CreateExerciseProgram(ExerciseProgramViewModel model)
        {
            model.DurationInDays = model.DurationInDays * 7;

            var content = new ObjectContent(typeof(ExerciseProgramViewModel), model, new JsonMediaTypeFormatter());

            _httpClient.Post($"api/ExercisePrograms/", content);
        }
    }
}