using System;
using MemoBll.Managers;
using MemoDTO;
using System.Web.Http;
using MemoBll.ManagersInterfaces;

namespace MemoRise.Controllers
{
    public class UserProfileController : ApiController
    {
        private IUserProfileBll userProfile;

        public UserProfileController()
        {
            userProfile = new UserProfileBll();
        }

        public UserProfileController(IUserProfileBll userProfile)
        {
            this.userProfile = userProfile;
        }

        [HttpGet]
        [Authorize]
        [Route("UserProfile/GetUserByLogin/{userLogin}")]
        public IHttpActionResult GetUserByLogin(string userLogin)
        {
            try
            {
                return Ok(userProfile.GetUserByLogin(userLogin));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("UserProfile/GetUserById/{userId}")]
        public IHttpActionResult GetUserById(string userId)
        {
            try
            {
                return Ok(userProfile.GetUserById(userId));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("UserProfile/GetUserByEmail/{userEmail}")]
        public IHttpActionResult GetUserByEmail(string userEmail)
        {
            try
            {
                return Ok(userProfile.GetUserByEmail(userEmail));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("UserProfile/GetCoursesByUser/{userLogin}")]
        public IHttpActionResult GetCoursesByUser(string userLogin)
        {
            try
            {
                return Ok(userProfile.GetCoursesByUser(userLogin));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("UserProfile/GetDecksByUser/{userLogin}")]
        public IHttpActionResult GetDecksByUser(string userLogin)
        {
            try
            {
                return Ok(userProfile.GetDecksByUser(userLogin));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult UpdateUserById(UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(userProfile.UpdateUserById(user));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult UpdateUserProfileById(UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(userProfile.UpdateUserProfileById(user));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult UpdateUserByLogin(IdentityUpdateDTO identityUpdate)
        {
            if (identityUpdate == null)
            {
                return BadRequest("Object has null value!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(userProfile.UpdateUserByLogin(
                    identityUpdate.ExistingLogin,
                    identityUpdate.NewUserData));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
