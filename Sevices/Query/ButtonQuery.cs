using EFModel;
using EFModel.MyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sevices
{
    public partial class ButtonService
    {


        public class MenuButton
        {
            public string id;
            public string toid;
            public string text;
            public string iconCls;
            public string sToMenuId;
        }



        /// <summary>
        /// 获取菜单按钮数据列表
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {

            //根级菜单
            var FirstMenu= (from m in _server.db.Menus
                            where m.bIsDeleted == false && m.sParentMenuId==string.Empty
                            orderby m.iOrder
                            select new MenuButton
                            {
                                id = m.ID.ToString(),
                                text = m.sMenuName,
                            }).ToList();
            //二级菜单
            var Menu = (from m in _server.db.Menus
                        where m.bIsDeleted == false && m.sParentMenuId != string.Empty
                        orderby m.iOrder
                        select new MenuButton
                        {
                            id = m.ID.ToString(),
                            text = m.sMenuName,
                            toid = m.sParentMenuId
                        }).ToList();
            //二级菜单按钮
            var Button = from m in _server.db.Button
                         select new MenuButton
                         {
                             id = m.ID.ToString(),
                             text = m.sButtonName,
                             iconCls = m.sButtonIcon,
                             sToMenuId = m.sToMenuId.ToString()
                         };

            JArray Main = new JArray();

            foreach (var m in FirstMenu)
            {
                foreach (var n in Menu)
                {
                    if (m.id == n.toid)
                    {
                        foreach (var k in Button)
                        {
                            if (n.id == k.sToMenuId)
                            {//按钮所属菜单

                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}
