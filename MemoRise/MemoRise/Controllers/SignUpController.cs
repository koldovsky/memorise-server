using System.Web.Http;
using Newtonsoft.Json;
using MemoBll;
using MemoDTO;

namespace MemoRise.Controllers
{
    public class SignUpController : ApiController
    {
        SignUpBll signUp = new SignUpBll();

        // TODO: return normal UserDTO
        [HttpPost]
        public UserDTO CreateUser(string userSignUpData)
        {
            UserLoginDTO signUpData = JsonConvert.DeserializeObject<UserLoginDTO>(userSignUpData);
            bool IsAccepted=signUp.CreateUser(signUpData.Login, signUpData.Password, signUpData.Email);
            return new UserDTO { Email = signUpData.Email };
        }
    }
}
