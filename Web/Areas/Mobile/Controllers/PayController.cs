using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Mobile.Controllers
{
    /// <summary>
    /// 支付相关
    /// </summary>
    public class PayController : Controller
    {
        //
        // GET: /Mobile/Pay/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 支付请求
        /// </summary>
        public void Pay()
        {
            //string out_order_no = WIDout_trade_no.Text;
            ////商品名称
            //string subject = WIDsubject.Text;
            ////金额
            //string total_fee = WIDtotal_fee.Text;
            ////订单描述
            //string body = WIDbody.Text;

            ////商户号（6位数字）
            //string user_seller = "385469";

            ////合作身份者PID，签约账号，由16位纯数字组成的字符串，请登录商户后台查看
            //string partner = "738513346376621";

            //// MD5密钥，安全检验码，由数字和字母组成的32位字符串，请登录商户后台查看
            //string key = "JHeP76Kzd8aMQv8GZxZ3Gi8NgI2gfgAW";

            //// 服务器异步通知页面路径  需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
            //string notify_url = "http://www.ltgirl.com/Play/NotifyUrl.aspx";
            //// 页面跳转同步通知页面路径 需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
            //string return_url = "http://www.xisese.com/Play/ReturnUrl.aspx";
        }
    }
}
