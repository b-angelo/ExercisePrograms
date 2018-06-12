using System.Collections.Generic;
using System.Web.Http;
using ExerciseProgram.Api.Services;
using ExerciseProgram.Models.ViewModels;

namespace ExerciseProgram.Api.Controllers
{
    public class ExerciseProgramController : ApiController
    {
        private ExerciseProgramService _exerciseService = new ExerciseProgramService();

        [HttpGet]
        [Route("api/ExercisePrograms/")]
        public List<ExerciseProgramViewModel> GetAllExercisePrograms()
        {
            return _exerciseService.GetExercisesPrograms();
        }

        [HttpPost]
        [Route("api/ExercisePrograms/")]
        public void CreateExerciseProgram([FromBody] ExerciseProgramViewModel model)
        {
            _exerciseService.CreateExerciseProgram(model);
        }
    }
}