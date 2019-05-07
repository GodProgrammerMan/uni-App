using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebAPI.App_Start.Authorization
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {

            base.OnAuthorization(actionContext);

        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var httpContext = HttpContext.Current;
            if (httpContext == null)
            {
                base.HandleUnauthorizedRequest(actionContext);
                return;
            }

            actionContext.Response = new HttpResponseMessage()
            {
                StatusCode = httpContext.User.Identity.IsAuthenticated == false
                                    ? System.Net.HttpStatusCode.Unauthorized
                                    : System.Net.HttpStatusCode.Forbidden,
            };
        }
    }
}