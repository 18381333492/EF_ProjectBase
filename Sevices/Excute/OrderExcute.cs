﻿using EFModel;
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

        /// <summary>
        /// 根据订单ID取消订单
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        public int CancelOrder(Guid sOrderId)
        {
            var order = excute.db.Orders.Find(sOrderId);
            order.bIsDeleted = true;
            return excute.SaveChange();
        }

        
        /// <summary>
        /// 根据订单编号修改订单状态
        /// </summary>
        /// <param name="sOrderNO"></param>
        /// <returns></returns>
        public int AlterStateByOrderNo(string sOrderNO)
        {
            var order = excute.db.Orders.FirstOrDefault(m=>m.sOrderNo== sOrderNO);
            if (order.iState == 0)
            {
                order.iState = 1;//修改为已支付
                order.dPayTime = DateTime.Now;
                return  excute.SaveChange();
            }
            else
            {
                return -2;
            }
        }
    }
}
