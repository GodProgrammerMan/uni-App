using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Utilities
{
    /// <summary>
    /// 获取统一域名、cookei 
    /// </summary>
    public class BaseGlobalParameter
    {
        /// <summary>
        /// 域名
        /// </summary>
        public static string Url = "http://localhost:30668/";//http://room.api.zp365.com/   //http://localhost:30668/
        /// <summary>
        ///  //存储在前端cookei 里的token信息
        /// </summary>
        public static string defUinfoCookie = "_ufs";
        /// <summary>
        ///  //存储在后台cookei 里的token信息
        /// </summary>
        public static string defUinfoAdminCookie = "_ufsadmin";

        /// <summary>
        ///  //存储在系统cookei 里的token信息
        /// </summary>
        public static string defUinfoSysCookie = "_ufsSys";
    }
}
