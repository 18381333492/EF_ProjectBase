using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Base.Message
{

    /// <summary>
    /// 微信消息基础
    /// </summary>
    public class BaseMessage
    {
        public string ToUserName;       //开发者微信号
        public string FromUserName;     //发送方帐号（微信用户的OpenID)
        public string CreateTime;       //发送时间（时间戳）
        public MsgType MsgType;         //发送的消息类型
    }

    /// <summary>
    /// 微信的消息类型
    /// </summary>
    public enum MsgType
    {
        text=1,             //文本

        image=2,           //图像

        voice=3,           //声音

        video=4,           //视频

        shortvideo=5,      //小视屏
            
        location=6,        //位置

        link=7,            //链接

        Event=8            //事件类型

    }
}
