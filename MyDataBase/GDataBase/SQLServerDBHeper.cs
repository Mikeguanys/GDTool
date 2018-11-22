using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GDataBase
{
    /// <summary>
    /// SQLServer数据访问层
    /// </summary>
    public class SQLServerDBHeper : SQLServerBS, SQLServerIDataBase
    {
        /// <summary>
        /// 方法重构
        /// </summary>
        public SQLServerDBHeper()
        {

        }
        /// <summary>
        /// 方法重构，连接名字
        /// </summary>
        public SQLServerDBHeper(string ConnStr) : base(ConnStr)
        {

        }
        /// <summary>
        /// 新增一条记录返回Id
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="valuestr"></param>
        /// <param name="tablename"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public int GetAddGetId(string filename, string valuestr, string tablename, SqlParameter[] cmdParms)
        {
            string sql = string.Format("insert into {0}({1}) values({2})", tablename, filename, valuestr);
            return BsAddGetId(sql, cmdParms);
        }
        /// <summary>
        /// 新增一条记录返回Id
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="valuestr"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public int GetAddGetId(string filename, string valuestr, string tablename)
        {
            string sql = string.Format("insert into {0}({1}) values({2})", tablename, filename, valuestr);
            return BsAddGetId(sql);
        }
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="valuestr"></param>
        /// <param name="tablename"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public bool Add(string filename, string valuestr, string tablename, SqlParameter[] cmdParms)
        {
            string sql = string.Format("insert into {0}({1}) values({2})", tablename, filename, valuestr);
            return BsExecuteSQL(sql, cmdParms);
        }
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="valuestr"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public bool Add(string filename, string valuestr, string tablename)
        {
            string sql = string.Format("insert into {0}({1}) values({2})", tablename, filename, valuestr);
            return BsExecuteSQL(sql);
        }
        /// <summary>
        /// 添加一条数据返回任意字段数据
        /// parameter[最后输出].Direction=ParameterDirection.Output；
        /// </summary>
        /// <param name="tableId">表格Id</param>
        /// <param name="outName">返回的数据的字段名</param>
        /// <param name="filename">添加的字段名字：字段1,字段2,字段3</param>
        /// <param name="valuestr">添加的值：1,1,1,0</param>
        /// <param name="tablename">表的名称</param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public string OutAddAnyColum(string tableId, string outName, string filename, string valuestr, string tablename, SqlParameter[] cmdParms)
        {
            string sql = string.Format("insert into {0}({1}) values({2});select @" + outName + "=" + outName + " FROM {0} where " + tableId + " IN (select TOP 1 scope_identity() as id FROM {0} order BY " + tableId + " desc)", tablename, filename, valuestr);
            bool r = BsExecuteSQL(sql, cmdParms);
            if (r)
            {
                return Convert.ToString(cmdParms[cmdParms.Length - 1].Value);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="filename">字段名</param>
        /// <param name="valuestr">值的集合(),(),()</param>
        /// <param name="tablename">表名</param>        
        /// <returns></returns>
        public bool MoreAdd(string filename, string[] valuestr, string tablename)
        {
            string sql = string.Format("insert into {0}({1}) values {2}", tablename, filename, string.Join(",", valuestr));
            return BsMoreExecute(sql);
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="valuestr">(),()</param>
        /// <param name="tablename"></param>        
        /// <returns></returns>
        public bool MoreAdd(string filename, string valuestr, string tablename)
        {
            string sql = string.Format("insert into {0}({1}) values {2}", tablename, filename, valuestr);
            return BsMoreExecute(sql);
        }
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="setcondition"></param>
        /// <param name="condition"></param>
        /// <param name="tablename"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public bool Update(string setcondition, string condition, string tablename, SqlParameter[] cmdParms)
        {
            string sql = string.Format("update {0} set {1} where 1=1 {2}", tablename, setcondition, condition);
            return BsExecuteSQL(sql, cmdParms);
        }
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="setcondition"></param>
        /// <param name="condition"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public bool Update(string setcondition, string condition, string tablename)
        {
            string sql = string.Format("update {0} set {1} where 1=1 {2}", tablename, setcondition, condition);
            return BsExecuteSQL(sql);
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="tablename"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public bool Delete(string condition, string tablename, SqlParameter[] cmdParms)
        {
            string sql = string.Format("delete from {0} where 1=1 {1}", tablename, condition);
            return BsExecuteSQL(sql, cmdParms);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public bool Delete(string condition, string tablename)
        {
            string sql = string.Format("delete from {0} where 1=1 {1}", tablename, condition);
            return BsExecuteSQL(sql);
        }
        /// <summary>
        /// 返回第一行第一列
        /// </summary>
        /// <param name="GetColoum"></param>
        /// <param name="condition"></param>
        /// <param name="tablename"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public object GetSingle(string GetColoum, string condition, string tablename, SqlParameter[] cmdParms)
        {
            string sql = string.Format("select {0} from {1} where 1=1 {2}", GetColoum, tablename, condition);
            return GetSingle(sql, cmdParms);
        }
        /// <summary>
        /// 返回第一行第一列
        /// </summary>
        /// <param name="GetColoum"></param>
        /// <param name="condition"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public object GetSingle(string GetColoum, string condition, string tablename)
        {
            string sql = string.Format("select {0} from {1} where 1=1 {2}", GetColoum, tablename, condition);
            return GetSingle(sql);
        }
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="contion"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public bool Exists(string contion, string tablename)
        {
            string sql = string.Format("select 1 from {0} where 1=1 {1};", tablename, contion);
            return BsExecuteScalar(sql);
        }
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="contion"></param>
        /// <param name="tablename"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public bool Exists(string contion, string tablename, SqlParameter[] cmdParms)
        {
            string sql = string.Format("select 1 from {0} where 1=1 {1};", tablename, contion);
            return BsExecuteScalar(sql, cmdParms);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="contion"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string contion, string tablename)
        {
            string sql = string.Format("select * from {0} where 1=1 {1};", tablename, contion);
            return BsDataTable(sql);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="contion"></param>
        /// <param name="tablename"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string contion, string tablename, SqlParameter[] values)
        {
            string sql = string.Format("select * from {0} where 1=1 {1};", tablename, contion);
            return BsDataTable(sql, values);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contion"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string contion, string tablename)
        {
            string sql = string.Format("select * from {0} where 1=1 {1};", tablename, contion);
            return BsDataSet(sql);
        }
        /// <summary>
        /// 获得多个表
        /// </summary>
        /// <param name="contion"></param>
        /// <param name="tablename"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string contion, string tablename, SqlParameter[] values)
        {
            string sql = string.Format("select * from {0} where 1=1 {1};", tablename, contion);
            return BsDataSet(sql, values);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="RowCount"></param>
        /// <param name="Sqlstr"></param>
        public void GetPagingData(ref DataTable dt, ref int RowCount, string Sqlstr)
        {
            DataSet ds = BsDataSet(Sqlstr);
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
        /// 获取分页数据(存储过程)
        /// </summary>
        /// <param name="dt">返回分页表</param>
        /// <param name="RowCount">返回总行数</param>
        /// <param name="ProcName">存储过程名称</param>
        /// <param name="ThisPage">当前页数</param>
        /// <param name="TableName">表名</param>
        /// <param name="PageSize">页数</param>
        /// <param name="Condition">条件</param>
        /// <param name="Sorting">排序</param>
        public void GetPagingData(ref DataTable dt, ref int RowCount, string ProcName, int ThisPage, string TableName, int PageSize, string Condition, string Sorting)
        {
            SqlParameter[] parameter = {
                                       new SqlParameter("@ThisPage",SqlDbType.Int),
                                       new SqlParameter("@PageSize",SqlDbType.Int),
                                       new SqlParameter("@TableName",SqlDbType.Text),
                                       new SqlParameter("@Condition",SqlDbType.Text),
                                       new SqlParameter("@Sorting",SqlDbType.VarChar,50)
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
        /// 泛型约束查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
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
                DataTable dt = BsDataTable(sql);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return default(T);
                }
                return dt.Rows[0].ToModel<T>();
            }
        }
        /// <summary>
        /// 泛型约束查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public T GTSearch<T>(string sql, SqlParameter[] par) where T : new()
        {
            if (string.IsNullOrEmpty(sql))
            {
                return default(T);
            }
            else
            {
                DataTable dt = BsDataTable(sql, par);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return default(T);
                }

                return dt.Rows[0].ToModel<T>();
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
                    lt.Add(dt.Rows[i].ToModel<T>());
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
        public List<T> GTSearchList<T>(string sql, SqlParameter[] par) where T : new()
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
                    lt.Add(dt.Rows[i].ToModel<T>());
                }
            }
            return lt;
        }
    }
}
