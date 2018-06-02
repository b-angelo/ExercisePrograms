using ExerciseProgram.Api.Data.Entities;
using ExerciseProgram.Api.Services;
using ExerciseProgram.Models.ViewModels;
using System.Net;
using System.Web.Http;

namespace ExerciseProgram.Api.Controllers
{
    public class UserProfileController : ApiController
    {
        private ExerciseProgramDataContext db = new ExerciseProgramDataContext();
        private UserProfileService _userProfileService = new UserProfileService();

        public UserProfileViewModel GetExercises()
        {
            return _userProfileService.GetUserProfile(2);
        }

        [HttpPost]
        [Route("api/UserProfile/{userPk:int}/{weight:int}/{height:int}/{emailAddress}/")]
        public HttpStatusCode UpdateUserProfile([FromUri] int userPk, [FromUri] int weight, [FromUri] int height, [FromUri] string emailAddress)
        {
            _userProfileService.UpdateUserProfile(2, weight, height, emailAddress);

            return HttpStatusCode.Created;
        }

        [HttpDelete]
        [Route("api/UserProfile/weight/{id:int}")]
        public HttpStatusCode DeleteUserWeight([FromUri] int id)
        {
            _userProfileService.DeleteUserWeightEntry(id);

            return HttpStatusCode.OK;
        }
    }
}
