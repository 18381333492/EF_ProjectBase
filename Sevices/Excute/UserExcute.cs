using EFModel;
using Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Common;

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
            item.dInsertTime = DateTime.Now;
            item.bState = true;
            item.sPassWord = C_String.MD5(item.sPassWord);
            item.sPhone = string.Empty;
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
            return excute.Cancel<User>(Ids,this, "Cancel");
        }

        /// <summary>
        /// 冻结用户
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [Log("用户", Operate.Freeze)]
        public int Freeze(string Ids)
        {
            string sSql =string.Format("Update User Set State=0 Where ID IN({0})",Ids);
            return excute.Excute(sSql, this, "Freeze", new { ID = Ids });
        }
    }
}
