using EFModel;
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
    /// 订单相关
    /// </summary>
    public class OrdersController : MobileBaseController<OrdersService>
    {
        //
        // GET: /Mobile/Order/

        
        /// <summary>
        /// 下单页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 下订单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void BookOrder(Orders order)
        {
            if (_server.Add(order) > 0)
            {
                result.success = true;
                result.info = "下单成功!";
            }
            else
                result.info = "操作失败!";
        }
    }
}
