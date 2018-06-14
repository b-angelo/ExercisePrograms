using ExerciseProgram.Api.Services;
using ExerciseProgram.Models.ViewModels;
using System;
using System.Net;
using System.Web.Http;

namespace ExerciseProgram.Api.Controllers
{
    public class UserProfileController : ApiController
    {
        private UserProfileService _userProfileService = new UserProfileService();

        [HttpGet]
        [Route("api/UserProfile")]
        public UserProfileViewModel UserProfile([FromUri] string pageFrom, [FromUri] string pageTo)
        {
            return _userProfileService.GetUserProfile(2, Convert.ToInt16(pageFrom), Convert.ToInt16(pageTo));
        }

        [HttpPost]
        [Route("api/UserProfile")]
        public HttpStatusCode CreateUserProfile([FromBody] UserProfileViewModel model)
        {
            // ToDo: add "create user view model"
            // ToDo: add service method for "create" user profile;
            
            return HttpStatusCode.Created;
        }

        [HttpPost]
        [Route("api/UserProfile/{userId:int}")]
        public HttpStatusCode UpdateUserProfile([FromUri] int userId, [FromBody] UserProfileViewModel model)
        {     
            _userProfileService.UpdateUserProfile(userId, model);

            return HttpStatusCode.Created;
        }

        [HttpDelete]
        [Route("api/UserProfile/{userId:int}")]
        public HttpStatusCode DeleteUserProfile([FromUri] int id)
        {
            _userProfileService.DeleteUserProfile(id);

            return HttpStatusCode.OK;
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
