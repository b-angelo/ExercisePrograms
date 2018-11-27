﻿using ExerciseProgram.Models.ViewModels;
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
        
        [HttpPost]
        public void CreateExerciseProgram(ProgramViewModel model)
        {
            model.LengthInDays = model.LengthInDays * 7;

            var content = new ObjectContent(typeof(ProgramViewModel), model, new JsonMediaTypeFormatter());

            _httpClient.Post($"api/ExercisePrograms/", content);
        }
    }
}