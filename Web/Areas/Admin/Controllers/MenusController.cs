using EFModel;
using Sevices;
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
    public class MenusController : AdminBaseController<MenusService>
    {
        //
        // GET: /Admin/Menus/
   
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 获取菜单列表数据
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            string data = _server.GetList();
            return Content(data);
        }

        /// <summary>
        /// 获取菜单栏目
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMenusList()
        {
            result.data = _server.GetMenusList();
            if (!string.IsNullOrEmpty(result.data.ToString()))
            {
                result.success = true;
            }
            else
            {
                result.info = "菜单加载失败!";
            }   
            return Content(result.toJson());
        }

        /// <summary>
        /// 获取一级菜单栏目
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFirstMenus()
        {
            return Content(_server.GetFirstMenus());
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public ActionResult Insert(Menus menu)
        {
            int res= _server.Add(menu);
            if (res>0)
            {
                result.success = true;
            }
            return Content(result.toJson());
        }

        public ActionResult Update(Menus menu)
        {
            int res = _server.Add(menu);
            if (res > 0)
            {
                result.success = true;
            }
            return Content(result.toJson());
        }
    }
}
