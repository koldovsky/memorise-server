using System.Web.Http;
using Newtonsoft.Json;
using MemoBll;
using MemoRise.Models;

namespace MemoRise.Controllers
{
    public class SignUpController : ApiController
    {
        SignUp signUp = new SignUp();
        public string CreateUser(string userSignUpData)
        {
            UserLoginData signUpData = JsonConvert.DeserializeObject<UserLoginData>(userSignUpData);
            bool IsAccepted=signUp.CreateUser(signUpData.Login, signUpData.Password, signUpData.Email);
            return IsAccepted.ToString();
        }
    }
}
