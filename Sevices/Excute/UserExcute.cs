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
    public partial class UserService: ServiceBase
    {

        /// <summary>
        /// 添加后台用户
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        [Log("用户",Operate.Create)]
        public int Add(User item)
        {
            excute.Add<User>(item);
            return excute.SaveChange(this,"Add");      
        }

        /// <summary>
        /// 编辑后台用户
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Log("用户", Operate.Update)]
        public int Edit(User item)
        {
            excute.Edit<User>(item);
             return excute.SaveChange(this, "Edit");
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="Ids"></param>
        [Log("用户", Operate.Delete)]
        public int Cancel(string Ids)
        {
            int res= excute.Cancel<User>(Ids);
            if (res > 0)
            {//手动写日志
                LogHelper.OperateLog(this, "Cancel");
            }
            return res;
        }

        /// <summary>
        /// 冻结用户
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [Log("用户", Operate.Freeze)]
        public int Freeze(string Ids)
        {
            string sSql = "Update User Set State=0 Where ID IN(@ID)";
            int res= excute.Update(sSql,new { ID= Ids });
            if (res > 0)
            {//手动写日志
                LogHelper.OperateLog(this, "Freeze");
            }
            return res;
        }
    }
}
