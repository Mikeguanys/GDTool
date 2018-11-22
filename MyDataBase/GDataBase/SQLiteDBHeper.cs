using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Reflection;

namespace GDataBase
{
    /// <summary>
    /// SQLite数据类
    /// </summary>
    public class SQLiteDBHeper : SQLiteBS, ISQLiteBase
    { /// <summary>
      /// 方法重构
      /// </summary>
        public SQLiteDBHeper()
        {

        }
        /// <summary>
        /// 方法重构，连接名字
        /// </summary>
        public SQLiteDBHeper(string ConnStr) : base(ConnStr)
        {

        }
        /// <summary>
        /// 新增一条记录返回Id
        /// </summary>
        /// <param name="filename">字段名</param>
        /// <param name="valuestr">值</param>
        /// <param name="tablename">表名</param>
        /// <param name="cmdParms">参数</param>
        /// <returns></returns>
        public object GetAddGetId(string filename, string valuestr, string tablename, params SQLiteParameter[] cmdParms)
        {
            string sql = string.Format("insert into {0}({1}) values({2})", tablename, filename, valuestr);
            return BsAddGetId(sql, cmdParms);
        }
        /// <summary>
        /// 新增一条记录返回Id
        /// </summary>
        /// <param name="filename">字段名</param>
        /// <param name="valuestr">值</param>
        /// <param name="tablename">表名</param>        
        /// <returns></returns>
        public object GetAddGetId(string filename, string valuestr, string tablename)
        {
            string sql = string.Format("insert into {0}({1}) values({2})", tablename, filename, valuestr);
            return BsAddGetId(sql);
        }
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="filename">字段名</param>
        /// <param name="valuestr">值</param>
        /// <param name="tablename">表</param>
        /// <param name="cmdParms">参数</param>
        /// <returns>bool</returns>
        public bool Add(string filename, string valuestr, string tablename, params SQLiteParameter[] cmdParms)
        {
            string sql = string.Format("insert into {0}({1}) values({2})", tablename, filename, valuestr);
            return BsExecuteSQL(sql, cmdParms);
        }
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="filename">字段名</param>
        /// <param name="valuestr">值</param>
        /// <param name="tablename">表</param>
        /// <param name="cmdParms">参数</param>
        /// <returns>bool</returns>
        public bool Add(string filename, string valuestr, string tablename)
        {
            string sql = string.Format("insert into {0}({1}) values({2})", tablename, filename, valuestr);
            return BsExecuteSQL(sql);
        }
        /// <summary>
        /// 插入多条数据
        /// </summary>
        /// <param name="filename">字段名</param>
        /// <param name="valuestr">值的集合(),(),()</param>
        /// <param name="tablename">表名</param>
        /// <param name="cmdParms">参数</param>
        /// <returns></returns>
        public bool MoreAdd(string filename, List<string> valuestr, string tablename, params SQLiteParameter[] cmdParms)
        {
            string sql = string.Format("insert into {0}({1}) values {2}", tablename, filename, string.Join(",", valuestr));
            return BsMoreExecute(sql, valuestr.Count, cmdParms);
        }
        /// <summary>
        /// 插入多条数据
        /// </summary>
        /// <param name="filename">字段名</param>
        /// <param name="valuestr">值的集合(),(),()</param>
        /// <param name="tablename">表名</param>        
        /// <returns></returns>
        public bool MoreAdd(string filename, List<string> valuestr, string tablename)
        {
            string sql = string.Format("insert into {0}({1}) values {2}", tablename, filename, string.Join(",", valuestr));
            return BsMoreExecute(sql, valuestr.Count);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="setcondition">更新的字段</param>
        /// <param name="condition">条件</param>
        /// <param name="tablename">表名</param>
        /// <param name="cmdParms">参数</param>
        /// <returns></returns>
        public bool Update(string setcondition, string condition, string tablename, params SQLiteParameter[] cmdParms)
        {
            string sql = string.Format("update {0} set {1} where 1=1 {2}", tablename, setcondition, condition);
            return BsExecuteSQL(sql, cmdParms);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="setcondition">更新的字段</param>
        /// <param name="condition">条件</param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public bool Update(string setcondition, string condition, string tablename)
        {
            string sql = string.Format("update {0} set {1} where 1=1 {2}", tablename, setcondition, condition);
            return BsExecuteSQL(sql);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="tablename">表名</param>
        /// <param name="cmdParms">参数</param>
        /// <returns></returns>
        public bool Delete(string condition, string tablename, params SQLiteParameter[] cmdParms)
        {
            string sql = string.Format("delete from {0} where 1=1 {1}", tablename, condition);
            return BsExecuteSQL(sql, cmdParms);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="tablename">表名</param>        
        /// <returns></returns>
        public bool Delete(string condition, string tablename)
        {
            string sql = string.Format("delete from {0} where 1=1 {1}", tablename, condition);
            return BsExecuteSQL(sql);
        }
        /// <summary>
        /// 返回第一行第一列
        /// </summary>
        /// <param name="GetColoum">返回的字段</param>
        /// <param name="condition">条件</param>
        /// <param name="tablename">表名</param>
        /// <param name="cmdParms">参数</param>
        /// <returns></returns>
        public object GetSingle(string GetColoum, string condition, string tablename, params SQLiteParameter[] cmdParms)
        {
            string sql = string.Format("select {0} from {1} where 1=1 {2}", GetColoum, tablename, condition);
            return BsGetScalar(sql, cmdParms);
        }
        /// <summary>
        /// 返回第一行第一列
        /// </summary>
        /// <param name="GetColoum">返回的字段</param>
        /// <param name="condition">条件</param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public object GetSingle(string GetColoum, string condition, string tablename)
        {
            string sql = string.Format("select {0} from {1} where 1=1 {2}", GetColoum, tablename, condition);
            return BsGetScalar(sql);
        }
        /// <summary>
        /// 查询是否存在
        /// </summary>
        /// <param name="contion">条件</param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public bool Exists(string contion, string tablename)
        {
            return Convert.ToInt32(GetSingle(" count(1)", contion, tablename)) > 0;
        }
        /// <summary>
        /// 查询是否存在
        /// </summary>
        /// <param name="contion">条件</param>
        /// <param name="tablename">表名</param>
        /// <param name="cmdParms">参数</param>
        /// <returns></returns>
        public bool Exists(string contion, string tablename, params SQLiteParameter[] cmdParms)
        {
            return Convert.ToInt32(GetSingle(" count(1)", contion, tablename, cmdParms)) > 0;
        }
        /// <summary>
        /// 获取一个表
        /// </summary>
        /// <param name="contion">条件</param>
        /// <param name="tablename">表名字</param>
        /// <returns></returns>
        public System.Data.DataTable GetTable(string contion, string tablename)
        {
            string sql = string.Format("select * from {0} where 1=1 {1};", tablename, contion);
            return BsDataTable(sql);
        }
        /// <summary>
        /// 获取一个表
        /// </summary>
        /// <param name="contion">条件</param>
        /// <param name="tablename">表名字</param>
        /// <param name="values"></param>
        /// <returns></returns>
        public System.Data.DataTable GetTable(string contion, string tablename, params SQLiteParameter[] values)
        {
            string sql = string.Format("select * from {0} where 1=1 {1};", tablename, contion);
            return BsDataTable(sql, values);
        }
        /// <summary>
        /// 获取多个表
        /// </summary>
        /// <param name="contion">条件</param>
        /// <param name="tablename">表名字</param>
        /// <returns></returns>
        public System.Data.DataSet GetDataSet(string contion, string tablename)
        {
            string sql = string.Format("select * from {0} where 1=1 {1};", tablename, contion);
            return BsDataSet(sql);
        }
        /// <summary>
        /// 获取多个表
        /// </summary>
        /// <param name="contion">条件</param>
        /// <param name="tablename">表名字</param>
        /// <param name="values"></param>
        /// <returns></returns>
        public System.Data.DataSet GetDataSet(string contion, string tablename, params SQLiteParameter[] values)
        {
            string sql = string.Format("select * from {0} where 1=1 {1};", tablename, contion);
            return BsDataSet(sql, values);
        }
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="DataSour">返回数据源</param>
        /// <param name="RowCount">总数据量</param>
        /// <param name="ThisPage">当前页</param>
        /// <param name="PageSize">一页多少条数据</param>
        /// <param name="sql1">数据源SQL</param>
        /// <param name="sql2">总数据量SQL</param>
        public void PagingList(ref System.Data.DataTable DataSour, ref int RowCount, int ThisPage, int PageSize, string sql1, string sql2)
        {
            string sql = string.Format("{0} limit {2},{3};{1}", sql1, sql2, ThisPage, PageSize);
            System.Data.DataSet ds = BsDataSet(sql);
            if (ds == null)
            {
                DataSour = null;
                RowCount = 0;
            }
            else
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    DataSour = null;
                    RowCount = 0;
                }
                else
                {
                    DataSour = ds.Tables[0];
                    RowCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                }
            }
        }
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="DataSour">返回数据源</param>
        /// <param name="RowCount">总数据量</param>
        /// <param name="ThisPage">当前页</param>
        /// <param name="PageSize">一页多少条数据</param>
        /// <param name="Condition">条件</param>
        /// <param name="tablename">表名</param>
        public void ThisPagingList(ref System.Data.DataTable DataSour, ref int RowCount, int ThisPage, int PageSize, string Condition, string tablename)
        {
            string sql = string.Format("select * from {0} where 1=1 {1} limit {2},{3};select count(1) from {0} where 1=1 {1}", tablename, Condition, ThisPage, PageSize);
            System.Data.DataSet ds = BsDataSet(sql);
            if (ds == null)
            {
                DataSour = null;
                RowCount = 0;
            }
            else
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    DataSour = null;
                    RowCount = 0;
                }
                else
                {
                    DataSour = ds.Tables[0];
                    RowCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                }
            }
        }
        /// <summary> 
        /// 获取分页数据(存储过程)
        /// </summary>
        /// <param name="dt">返回来的分页数据</param>
        /// <param name="RowCount">返回来的行数</param>
        /// <param name="ProcName">当前的页码数</param>
        /// <param name="ThisPage">一页多少条数据</param>
        /// <param name="TableName">表名</param>
        /// <param name="PageSize">分页大小</param>
        /// <param name="Condition">查询条件</param>
        /// <param name="Sorting">排序</param>
        public void GetPagingData(ref DataTable dt, ref int RowCount, string ProcName, int ThisPage, string TableName, int PageSize, string Condition, string Sorting)
        {
            SQLiteParameter[] parameter = {
                                       new SQLiteParameter("@ThisPage",DbType.Int32),
                                       new SQLiteParameter("@PageSize",DbType.Int32),
                                       new SQLiteParameter("@TableName",DbType.String),
                                       new SQLiteParameter("@Conditions",DbType.String),
                                       new SQLiteParameter("@Sorting",DbType.String,50)
                                       };
            parameter[0].Value = ThisPage;
            parameter[1].Value = PageSize;
            parameter[2].Value = TableName;
            parameter[3].Value = Condition;
            parameter[4].Value = Sorting;
            DataSet ds = MoreExecuteStorage(ProcName, parameter);
            if (ds == null)
            {
                dt = null;
            }
            else
            {
                if (ds.Tables.Count < 2)
                {
                    dt = null;
                }
                else
                {
                    dt = ds.Tables[0];
                    RowCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                }
            }
        }
        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="ActEr">操作人</param>
        /// <param name="Act">操作动作</param>
        /// <param name="Log">日志内容</param>
        /// <returns></returns>
        public bool RecordLog(string ActEr, string Act, string Log)
        {
            string Colums = "F_Sid,F_Act,F_log,F_Ip,F_Client,F_ClientAgent,F_Ok,F_CreateDate";
            string Values = "@F_Sid,@F_Act,@F_log,@F_Ip,@F_Client,@F_ClientAgent,1,NOW()";
            SQLiteParameter[] parameters = {
                              new SQLiteParameter("@F_Sid", DbType.Int32,11),
                              new SQLiteParameter("@F_Act", DbType.String,32),
                              new SQLiteParameter("@F_log", DbType.String,1024)
                                          };
            parameters[0].Value = ActEr;
            parameters[1].Value = Act;
            parameters[2].Value = Log;
            return Add(Colums, Values, "t_sys_log", parameters);
        }
        /// <summary>
        /// 泛型约束查询
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public T GTSearch<T>(string sql) where T : new()
        {
            T t = new T();
            if (string.IsNullOrEmpty(sql))
            {
                return default(T);
            }
            else
            {
                DataRow dr = BsRows(sql);
                if (dr == null)
                {
                    return default(T);
                }
                return ToModel<T>(dr);
            }
        }
        /// <summary>
        /// 泛型约束查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public T GTSearch<T>(string sql, SQLiteParameter[] par) where T : new()
        {
            if (string.IsNullOrEmpty(sql))
            {
                return default(T);
            }
            else
            {
                DataRow dr = BsRows(sql, par);
                if (dr == null)
                {
                    return default(T);
                }
                return ToModel<T>(dr);
            }
        }
        /// <summary>
        /// 泛型函数集合
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public List<T> GTSearchList<T>(string sql) where T : new()
        {
            List<T> lt = new List<T>();
            DataTable dt = BsDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lt.Add(ToModel<T>(dt.Rows[i]));
                }
            }
            return lt;
        }
        /// <summary>
        /// 查询泛型集合
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="par">集合</param>
        /// <returns></returns>
        public List<T> GTSearchList<T>(string sql, SQLiteParameter[] par) where T : new()
        {
            List<T> lt = new List<T>();
            DataTable dt = BsDataTable(sql, par);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lt.Add(ToModel<T>(dt.Rows[i]));
                }
            }
            return lt;
        }
        /// <summary>
        /// 转化成Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        private T ToModel<T>(DataRow row) where T : new()
        {
            T t = new T();
            PropertyInfo[] propertyinfo = t.GetType().GetProperties();
            object value;
            foreach (PropertyInfo p in propertyinfo)
            {
                if (row.Table.Columns.Contains(p.Name))
                {
                    value = row[p.Name];
                    switch (p.PropertyType.ToString())
                    {
                        case "System.String":
                            p.SetValue(t, Convert.ToString(value), null);
                            break;
                        case "System.Int32":
                            p.SetValue(t, Convert.ToInt32(value), null);
                            break;
                        case "System.Int64":
                            p.SetValue(t, Convert.ToInt64(value), null);
                            break;
                        case "System.DateTime":
                            p.SetValue(t, Convert.ToDateTime(value), null);
                            break;
                        case "System.Boolean":
                            p.SetValue(t, Convert.ToBoolean(value), null);
                            break;
                        case "System.Double":
                            p.SetValue(t, Convert.ToDouble(value), null);
                            break;
                        case "System.Decimal":
                            p.SetValue(t, Convert.ToDecimal(value), null);
                            break;
                        default:
                            p.SetValue(t, value, null);
                            break;
                    }
                }
            }
            return t;
        }
    }
}