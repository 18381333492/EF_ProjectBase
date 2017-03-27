using EFModel;
using EFModel.MyModels;
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
        /// 会员页面查询
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 根据订单ID查看订单详情视图
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        public ActionResult Detail()
        {
            return View();
        }

        /// <summary>
        /// 根据手机号码查询用户订单
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="Sta"></param>
        /// <param name="End"></param>
        /// <param name="searchText"></param>
        /// <param name="iState"></param>
        /// <returns></returns>

        public ActionResult List(PageInfo Info, string sPhone, int iState = -1)
        {
            return Content(_server.GetListByPhone(Info, sPhone, iState));
        }

        /// <summary>
        /// 检查订单状态
        /// </summary>
        /// <param name="sOrderId"></param>
        public void CheckOrderState(Guid sOrderId)
        {
            
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
