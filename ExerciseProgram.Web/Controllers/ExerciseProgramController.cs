using ExerciseProgram.Models.InputModel;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Mvc;
using System.Linq;
using ExerciseProgram.Api.Services;

namespace ExerciseProgram.WebApp.Controllers
{
    public class ExerciseProgramController : Controller
    {
        private ExerciseProgramService _exerciseService = new ExerciseProgramService();

        [HttpGet]
        public ActionResult ExercisePrograms()
        {
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;

            if (Request.QueryString.HasKeys())
            {
                ViewBag.SelectedDate = Request.QueryString["monthYear"].ToString();

                var queryDate = Convert.ToDateTime(Request.QueryString["monthYear"].ToString());

                year = queryDate.Year;
                month = queryDate.Month;
            }

            var exercisePrograms = _exerciseService.GetExercisesPrograms(year, month);

            return View(exercisePrograms);
        }

        [HttpGet]
        public ActionResult ExerciseProgramDetail(int? id)
        {
            if (id == null)
                return Redirect("~/Home/Index");

            var exerciseProgramDetail = _exerciseService.GetExerciseProgramById(id.Value);

            return View(exerciseProgramDetail);
        }
        
        public ActionResult CreateExerciseProgram()
        {
            var model = new ProgramInputModel
            {
                Name = $"{Environment.UserName} - {DateTime.Today.ToShortDateString()}",
                Description = $"Workout for {DateTime.Today.ToShortDateString()}",
                LengthInDays = 1

            };

            var programId = _exerciseService.CreateExerciseProgram(model);

            return RedirectToAction("ExerciseProgramDetail", "ExerciseProgram", new { id = Convert.ToInt32(programId)});
        }

        public void UpdateExerciseProgram(ProgramInputModel model)
        {
            _exerciseService.UpdateExerciseProgram(model);
        }

        public void AddExerciseToProgram(AddExerciseToProgramInputModel model)
        {
            _exerciseService.AddExerciseToProgram(model.ProgramId, model);
        }

        [HttpPost]
        public void SaveExercise(SaveWorkoutInputModel model)
        {
            _exerciseService.SaveWorkout(model);

            TempData["Saved"] = $"Exercise Saved @ {DateTime.Now.ToLongTimeString()}";
        }

        [HttpPost]
        public void DeleteSet(SaveWorkoutInputModel model)
        {
            _exerciseService.DeleteSet(model);

            TempData["Saved"] = $"Set Deleted @ {DateTime.Now.ToLongTimeString()}";
        }

        [HttpPost]
        public void AddSet(SaveWorkoutInputModel model)
        {
            _exerciseService.AddSet(model);

            TempData["Saved"] = $"Set Added @ {DateTime.Now.ToLongTimeString()}";
        }

        [HttpPost]
        public void CompleteWorkout(int? programId)
        {
            _exerciseService.CompleteWorkout(programId.Value);
        }
    }
}