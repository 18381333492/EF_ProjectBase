using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Sevices;
using Web.App_Start;
using EFModel.MyModels;
using EFModel;

namespace Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController<UserService>
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 后台用户登录
        /// </summary>
        /// <param name="sUserName"></param>
        /// <param name="sPassWord"></param>
        /// <returns></returns>
        public ActionResult CheckLogin(string sUserName, string sPassWord,string sImgCode)
        {
            if (sImgCode == Session[SESSION.ImgCode].ToString())
            {
                var user = _server.Login(sUserName, sPassWord);
                if (user != null)
                {
                    Session[SESSION.User] = new UserInfo()
                    {
                        ID = user.ID,
                        sUserName = user.sUserName,
                        sRoleId = user.sRoleID     
                    };

                    //缓存用户的二级菜单和按钮
                    var menu = Resolve<MenusService>();
                    var button= Resolve<ButtonService>();
                    Session[SESSION.Menu] = menu.GetSecondMenus(user.sRoleID);
                    Session[SESSION.Button] = button.GetButton(user.sRoleID);
                    result.success = true;
                }
                else
                {
                    result.info = "用户名或密码错误!";
                }
            }
            else
            {
                result.info = "验证码错误!";
            }
            return Content(result.toJson());
        }

        /// <summary>
        /// 获取图形验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetImgCode()
        {
            string sCode = C_ImgCode.CreateValidateCode(5);
            var code=C_ImgCode.CreateValidateGraphic(sCode);
            Session["ImgCode"] = sCode;
            return File(code, "@image/jpeg");
        }
   
    }
}
