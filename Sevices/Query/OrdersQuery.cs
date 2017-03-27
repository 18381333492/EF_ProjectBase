using EFModel;
using EFModel.MyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Sevices
{
    public partial class OrdersService : ServiceBase
    {

        /// <summary>
        /// 分页获取订单数据
        /// </summary>
        /// <param name="Info">分页参数</param>
        /// <param name="Sta">开始时间</param>
        /// <param name="End">结束时间</param>
        /// <param name="searchText"></param>
        /// <param name="iState"></param>
        /// <returns></returns>
        public string GetList(PageInfo Info, string Sta, string End, string searchText, int iState)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Append("SELECT * FROM [Orders] WHERE 1=1");

            //条件查询
            if (iState > -1)
            {
                sSql.AppendFormat(" AND iState={0}", iState);
            }
            if (!string.IsNullOrEmpty(searchText))
            {
                sSql.AppendFormat(" AND iState={0}", iState);
            }
            Info.sort = "dBookTime";
            Info.order = OrderType.DESC;
            return query.QueryPage(@"select * from [Orders]", Info, null);

        }

        /// <summary>
        /// 根据手机号码查询用户订单
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="sPhone"></param>
        /// <param name="iState"></param>
        /// <returns></returns>
        public string GetListByPhone(PageInfo Info, string sPhone, int iState)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Append("SELECT * FROM [Orders] WHERE 1=1");

            //条件查询
            if (iState > -1)
            {
                sSql.AppendFormat(" AND iState={0}", iState);
            }
            if (!string.IsNullOrEmpty(sPhone))
            {
                sSql.AppendFormat(" AND sPhone LIKE '%{0}%'", sPhone);
            }
            else
            {//没有输入号码查询的时候
               return
                    C_Json.toJson(new {
                    total = 0,
                    rows=new List<object>()
                });
            }
            Info.sort = "dBookTime";
            Info.order = OrderType.DESC;
            return query.QueryPage(sSql.ToString(), Info, null);

        }
    }
}
