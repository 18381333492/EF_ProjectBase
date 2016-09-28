using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.App_Start;

namespace Web.Areas.Admin.Controllers
{

    /// <summary>
    /// 菜单控制器
    /// </summary>
    public class MenusController : AdminBaseController
    {
        //
        // GET: /Admin/Menus/

        
        /// <summary>
        /// 获取菜单栏目
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMenusList()
        {
            return Content(string.Empty);
        }

    }
}
