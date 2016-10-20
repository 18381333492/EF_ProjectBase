using EFModel;
using Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sevices
{
    public partial class RoleService : ServiceBase
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        [Log("角色",Operate.Create)]
        public int Add(Role item)
        {
            excute.Add<Role>(item);
            return excute.SaveChange(this,"Add");      
        }

        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Log("角色", Operate.Update)]
        public int Edit(Role item)
        {
            excute.Edit<Role>(item);
             return excute.SaveChange(this, "Edit");
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="Ids"></param>
        [Log("角色", Operate.Delete)]
        public int Cancel(string Ids)
        {
            int res= excute.Cancel<Role>(Ids);
            if (res > 0)
            {//手动写日志
                LogHelper.OperateLog(this, "Cancel");
            }
            return res;
        }
    }
}
