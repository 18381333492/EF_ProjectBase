using EFModel.MyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.App_Start
{
    public class AdminBaseController : Controller
    {
        //
        // GET: /AdminBase/

        public Result result;

        public AdminBaseController()
        {
            result = new Result();
        }
    }
}
