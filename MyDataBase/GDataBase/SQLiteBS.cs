using System;
using System.Data;
using System.Data.SQLite;

namespace GDataBase
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SQLiteBS : MyGT
    {  //引导数据库连接数据库调用Web.Config文件      
        private SQLiteConnection connection;
        private int outtime = 30;
        //创建连接  
        private SQLiteConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SQLiteConnection(System.Configuration.ConfigurationManager.AppSettings["connectionstring"]);
                    //打开连接  
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
            set { connection = value; }
        }
        /// <summary>
        /// 方法重构
        /// </summary>
        /// <param name="connstring"></param>
        public SQLiteBS()
        {
            connection = new SQLiteConnection(System.Configuration.ConfigurationManager.AppSettings["connectionstring"]);
        }
        /// <summary>
        /// 方法重构
        /// </summary>
        /// <param name="connstring"></param>
        public SQLiteBS(string connstring)
        {
            connection = new SQLiteConnection(System.Configuration.ConfigurationManager.AppSettings[connstring]);
        }
        /// <summary>
        /// 直接执行SQL语句
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public bool BsExecuteSQL(string safeSql)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(safeSql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                    return false;
                }
                finally
                {
                    Connection.Close();
                    //SQLite 释放后不实例化执行会有问题
                    //Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 直接执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>  
        public bool BsExecuteSQL(string sql, params SQLiteParameter[] values)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(sql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    cmd.Parameters.AddRange(values);
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                    return false;
                }
                finally
                {
                    Connection.Close();
                    //SQLite 释放后不实例化执行会有问题
                    //Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 事物执行多条SQL
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="RustltCount">返回的结果数</param>
        /// <returns></returns>
        public bool BsMoreExecute(string sql, int RustltCount)
        {
            SQLiteTransaction transaction = Connection.BeginTransaction();
            try
            {
                using (SQLiteCommand Cmd = new SQLiteCommand(sql, Connection))
                {
                    Cmd.CommandTimeout = outtime;
                    int Ruslt = Cmd.ExecuteNonQuery();
                    if (Ruslt > RustltCount)
                    {
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                transaction.Rollback();
                return false;
            }
            finally
            {
                Connection.Close();
                //SQLite 释放后不实例化执行会有问题                
                //Connection.Dispose();
                transaction.Dispose();
            }
        }
        /// <summary>
        /// 事物执行多条SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="RustltCount"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool BsMoreExecute(string sql, int RustltCount, params SQLiteParameter[] values)
        {
            SQLiteTransaction transaction = Connection.BeginTransaction();
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, Connection))
                {
                    cmd.CommandTimeout = outtime;
                    cmd.Parameters.AddRange(values);
                    int Ruslt = cmd.ExecuteNonQuery();
                    if (Ruslt > RustltCount)
                    {
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                transaction.Rollback();
                return false;
            }
            finally
            {
                Connection.Close();
                //SQLite 释放后不实例化执行会有问题
                //Connection.Dispose();
                transaction.Dispose();
            }
        }
        /// <summary>
        /// 返回第一行第一列
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public object BsGetScalar(string safeSql)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(safeSql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    object result = cmd.ExecuteScalar();
                    return result;
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                    return null;
                }
                finally
                {
                    Connection.Close();
                    //SQLite 释放后不实例化执行会有问题
                    //Connection.Dispose();
                }

            }
        }
        /// <summary>
        /// 返回第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public object BsGetScalar(string sql, params SQLiteParameter[] values)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(sql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    cmd.Parameters.AddRange(values);
                    object result = cmd.ExecuteScalar();
                    return result;
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                    return null;
                }
                finally
                {
                    Connection.Close();
                    //SQLite 释放后不实例化执行会有问题
                    //Connection.Dispose();
                }

            }
        }
        /// <summary>
        /// 返回一行数据
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public DataRow BsRows(string safeSql)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(safeSql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        return dt.Rows[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                    return null;
                }
                finally
                {
                    Connection.Close();
                    //SQLite 释放后不实例化执行会有问题
                    //Connection.Dispose();
                }

            }
        }
        /// <summary>
        /// 返回一行数据
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public DataRow BsRows(string sql, params SQLiteParameter[] values)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(sql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    cmd.Parameters.AddRange(values);
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        return dt.Rows[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                    return null;
                }
                finally
                {
                    Connection.Close();
                    //SQLite 释放后不实例化执行会有问题
                    //Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 返回一个DataTable 
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public DataTable BsDataTable(string safeSql)
        {
            DataTable dt = new DataTable();
            using (SQLiteCommand cmd = new SQLiteCommand(safeSql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                    return null;
                }
                finally
                {
                    Connection.Close();
                    //SQLite 释放后不实例化执行会有问题
                    //Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 返回一个DataTable 
        /// </summary>
        /// <param name="safeSql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataTable BsDataTable(string safeSql, params SQLiteParameter[] values)
        {
            DataTable dt = new DataTable();
            using (SQLiteCommand cmd = new SQLiteCommand(safeSql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    cmd.Parameters.AddRange(values);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                    return null;
                }
                finally
                {
                    Connection.Close();
                    //SQLite 释放后不实例化执行会有问题
                    //Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataSet BsDataSet(string sql, params SQLiteParameter[] values)
        {
            DataSet ds = new DataSet();
            using (SQLiteCommand cmd = new SQLiteCommand(sql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    cmd.Parameters.AddRange(values);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                    return null;
                }
                finally
                {
                    Connection.Close();
                    //SQLite 释放后不实例化执行会有问题
                    //Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet BsDataSet(string sql)
        {
            DataSet ds = new DataSet();
            using (SQLiteCommand cmd = new SQLiteCommand(sql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                    return null;
                }
                finally
                {
                    Connection.Close();
                    //SQLite 释放后不实例化执行会有问题
                    //Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 新增一条记录返回Id
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string BsAddGetId(string sql)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(sql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        cmd.CommandText = "SELECT LAST_INSERT_ID();";
                        object result = cmd.ExecuteScalar();
                        return result.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                    return null;
                }
                finally
                {
                    Connection.Close();
                    //SQLite 释放后不实例化执行会有问题
                    //Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 新增一条记录返回Id
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public string BsAddGetId(string sql, params SQLiteParameter[] values)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(sql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    cmd.Parameters.AddRange(values);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        cmd.CommandText = "SELECT LAST_INSERT_ID();";
                        object result = cmd.ExecuteScalar();
                        return result.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                    return null;
                }
                finally
                {
                    Connection.Close();
                    //SQLite 释放后不实例化执行会有问题
                    //Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 执行存储方法返回一个表
        /// </summary>
        /// <param name="storedName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable ExecuteStorage(string storedName, SQLiteParameter[] param)
        {
            DataTable dt = new DataTable();
            try
            {
                //MySQL调用存储过程时数据库名字必须要小写            

                using (SQLiteCommand cmd = new SQLiteCommand(storedName, Connection))
                {
                    cmd.CommandTimeout = outtime;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedName;
                    //注意输出参数要设置大小,否则size默认为0,
                    cmd.Parameters.AddRange(param);
                    //执行           
                    //得到输出参数的值,把赋值给name,注意,这里得到的是object类型的,要进行相应的类型轮换
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return null;
            }
            finally
            {
                Connection.Close();
                //SQLite 释放后不实例化执行会有问题
                //Connection.Dispose();
            }

        }
        /// <summary>
        /// 执行存储方法返回多个表
        /// </summary>
        /// <param name="storedName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataSet MoreExecuteStorage(string storedName, SQLiteParameter[] param)
        {
            DataSet dt = new DataSet();
            try
            {
                //MySQL调用存储过程时数据库名字必须要小写            

                using (SQLiteCommand cmd = new SQLiteCommand(storedName, Connection))
                {
                    cmd.CommandTimeout = outtime;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedName;
                    //注意输出参数要设置大小,否则size默认为0,
                    cmd.Parameters.AddRange(param);
                    //执行           
                    //得到输出参数的值,把赋值给name,注意,这里得到的是object类型的,要进行相应的类型轮换
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return null;
            }
            finally
            {
                Connection.Close();
                //SQLite 释放后不实例化执行会有问题
                //Connection.Dispose();
            }
        }
        /// <summary>
        /// 返回一个值
        /// </summary>
        /// <param name="storedName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public string StringExecuteStorage(string storedName, SQLiteParameter[] param)
        {
            DataTable dt = new DataTable();
            SQLiteCommand cmd = null;
            try
            {
                //MySQL调用存储过程时数据库名字必须要小写                            
                using (cmd = new SQLiteCommand(storedName, Connection))
                {
                    cmd.CommandTimeout = outtime;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedName;
                    //注意输出参数要设置大小,否则size默认为0,
                    cmd.Parameters.AddRange(param);
                    //执行     
                    return Convert.ToString(cmd.ExecuteScalar());
                    //得到输出参数的值,把赋值给name,注意,这里得到的是object类型的,要进行相应的类型轮换
                }
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return null;
            }
            finally
            {
                Connection.Close();
                //SQLite 释放后不实例化执行会有问题
                //Connection.Dispose();
            }
        }
    }
}