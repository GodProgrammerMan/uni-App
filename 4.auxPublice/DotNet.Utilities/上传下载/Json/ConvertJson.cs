using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Data.Common;
using Newtonsoft.Json;

namespace DotNet.Utilities
{
    //JSON转换类
    public class ConvertJson
    {
         

        #region Obj转换为Json

        public static string ToJson(object jsonObject)
        {
            return  JsonConvert.SerializeObject(jsonObject);
        }
     
        #endregion


        #region JSON转换为obj

        public static object JsonToobj(string json )
        {
            return JsonConvert.DeserializeObject(json);
        }

        public static object JsonToobj<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        #endregion

    }
}