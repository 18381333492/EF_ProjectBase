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
    public partial class UserService
    {

        private ServicesBase _server;

        public UserService()
        {
            _server = new ServicesBase();
        }

        /// <summary>
        /// 添加后台用户
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        [Log("用户",Operate.Create)]
        public int Add(User item)
        {
            item.ID = Guid.NewGuid();
            item.sPassWord = string.Empty;
            item.sPhone = "18381333492";
            item.sRoleID = Guid.NewGuid();
            item.sUserName = "TT";
            item.bState = true;
            item.bIsDeleted = false;
            _server.Add<User>(item);
            return _server.SaveChange(this,"Add");      
        }

        /// <summary>
        /// 编辑后台用户
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Log("用户", Operate.Update)]
        public int Edit(User item)
        {
             _server.Edit<User>(item);
             return  _server.SaveChange(this, "Edit");
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="Ids"></param>
        [Log("用户", Operate.Delete)]
        public int Cancel(string Ids)
        {
            int res= _server.Cancel<User>(Ids);
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
            int res=_server.Update(sSql,new { ID= Ids });
            if (res > 0)
            {//手动写日志
                LogHelper.OperateLog(this, "Freeze");
            }
            return res;
        }
    }
}
