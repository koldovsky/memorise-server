using System.Web.Http;
using Newtonsoft.Json;
using MemoBll;
using MemoDTO;

namespace MemoRise.Controllers
{
    public class SignInController : ApiController
    {
        SignInBll signIn = new SignInBll(); 

        [HttpGet]
        public UserDTO GetUser(string userLoginData)
        {
            UserLoginDTO loginData = JsonConvert.DeserializeObject<UserLoginDTO>(userLoginData);
            return signIn.GetUser(loginData.Login, loginData.Password);
        }
    }
}
