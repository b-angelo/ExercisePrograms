using System.Collections.Generic;
using System.Web.Http;
using ExerciseProgram.Api.Services;
using ExerciseProgram.Models.ViewModels;

namespace ExerciseProgram.Api.Controllers
{
    public class ExerciseController : ApiController
    {
        private ExerciseService _exerciseService = new ExerciseService();

        [HttpGet]
        [Route("api/Exercise/{id:int}")]
        public ExerciseViewModel GetExerciseById([FromUri] int id)
        {
            return _exerciseService.GetExerciseById(id);
        }
        
        [HttpGet]
        [Route("api/Exercises/")]
        public List<ExerciseViewModel> GetAllExercises()
        {           
            return _exerciseService.GetExercises();
        }
    }
}