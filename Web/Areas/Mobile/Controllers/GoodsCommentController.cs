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
    /// 商品评论相关
    /// </summary>
    public class GoodsCommentController : MobileBaseController<OrdersService>
    {
        //
        // GET: /Mobile/Order/

        /// <summary>
        /// 添加商品评论
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void AddGoodsComment(Orders order)
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
