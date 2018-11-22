using GDateBase2v.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace GDateBase2v.MySQL
{
    public class MySQLBasis : SQLConnection, SQLMethodInterface
    {
        #region 数据库连接属性
        private MySqlConnection Connection;
        private MySqlCommand Comd;
        /// <summary>
        /// SQLServerBasis()
        /// </summary>
        public MySQLBasis()
        {
            Connection = new MySqlConnection(DefConnection);
        }
        /// <summary>
        /// MySQLBasis(string ConnectinName)
        /// </summary>
        /// <param name="ConnectinName"></param>
        public MySQLBasis(string ConnectinName)
        {
            if (string.IsNullOrEmpty(ConnectinName))
            {
                Connection = new MySqlConnection(DefConnection);
            }
            else
            {
                Connection = new MySqlConnection(ConnectionStr(ConnectinName));
            }
        }
        /// <summary> 
        /// 打开数据库连接 
        /// </summary> 
        private void ConnectionOpen()
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Close();
                Comd = new MySqlCommand();
                Comd.Connection = Connection;
                try
                {
                    Connection.Open();
                }
                catch (Exception ex)
                {
                    ReadError(ex.Message);
                }
            }
        }
        /// <summary> 
        /// 关闭数据库连接 
        /// </summary> 
        private void ConnectionClose()
        {
            Connection.Close();
            //Connection.Dispose();
            //Comd.Dispose();
        }
        #endregion
        #region 数据库执行方法        
        /// <summary>
        /// 新增并返回自增主键ID
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns></returns>
        public int BsAddGetId(string SQLString)
        {
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    if (Comd.ExecuteNonQuery() > 0)
                    {
                        Comd.CommandText = "select @@IDENTITY as newids";
                        return Convert.ToInt32(Comd.ExecuteScalar());
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return 0;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 新增并返回自增主键ID
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">MySqlParameter[]</param>
        /// <returns></returns>
        public int BsAddGetId(string SQLString, object Parameter)
        {
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    Comd.Parameters.AddRange((Parameter as MySqlParameter[]));
                    if (Comd.ExecuteNonQuery() > 0)
                    {
                        Comd.CommandText = "select @@IDENTITY as newids";
                        return Convert.ToInt32(Comd.ExecuteScalar());
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return 0;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="ds"></param>
        /// <returns>bool</returns>
        public bool BsBatchAdd(string SQLString, DataSet ds)
        {
            ConnectionOpen();
            int TableCount = ds.Tables.Count;
            int r = 0;
            try
            {
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    using (MySqlDataAdapter Adapter = new MySqlDataAdapter())
                    {
                        foreach (DataTable dt in ds.Tables)
                        {
                            Adapter.SelectCommand = Comd;
                            Adapter.Fill(ds, dt.TableName);
                            if (Adapter.Update(ds, dt.TableName) > 0)
                            {
                                r++;
                            }
                        }
                    }
                }
                return r == TableCount;
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return false;
            }
            finally
            {
                ConnectionClose();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="SQLString"></param>
        /// <returns>DataSet</returns>

        public DataSet BsDataSet(string SQLString)
        {
            DataSet ds = new DataSet();
            try
            {
                ConnectionOpen();
                using (MySqlDataAdapter rs = new MySqlDataAdapter(SQLString, Connection))
                {
                    rs.Fill(ds);
                }
                return ds;
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="ListTableName">表名</param>   
        /// <returns>DataSet</returns>
        public DataSet BsDataSet(string SQLString, string[] ListTableName)
        {
            DataSet ds = new DataSet();
            try
            {
                ConnectionOpen();
                using (MySqlDataAdapter Adapter = new MySqlDataAdapter(SQLString, Connection))
                {
                    for (int i = 0; i < ListTableName.Length; i++)
                    {
                        Adapter.TableMappings.Add($"Table{(i == 0 ? "" : i.ToString())}", ListTableName[i]);
                    }
                    Adapter.Fill(ds);
                }
                return ds;
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">参数</param>
        /// <returns>DataSet</returns>
        public DataSet BsDataSet(string SQLString, object Parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    Comd.Parameters.AddRange((Parameter as MySqlParameter[]));
                    using (MySqlDataAdapter Adapter = new MySqlDataAdapter(Comd))
                    {
                        Adapter.Fill(ds);
                    }
                    Comd.Parameters.Clear();
                }
                return ds;
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="ListTableName">表名</param>
        /// <param name="Parameter">参数</param>
        /// <returns>DataSet</returns>
        public DataSet BsDataSet(string SQLString, string[] ListTableName, object Parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    Comd.Parameters.AddRange((Parameter as MySqlParameter[]));
                    using (MySqlDataAdapter Adapter = new MySqlDataAdapter(Comd))
                    {
                        for (int i = 0; i < ListTableName.Length; i++)
                        {
                            Adapter.TableMappings.Add($"Table{(i == 0 ? "" : i.ToString())}", ListTableName[i]);
                        }
                        Adapter.Fill(ds);
                    }
                    Comd.Parameters.Clear();
                }
                return ds;
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>DataTable</returns>
        public DataTable BsDataTable(string SQLString)
        {
            DataTable ds = new DataTable();
            try
            {
                ConnectionOpen();
                using (MySqlDataAdapter rs = new MySqlDataAdapter(SQLString, Connection))
                {
                    rs.Fill(ds);
                }
                return ds;
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return ds;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">参数</param>
        /// <returns>DataTable</returns>
        public DataTable BsDataTable(string SQLString, object Parameter)
        {
            DataTable ds = new DataTable();
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand())
                {
                    Comd.Parameters.AddRange(Parameter as MySqlParameter[]);
                    using (MySqlDataAdapter Adapter = new MySqlDataAdapter(Comd))
                    {
                        Adapter.Fill(ds);
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return ds;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 执行数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>bool</returns>
        public bool BsExecute(string SQLString)
        {
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    return Comd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return false;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 执行数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="RCount">返回执行结果</param>
        /// <returns>bool</returns>
        public bool BsExecute(string SQLString, int RCount)
        {
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    return Comd.ExecuteNonQuery() > RCount;
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return false;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 执行数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="RCount">返回执行结果</param>
        /// <param name="Parameter">参数</param>
        /// <returns>bool</returns>
        public bool BsExecute(string SQLString, int RCount, object Parameter)
        {
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    Comd.Parameters.AddRange(Parameter as MySqlParameter[]);
                    return Comd.ExecuteNonQuery() > RCount;
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return false;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 执行数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">参数</param>
        /// <returns>bool</returns>
        public bool BsExecute(string SQLString, object Parameter)
        {
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    Comd.Parameters.AddRange(Parameter as MySqlParameter[]);
                    return Comd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return false;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 是否存在数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>    
        /// <returns>bool</returns>
        public bool BsExist(string SQLString)
        {
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    return Comd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return false;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 是否存在数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">参数</param>
        /// <returns>bool</returns>
        public bool BsExist(string SQLString, object Parameter)
        {
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    Comd.Parameters.AddRange(Parameter as MySqlParameter[]);
                    return Comd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return false;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 查询一行数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>    
        /// <returns>一行数据</returns>
        public DataRow BsRows(string SQLString)
        {
            DataTable dt = new DataTable();
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    var ReadRows = Comd.ExecuteReader();
                    if (ReadRows.HasRows)
                    {
                        dt.Load(ReadRows);
                        return dt.Rows[0];
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 查询一行数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">参数</param>
        /// <returns>一行数据</returns>
        public DataRow BsRows(string SQLString, object Parameter)
        {
            DataTable dt = new DataTable();
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    Comd.Parameters.AddRange(Parameter as MySqlParameter[]);
                    var ReadRows = Comd.ExecuteReader();
                    if (ReadRows.HasRows)
                    {
                        dt.Load(ReadRows);
                        return dt.Rows[0];
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 查询单个数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param> 
        /// <returns>单个数据</returns>
        public object BsSingle(string SQLString)
        {
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    return Comd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 查询单个数据
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="Parameter">参数</param>
        /// <returns>单个数据</returns>
        public object BsSingle(string SQLString, object Parameter)
        {
            try
            {
                ConnectionOpen();
                using (Comd = new MySqlCommand(SQLString, Connection))
                {
                    Comd.Parameters.AddRange(Parameter as MySqlParameter[]);
                    return Comd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="StorageName">存储名字</param>
        /// <param name="Parameter">参数</param>
        /// <returns>DataSet</returns>
        public DataSet BsStorageDs(string StorageName, object Parameter)
        {
            DataSet ds = new DataSet();
            try
            {
                //MySQL调用存储过程时数据库名字必须要小写            
                ConnectionOpen();
                using (Comd = new MySqlCommand(StorageName, Connection))
                {
                    Comd.CommandTimeout = OutTime;
                    Comd.CommandType = CommandType.StoredProcedure;
                    Comd.CommandText = StorageName;
                    //注意输出参数要设置大小,否则size默认为0,
                    Comd.Parameters.AddRange(Parameter as MySqlParameter[]);
                    //得到输出参数的值,把赋值给name,注意,这里得到的是object类型的,要进行相应的类型轮换
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(Comd))
                    {
                        adapter.Fill(ds);
                    }
                    Comd.Parameters.Clear();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="StorageName">存储名字</param>
        /// <param name="Parameter">参数</param>
        /// <returns>DataTable</returns>
        public DataTable BsStorageDt(string StorageName, object Parameter)
        {
            DataTable dt = new DataTable();
            try
            {
                //MySQL调用存储过程时数据库名字必须要小写            
                ConnectionOpen();
                using (Comd = new MySqlCommand(StorageName, Connection))
                {
                    Comd.CommandTimeout = OutTime;
                    Comd.CommandType = CommandType.StoredProcedure;
                    Comd.CommandText = StorageName;
                    //注意输出参数要设置大小,否则size默认为0,
                    Comd.Parameters.AddRange(Parameter as MySqlParameter[]);
                    //得到输出参数的值,把赋值给name,注意,这里得到的是object类型的,要进行相应的类型轮换
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(Comd))
                    {
                        adapter.Fill(dt);
                    }
                    Comd.Parameters.Clear();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="StorageName">存储名字</param>
        /// <param name="Parameter">参数</param>
        /// <returns>单个数</returns>
        public string BsStorageStr(string StorageName, object Parameter)
        {
            DataTable dt = new DataTable();
            try
            {
                //MySQL调用存储过程时数据库名字必须要小写            
                ConnectionOpen();
                using (Comd = new MySqlCommand(StorageName, Connection))
                {
                    Comd.CommandTimeout = OutTime;
                    Comd.CommandType = CommandType.StoredProcedure;
                    Comd.CommandText = StorageName;
                    //注意输出参数要设置大小,否则size默认为0,
                    Comd.Parameters.AddRange(Parameter as MySqlParameter[]);
                    //得到输出参数的值,把赋值给name,注意,这里得到的是object类型的,要进行相应的类型轮换
                    object obj = Comd.ExecuteScalar();
                    if (obj == null)
                    {
                        return null;
                    }
                    else
                    {
                        return obj.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SQLString">SQLString</param>
        /// <param name="Count">执行条数</param>
        /// <returns></returns>
        public bool BsTranExecute(string SQLString, int Count = 0)
        {
            ConnectionOpen();
            MySqlTransaction transaction = Connection.BeginTransaction();
            try
            {
                Comd = new MySqlCommand(SQLString);
                bool Ruslt = Comd.ExecuteNonQuery() > Count;
                if (Ruslt)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }
                return Ruslt;
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                transaction.Rollback();
                return false;
            }
            finally
            {
                transaction.Dispose();
                ConnectionClose();
            }
        }
        /// <summary>
        /// 事务执行
        /// </summary>
        /// <param name="SQLString">SQLString</param>
        /// <param name="Parameter">参数</param>
        /// <param name="Count">执行条数</param>
        /// <returns></returns>
        public bool BsTranExecute(string SQLString, object Parameter, int Count = 0)
        {
            ConnectionOpen();
            MySqlTransaction transaction = Connection.BeginTransaction();
            try
            {
                using (Comd = new MySqlCommand(SQLString))
                {
                    Comd.Parameters.AddRange(Parameter as MySqlParameter[]);
                    bool Ruslt = Comd.ExecuteNonQuery() > Count;
                    if (Ruslt)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                    return Ruslt;
                }
            }
            catch (Exception ex)
            {
                ReadError(ex.Message);
                transaction.Rollback();
                return false;
            }
            finally
            {
                transaction.Dispose();
                ConnectionClose();
            }
        }
        #endregion
    }
}
