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
        [Route("api/ExercisePrograms/Active/{id:int}")]
        public ExerciseProgramViewModel GetActiveExerciseProgramByUserId([FromUri] int id)
        {
            return _exerciseService.GetActiveExerciseProgramByUserId(id);
        }

        [HttpGet]
        [Route("api/ExercisePrograms/")]
        public List<ExerciseProgramViewModel> GetAllExercisePrograms()
        {
            return _exerciseService.GetExercisesPrograms();
        }

        [HttpGet]
        [Route("api/ExercisePrograms/{id:int}/Exercises/")]
        public List<ExerciseProgramViewModel> GetAllExercisesForProgram([FromUri] int id)
        {
            return _exerciseService.GetExercisesPrograms(); // ToDo: create service method
        }

        [HttpPost]
        [Route("api/ExercisePrograms/")]
        public void CreateExerciseProgram([FromBody] ExerciseProgramViewModel model)
        {
            _exerciseService.CreateExerciseProgram(model); // ToDo: return status code
        }

        [HttpPut]
        [Route("api/ExercisePrograms/")]
        public void UpdateExerciseProgram([FromBody] ExerciseProgramViewModel model)
        {
            _exerciseService.CreateExerciseProgram(model); // ToDo: create service method, return status code
        }

        [HttpPost]
        [Route("api/ExercisePrograms/{id:int}/Exercises")]
        public void AddExerciseToProgram([FromBody] ExerciseViewModel model)
        {
          //  _exerciseService.CreateExerciseProgram(model); // ToDo: create service method, return status code
        }

        [HttpDelete]
        [Route("api/ExercisePrograms/{programId:int}/Exercises/{exerciseId:int}")]
        public void RemoveExerciseFromProgram([FromBody] ExerciseViewModel model)
        {
          //  _exerciseService.CreateExerciseProgram(model); // ToDo: create service method, return status code
        }
    }
}