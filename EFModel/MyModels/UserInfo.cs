using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModel.MyModels
{

    /// <summary>
    /// 后台session保存的数据
    /// </summary>
    public  class UserInfo
    {
        public Guid ID
        {
            get;
            set;
        }

        public string sUserName
        {
            get;
            set;
        }

        public Guid sRoleId
        {
            get;
            set;
        }
    }
}
