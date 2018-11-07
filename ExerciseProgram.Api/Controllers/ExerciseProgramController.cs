using System.Collections.Generic;
using System.Net;
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
        public ProgramViewModel GetActiveExerciseProgramByUserId([FromUri] int id)
        {
            return _exerciseService.GetActiveExerciseProgramByUserId(id);
        }

        [HttpGet]
        [Route("api/ExercisePrograms/")]
        public List<ProgramViewModel> GetAllExercisePrograms()
        {
            return _exerciseService.GetExercisesPrograms();
        }

        [HttpGet]
        [Route("api/ExercisePrograms/{id:int}/Exercises/")]
        public List<ExerciseViewModel> GetAllExercisesForProgram([FromUri] int id)
        {
            return new List<ExerciseViewModel>();
        }

        [HttpPost]
        [Route("api/ExercisePrograms/")]
        public HttpStatusCode CreateExerciseProgram([FromBody] ProgramViewModel model)
        {
            if (_exerciseService.CreateExerciseProgram(model))
            {
                return HttpStatusCode.Created;
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }            
        }

        [HttpPut]
        [Route("api/ExercisePrograms/")]
        public HttpStatusCode UpdateExerciseProgram([FromBody] ProgramViewModel model)
        {
            _exerciseService.CreateExerciseProgram(model); // ToDo: create service method, return status code

            return HttpStatusCode.OK;
        }

        [HttpPost]
        [Route("api/ExercisePrograms/{id:int}/Exercises")]
        public HttpStatusCode AddExerciseToProgram([FromBody] ExerciseViewModel model)
        {
            //  _exerciseService.CreateExerciseProgram(model); // ToDo: create service method, return status code
            return HttpStatusCode.Created;
        }

        [HttpDelete]
        [Route("api/ExercisePrograms/{programId:int}/Exercises/{exerciseId:int}")]
        public HttpStatusCode RemoveExerciseFromProgram([FromBody] ExerciseViewModel model)
        {
            //  _exerciseService.CreateExerciseProgram(model); // ToDo: create service method, return status code
            return HttpStatusCode.OK;
        }
    }
}