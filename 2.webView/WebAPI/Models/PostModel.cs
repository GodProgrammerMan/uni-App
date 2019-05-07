using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// Post参数
    /// </summary>
    public class PostModel
    {
        #region 用户post参数
        /// <summary>
        /// 密码登录
        /// </summary>
        public class LoginParameter
        {
            /// <summary>
            /// 登录名
            /// </summary>
            public string LoginName { get; set; }

            /// <summary>
            /// 登录密码
            /// </summary>
            public string passWord { get; set; }
        }
        #endregion
    }
}