using System.Web.Http;
using Newtonsoft.Json;
using MemoBll;
using MemoRise.Models;

namespace MemoRise.Controllers
{
    public class SignInController : ApiController
    {
        SignIn signIn = new SignIn(); 
        public string GetUser(string userLoginData)
        {
            UserLoginData loginData = JsonConvert.DeserializeObject<UserLoginData>(userLoginData);
            var user = JsonConvert.SerializeObject(signIn.GetUser(loginData.Login, loginData.Password));
            return user;
        }
    }
}
