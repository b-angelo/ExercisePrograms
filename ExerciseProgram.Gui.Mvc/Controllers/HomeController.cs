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
        private readonly HttpClientBase<SubscriberProfileViewModel> _httpClient = new HttpClientBase<SubscriberProfileViewModel>();

        public ActionResult Index()
        {
            SubscriberProfileViewModel todaysWorkout;

            todaysWorkout = _httpClient.GetSingle($"api/SubscriberProfile/");

            if (todaysWorkout == null)
            {
                todaysWorkout = new SubscriberProfileViewModel();
            }

            return View(todaysWorkout);
        }
    }
}