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

        // ToDo: create method for user profile

        [HttpGet]
        [Route("api/UserProfile/")]
        public UserProfileViewModel UserProfile([FromUri] string pageFrom, [FromUri] string pageTo)
        {
            return _userProfileService.GetUserProfile(2, Convert.ToInt16(pageFrom), Convert.ToInt16(pageTo));
        }

        [HttpPost]
        [Route("api/UserProfile/{userId:int}")] // ToDo: pass variables in body
        public HttpStatusCode UpdateUserProfile([FromUri] int userId, [FromBody] UserProfileViewModel model)
        { 
            // ToDo: allow option to soft delete            
            _userProfileService.UpdateUserProfile(userId, model);

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
