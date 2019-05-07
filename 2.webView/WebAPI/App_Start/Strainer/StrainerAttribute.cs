using DotNet.Utilities;
using RedisCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace WebAPI.App_Start.Strainer
{
    /// <summary>
    /// 过滤器
    /// </summary>
    public class StrainerAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {

        private static RedisStackExchangeHelper _redis = new RedisStackExchangeHelper();
        
        /// <summary>
        /// 是否验证单用户登录
        /// </summary>
        public bool IsCheckUser { get; set; }

        /// <summary>
        /// 每次请求都会进行过滤
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            base.OnActionExecuting(actionContext);

            CheckUserSingle(actionContext, IsCheckUser);
        }


        //单用户登录
        private void CheckUserSingle(HttpActionContext actionContext, bool IsCheckUser)
        {
            if (IsCheckUser == false)
            {
                return;
            }
            else //单用户登录校验
            {

                try
                {
                    //如果是后台管理请求的数据则直接跳过 不做单用户校验
                    var CheckAdminNoUserSingle = actionContext.Request.Headers.GetValues("AdminNoUserSingle");
                    if (CheckAdminNoUserSingle != null)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {

                }

                var httpContext = HttpContext.Current;
                var json = new JSONResult<string>();
                json.Result = "单用户登录";
                json.ret = 3;

                if (actionContext.Request.Headers.Authorization == null)
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage()
                    {
                        Content = new System.Net.Http.StringContent(ConvertJson.ToJson(json)),

                        StatusCode = System.Net.HttpStatusCode.Unauthorized
                    };
                    return;

                }

                var HeadersToken = actionContext.Request.Headers.Authorization.Parameter;
                var token = _redis.HashGet<string>(RedisGroup.SingleUserGroup, HeadersToken);
                if (token == null || token == "" || token == "null")
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage()
                    {
                        Content = new System.Net.Http.StringContent(ConvertJson.ToJson(json)),
                        StatusCode = System.Net.HttpStatusCode.Unauthorized
                    };
                }
            }
        }

    }
}