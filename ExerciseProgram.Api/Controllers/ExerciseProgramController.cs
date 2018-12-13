using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExerciseProgram.Api.Services;
using ExerciseProgram.Models.InputModel;
using ExerciseProgram.Models.ViewModels;

namespace ExerciseProgram.Api.Controllers
{
    public class ExerciseProgramController : ApiController
    {
        private ExerciseProgramService _exerciseService = new ExerciseProgramService();

        [HttpGet]
        [Route("api/ExercisePrograms/{id:int}")]
        public ProgramViewModel GetExerciseProgramById([FromUri] int id)
        {
            return _exerciseService.GetExerciseProgramById(id);
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
        public HttpResponseMessage CreateExerciseProgram([FromBody] ProgramInputModel model)
        {
            var programId = _exerciseService.CreateExerciseProgram(model);
            var response = Request.CreateResponse(HttpStatusCode.Created);
           
            response.Headers.Location = new System.Uri($"{ConfigurationManager.AppSettings["ExerciseApiService"]}api/ExercisePrograms/{programId}");

            return response;
        }

        [HttpPut]
        [Route("api/ExercisePrograms/")]
        public HttpStatusCode UpdateExerciseProgram([FromBody] ProgramInputModel model)
        {
            _exerciseService.CreateExerciseProgram(model); // ToDo: create service method, return status code

            return HttpStatusCode.OK;
        }

        [HttpPost]
        [Route("api/ExercisePrograms/{programId:int}/exercises/")]
        public HttpStatusCode AddExerciseToProgram([FromUri] int programId, [FromBody] AddExerciseToProgramInputModel model)
        {
            _exerciseService.AddExerciseToProgram(programId, model);

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