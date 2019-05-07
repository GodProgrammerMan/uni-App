using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Utilities
{
    public class RedisGroup
    {
        //说明：如果缓存需要分组则在后尾加上:号


        /// <summary>
        /// 秒杀房源 
        /// </summary>
        public static string SecKillHouseGroup = "SecKillHouseGroup";

        /// <summary>
        /// 单用户登录
        /// </summary>
        public static string SingleUserGroup = "UserTokenGroup";

        /// <summary>
        /// 活动信息
        /// </summary>
        public static string OpenActivityDataGroup = "OpenActivityGroup";


    }
}
