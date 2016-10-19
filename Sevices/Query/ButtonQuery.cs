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
    public partial class ButtonService: ServiceBase
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

            try
            {
                //根级菜单
                var FirstMenu = (from m in query.db.Menus
                                 where m.bIsDeleted == false && m.sParentMenuId == string.Empty
                                 orderby m.iOrder
                                 select new MenuButton
                                 {
                                     id = m.ID.ToString(),
                                     text = m.sMenuName,
                                 }).ToList();
                //二级菜单
                var Menu = (from m in query.db.Menus
                            where m.bIsDeleted == false && m.sParentMenuId != string.Empty
                            orderby m.iOrder
                            select new MenuButton
                            {
                                id = m.ID.ToString(),
                                text = m.sMenuName,
                                toid = m.sParentMenuId
                            }).ToList();
                //二级菜单按钮
                var Button = from m in query.db.Button orderby m.iOrder 
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
                    JObject job = new JObject();
                    job.Add(new JProperty("id", m.id));
                    job.Add(new JProperty("text", m.text));
                    JArray Sec_Array = new JArray();
                    foreach (var n in Menu)
                    {
                        if (m.id == n.toid)
                        {
                            JObject job_sec = new JObject();
                            job_sec.Add(new JProperty("id", n.id));
                            job_sec.Add(new JProperty("text", n.text));
                            job_sec.Add(new JProperty("iconCls",string.Empty));

                            JArray third_Array = new JArray();
                            foreach (var k in Button)
                            {
                                if (n.id == k.sToMenuId)
                                {//按钮所属菜单
                                    JObject job_thrid = new JObject();
                                    job_thrid.Add(new JProperty("id", k.id));
                                    job_thrid.Add(new JProperty("text", k.text));
                                    job_thrid.Add(new JProperty("iconCls", k.iconCls));
                                    third_Array.Add(job_thrid);
                                }
                            }
                            job_sec.Add(new JProperty("children", third_Array));
                            Sec_Array.Add(job_sec);
                        }
                    }
                    job.Add(new JProperty("children", Sec_Array));
                    Main.Add(job);
                }
                return Main.ToString();
            }
            catch (Exception e)
            {
                Logs.LogHelper.ErrorLog(e);
                return string.Empty;
            }
        }


        /// <summary>
        /// 根据主键ID获取按钮实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Button Get(Guid ID)
        {
            try
            {
                return query.db.Button.Find(ID);
            }
            catch (Exception e)
            {
                Logs.LogHelper.ErrorLog(e);
                return null;
            }
        }
    }
}
