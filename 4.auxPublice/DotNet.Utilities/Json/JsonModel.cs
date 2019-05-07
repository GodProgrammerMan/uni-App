using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Utilities
{
    public class JsonModel
    {
        public JsonModel()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //


            //{"total":0}
            //CommonJsonModel model = new CommonJsonModel(json);
            //model.GetValue("total") // return 0


            //{"total":0,"data":{"377149574" : 1}} 
            //CommonJsonModel model = new CommonJsonModel(json);
            //model.GetModel("data").GetValue("377149574") //return 1


            //{"total":0,"data":{"377149574":[{"cid":"377149574"}]}}
            //CommonJsonModel model = new CommonJsonModel(json);
            //model.GetCollection("377149574").GetCollection()[0].GetValue("cid") //return 377149574
        }

        protected string _GetKey(string rawjson)
        {
            if (string.IsNullOrEmpty(rawjson))
                return rawjson;

            rawjson = rawjson.Trim();

            string[] jsons = rawjson.Split(new char[] { ':' });

            if (jsons.Length < 2)
                return rawjson;

            return jsons[0].Replace("\"", "").Trim();
        }

        protected string _GetValue(string rawjson)
        {
            if (string.IsNullOrEmpty(rawjson))
                return rawjson;

            rawjson = rawjson.Trim();

            string[] jsons = rawjson.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            if (jsons.Length < 2)
                return rawjson;

            StringBuilder builder = new StringBuilder();

            for (int i = 1; i < jsons.Length; i++)
            {
                builder.Append(jsons[i]);

                builder.Append(":");
            }

            if (builder.Length > 0)
                builder.Remove(builder.Length - 1, 1);

            string value = builder.ToString();

            if (value.StartsWith("\""))
                value = value.Substring(1);

            if (value.EndsWith("\""))
                value = value.Substring(0, value.Length - 1);

            return value;
        }

        protected List<string> _GetCollection(string rawjson)
        {
            //[{},{}]

            char c1 = (char)1;
            char c2 = (char)2;
            rawjson = rawjson.Replace("\\\\", c1.ToString()).Replace("\\\"", c2.ToString()).Replace(c1.ToString(), "\\\\");

            List<string> list = new List<string>();

            if (string.IsNullOrEmpty(rawjson))
                return list;

            rawjson = rawjson.Trim();

            StringBuilder builder = new StringBuilder();

            int nestlevel = -1;

            int mnestlevel = -1;

            int dqmlevel = -1;

            bool BeStart = false;
            for (int i = 0; i < rawjson.Length; i++)
            {
                if (i == 0)
                    continue;
                else if (i == rawjson.Length - 1)
                    continue;

                char jsonchar = rawjson[i];

                if (jsonchar == '{')
                {
                    nestlevel++;
                }

                if (jsonchar == '}')
                {
                    nestlevel--;
                }

                if (jsonchar == '[')
                {
                    mnestlevel++;
                }

                if (jsonchar == ']')
                {
                    mnestlevel--;
                }

                if (jsonchar == '"' && !BeStart)
                {
                    BeStart = true;
                    dqmlevel++;
                }
                else if (jsonchar == '"' && BeStart)
                {
                    BeStart = false;
                    dqmlevel--;
                }

                if (jsonchar == ',' && nestlevel == -1 && mnestlevel == -1 && dqmlevel == -1)
                {
                    list.Add(builder.ToString().Replace(c2.ToString(), "\\\""));
                    builder = new StringBuilder();
                }
                else
                {
                    builder.Append(jsonchar);
                }
            }

            if (builder.Length > 0)
                list.Add(builder.ToString().Replace(c2.ToString(), "\\\""));

            return list;
        }
    }
    public class CommonJsonModel : JsonModel
    {
        private string rawjson;

        private bool isValue = false;

        private bool isModel = false;

        private bool isCollection = false;


        /// <summary>
        ///解析JSON，键：GetModel(key) 集合：GetChild(key)[n]  值：GetValue(key)
        /// </summary>
        public CommonJsonModel(string rawjson)
        {
            this.rawjson = rawjson;

            if (string.IsNullOrEmpty(rawjson))
                throw new Exception("missing rawjson");

            rawjson = rawjson.Trim();

            if (rawjson.StartsWith("{"))
            {
                isModel = true;
            }
            else if (rawjson.StartsWith("["))
            {
                isCollection = true;
            }
            else
            {
                isValue = true;
            }
        }

        public string Rawjson
        {
            get { return rawjson; }
        }

        public bool IsValue()
        {
            return isValue;
        }
        public bool IsValue(string key)
        {
            if (!isModel)
                return false;

            if (string.IsNullOrEmpty(key))
                return false;

            foreach (string subjson in base._GetCollection(this.rawjson))
            {
                CommonJsonModel model = new CommonJsonModel(subjson);

                if (!model.IsValue())
                    continue;

                if (model.Key == key)
                {
                    CommonJsonModel submodel = new CommonJsonModel(model.Value);

                    return submodel.IsValue();
                }
            }

            return false;
        }
        public bool IsModel()
        {
            return isModel;
        }
        public bool IsModel(string key)
        {
            if (!isModel)
                return false;

            if (string.IsNullOrEmpty(key))
                return false;

            foreach (string subjson in base._GetCollection(this.rawjson))
            {
                CommonJsonModel model = new CommonJsonModel(subjson);

                if (!model.IsValue())
                    continue;

                if (model.Key == key)
                {
                    CommonJsonModel submodel = new CommonJsonModel(model.Value);

                    return submodel.IsModel();
                }
            }

            return false;
        }
        public bool IsCollection()
        {
            return isCollection;
        }
        public bool IsCollection(string key)
        {
            if (!isModel)
                return false;

            if (string.IsNullOrEmpty(key))
                return false;

            foreach (string subjson in base._GetCollection(this.rawjson))
            {
                CommonJsonModel model = new CommonJsonModel(subjson);

                if (!model.IsValue())
                    continue;

                if (model.Key == key)
                {
                    CommonJsonModel submodel = new CommonJsonModel(model.Value);

                    return submodel.IsCollection();
                }
            }

            return false;
        }


        /// <summary>
        /// 当模型是对象，返回拥有的key
        /// </summary>
        /// <returns></returns>
        public List<string> GetKeys()
        {
            if (!isModel)
                return null;

            List<string> list = new List<string>();

            foreach (string subjson in base._GetCollection(this.rawjson))
            {
                string key = new CommonJsonModel(subjson).Key;

                if (!string.IsNullOrEmpty(key))
                    list.Add(key);
            }

            return list;
        }

        /// <summary>
        /// 当模型是对象，key对应是值，则返回key对应的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            if (!isModel)
                return "";


            if (string.IsNullOrEmpty(key))
                return "";

            foreach (string subjson in base._GetCollection(this.rawjson))
            {
                CommonJsonModel model = new CommonJsonModel(subjson);

                if (!model.IsValue())
                    continue;

                if (model.Key == key)
                    return model.Value;
            }

            return "";

        }

        /// <summary>
        /// 模型是对象，key对应是对象，返回key对应的对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public CommonJsonModel GetModel(string key)
        {
            if (!isModel)
                return null;

            if (string.IsNullOrEmpty(key))
                return null;

            foreach (string subjson in base._GetCollection(this.rawjson))
            {
                CommonJsonModel model = new CommonJsonModel(subjson);

                if (!model.IsValue())
                    continue;

                if (model.Key == key)
                {
                    CommonJsonModel submodel = new CommonJsonModel(model.Value);

                    if (!submodel.IsModel())
                        return null;
                    else
                        return submodel;
                }
            }

            return null;
        }

        /// <summary>
        /// 模型是对象，key对应是集合，返回集合
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public CommonJsonModel GetCollection(string key)
        {
            if (!isModel)
                return null;

            if (string.IsNullOrEmpty(key))
                return null;

            foreach (string subjson in base._GetCollection(this.rawjson))
            {
                CommonJsonModel model = new CommonJsonModel(subjson);

                if (!model.IsValue())
                    continue;

                if (model.Key == key)
                {
                    CommonJsonModel submodel = new CommonJsonModel(model.Value);

                    if (!submodel.IsCollection())
                        return null;
                    else
                        return submodel;
                }
            }

            return null;
        }


        /// <summary>
        /// 模型是集合，返回自身
        /// </summary>
        /// <returns></returns>
        public List<CommonJsonModel> GetCollection()
        {
            List<CommonJsonModel> list = new List<CommonJsonModel>();

            if (IsValue())
                return list;

            foreach (string subjson in base._GetCollection(rawjson))
            {
                list.Add(new CommonJsonModel(subjson));
            }

            return list;
        }


        /// <summary>
        /// 模型是对象，key对应是集合，返回集合
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<CommonJsonModel> GetChild(string key)
        {
            if (!isModel)
                return null;

            if (string.IsNullOrEmpty(key))
                return null;

            foreach (string subjson in base._GetCollection(this.rawjson))
            {
                CommonJsonModel model = new CommonJsonModel(subjson);

                if (!model.IsValue())
                    continue;

                if (model.Key == key)
                {
                    CommonJsonModel submodel = new CommonJsonModel(model.Value);

                    if (!submodel.IsCollection())
                        return null;
                    else
                    {
                        List<CommonJsonModel> list = new List<CommonJsonModel>();

                        if (IsValue())
                            return list;

                        foreach (string subjson2 in base._GetCollection(model.Value))
                        {
                            list.Add(new CommonJsonModel(subjson2));
                        }

                        return list;

                    }

                }
            }

            return null;
        }





        /// <summary>
        /// 当模型是值对象，返回key
        /// </summary>
        private string Key
        {
            get
            {
                if (IsValue())
                    return base._GetKey(rawjson);

                return "";
            }
        }
        /// <summary>
        /// 当模型是值对象，返回value
        /// </summary>
        private string Value
        {
            get
            {
                if (!IsValue())
                    return "";

                return base._GetValue(rawjson);
            }
        }
    }
}
