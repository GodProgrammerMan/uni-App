using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Utilities
{
    /// <summary>
    /// JSON帮助类
    /// </summary>
    public class JsonHelper
    {
        private IJsonHelper jsonHelper = new NtsJsonHelpercs();

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Serialize(object obj)
        {
            return jsonHelper.Serialize(obj);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T Deserialize<T>(string json) where T : class
        {
            return jsonHelper.Deserialize<T>(json);
        }
    }
}
