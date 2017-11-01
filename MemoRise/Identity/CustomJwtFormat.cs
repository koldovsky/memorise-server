using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Configuration;
using System.IdentityModel.Tokens;
using Thinktecture.IdentityModel.Tokens;

namespace MemoRise.Identity
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private static readonly byte[] SECRETKEY = TextEncodings.Base64Url
                     .Decode(ConfigurationManager.AppSettings["secret"]);

        private readonly string issuerName;

        public CustomJwtFormat(string issuer)
        {
            issuerName = issuer;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var signingKey = new HmacSigningCredentials(SECRETKEY);
            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;

            return new JwtSecurityTokenHandler().WriteToken(
                   new JwtSecurityToken(
                       issuerName,
                       "Any",
                       data.Identity.Claims,
                   issued.Value.UtcDateTime,
                   expires.Value.UtcDateTime,
                   signingKey));
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}