using System.Data;

namespace GDateBase2v.Interface
{
    interface SQLMethodInterface
    {
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns></returns>
        bool BsExist(string SQLString);
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">参数</param>
        /// <returns>bool</returns>
        bool BsExist(string SQLString, object Parameter);
        /// <summary>
        /// 获得第一行第一列数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>bool</returns>
        object BsSingle(string SQLString);
        /// <summary>
        /// 获得第一行第一列数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">参数</param>
        /// <returns>单个数据</returns>
        object BsSingle(string SQLString, object Parameter);
        /// <summary>
        /// 新增并返回自增主键ID
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>单个数据</returns>
        int BsAddGetId(string SQLString);
        /// <summary>
        /// 新增并返回自增主键ID
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">参数</param>
        /// <returns>int</returns>
        int BsAddGetId(string SQLString, object Parameter);
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="dt">表名</param>
        /// <returns>int</returns>
        bool BsBatchAdd(string SQLString, DataSet dt);
        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>bool</returns>
        bool BsExecute(string SQLString);
        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">参数</param>
        /// <returns>bool</returns>
        bool BsExecute(string SQLString, object Parameter);
        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="RCount">返回结果数</param>
        /// <returns>bool</returns>
        bool BsExecute(string SQLString, int RCount);
        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="RCount">返回结果数</param>
        /// <param name="Parameter">参数</param>
        /// <returns>bool</returns>
        bool BsExecute(string SQLString, int RCount, object Parameter);
        /// <summary>
        /// 事务执行
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>bool</returns>
        bool BsTranExecute(string SQLString, int Count);
        /// <summary>
        /// 事务执行
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">参数</param>
        /// <returns>bool</returns>
        bool BsTranExecute(string SQLString, object Parameter, int Count);
        /// <summary>
        /// 获取一行数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>返回一行数据</returns>
        DataRow BsRows(string SQLString);
        /// <summary>
        /// 获取一行数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">参数</param>
        /// <returns>返回一行数据</returns>
        DataRow BsRows(string SQLString, object Parameter);
        /// <summary>
        /// 查询DataTable
        /// </summary>
        /// <param name="SQLString">参数</param>
        /// <returns>DataTable</returns>
        DataTable BsDataTable(string SQLString);
        /// <summary>
        /// 查询DataTable
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">参数</param>
        /// <returns>DataTable</returns>
        DataTable BsDataTable(string SQLString, object Parameter);
        /// <summary>
        /// 返回DataSet对象
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>返回多个表</returns>
        DataSet BsDataSet(string SQLString);
        /// <summary>
        /// 返回DataSet对象
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">参数</param>
        /// <returns>返回多个表</returns>
        DataSet BsDataSet(string SQLString, object Parameter);

        /// <summary>
        /// 赋给DataSet里的表名
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="ListTableName">表名列表</param>
        /// <returns>返回多个表</returns>
        DataSet BsDataSet(string SQLString, string[] ListTableName);
        /// <summary>
        /// 赋给DataSet里的表名
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="ListTableName">表名列表</param>
        /// <param name="Parameter">参数</param>
        /// <returns>返回多个表</returns>
        DataSet BsDataSet(string SQLString, string[] ListTableName, object Parameter);
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="StorageName">存储名字</param>
        /// <param name="Parameter">参数</param>
        /// <returns>返回string</returns>
        string BsStorageStr(string StorageName, object Parameter);
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="StorageName">存储名字</param>
        /// <param name="Parameter">参数</param>
        /// <returns>返回表</returns>
        DataTable BsStorageDt(string StorageName, object Parameter);
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="StorageName">存储名字</param>
        /// <param name="Parameter">参数</param>
        /// <returns>返回多个表</returns>
        DataSet BsStorageDs(string StorageName, object Parameter);
    }
}
