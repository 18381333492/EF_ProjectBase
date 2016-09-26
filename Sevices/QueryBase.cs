using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using EFModel.MyModels;
using Logs;

namespace Sevices
{
    public partial class ServicesBase
    {
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
        /// 分页查询数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="info"></param>
        /// <param name="sWhereFields"></param>
        /// <param name="sSelectFields"></param>
        /// <returns></returns>
        public object QueryPage<T>(PageInfo info, string sWhereFields, string sSelectFields="*") where T:class,new ()
        {

            try
            {
                var entry = this.db.Database.SqlQuery<T>(@"EXEC Proc_PageQuery 
                                                            @sTableName,
                                                            @page,
                                                            @rows,
                                                            @sSelectFields,
                                                            @sOrderField,
                                                            @sOrder,
                                                            @sWhereFields"
                                                                          , new
                                                                          {
                                                                              sTableName = typeof(T).Name,
                                                                              page = info.page,//页码
                                                                              rows = info.rows,//数量
                                                                              sSelectFields = sSelectFields,
                                                                              sOrderField = info.sort,//排序的字段
                                                                              sOrder = info.order,//排序ASC OR DESC
                                                                              sWhereFields = sWhereFields //过滤的字段
                                                                          });
                return entry;
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(e);
                return null;
            }
        }

        /// <summary>
        /// 通过Sql语句分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public object QueryPage<T>(PageInfo info,string sql)
        {
            try
            {
                string sSql = string.Format(@"select 
                                            top @rows * from
                                            (select ROW_NUMBER() OVER(order by @sort @order) as _Num,*
                                            from
                                            ({0}) as query) as entry 
                                            where _Num>@rows*(@page-1)
                                            select COUNT(*) from (select * from Table_Module) as _temp
                                        ", sql);

                var entry = this.db.Database.SqlQuery<T>(sSql,
                                                              new
                                                              {
                                                                  rows = info.rows,
                                                                  sort = info.sort,
                                                                  order = info.order,
                                                                  page = info.page
                                                              });

                return entry;
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(e);
                return null;
            }
        }

    }
}
