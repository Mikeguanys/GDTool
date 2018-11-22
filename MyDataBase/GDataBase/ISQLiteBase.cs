using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace GDataBase
{
    interface ISQLiteBase
    {
        /// <summary>
        /// 添加并返回Id
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        object GetAddGetId(string filename, string valuestr, string tablename, params SQLiteParameter[] cmdParms);
        /// <summary>
        /// 添加并返回Id
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        object GetAddGetId(string filename, string valuestr, string tablename);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        bool Add(string filename, string valuestr, string tablename, params SQLiteParameter[] cmdParms);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        bool Add(string filename, string valuestr, string tablename);
        /// <summary>
        /// 添加多条
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        bool MoreAdd(string filename, List<string> valuestr, string tablename, params SQLiteParameter[] cmdParms);
        /// <summary>
        /// 添加多条
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        bool MoreAdd(string filename, List<string> valuestr, string tablename);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        bool Update(string setcondition, string condition, string tablename, params SQLiteParameter[] cmdParms);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        bool Update(string setcondition, string condition, string tablename);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        bool Delete(string sql, string tablename, params SQLiteParameter[] cmdParms);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        bool Delete(string sql, string tablename);
        /// <summary>
        /// 返回一个值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        object GetSingle(string GetColoum, string condition, string tablename, params SQLiteParameter[] cmdParms);
        /// <summary>
        /// 返回一个值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        object GetSingle(string GetColoum, string condition, string tablename);
        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        bool Exists(string strSql, string tablename);
        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        bool Exists(string strSql, string tablename, params SQLiteParameter[] cmdParms);
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="DataSour">返回数据源</param>
        /// <param name="RowCount">返回总页数</param>
        /// <param name="ThisPage">当前第几页</param>
        /// <param name="PageSize">分页大小</param>
        /// <param name="Condition">条件</param>
        void PagingList(ref System.Data.DataTable DataSour, ref int RowCount, int ThisPage, int PageSize, string sql1, string sql2);
        /// <summary>
        /// 获取分页列表单表或者临时表的形式
        /// </summary>
        /// <param name="DataSour">返回数据源</param>
        /// <param name="RowCount">返回总页数</param>
        /// <param name="ThisPage">当前第几页</param>
        /// <param name="PageSize">分页大小</param>
        /// <param name="Condition">条件</param>
        void ThisPagingList(ref System.Data.DataTable DataSour, ref int RowCount, int ThisPage, int PageSize, string Condition, string tablename);
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        DataTable GetTable(string safeSql, string tablename);
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="safeSql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        DataTable GetTable(string safeSql, string tablename, params SQLiteParameter[] values);
        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>  
        DataSet GetDataSet(string sql, string tablename);
        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>  
        DataSet GetDataSet(string sql, string tablename, params SQLiteParameter[] values);
    }
}
