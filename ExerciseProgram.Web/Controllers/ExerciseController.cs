using ExerciseProgram.Api.Services;
using System.Web.Mvc;

namespace ExerciseProgram.Gui.Mvc.Controllers
{
    public class ExerciseController : Controller
    {
        private ExerciseService _exerciseService = new ExerciseService();

        [HttpGet]
        public ActionResult Exercise()
        {
            var exercises = _exerciseService.GetExercises();

            return PartialView(exercises);
        }
    }
}