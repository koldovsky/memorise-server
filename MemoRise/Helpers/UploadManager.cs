using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using System.Configuration;

namespace MemoRise.Helpers
{
    public class UploadManager
    {
        public static ImageEndpoint GetInstance()
        {
            var clientId = ConfigurationManager.AppSettings["clientId"];
            var clientSecret = ConfigurationManager.AppSettings["clientSecret"];
            return new ImageEndpoint(new ImgurClient(clientId, clientSecret));
        }
    }
}