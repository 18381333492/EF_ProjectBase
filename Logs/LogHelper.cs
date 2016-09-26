using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logs
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 写操作日志
        /// </summary>
        /// <param name="method">方法名</param>
        /// <param name="parameter">参数</param>
        public static void OperateLog(object services,string method)
        {
            MethodInfo p = services.GetType().GetMethod(method);
            var log=p.GetCustomAttribute(typeof(LogAttribute)) as LogAttribute;
        }



        /// <summary>
        /// 写错误日志
        /// </summary>
        public static void ErrorLog(Exception e)
        {

        }
    }
}
