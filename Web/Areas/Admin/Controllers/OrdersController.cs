using EFModel.MyModels;
using Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.App_Start;

namespace Web.Areas.Admin.Controllers
{
    public class OrdersController : AdminBaseController<OrdersService>
    {
        //
        // GET: /Admin/Orders/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取订单数据列表
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public ActionResult List(PageInfo Info,string Sta,string End,string searchText,int iState=-1)
        {
            return Content(_server.GetList(Info, Sta, End, searchText, iState));
        }

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="ID"></param>
        public void Alter(Guid ID)
        {
            if (_server.Alter(ID) > 0)
            {
                result.success = true;
                result.info = "修改成功";
            }
            else result.info = "操作失败!";
        }
    }
}
