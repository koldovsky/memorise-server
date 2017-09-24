﻿using MemoBll;
using MemoDTO;
using System.Collections.Generic;
using System.Web.Http;

namespace MemoRise.Controllers
{
    public class UserProfileController : ApiController
    {
        UserProfileBll userProfile = new UserProfileBll();

        [HttpGet]
        [Route("UserProfile/GetCoursesByUser/{userEmaile}")]
        public List<CourseDTO> GetCoursesByUser(string userEmail)
        {
            return userProfile.GetCoursesByUser(userEmail);
        }

        //[HttpGet]
        //[Route("UserProfile/GetCoursesByUser/{userEmaile}")]
        //public List<DeckDTO> GetDecksByUser(string userEmail)
        //{
        //    return userProfile.GetDecksByUser(userEmail);
        //}

        [HttpGet]
        public UserDTO GetUserById(int id)
        {
            return userProfile.GetUser(id);
        }
    }
}