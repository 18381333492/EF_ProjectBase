using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Common
{
    /// <summary>
    /// 配置文件的相关操作的封装
    /// </summary>
    public class C_Config
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="ConnStrinName"></param>
        /// <returns></returns>
        public static string ReadConnString(string ConnStrinName)
        {
            string result = string.Empty;
            try
            {
                ConnectionStringSettings cConstrset = ConfigurationManager.ConnectionStrings[ConnStrinName];
                result = cConstrset.ConnectionString;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
    }
}
