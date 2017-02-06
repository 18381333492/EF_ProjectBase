using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Base.Message
{
    /// <summary>
    /// 消息接口
    /// </summary>
    public abstract class IBaseAction
    {

        public virtual string HandleText()
        {
            return string.Empty;
        }

        public virtual string HandleImage()
        {
            return string.Empty;
        }

        public virtual string HandleLink()
        {
            return string.Empty;
        }

        public virtual string HandleLocation()
        {
            return string.Empty;
        }

     
        public virtual string HandleVideo()
        {
            return string.Empty;
        }

        public virtual string HandleVoice()
        {
            return string.Empty;
        }

        ///// <summary>
        ///// 关注时触发
        ///// </summary>
        ///// <param name="eventdata"></param>
        ///// <returns></returns>
        //public string HandleSubscribeEvent(WeiXin.Base.Receive.Event.SubscribeEvent eventdata)
        //{
        //    #region 关注时 触发
        //    string sResult = string.Empty;
        //    try
        //    {
        //        string fromUserName = eventdata.FromUserName.Text;              //openid
        //        string toUserName = eventdata.ToUserName.Text;                  //原始id
        //        string eventKey = eventdata.
        //                            EventKey.
        //                            Text.
        //                            Replace("qrscene_", string.Empty);          //通过二维码扫码关注 获得的

        //        sResult = WeiXinTool.BuildAttentionAutoReply(fromUserName, toUserName, eventKey);

        //    }
        //    catch (Exception ex)
        //    {
        //        SystemLog.Logs.GetLog().WriteErrorLog(ex);
        //    }
        //    return sResult;
        //    #endregion
        //}

        ///// <summary>
        ///// 取消关注
        ///// </summary>
        ///// <param name="eventdata"></param>
        ///// <returns></returns>
        //public string HandleUnSubscribeEvent(WeiXin.Base.Receive.Event.UnSubscribeEvent eventdata)
        //{
        //    #region 取消关注
        //    string sResult = string.Empty;
        //    return sResult;
        //    #endregion
        //}

        //public string HandleViewClick(WeiXin.Base.Receive.Event.ViewClick eventdata)
        //{
        //    return string.Empty;
        //}

        ///// <summary>
        ///// 模板消息发送结果
        ///// </summary>
        ///// <param name="eventdata"></param>
        ///// <returns></returns>
        //public string HandleTemplateMessageStatus(WeiXin.Base.Send.Template.Message.TemplateMessageStatusEvent eventdata)
        //{
        //    #region 模板消息发送结果
        //    string sResult = string.Empty;
        //    return sResult;
        //    #endregion
        //}
    }
}
