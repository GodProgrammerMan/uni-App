using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Utilities
{
    public class BaseHttpGetPostHepler
    {
        /// <summary>
        /// 统一的GET方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public JSONResult<T> UnifiedFucnGet<T>(string BaseURL, Dictionary<string, string> param,
            out System.Net.HttpStatusCode StatusCode, string CookieName = "")
        {
            var model = new JSONResult<T>();
            var msgresult = "";
            var errmsg = "";
            var code = new System.Net.HttpStatusCode();
            try
            {
                if (CookieName == "")
                    CookieName = BaseGlobalParameter.defUinfoCookie;
                var isSucceed = HttpGetPostHepler.Get(BaseURL, param, out msgresult, out errmsg, out code, CookieName);
                if (isSucceed == true)
                {
                    var res = Newtonsoft.Json.JsonConvert.DeserializeObject
                  <JSONResult<T>>(msgresult);
                    StatusCode = code;
                    return res;
                }
            }
            catch (Exception ex)
            {
                if (errmsg != "")
                    model.Result = ex.Message;
                else
                    model.Result = "读取失败:" + ex.Message;
                model.ret = 4;
                model.Success = false;
            }
            StatusCode = code;
            model.Result = errmsg;
            model.Success = false;
            model.ret = 3;
            return model;

        }


        /// <summary>
        /// 统一的POST方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public JSONResult<T> UnifiedFucnPost<T>(string BaseURL, Dictionary<string, string> parseData
            , out System.Net.HttpStatusCode StatusCode, string CookieName = "")
        {
            var model = new JSONResult<T>();
            var msgresult = "";
            var errmsg = "";
            var code = new System.Net.HttpStatusCode();
            try
            {
                if (CookieName == "")
                    CookieName = BaseGlobalParameter.defUinfoCookie;
                var isSucceed = HttpGetPostHepler.Post(BaseURL, parseData, out msgresult, out errmsg, out code, CookieName);
                if (isSucceed == true)
                {
                    var res = Newtonsoft.Json.JsonConvert.DeserializeObject
                   <JSONResult<T>>(msgresult);
                    StatusCode = code;
                    return res;

                }
            }
            catch (Exception ex)
            {
                if (errmsg != "")
                    model.Result = ex.Message;
                else
                    model.Result = "读取失败:" + ex.Message;
                model.ret = 4;
                model.Success = false;
            }
            StatusCode = code;
            model.Result = errmsg;
            model.Success = false;
            model.ret = 3;
            return model;

        }




        /// <summary>
        /// 统一的Get方法---返回json格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public string UnifiedFucnGet_Json(string BaseURL, Dictionary<string, string> parseData
            , out System.Net.HttpStatusCode StatusCode)
        {
            var msgresult = "";
            var errmsg = "";
            var code = new System.Net.HttpStatusCode();
            try
            {
                var isSucceed = HttpGetPostHepler.Get(BaseURL, parseData, out msgresult, out errmsg, out code, "");

                StatusCode = code;
            }
            catch (Exception ex)
            {
                StatusCode = code;
                return "出错了:" + ex.Message + "   json:error" + errmsg + "";
            }

            StatusCode = code;
            return msgresult;
        }

        /// <summary>
        /// 统一的POST方法---返回json格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public string UnifiedFucnPost_Json(string BaseURL, Dictionary<string, string> parseData
            , out System.Net.HttpStatusCode StatusCode)
        {
            var msgresult = "";
            var errmsg = "";
            var code = new System.Net.HttpStatusCode();
            try
            {
                var isSucceed = HttpGetPostHepler.Post(BaseURL, parseData, out msgresult, out errmsg, out code, "");

                StatusCode = code;
            }
            catch (Exception ex)
            {
                StatusCode = code;
                return "出错了:" + ex.Message + "   json:error" + errmsg + "";
            }

            StatusCode = code;
            return msgresult;
        }



    }
}
