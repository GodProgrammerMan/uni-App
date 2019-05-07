using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Utilities
{
    class NtsJsonHelpercs : IJsonHelper
    {
        public T Deserialize<T>(string json) where T : class
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            JsonReader reader = new JsonTextReader(new StringReader(json));
            return jsonSerializer.Deserialize<T>(reader);
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
