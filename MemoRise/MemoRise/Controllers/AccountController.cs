using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDTO;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Http;

namespace MemoRise.Controllers
{
    public class AccountController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());

        [HttpPost]
        public async Task<IHttpActionResult> SignIn(
            [FromBody] UserLoginDTO registeredUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await unitOfWork.Users.FindByNameAsync(
                      registeredUser.Login);
            if (user != null)
            {
                var result = await unitOfWork.Users.CheckPasswordAsync(user,
                             registeredUser.Password);

                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("The user name or password is incorrect");
                }
            }
           
            return BadRequest("User with such name not found");
         
        }
        [HttpPost]
        public async Task<IHttpActionResult> SignUp(
            [FromBody] UserLoginDTO newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userWithSuchEmail = await unitOfWork.Users.FindByEmailAsync(
                      newUser.Email);
            if (userWithSuchEmail!=null)
            {
                return BadRequest("User with such email already exists");
            }
            UserProfile userProfile = new UserProfile
            {
                IsBlocked = false
            };
            var user = new User()
            {

                UserName = newUser.Login,
                Email = newUser.Email,
                UserProfile = userProfile

            };

            var result = await unitOfWork.Users
                        .CreateAsync(user, newUser.Password);
            if (result.Succeeded)
            {
                result = unitOfWork.Users.AddToRole(user.Id, "Customer");
                return Ok();
            }
            else
            {
                return GetErrorResult(result);
            }

        }
        
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
        //TODO: add pasword confirmation
        //private async Task<bool> sendConfirmationEmailAsync(User user)
        //{

        //    var code = await unitOfWork.Users
        //        .GenerateEmailConfirmationTokenAsync(user.Id);
        //    var callbackUrl = Url.Action("ConfirmEmail", "Account",
        //   new { userId = user.Id, code = code },
        //   protocol: Request.Url.Scheme);

        //    await unitOfWork.Users.SendEmailAsync(
        //        user.Id,
        //        "Confirm your account",
        //        "Please confirm your account by clicking this link: <a href=\""
        //        + callbackUrl + "\">link</a>");

        //}
    }
}
