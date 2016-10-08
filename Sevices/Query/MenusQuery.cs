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
    /// <summary>
    /// 菜单服务
    /// </summary>
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
        /// 获取一级菜单数据
        /// </summary>
        /// <returns></returns>
        public string GetFirstMenus()
        {
            try
            {
                var entry = from m in _server.db.Menus
                            where m.sParentMenuId == string.Empty
                            orderby m.iOrder
                            select new
                            {
                                id = m.ID,
                                text = m.sMenuName
                            };
                JArray array =C_Json.Array(C_Json.toJson(entry));
                JObject job = new JObject();
                job.Add(new JProperty("id", string.Empty));
                job.Add(new JProperty("text", "一级菜单"));
                array.AddFirst(job);
                return array.ToString();
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
                JArray array = C_Json.Array(C_Json.toJson(entry));
                var Dic = new Dictionary<string, object>();
                Dic.Add("rows", array);
                return  C_Json.JsonString(Dic).Replace("sParentMenuId", "_parentId");    
            }
            catch (Exception e)
            {
                Logs.LogHelper.ErrorLog(e);
                return string.Empty;
            }
        }
       
    }
}
