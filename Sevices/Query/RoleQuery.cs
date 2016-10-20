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
    public partial class RoleService : ServiceBase
    {

        /// <summary>
        /// 分页获取角色数据列表
        /// </summary>
        /// <param name="Info">分页参数</param>
        /// <param name="Params">查询参数</param>
        /// <returns></returns>
        public string GetList(PageInfo Info,Dictionary<string,object> Params)
        {
            return query.QueryPage<Dictionary<string,object>>(@"select * from [Role]",Info, null);
        }

        /// <summary>
        /// 获取角色数据
        /// </summary>
        /// <param name="ID">主键ID</param>
        /// <returns></returns>
        public Role Get(string ID)
        {
            return query.db.Role.Find(ID);
        }

        /// <summary>
        /// 获取所有的菜单和按钮
        /// </summary>
        /// <returns></returns>
        public string GetAllMenuAndButton()
        {
            try
            {
                /*
                * 获取菜单数据*
                */
                var menus = from m in query.db.Menus
                            where m.bIsDeleted == false
                            orderby m.iOrder ascending
                            select new
                            {
                                m.ID,
                                m.iOrder,
                                m.sMenuName,
                                m.sParentMenuId,
                            };
                /*
                 * 获取菜单按钮数据*
                 */
                var button = from n in query.db.Button
                             orderby n.iOrder ascending
                             select new
                             {
                                 n.ID,
                                 n.sButtonName,
                                 n.sToMenuId,
                             };

                JObject job = new JObject();
                job.Add(new JProperty("menu", C_Json.Array(C_Json.toJson(menus))));
                job.Add(new JProperty("button", C_Json.Array(C_Json.toJson(button))));
                return job.ToString();
            }
            catch (Exception e)
            {
                Logs.LogHelper.ErrorLog(e);
                return null;
            }
        }
    }
}
