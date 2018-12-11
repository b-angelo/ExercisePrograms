using ExerciseProgram.Api.Services;
using ExerciseProgram.Models.InputModel;
using ExerciseProgram.Models.ViewModels;
using System.Net;
using System.Web.Http;

namespace ExerciseProgram.Api.Controllers
{
    public class SubscriberProfileController : ApiController
    {
        private UserProfileService _userProfileService = new UserProfileService();

        [HttpGet]
        [Route("api/UserProfile")]
        public UserProfileViewModel UserProfile([FromUri] string pageFrom, [FromUri] string pageTo)
        {
            return _userProfileService.GetUserProfile();
        }

        [HttpPost]
        [Route("api/UserProfile")]
        public HttpStatusCode CreateUserProfile([FromBody] UpdateProfileInputModel model)
        {
            _userProfileService.UpdateUserProfile(model);

            return HttpStatusCode.Created;
        }
        
        [HttpDelete]
        [Route("api/UserProfile/{userId:int}")]
        public HttpStatusCode DeleteUserProfile([FromUri] int id)
        {

            return HttpStatusCode.OK;
        }

        [HttpDelete]
        [Route("api/UserProfile/weight/{id:int}")]
        public HttpStatusCode DeleteUserWeight([FromUri] int id)
        {
            _userProfileService.DeleteUserWeight(id);

            return HttpStatusCode.OK;
        }
    }
}
