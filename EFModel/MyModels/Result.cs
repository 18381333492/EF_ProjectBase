using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModel.MyModels
{
    public class Result
    {
        /// <summary>
        /// 需要返回的数据
        /// </summary>
        public object data
        {
            get;
            set;
        }

        /// <summary>
        /// 信息描述
        /// </summary>
        public string info
        {
            get { return "操作成功"; }
            set { }
        }

        /// <summary>
        /// 成功标识
        /// </summary>
        public bool success
        {
            get { return false; }
            set { }
        } 


        public string toJson()
        {
            return C_Json.toJson(this);
        }
    }
    
}
