using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
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

        public ActionResult CheckLogin()
        {
            return View();
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
