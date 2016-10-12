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
    public class RoleController : AdminBaseController
    {
        //
        // GET: /Admin/Home/
        public RoleController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }


     
    }
}
