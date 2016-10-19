﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModel.MyModels
{
    /// <summary>
    /// 分页数据对象
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        /// 当前页索引
        /// </summary>
        public int page
        {
            get;
            set;
        }

        /// <summary>
        /// 页面数据的大小
        /// </summary>
        public int rows
        {
            get;
            set;
        }

        /// <summary>
        /// 排序的字段名称
        /// </summary>
        public string sort
        {
            get;
            set;
        }

        /// <summary>
        /// 排序方式asc or desc
        /// </summary>
        public Order order
        {
            get;
            set;
        }

        /// <summary>
        /// 关键字
        /// </summary>
        public string sKeyWord
        {
            get;
            set;
        }


        public enum Order
        {
            asc=0,
            desc=1
        }
    }
}
