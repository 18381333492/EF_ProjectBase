using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

    /// <summary>
    /// C# 基本数据类型的扩展
    /// </summary>
    public static class C_Convert
    {

        /// <summary>
        /// 将Object类型转化为Int16
        /// </summary>
        /// <param name="s"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static short toInt16(this object s, short result = 0)
        {
            Int16.TryParse(s.ToString(), out result);
            return result;
        }

        /// <summary>
        /// 将Object类型转化为Int32
        /// </summary>
        /// <param name="s"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static int toInt32(this object s,int result=0)
        {
            Int32.TryParse(s.ToString(), out result);
            return result;
        }

        /// <summary>
        /// 将Object类型转化为Int32
        /// </summary>
        /// <param name="s"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static long toInt64(this object s, long result = 0)
        {
            Int64.TryParse(s.ToString(), out result);
            return result;
        }

        public static bool toBoolean(this object s,bool result=false)
        {
            Boolean.TryParse(s.ToString(), out result);
            return result;
        }
    }
}
