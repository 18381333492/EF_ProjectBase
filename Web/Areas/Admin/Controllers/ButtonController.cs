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
    public class ButtonController : AdminBaseController
    {
        //
        // GET: /Admin/Button/

        private ButtonService server;

        public ButtonController()
        {
            server = new ButtonService();
        }

        #region 菜单按钮视图

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(Guid ID)
        {
            var button = server.Get(ID) != null ? server.Get(ID) : new Button();
            return View(button);
        }

        #endregion

        /// <summary>
        /// 获取菜单按钮数据
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return Content(server.GetList());
        }

        /// <summary>
        /// 添加菜单下面的按钮
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public ActionResult Insert(Button button)
        {
            int res = server.Add(button);
            if (res > 0)
            {
                result.success = true;
            }
            return Content(result.toJson());
        }


        /// <summary>
        /// 编辑菜单下面的按钮
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public ActionResult Update(Button button)
        {
            int res = server.Edit(button);
            if (res > 0)
            {
                result.success = true;
            }
            return Content(result.toJson());
        }

    }
}
