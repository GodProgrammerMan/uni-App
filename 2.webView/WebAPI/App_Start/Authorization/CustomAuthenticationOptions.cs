using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;

namespace WebAPI.App_Start.Authorization
{
    public class CustomAuthenticationOptions
    {
        private static OAuthBearerAuthenticationOptions _bearerOAuthOptions = new OAuthBearerAuthenticationOptions();
        public static OAuthBearerAuthenticationOptions BearerOAuthOptions => _bearerOAuthOptions;

        public string GenerateAuthorization(UsersLoginInfo loginInfo, TimeSpan expiresTimeSpan)
        {
            if (string.IsNullOrWhiteSpace(loginInfo?.UID) ||
                string.IsNullOrWhiteSpace(loginInfo?.Guid))
            {
                return null;
            }

            ClaimsIdentity Identity = new ClaimsIdentity("Bearer");
            Identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, loginInfo.UID));//uid
            Identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", loginInfo.UID));//uid
            Identity.AddClaim(new Claim(ClaimTypes.Name, loginInfo.Guid));
            Identity.AddClaim(new Claim("OrganizationID", loginInfo.UID));

            var ticket = new AuthenticationTicket(Identity, new AuthenticationProperties());
            var currentUtc = DateTime.Now;
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.Add(expiresTimeSpan);
            return BearerOAuthOptions.AccessTokenFormat.Protect(ticket);

        }

        /// <summary>
        /// 登录成功后,传入uid，userName生成token
        /// </summary>
        /// <returns></returns>
        public string GenerateAuthorization(UsersLoginInfo loginInfo)
        {   //默认授权验证时间是一天时间   TimeSpan.FromHours(24)
            return GenerateAuthorization(loginInfo, TimeSpan.FromHours(24));
        }
    }

    public class UsersLoginInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// guid
        /// </summary>
        public string Guid { get; set; }
    }
}
public static class ExtensionsClaimsIdentity
{

    public static string OrganizationID(this ClaimsIdentity value)
    {

        var claim = value.FindFirst("OrganizationId");
        return (claim != null) ? claim.Value : string.Empty;

    }

}
