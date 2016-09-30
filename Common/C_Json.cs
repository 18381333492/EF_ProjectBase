using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Common
{
    public class C_Json
    {

        /// <summary>
        /// json序列化为字符串
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static string toJson(object m)
        {
            try
            {
                return JsonConvert.SerializeObject(m);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static JArray Parse(string sJson)
        {
            return JsonConvert.DeserializeObject(sJson) as JArray;
        }

        /// <summary>
        /// 根据传来的字典组装json数据 
        /// </summary>
        /// <param name="collect"></param>
        /// <returns></returns>
        public static string JsonString(Dictionary<string,object> collect)
        {
            JObject job = new JObject();
            foreach(var prop in collect)
            {
                job.Add(new JProperty(prop.Key, prop.Value));
            }
            return job.ToString();
        }
    }
}
