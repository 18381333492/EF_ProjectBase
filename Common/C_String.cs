using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class C_String
    {

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = Encoding.UTF8.GetBytes(str);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < md5data.Length; i++)
            {
                sBuilder.Append(md5data[i].ToString("X2"));
            }
            return sBuilder.ToString();
        }


        public static string NoHtml()
        {
            return null;
        }
    }
}
