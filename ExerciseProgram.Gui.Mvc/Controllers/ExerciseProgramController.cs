using ExerciseProgram.Models.InputModel;
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

        [HttpGet]
        public ActionResult ExercisePrograms()
        {
            List<ProgramViewModel> result;

            if (Request.QueryString.HasKeys())
            {
                var pagingFrom = Request.QueryString["pagingFrom"].ToString();
                var pagingTo = Request.QueryString["pagingTo"].ToString();
            }

            result = _httpClient.GetList($"api/ExercisePrograms/");
                      
            return View(result);
        }

        [HttpGet]
        public ActionResult ExerciseProgramDetail(int id)
        {
            ProgramViewModel result;

            result = _httpClient.GetSingle($"api/ExercisePrograms/{id}");

            return View(result);
        }
        
        public ActionResult CreateExerciseProgram()
        {
            var model = new ProgramInputModel
            {
                Name = $"{Environment.UserName} - {DateTime.Today.ToShortDateString()}",
                Description = $"{Environment.UserName} - {DateTime.Today.ToShortDateString()}",
                LengthInDays = 1

            };
            var content = new ObjectContent(typeof(ProgramInputModel), model, new JsonMediaTypeFormatter());

            var reponse = _httpClient.Post($"api/ExercisePrograms/", content);
            var index = reponse.Headers.Location.ToString().LastIndexOf('/') + 1;
            var programId = reponse.Headers.Location.ToString().Substring(index);

            ViewBag.ProgramCreated = "Created";

            return RedirectToAction("ExerciseProgramDetail", "ExerciseProgram", new { id = Convert.ToInt32(programId)});
        }

        public ActionResult AddExerciseToProgram(int programId, int exerciseId)
        {
            var reponse = _httpClient.Post($"api/ExercisePrograms/{programId}/Exercises/{exerciseId}", null);

            return RedirectToAction("ExerciseProgramDetail", "ExerciseProgram", new { id = Convert.ToInt32(programId) });
        }

        //[HttpPost]
        //public ActionResult CreateExerciseProgram(NewProgramInputModel model)
        //{
        //    model.LengthInDays = model.LengthInDays * 7;

        //    var content = new ObjectContent(typeof(NewProgramInputModel), model, new JsonMediaTypeFormatter());

        //    _httpClient.Post($"api/ExercisePrograms/", content);

        //    ViewBag.Saved = "ProgramInfoSaved";

        //    return View();
        //}
    }
}