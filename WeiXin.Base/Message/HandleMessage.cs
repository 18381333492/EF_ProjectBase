using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                case MsgType.text:
                    sResult = Action.HandleText();
                    break;
                case MsgType.image:
                    sResult = Action.HandleImage();
                    break;
                case MsgType.link:
                    sResult = Action.HandleLink();
                    break;
                case MsgType.voice:
                    sResult = Action.HandleVoice();
                    break;
                case MsgType.shortvideo:
                    sResult = Action.HandleVideo();
                    break;
                case MsgType.video:
                    sResult = Action.HandleVideo();
                    break;
                case MsgType.location:
                    sResult = Action.HandleLocation();
                    break;
            }
            return sResult;
        }
    }
}
