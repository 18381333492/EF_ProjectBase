using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiXin.Base.Message.ReceiveModels;
using WeiXin.Tool;

namespace WeiXin.Base.Message
{
    /// <summary>
    /// 处理消息
    /// </summary>
    public class HandleMessage
    {
        /// <summary>
        /// 用于处理消息类
        /// </summary>
        private IBaseAction Action { get; set; }

        public HandleMessage(IBaseAction Action)
        {
            this.Action = Action;
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="xmlcontent"></param>
        /// <returns></returns>
        public string ProcessMessage(MsgType type, string xmlcontent)
        {
            if (null == Action) return string.Empty;

            string sResult = string.Empty;

            switch (type)
            {
                case MsgType.TEXT:                      //文本
                    sResult = Action.HandleText(XmlHelper.XmlToObject<TextMessage>(xmlcontent));
                    break;
                case MsgType.IMAGE:                     //图片
                    sResult = Action.HandleImage(XmlHelper.XmlToObject<ImageMessage>(xmlcontent));
                    break;
                case MsgType.LINK:                      //链接
                    sResult = Action.HandleLink(XmlHelper.XmlToObject<LinkMessage>(xmlcontent));
                    break;
                case MsgType.VOICE:                     //语音
                    sResult = Action.HandleVoice(XmlHelper.XmlToObject<VoiceMessage>(xmlcontent));
                    break;
                case MsgType.SHORTVIDEO:                //小视频
                    sResult = Action.HandleVideo(XmlHelper.XmlToObject<VideoMessage>(xmlcontent));
                    break;
                case MsgType.VIDEO:                     //视频
                    sResult = Action.HandleVideo(XmlHelper.XmlToObject<VideoMessage>(xmlcontent));
                    break;
                case MsgType.LOCATION:                  //位置
                    sResult = Action.HandleLocation(XmlHelper.XmlToObject<LocationMessage>(xmlcontent));
                    break;
            }
            return sResult;
        }




    }
}
