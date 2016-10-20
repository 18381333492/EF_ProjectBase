using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using EFModel.MyModels;
using Logs;
using EFModel;
using System.Data.Entity.Infrastructure;
using Newtonsoft.Json.Linq;



namespace Sevices
{
    public  class QueryBase
    {
        public Entities db;

        public QueryBase()
        {
            db = new Entities();
        }

        /// <summary>
        /// 根据sql语句查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public object Query<T>(string sql,params object[] param)where T:class,new()
        {
            var entry=this.db.Database.SqlQuery<T>(sql,param);
            return entry;
        }


        /// <summary>
        /// 通过Sql语句分页查询
        /// </summary>
        /// <typeparam name="T">必需是实体模型</typeparam>
        /// <param name="sql"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public string QueryPage<T>(string sql, PageInfo info,object param) 
        {
            try
            {
                string sSql = string.Format(@"DECLARE @rows int 
                                                SELECT @rows=COUNT(*) FROM(select * from [User]) as entry 
                                                SELECT  TOP 
                                                {1} *,@rows MaxRows FROM
                                                (SELECT  ROW_NUMBER() OVER(ORDER BY {2} {3}) AS Number,*
                                                FROM ({0}) AS query) AS entry 
                                                WHERE  Number>{1}*({4}-1) ", sql,
                                                info.rows,
                                                info.sort,
                                                info.order,
                                                info.page);

                DapperHelper.QueryBase ba = new DapperHelper.QueryBase();

                var entry = ba.QueryPage(sSql, param);

                if (entry != null)
                {
                    JObject job = new JObject();
                    job.Add(new JProperty("rows", C_Json.Array(C_Json.toJson(entry))));
                    job.Add(new JProperty("total", entry[0]["MaxRows"].toInt32()));
                    return job.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(e);
                return null;
            }
        }

    }
}
