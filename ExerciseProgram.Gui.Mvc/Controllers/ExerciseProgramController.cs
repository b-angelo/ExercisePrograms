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
        private readonly HttpClientBase<ProgramViewModel> _httpClient = new HttpClientBase<ProgramViewModel>();
        private readonly HttpClientBase<ExerciseViewModel> _httpClient2 = new HttpClientBase<ExerciseViewModel>();

        [HttpGet]
        public ActionResult ExerciseProgram()
        {
            List<ProgramViewModel> result;

            result = _httpClient.GetList($"api/ExercisePrograms/");
                      
            return View(result);
        }

        [HttpGet]
        public ActionResult GetExerciseList()
        {
            List<ExerciseViewModel> result;

            result = _httpClient2.GetList($"api/Exercise/");

            return View(result);
        }

        [HttpGet]
        public ActionResult GetExerciseListForProgram()
        {
            List<ExerciseViewModel> result;

            result = _httpClient2.GetList($"api/ExercisePrograms/1/Exercises/");

            return View(result);
        }

        [HttpPost]
        public void CreateExerciseProgram(ProgramViewModel model)
        {
            model.LengthInDays = model.LengthInDays * 7;

            var content = new ObjectContent(typeof(ProgramViewModel), model, new JsonMediaTypeFormatter());

            _httpClient.Post($"api/ExercisePrograms/", content);
        }
    }
}