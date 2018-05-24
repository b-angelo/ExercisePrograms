using ExerciseProgram.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ExerciseProgram.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Exercise()
        {
            List<ExerciseViewModel> exercises = new List<ExerciseViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:30305/");

                var responseTask = client.GetAsync("api/Exercise");
                responseTask.Wait();

                var result = responseTask.Result;
                
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<ExerciseViewModel>>();
                    readTask.Wait();

                    exercises = readTask.Result;
                }
                else //web api sent error response 
                {
                    ////log response status here..

                    //students = Enumerable.Empty<StudentViewModel>();

                    //ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(exercises);
        }
    }
}