using System.Web.Http;
using Newtonsoft.Json;
using MemoBll;
using MemoDTO;

namespace MemoRise.Controllers
{
    public class SignInController : ApiController
    {
        SignInBll signIn = new SignInBll(); 
        public string GetUser(string userLoginData)
        {
            UserLoginDTO loginData = JsonConvert.DeserializeObject<UserLoginDTO>(userLoginData);
            var user = JsonConvert.SerializeObject(signIn.GetUser(loginData.Login, loginData.Password));
            return user;
        }
    }
}
