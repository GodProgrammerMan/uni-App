using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{

    /// <summary>
    /// 取服务器时间
    /// </summary>
    [System.Web.Http.RoutePrefix("api/ServerTimes")]
    public class ServerTimesController : ApiController
    { 

        /// <summary>
        /// 取服务器时间
        /// </summary>
        /// <returns></returns>
        // GET: ServerTimes

        [System.Web.Http.Route("Index")]
        [System.Web.Http.HttpGet]
        public string Index()
        {
            //DateTime date = System.DateTime.Now;
            //return TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(System.DateTime.Now.ToString())).TotalMilliseconds();

            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }
        public string ConvertDateTimeInt()
        {
            double intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            intResult = (System.DateTime.Now - startTime).TotalMilliseconds;
            long t = (System.DateTime.Now.Ticks - startTime.Ticks) / 10000;            //除10000调整为13位
            return t.ToString();
        }
    }
}