using Blog_MainService;
using DotNet.Utilities;
using DotNet.Utilities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static WebAPI.Models.PostModel;

namespace WebAPI.Controllers.BlogMain
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    [System.Web.Http.RoutePrefix("api/UserInfo")]
    public class mb_UserController : ApiController
    {
            /// <summary>
            /// 密码登录 
            /// </summary>
            /// <param name="obj"> </param> 
            /// <returns></returns>
            [Route("CodeUserLogin")]
            [HttpPost]
            public async Task<JSONResult<string>> CodeUserLogin([FromBody]  LoginParameter obj)
            {
                return await Task.Run(() =>
                {
                    return new BaseJsonResult().UnifiedFucn(() =>
                    {
                        var model = new JSONResult<string>();
                        if (obj == null)
                        {
                            model.ret = 1;
                            model.Result = "参数错误，填写参数";
                            model.Content = "登录失败";
                            return model;
                        }
                        if (obj.LoginName == null || obj.LoginName == "")
                        {
                            model.ret = 1;
                            model.Result = "登录名不能为空";
                            model.Content = "登录失败";
                            return model;
                        }
                        if (obj.passWord == null || obj.passWord == "")
                        {
                            model.ret = 1;
                            model.Result = "密码不能为空";
                            model.Content = "登录失败";
                            return model;
                        }
                        var Model =new mb_UserService().GetUserLogin(obj.LoginName);

                        if (Model != null)
                        {
                            string UserKey = Md5.md5(obj.passWord, 32) + Md5.md5(Model.UserKeyStr, 32);
                            if (UserKey.Equals(Model.UserKey))
                            {
                                model.ret = 0;
                                model.Result = "登录成功";
                                model.Content = "登录成功";
                            }
                            else
                            {
                                model.ret = 2;
                                model.Result = "密码错误";
                                model.Content = "登录失败";
                            }
                        }
                        else
                        {
                            model.ret = 5;
                            model.Result = "不存在该用户";
                            model.Content = "登录失败";
                        }
                        return model;
                    });

                });
            }

        /// <summary>
        /// 密码登录 
        /// </summary>
        /// <param name="obj"> </param> 
        /// <returns></returns>
        [Route("index")]
        [HttpGet]
        public async Task<JSONResult<string>> CodeUserLogin()
        {
            return await Task.Run(() =>
            {
                return new BaseJsonResult().UnifiedFucn(() =>
                {
                    var model = new JSONResult<string>();

                    var Model = new mb_UserService().GetUserLogin("lrb");

                    model.Result = Model.CheckTime+Model.UserName+Model.QQ;

                    return model;
                });

            });
        }
    }
}
