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
    public partial class ButtonService: ServiceBase
    {

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [Log("按钮", Operate.Create)]
        public int Add(Button button)
        {
            button.ID = Guid.NewGuid();
            excute.Add<Button>(button);
            return excute.SaveChange(this,"Add");
        }

        /// <summary>
        /// 编辑按钮
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [Log("按钮", Operate.Update)]
        public int Edit(Button button)
        {
            excute.Edit<Button>(button);
            return excute.SaveChange(this, "Edit");
        }

    }
}
