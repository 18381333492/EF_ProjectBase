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
    public class OperateLogController : AdminBaseController<OperateLogService>
    {
        //
        // GET: /Admin/OpreateLog/

        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 分页获取操作日志数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ActionResult List(PageInfo info)
        {
            return Content(_server.GetList(info, null));
        }
    }
}
