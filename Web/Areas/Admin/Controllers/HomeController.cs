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
    public class HomeController : AdminBaseController
    {
        //
        // GET: /Admin/Home/


        public ActionResult Index()
        {
            UserService _server = new UserService();
            User user = new User();
            user.ID=Guid.NewGuid();
            user.sPassWord = "5522915+.q";
            user.sPhone = "18381333492";
            user.sUserName = "Admin";
            user.bState = true;
            user.dInsertTime = DateTime.Now;
            _server.Add(user);
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
            if (sImgCode == Session["ImgCode"].ToString())
            {
                UserService _server = new UserService();
                var user = _server.Login(sUserName, sPassWord);
                if (user != null)
                {
                    Session["User"] = new UserInfo()
                    {
                        ID = user.ID,
                        sUserName = user.sUserName
                    };
                }
                else
                {
                    result.success = false;
                    result.info = "用户名或密码错误!";
                }
            }
            else
            {
                result.success = false;
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
            Session["ImgCode"] = code;
            return File(code, "@image/jpeg");
        }
   
    }
}
