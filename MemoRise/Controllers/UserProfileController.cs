using System;
using MemoBll;
using MemoBll.Managers;
using MemoDTO;
using System.Collections.Generic;
using System.Web.Http;

namespace MemoRise.Controllers
{
    public class UserProfileController : ApiController
    {
        UserProfileBll userProfile = new UserProfileBll();

        [HttpGet]
        //[Authorize(Roles = "Customer")]
        [Route("UserProfile/GetUserByLogin/{userLogin}")]
        public IHttpActionResult GetUserByLogin(string userLogin)
        {
            try
            {
                return Ok(userProfile.GetUserByLogin(userLogin));
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Could not find such user.";
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //[Route("UserProfile/GetCoursesByUser/{userEmail}")]
        //public List<CourseDTO> GetCoursesByUser(string userEmail)
        //{
        //    return userProfile.GetCoursesByUser(userEmail);
        //}

        //[HttpGet]
        //[Route("UserProfile/GetCoursesByUser/{userEmaile}")]
        //public List<DeckDTO> GetDecksByUser(string userEmail)
        //{
        //    return userProfile.GetDecksByUser(userEmail);
        //}
    }
}
