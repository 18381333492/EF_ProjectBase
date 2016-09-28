using EFModel;
using EFModel.MyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Sevices
{
    /// <summary>
    /// 菜单的服务
    /// </summary>
    public partial class MenusService
    {

        private ServicesBase _server;

        public MenusService()
        {
            _server = new ServicesBase();
        }


    }
}
