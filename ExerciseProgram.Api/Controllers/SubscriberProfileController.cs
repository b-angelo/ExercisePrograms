using ExerciseProgram.Api.Services;
using ExerciseProgram.Models.InputModel;
using ExerciseProgram.Models.ViewModels;
using System.Net;
using System.Web.Http;

namespace ExerciseProgram.Api.Controllers
{
    public class SubscriberProfileController : ApiController
    {
        private SubscriberProfileService _subscriberProfileService = new SubscriberProfileService();

        [HttpGet]
        [Route("api/SubscriberProfile")]
        public SubscriberProfileViewModel UserProfile()
        {
            return _subscriberProfileService.GetUserProfile();
        }

        [HttpPost]
        [Route("api/UserProfile")]
        public HttpStatusCode CreateUserProfile([FromBody] UpdateProfileInputModel model)
        {
            _subscriberProfileService.UpdateUserProfile(model);

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
            _subscriberProfileService.DeleteUserWeight(id);

            return HttpStatusCode.OK;
        }
    }
}
