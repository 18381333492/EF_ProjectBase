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
    public partial class OrdersService: ServiceBase
    {

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public int Add(Orders item)
        {
            if (string.IsNullOrEmpty(item.sActivity))
                item.sActivity = string.Empty;
            if (string.IsNullOrEmpty(item.sOrderRemark))
                item.sOrderRemark = string.Empty;
            item.ID = Guid.NewGuid();
            item.sOrderNo = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            item.dBookTime = DateTime.Now;
            item.dPayTime = DateTime.Now;
            item.iState = 0;//待付款
            excute.Add<Orders>(item);
            return excute.SaveChange();
        }

        /// <summary>
        /// 根据ID修改订单状态
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Alter(Guid ID)
        {
            var order= excute.db.Orders.Find(ID);
            order.iState = order.iState + 1;
            return  excute.SaveChange();
        }
    }
}
