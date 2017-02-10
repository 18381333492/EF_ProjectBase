using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using WeiXin.Base.Message;
using WeiXin.Base.Message.ReceiveModels;
using WeiXin.Base.Message.SendModels;

namespace Web.App_Start.WeiXinMessage
{
    public class AutoHandleMessage : IBaseAction
    {
        //需要处理那些消息就重写

        /// <summary>
        /// 处理微信文本消息
        /// </summary>
        /// <returns></returns>
        public override string HandleText(TextMessage message)
        {


            List<item> Articles = new List<item>();
            Articles.Add(new item()
            {
                Title = "测试图文消息1",
                Url = "fdssdfsdf",
                PicUrl = "dsdsad",
            });
            Articles.Add(new item()
            {
                Title = "测试图文消息2",
                Url = "fdssdfsdf",
                PicUrl = "dsdsad",
            });
            return MessageHelper.News(Articles,message);
           // return  MessageHelper.Text("成功了啊", message);

        }




    }
}