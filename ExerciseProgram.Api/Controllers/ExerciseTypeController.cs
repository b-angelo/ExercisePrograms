using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ExerciseProgram.Api.Data.Entities;

namespace ExerciseProgram.Api.Controllers
{
    public class ExerciseTypeController : ApiController
    {
        private ExerciseProgramDataContext db = new ExerciseProgramDataContext();

        // ToDo: get exercise types
    }
}