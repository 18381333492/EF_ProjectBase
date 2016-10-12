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
    public partial class ButtonService
    {

        private ServicesBase _server;

        public ButtonService()
        {
            _server = new ServicesBase();
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [Log("按钮", Operate.Create)]
        public int Add(Button button)
        {
            button.ID = Guid.NewGuid();
            _server.Add<Button>(button);
            return _server.SaveChange(this,"Add");
        }

        /// <summary>
        /// 编辑按钮
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [Log("按钮", Operate.Update)]
        public int Edit(Button button)
        {
            _server.Edit<Button>(button);
            return _server.SaveChange(this, "Edit");
        }

    }
}
