using MemoBll;
using Newtonsoft.Json;
using System.Web.Http;

namespace MemoRise.Controllers
{
    public class UserProfileController : ApiController
    {
        UserProfileBll userProfile = new UserProfileBll();

        public string GetCoursesByUser(string userEmail)
        {
            return JsonConvert.SerializeObject(userProfile.GetCoursesByUser(userEmail));
        }
        public string GetDecksByUser(string userEmail)
        {
            return JsonConvert.SerializeObject(userProfile.GetDecksByUser(userEmail));
        }
    }
}
