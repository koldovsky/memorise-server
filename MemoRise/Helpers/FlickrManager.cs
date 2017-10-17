using System;
using System.Configuration;
using System.Web;
using FlickrNet;

namespace MemoRise.Helpers
{
    public class FlickrManager
    {
        public static OAuthAccessToken OAuthToken
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["OAuthToken"] == null)
                {
                    return null;
                }

                var values = HttpContext.Current.Request.Cookies["OAuthToken"].Values;
                return new OAuthAccessToken
                {
                    FullName = values["FullName"],
                    Token = values["Token"],
                    TokenSecret = values["TokenSecret"],
                    UserId = values["UserId"],
                    Username = values["Username"]
                };
            }

            set
            {
                // Stores the authentication token in a cookie which will expire in 1 hour
                var cookie = new HttpCookie("OAuthToken")
                {
                    Expires = DateTime.UtcNow.AddHours(1),
                };
                cookie.Values["FullName"] = value.FullName;
                cookie.Values["Token"] = value.Token;
                cookie.Values["TokenSecret"] = value.TokenSecret;
                cookie.Values["UserId"] = value.UserId;
                cookie.Values["Username"] = value.Username;
                HttpContext.Current.Response.AppendCookie(cookie);
            }
        }

        public static Flickr GetInstance()
        {
            var apiKey = ConfigurationManager.AppSettings["flickrApi"];
            var sharedSecret = ConfigurationManager.AppSettings["flickrSharedSecret"];
            return new Flickr(apiKey, sharedSecret);
        }

        public static Flickr GetAuthInstance()
        {
            var apiKey = ConfigurationManager.AppSettings["flickrApi"];
            var sharedSecret = ConfigurationManager.AppSettings["flickrSharedSecret"];
            var f = new Flickr(apiKey, sharedSecret);
            if (OAuthToken != null)
            {
                f.OAuthAccessToken = OAuthToken.Token;
                f.OAuthAccessTokenSecret = OAuthToken.TokenSecret;
            }

            return f;
        }
    }
}