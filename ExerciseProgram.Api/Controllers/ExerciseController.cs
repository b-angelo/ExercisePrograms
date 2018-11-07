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
        [Route("api/Exercise/{muscleGroupName}")]
        public List<ExerciseViewModel> GetExercisesByMuscleGroup([FromUri] string muscleGroupName)
        {
            return _exerciseService.GetExercises();
        }

        [HttpGet]
        [Route("api/Exercise/")]
        public List<ExerciseViewModel> GetAllExercises()
        {           
            return _exerciseService.GetExercises();
        }
    }
}