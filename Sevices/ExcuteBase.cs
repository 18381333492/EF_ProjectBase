using EFModel;
using Logs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevices
{
    public  class ExcuteBase
    {

        public Entities db;

        public ExcuteBase()
        {
            db = new Entities();
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entry"></param>
        public void Add<T>(T entry) where T:class,new()
        {
            this.db.Set<T>().Add(entry);
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entry"></param>
        public void Edit<T>(T entry) where T : class, new()
        {
            this.db.Set<T>().Attach(entry);
            this.db.Entry<T>(entry).State = EntityState.Modified;//编辑
        }


        /// <summary>
        /// 物理删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entry"></param>
        public void Delete<T>(T entry) where T : class, new()
        {
            this.db.Set<T>().Add(entry);
            this.db.Entry<T>(entry).State = EntityState.Deleted;//删除
        }


        /// <summary>
        /// 逻辑删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Ids">主键Ids集合</param>
        public int Cancel<T>(string Ids) where T : class, new()
        {
            int res = 0;
            try
            {
                res = this.db.Database.
                    ExecuteSqlCommand(@"UPDATE
                                        @tablename SET bIsDeleted = 1 
                                        WHERE ID IN(@ID)", new { tablename=typeof(T).Name, ID=Ids });
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(e);
            }
            return res;
        }

        /// <summary>
        /// 根据Sql语句更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">Sql语句</param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Update(string sql, params object[] param)
        {
            int res = 0;
            try
            {
                res = this.db.Database.ExecuteSqlCommand(sql, param);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(e);
            }
            return res;
        }



        /// <summary>
        /// 提交操作
        /// </summary>
        /// <returns></returns>
        public int SaveChange(object services ,string method)
        {
            int res = 0;
            try
            {
                res =db.SaveChanges();
                if(res>0)
                LogHelper.OperateLog(services, method);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(e);
            }
            return res;
        }


        /// <summary>
        /// 无操作日志提交操作
        /// </summary>
        /// <returns></returns>
        public int SaveChange()
        {
            int res = 0;
            try
            {
                res = db.SaveChanges();
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(e);
            }
            return res;
        }
    }
}
