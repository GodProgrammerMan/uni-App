
using SqlSugar; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper
{
    public class DBBase
    {

        private static SqlSugarClient GetInstance(DbType DbType, string ConnectionString)
        {

            //当参数IsAutoCloseConnection 设为true
            //每次执行操作都会执行 connection.close ，事务内特殊些，会在事务回滚或提交的的时候执行 connection.close
            //当参数IsAutoCloseConnection 设为false
            //需要用using(var db=getInstance()) 或者db.Ado.Dispose()或者db.Ado.Close()进行释放
            //db.dispose和using整个对象都不能使用 close释放掉下次还可以开始 
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnectionString,
                DbType = DbType,
                IsAutoCloseConnection = true
            });

            db.Ado.IsEnableLogEvent = true;
            db.Ado.LogEventStarting = (sql, pars) =>
            {
                System.Diagnostics.Debug.Print(sql);    //生成的sql
            };
            return db;
        }

        /// <summary>
        /// Blog_Main 数据库连接
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient Blog_MainDBConnection()
        {
            return GetInstance(DbType.SqlServer, Config.ConnectionDataSa);
        }

        /// <summary>
        /// Zp_ChooseHouse 数据库链接
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient Zp_ChooseHouseDBConnection()
        {
            return GetInstance(DbType.SqlServer, Config.ConnectionDataZpChooseHouse);
        }
        /// <summary>
        /// Zp_Main 数据库链接
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient Zp_MainDBConnection()
        {
            return GetInstance(DbType.SqlServer, Config.ConnectionDataZpMain);
        }
        /// <summary>
        /// Gxh_Main 数据库链接
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient Gxh_MainDBConnection()
        {
            return GetInstance(DbType.SqlServer, Config.ConnectionDataGxhMain);
        }
        

    }
}
