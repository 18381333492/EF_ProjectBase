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
    public partial class GoodsCommentService : ServiceBase
    {

        /// <summary>
        /// 添加商品评论
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public int Add(GoodsComment item)
        {
            item.ID = Guid.NewGuid();
            item.dCommentTime = DateTime.Now;
            excute.Add<GoodsComment>(item);
            return excute.SaveChange();
        }


        /// <summary>
        /// 编辑商品评论
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public int Edit(GoodsComment item)
        {
            excute.Edit<GoodsComment>(item);
            return excute.SaveChange();
        }

        ///// <summary>
        ///// 上下架商品
        ///// </summary>
        ///// <param name="Ids"></param>
        ///// <returns></returns>
        //public int UnderCarriage(List<Guid> Ids)
        //{
        //    var query=excute.db.Goods.Where(m => Ids.Contains(m.ID));
        //    foreach(var m in query)
        //    {
        //        m.bShelves = m.bShelves == true ? false : true;
        //        excute.Edit<Goods>(m);
        //    }
        //    return  excute.SaveChange();
        //}

    }
}
