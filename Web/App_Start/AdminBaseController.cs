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

    }
}
