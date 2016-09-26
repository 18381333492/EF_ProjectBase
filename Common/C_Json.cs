using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
    }
}
