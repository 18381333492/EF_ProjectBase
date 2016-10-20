using EFModel;
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
    public class UserController : AdminBaseController<UserService>
    {
        //
        // GET: /Admin/User/

        #region 后台用户视图
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        #endregion


        public ActionResult List(PageInfo Info)
        {
            return Content(_server.GetList(Info, null));
        }

        /// <summary>
        /// 添加后台用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult Insert(User user)
        {
            int res=_server.Add(user);
            if (res > 0)
            {
                result.success = true;
            }
            return Content(result.toJson());
        }
        
        /// <summary>
        /// 编辑后台用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult Update(User user)
        {
            int res = _server.Edit(user);
            if (res > 0)
            {
                result.success = true;
            }
            return Content(result.toJson());
        }

        /// <summary>
        /// 逻辑删除用户
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public ActionResult Cancel(string Ids)
        {
            int res = _server.Cancel(Ids);
            if (res > 0)
            {
                result.success = true;
            }
            return Content(result.toJson());
        }

        /// <summary>
        /// 冻结用户
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public ActionResult Freeze(string Ids)
        {
            int res = _server.Cancel(Ids);
            return View();
        }
    }
}
