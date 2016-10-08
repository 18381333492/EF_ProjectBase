using EFModel;
using EFModel.MyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Logs;

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


        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [Log("菜单",Operate.Create)]
        public int Add(Menus menu)
        {
            menu.ID = Guid.NewGuid();
            menu.sMenuIcon = string.Empty;
            menu.dInsertTime = DateTime.Now;
            _server.Add<Menus>(menu);
            return _server.SaveChange(this,"Add");
        }




    }
}
