using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeiXin.Base.Message
{
    /// <summary>
    /// 微信接收消息基础
    /// </summary>
    public class BaseMessage
    {
        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName;

        /// <summary>
        /// 发送方帐号(微信用户的OpenID)
        /// </summary>
        public string FromUserName;

        /// <summary>
        /// 发送时间(时间戳)
        /// </summary>
        public int CreateTime;

        /// <summary>
        /// 发送的消息类型
        /// </summary>
        public string MsgType;

        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public long MsgId;

    }

    /// <summary>
    /// 微信的消息类型
    /// </summary>
    public enum MsgType
    {
        TEXT=1,             //文本

        IMAGE=2,           //图片

        VOICE=3,           //声音

        VIDEO=4,           //视频

        SHORTVIDEO=5,      //小视屏
            
        LOCATION=6,        //位置

        LINK=7,            //链接

        EVENT=8            //事件类型

    }
}
