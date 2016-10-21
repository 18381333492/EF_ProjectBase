using EFModel.MyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.App_Start
{
    public class AdminBaseController<T> : Controller where T:class,new ()
    {
        //
        // GET: /AdminBase/

        public Result result;

        protected T _server;

        public AdminBaseController()
        {
            result = new Result();
            _server = Resolve<T>();
        }

        protected M Resolve<M>()
        {
            return (M)Activator.CreateInstance(typeof(M));
        }


        /// <summary>
        /// 缓存的session的相关信息
        /// </summary>
        public class SESSION
        {
           
            public static string User = "@_User";
            public static string Menu = "@_Menu";
            public static string Button = "@_Button";
            public static string ImgCode = "@_ImgCode";
        }


        /// <summary>
        /// 获取SessionUser
        /// </summary>
        /// <returns></returns>
        protected UserInfo SessionUser()
        {
            return Session[SESSION.User] as UserInfo;
        }


        /// <summary>
        /// 在ActionFiter执行完之后操作
        /// tip:主要根据角色获取权限相应的按钮
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var user = SessionUser();
            var sPath = filterContext.RequestContext.HttpContext.Request.Url.AbsolutePath;
        }

        
    }
}
