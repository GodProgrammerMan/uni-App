using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotNet.Utilities
{
    /// <summary>
    /// 使用方法
    /// [JsonConverter(typeof(IsoDateTimeConverter))]
    /// public DateTime Birthday { get; set; }
    /// </summary>
    public class ChinaDateTimeConverter : DateTimeConverterBase
    {
        public static IsoDateTimeConverter dtConverter =
            new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return dtConverter.ReadJson(reader, objectType, existingValue, serializer);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            dtConverter.WriteJson(writer, value, serializer);
        }
    }

}
