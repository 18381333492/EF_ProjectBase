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
        public ActionResult Add()
        {
            return View();
        }

        #endregion

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

    }
}
