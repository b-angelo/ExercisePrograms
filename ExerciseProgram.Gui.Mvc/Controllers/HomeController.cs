using ExerciseProgram.Models.ViewModels;
using ExerciseProgram.WebApp.Extentions;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System;

namespace ExerciseProgram.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClientBase<ProgramViewModel> _httpClient = new HttpClientBase<ProgramViewModel>();

        public ActionResult Index()
        {
            ProgramViewModel todaysWorkout;

            todaysWorkout = _httpClient.GetList($"api/ExercisePrograms/")
                                       .FirstOrDefault(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now);

            if (todaysWorkout == null)
            {
                todaysWorkout = new ProgramViewModel();
            }

            return View(todaysWorkout);
        }
    }
}