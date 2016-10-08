using EFModel;
using EFModel.MyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json.Linq;

namespace Sevices
{
    public partial class MenusService
    {
        public class MenuData
        {
            public string sMenuName;
            public List<Data> Menus=new List<Data>();
        }

        public class Data
        {
            public string sMenuName;
            public string sMenuLink;
        }

        /// <summary>
        /// 根据用户权限获取获取菜单列表数据
        /// </summary>
        /// <returns></returns>
        public string GetMenusList()
        {
            try
            {
                var MainMenu = new List<MenuData>();
                var menu = _server.db.Menus.
                    Where(m => m.sParentMenuId == string.Empty&&m.bIsDeleted==false).
                    OrderBy(m => m.iOrder).ToList();
                var childMenu = _server.db.Menus.
                    Where(m => m.sParentMenuId != string.Empty&& m.bIsDeleted == false).
                    OrderBy(m => m.iOrder).ToList();
                //组装菜单数据
                foreach (var m in menu)
                {
                    var Menu = new MenuData();
                    Menu.sMenuName = m.sMenuName;
                    foreach (var k in childMenu)
                    {
                        if (k.sParentMenuId.ToLower()== m.ID.ToString())
                        {
                            Menu.Menus.Add(new Data()
                            {
                                sMenuName = k.sMenuName,
                                sMenuLink = k.sMenuUrl
                            });
                        }
                    }
                    MainMenu.Add(Menu);
                }
                return C_Json.toJson(MainMenu);
            }
            catch (Exception e)
            {
                Logs.LogHelper.ErrorLog(e);
                return string.Empty;
            }
        }

        
        /// <summary>
        /// 获取所有的菜单列表数据
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {
            try
            {
                var entry = from m in _server.db.Menus
                            where m.bIsDeleted == false
                            orderby m.iOrder
                            select m;
                JArray array = JArray.Parse(C_Json.toJson(entry));

                JObject job = new JObject();
                job.Add(new JProperty("total", array.Count));
                job.Add(new JProperty("rows", array));
                //string sResult= job.ToString();
                //sResult = sResult.Replace("sParentMenuId", "_parentId");
                return job.ToString().Replace("sParentMenuId", "_parentId");
              //  var Dic = new Dictionary<string, object>();
                //Dic.Add("rows", array);
                //return  C_Json.JsonString(Dic).Replace("sParentMenuId", "_parentId");    
            }
            catch (Exception e)
            {
                Logs.LogHelper.ErrorLog(e);
                return string.Empty;
            }
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
