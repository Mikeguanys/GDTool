using System.Data;
using System.Data.SqlClient;

namespace GDataBase
{
    interface SQLServerIDataBase
    {
        /// <summary>
        /// 新增一条记录返回Id
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="valuestr"></param>
        /// <param name="tablename"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        int GetAddGetId(string filename, string valuestr, string tablename, SqlParameter[] cmdParms);
        /// <summary>
        /// 新增一条记录返回Id
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="valuestr"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        int GetAddGetId(string filename, string valuestr, string tablename);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="valuestr"></param>
        /// <param name="tablename"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        bool Add(string filename, string valuestr, string tablename, SqlParameter[] cmdParms);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="valuestr"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        bool Add(string filename, string valuestr, string tablename);
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="valuestr"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        bool MoreAdd(string filename, string[] valuestr, string tablename);
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="valuestr"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        bool MoreAdd(string filename, string valuestr, string tablename);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="setcondition"></param>
        /// <param name="condition"></param>
        /// <param name="tablename"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>        
        bool Update(string setcondition, string condition, string tablename, SqlParameter[] cmdParms);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="setcondition"></param>
        /// <param name="condition"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        bool Update(string setcondition, string condition, string tablename);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tablename"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        bool Delete(string sql, string tablename, SqlParameter[] cmdParms);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        bool Delete(string sql, string tablename);
        /// <summary>
        /// 返回一个值
        /// </summary>
        /// <param name="GetColoum"></param>
        /// <param name="condition"></param>
        /// <param name="tablename"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        object GetSingle(string GetColoum, string condition, string tablename, SqlParameter[] cmdParms);
        /// <summary>
        /// 返回一个值
        /// </summary>
        /// <param name="GetColoum"></param>
        /// <param name="condition"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        object GetSingle(string GetColoum, string condition, string tablename);
        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        bool Exists(string strSql, string tablename);
        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="tablename"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        bool Exists(string strSql, string tablename, SqlParameter[] cmdParms);
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="safeSql"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        DataTable GetDataTable(string safeSql, string tablename);
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="safeSql"></param>
        /// <param name="tablename"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        DataTable GetDataTable(string safeSql, string tablename, SqlParameter[] values);
        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        DataSet GetDataSet(string sql, string tablename);
        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tablename"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        DataSet GetDataSet(string sql, string tablename, SqlParameter[] values);
    }
}
