using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DotNet.Utilities
{
    /// <summary>
    /// 基础类JSON返回序列化类
    /// </summary>
    public class BaseJsonResult
    {
        /// <summary>
        /// 统一的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public JSONResult<T> UnifiedFucn<T>(Func<JSONResult<T>> func)
        {
            var model = new JSONResult<T>();
            try
            {
                var RetFunc = func();
                return RetFunc;
            }
            catch (Exception ex)
            {
                model.Result = "读取失败:" + ex.Message;
                model.ret = 3;
                model.Success = false;
            }
            return model;

        }

    }
}