using System.Web.Mvc;

namespace ExerciseProgram.WebApp.Controllers
{
    public class GoalsController : Controller
    {
        [HttpGet]
        public ActionResult Goals()
        {
            return View();
        }
    }
}