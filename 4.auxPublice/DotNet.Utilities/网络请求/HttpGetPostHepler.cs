using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace DotNet.Utilities
{
    public class HttpGetPostHepler
    {

        // GetLastUrl方法用于根据基准URL和查询参数字典获取最终URL
        //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));这句代码表示希望服务返回Json字符串。
        //content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); 表示以Json格式传递实体内容。

        /// <summary>
        /// 生成最终URL
        /// </summary>
        /// <param name="baseUrl">基准URL（不含查询串）</param>
        /// <param name="dictParam">查询参数字典</param>
        /// <returns>最终URL</returns>
        private static string GetLastUrl(string baseUrl, Dictionary<string, string> dictParam)
        {
            var sbUrl = new StringBuilder(baseUrl);
            if (dictParam != null && dictParam.Count > 0)
            {
                sbUrl.Append("?");
                int index = 0;
                foreach (var item in dictParam)
                {
                    sbUrl.Append(string.Format("{0}={1}", item.Key,
                        HttpUtility.UrlEncode(item.Value, Encoding.UTF8)));
                    if (index < dictParam.Count - 1)
                    {
                        sbUrl.Append("&");
                    }
                    index++;
                }
            }
            var url = sbUrl.ToString();
            return url;
        }

        /// <summary>
        /// GET方式调用Web Api
        /// </summary>
        /// <param name="baseUrl">基准URL（不含查询串）</param>
        /// <param name="dictParam">查询参数字典</param>
        /// <param name="result">返回数据（Json格式）</param>
        /// <param name="errMsg">出错信息</param>
        /// <param name="code">返回状态码</param>
        /// <param name="CookieName">cookie名称</param>
        /// <returns>成功与否</returns>
        public static bool Get(string baseUrl, Dictionary<string, string> dictParam,
            out string result, out string errMsg, out HttpStatusCode code, string CookieName)
        {
            errMsg = string.Empty;
            result = string.Empty;
            try
            {
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem();
                var url = "";
                if (dictParam == null)
                    url = GetLastUrl(baseUrl, new Dictionary<string, string>());
                else
                    url = GetLastUrl(baseUrl, dictParam);
                var AuthorizationValue = "";
                AuthorizationValue = Utils.GetCookie(CookieName);
                item.URL = url;
                item.Method = "GET";
                item.ContentType = "application/json";//返回类型    可选项有默认值   
                if (AuthorizationValue != null && AuthorizationValue != "null" && AuthorizationValue != "")
                {
                    //发送头部身份验证请求 
                    item.Header.Add("Authorization", "Bearer " + AuthorizationValue);

                }
                if (CookieName == BaseGlobalParameter.defUinfoAdminCookie)  //如果是后台发送的
                    item.Header.Add("AdminNoUserSingle", "true");
                HttpResult GetData = http.GetHtml(item);
                if (GetData.StatusCode == HttpStatusCode.OK)
                {
                    result = GetData.Html;
                    errMsg = "";
                    code = GetData.StatusCode;
                    return true;
                }

                if (GetData.StatusCode == HttpStatusCode.Unauthorized || GetData.StatusCode == HttpStatusCode.Forbidden)
                {
                    errMsg = "该用户未授权";
                    code = GetData.StatusCode;
                    return false;
                }

                code = GetData.StatusCode;
                return false;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                code = HttpStatusCode.InternalServerError;
                return false;
            }

        }

        /// <summary>
        /// POST方式调用Web Api
        /// </summary>
        /// <param name="baseUrl">基准URL（不含查询串）</param>
        /// <param name="dictParam">查询参数字典</param>
        /// <param name="parseData">传递实体数据（Json格式）</param>
        /// <param name="result">返回数据（Json格式）</param>
        /// <param name="errMsg">出错信息</param>
        /// <param name="code">返回状态码</param>
        /// <param name="CookieName">cookie名称</param>
        /// <returns>成功与否</returns>
        public static bool Post(string baseUrl, Dictionary<string, string> dictParam,
            out string result, out string errMsg, out HttpStatusCode code, string CookieName)
        {
            errMsg = string.Empty;
            result = string.Empty;
            try
            {

                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem();
                var strjson = "";
                if (dictParam == null)
                    strjson = "";
                else
                    strjson = SerializeDictionaryToJsonString(dictParam);   //请求参数

                var AuthorizationValue = "";
                AuthorizationValue = Utils.GetCookie(CookieName);
                item.URL = baseUrl;
                item.Method = "POST";
                if (strjson == "")
                    item.Postdata = "{}";
                else
                    item.Postdata = strjson;
                item.PostDataType = PostDataType.String;
                item.PostEncoding = System.Text.Encoding.UTF8;

                item.ContentType = "application/json";//返回类型    可选项有默认值   
                if (AuthorizationValue != null && AuthorizationValue != "null" && AuthorizationValue != "")
                {//发送头部身份验证请求 
                    item.Header.Add("Authorization", "Bearer " + AuthorizationValue);

                }
                if (CookieName == BaseGlobalParameter.defUinfoAdminCookie)  //如果是后台发送的
                    item.Header.Add("AdminNoUserSingle", "true");
                HttpResult GetData = http.GetHtml(item);
                if (GetData.StatusCode == HttpStatusCode.OK)
                {
                    result = GetData.Html;
                    errMsg = "";
                    code = GetData.StatusCode;
                    return true;
                }

                if (GetData.StatusCode == HttpStatusCode.Unauthorized || GetData.StatusCode == HttpStatusCode.Forbidden)
                {
                    errMsg = "该用户未授权";
                    code = GetData.StatusCode;
                    return false;
                }

                code = GetData.StatusCode;
                return false;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                code = HttpStatusCode.InternalServerError;
                return false;
            }
        }

        /// <summary>
        /// 将字典类型序列化为json字符串
        /// </summary>
        /// <typeparam name="TKey">字典key</typeparam>
        /// <typeparam name="TValue">字典value</typeparam>
        /// <param name="dict">要序列化的字典数据</param>
        /// <returns>json字符串</returns>
        public static string SerializeDictionaryToJsonString<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            if (dict.Count == 0)
                return "";

            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dict);
            return jsonStr;
        }
    }
}
