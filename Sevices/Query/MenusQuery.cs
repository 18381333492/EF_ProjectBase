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
    public partial class MenusService
    {

       
        /// <summary>
        /// 根据用户权限获取获取菜单列表数据
        /// </summary>
        /// <returns></returns>
        public string GetMenusList()
        {
            var menu = _server.db.Menus;
            return string.Empty;
        }

        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <param name="ID">主键ID</param>
        /// <returns></returns>
        public User Get(string ID)
        {
            return _server.db.User.Find(ID);
        }


        /// <summary>
        ///  用户登录
        /// </summary>
        /// <param name="sUserName">用户</param>
        /// <param name="sPassWord">密码</param>
        /// <returns></returns>
        public User Login(string sUserName, string sPassWord)
        {
            sPassWord = C_String.MD5(sPassWord);
            var user = _server.db.User.Where(m => m.sUserName == sUserName && m.sPassWord == sPassWord).SingleOrDefault();
            return user;
        }
    }
}
