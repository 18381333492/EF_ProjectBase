using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiXin.Base.Message;

namespace Web.App_Start.WeiXinMessage
{
    public class AutoHandleMessage : IBaseAction
    {
        //需要处理那些消息就重写

        /// <summary>
        /// 处理微信文本消息
        /// </summary>
        /// <returns></returns>
        public override string HandleText()
        {
            return string.Empty;
        }
    }
}