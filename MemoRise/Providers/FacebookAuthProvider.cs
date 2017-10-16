using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.Facebook;
using Claim = System.Security.Claims.Claim;

namespace MemoRise.Providers
{
    public class FacebookAuthProvider : IFacebookAuthenticationProvider
    {
        public Task Authenticated(FacebookAuthenticatedContext context)
        {
            context.Identity.AddClaim(new Claim("ExternalAccessToken", context.AccessToken));
            return Task.FromResult<object>(null);
        }

        public Task ReturnEndpoint(FacebookReturnEndpointContext context)
        {
            return Task.FromResult<object>(null);
        }

        public void ApplyRedirect(FacebookApplyRedirectContext context)
        {
            context.Response.Redirect(context.RedirectUri);
        }
    }
}