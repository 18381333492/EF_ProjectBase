using Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.App_Start;

namespace Web.Areas.Mobile.Controllers
{
    /// <summary>
    /// 支付相关
    /// </summary>
    public class PayController : MobileBaseController<OrdersService>
    {
        //
        // GET: /Mobile/Pay/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        public void PayNotify()
        {
            string meg = string.Empty;
            try
            {
                //交易金额
                string total_fee = Request.QueryString["total_fee"].ToString();
                //商户订单号
                string out_order_no = Request.QueryString["out_order_no"].ToString();
                //服务端校验码
                string sign = Request.QueryString["sign"].ToString();
                //云通付交易订单号
                string trade_no = Request.QueryString["trade_no"].ToString();
                //交易结果（TRADE_SUCCESS说明支付成功）
                string trade_status = Request.QueryString["trade_status"].ToString();
                //合作身份者PID，签约账号，由16位纯数字组成的字符串，请登录商户后台查看
                string partner =PayHelper.partner;
                // MD5密钥，安全检验码，由数字和字母组成的32位字符串，请登录商户后台查看
                string key =PayHelper.key;
                bool State = NotifyState(total_fee, out_order_no, sign, trade_no, trade_status, partner, key);
                if (State&&trade_status=="TRADE_SUCCESS")
                {//支付成功处理业务逻辑
                    //修改订单状态
                    if (_server.AlterStateByOrderNo(out_order_no) > 0)
                    {//业务逻辑修改改成功
                        meg = "验证成功";
                    }  
                }
                else
                {
                    meg = "验证失败";
                }
            }
            catch (Exception ex)
            {
                meg = "数据未传回或参数错误";
            }
            Response.Clear();
            Response.Write(meg);
        }


        /// <summary>
        /// 支付成功跳转链接
        /// </summary>
        public void Success()
        {
            if (Request.QueryString["trade_status"].ToString() == "TRADE_SUCCESS")
            {
                Redirect("/Mobile/Pay/SuccessTip");
            }
        }

        /// <summary>
        /// 验证状态
        /// </summary>
        /// <param name="total_fee">交易金额</param>
        /// <param name="out_order_no">商户订单号</param>
        /// <param name="sign">服务端校验码</param>
        /// <param name="trade_no">云通付交易订单号</param>
        /// <param name="trade_status">交易结果（TRADE_SUCCESS说明支付成功）</param>
        /// <param name="partner">合作身份者PID，签约账号，由16位纯数字组成的字符串，请登录商户后台查看</param>
        /// <param name="key">MD5密钥，安全检验码，由数字和字母组成的32位字符串，请登录商户后台查看</param>
        /// <returns></returns>
        public bool NotifyState(string total_fee, string out_order_no, string sign, string trade_no, string trade_status, string partner, string key)
        {
            string val = string.Empty;
            val += out_order_no + total_fee + trade_status + partner + key;
            val =PayHelper.md5(val.ToString());
            if (sign == val)
                return true;
            else
                return false;

        }
    }
}
