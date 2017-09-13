using MemoBll;
using MemoDTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;

namespace MemoRise.Controllers
{
    public class UserProfileController : ApiController
    {
        UserProfileBll userProfile = new UserProfileBll();

        [HttpGet]
        public List<CourseDTO> GetCoursesByUser(string userEmail)
        {
            return userProfile.GetCoursesByUser(userEmail);
        }

        [HttpGet]
        public List<DeckDTO> GetDecksByUser(string userEmail)
        {
            return userProfile.GetDecksByUser(userEmail);
        }

        //[HttpGet]
        //public UserDTO GetUserById(int id)
        //{
        //    return userProfile.GetDecksByUser(userEmail);
        //}
    }
}
