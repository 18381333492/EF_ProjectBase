using EFModel;
using EFModel.MyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevices
{
    public partial class UserService
    {

        /// <summary>
        /// 分页获取后台用户数据
        /// </summary>
        /// <param name="Info">分页参数</param>
        /// <param name="Params">查询参数</param>
        /// <returns></returns>
        public string GetList(PageInfo Info,Dictionary<string,object> Params)
        {
            return null;

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


    }
}
