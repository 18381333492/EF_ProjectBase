using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFModel;

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
            
            //反射获取用户信息和Ip地址
            string sUserName=services.GetType().GetProperty("sUserName").GetValue(services, null).ToString();
            string sIpAddress=services.GetType().GetProperty("sIpAddress").GetValue(services, null).ToString();

            MethodInfo p = services.GetType().GetMethod(method);
            var log=p.GetCustomAttribute(typeof(LogAttribute)) as LogAttribute;
            string sContent = log.type.ToString()+log.sModuleName;
            
            using (var db=new Entities())
            {
               db.OperateLog.Add(new OperateLog()
                {
                    ID = Guid.NewGuid(),
                    dInsertTime = DateTime.Now,
                    sCity = string.Empty,
                    sUserName = sUserName,
                    sIpAddress = sIpAddress,
                    sContent= sContent
               });
                db.SaveChanges();
            }      
        }



        /// <summary>
        /// 写错误日志
        /// </summary>
        public static void ErrorLog(Exception e)
        {

        }
    }
}
