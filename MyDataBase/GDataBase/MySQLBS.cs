using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace GDataBase
{
    /// <summary>
    /// MySQL抽象类型
    /// </summary>
    public abstract class MySQLBS : MyGT
    {
        //引导数据库连接数据库调用Web.Config文件      
        private MySqlConnection connection;
        private int outtime = 30;
        //创建连接  
        private MySqlConnection Connection
        {
            get
            {
                string connectionString = string.Empty;
                if (connection == null)
                {
                    connection = new MySqlConnection(System.Configuration.ConfigurationManager.AppSettings["connectionstring"]);
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
        ///
        public MySQLBS()
        {
            Connection = new MySqlConnection(System.Configuration.ConfigurationManager.AppSettings["connectionstring"]);
        }
        /// <summary>
        /// 方法重构
        /// </summary>
        /// <param name="connstring"></param>
        public MySQLBS(string connstring)
        {
            Connection = new MySqlConnection(System.Configuration.ConfigurationManager.AppSettings[connstring]);
        }
        /// <summary>
        /// 直接执行SQL语句
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public int BsExecute(string safeSql)
        {
            using (MySqlCommand cmd = new MySqlCommand(safeSql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                    return -1;
                }
                finally
                {
                    Connection.Close();
                    Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 直接执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>  
        public int BsExecute(string sql, params MySqlParameter[] values)
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    cmd.Parameters.AddRange(values);
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                    return -1;
                }
                finally
                {
                    Connection.Close();
                    Connection.Dispose();
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
            MySqlTransaction transaction = Connection.BeginTransaction();
            try
            {
                using (MySqlCommand Cmd = new MySqlCommand(sql, Connection))
                {
                    Cmd.CommandTimeout = outtime;
                    int Ruslt = Cmd.ExecuteNonQuery();
                    if (Ruslt >= RustltCount)
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
                Connection.Dispose();
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
        public bool BsMoreExecute(string sql, int RustltCount, params MySqlParameter[] values)
        {
            MySqlTransaction transaction = Connection.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, Connection))
                {
                    cmd.CommandTimeout = outtime;
                    cmd.Parameters.AddRange(values);
                    int Ruslt = cmd.ExecuteNonQuery();
                    if (Ruslt >= RustltCount)
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
                Connection.Dispose();
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
            using (MySqlCommand cmd = new MySqlCommand(safeSql, Connection))
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
                    Connection.Dispose();
                }

            }
        }
        /// <summary>
        /// 返回第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public object BsGetScalar(string sql, params MySqlParameter[] values)
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, Connection))
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
                    Connection.Dispose();
                }

            }
        }
        /// <summary>
        /// 返回一行数据
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public DataRow BsGetDataReader(string safeSql)
        {
            using (MySqlCommand cmd = new MySqlCommand(safeSql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    MySqlDataReader reader = cmd.ExecuteReader();
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
                    Connection.Dispose();
                }

            }
        }
        /// <summary>
        /// 返回一行数据
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public DataRow BsGetDataReader(string sql, params MySqlParameter[] values)
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    cmd.Parameters.AddRange(values);
                    MySqlDataReader reader = cmd.ExecuteReader();
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
                    Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 返回一个DataTable 
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public DataTable BsGetDataTable(string safeSql)
        {
            DataTable dt = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand(safeSql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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
                    Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 返回一个DataTable 
        /// </summary>
        /// <param name="safeSql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataTable BsGetDataTable(string safeSql, params MySqlParameter[] values)
        {
            DataTable dt = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand(safeSql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    cmd.Parameters.AddRange(values);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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
                    Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataSet BsGetDataSet(string sql, params MySqlParameter[] values)
        {
            DataSet ds = new DataSet();
            using (MySqlCommand cmd = new MySqlCommand(sql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    cmd.Parameters.AddRange(values);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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
                    Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataSet BsGetDataSet(string sql)
        {
            DataSet ds = new DataSet();
            using (MySqlCommand cmd = new MySqlCommand(sql, Connection))
            {
                try
                {
                    cmd.CommandTimeout = outtime;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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
                    Connection.Dispose();
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
            using (MySqlCommand cmd = new MySqlCommand(sql, Connection))
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
                    Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 新增一条记录返回Id
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public string BsAddGetId(string sql, params MySqlParameter[] values)
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, Connection))
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
                    Connection.Dispose();
                }
            }
        }
        /// <summary>
        /// 执行存储方法返回一个表
        /// </summary>
        /// <param name="storedName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable ExecuteStorage(string storedName, MySqlParameter[] param)
        {
            DataTable dt = new DataTable();
            try
            {
                //MySQL调用存储过程时数据库名字必须要小写            

                using (MySqlCommand cmd = new MySqlCommand(storedName, Connection))
                {
                    cmd.CommandTimeout = outtime;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedName;
                    //注意输出参数要设置大小,否则size默认为0,
                    cmd.Parameters.AddRange(param);
                    //执行           
                    //得到输出参数的值,把赋值给name,注意,这里得到的是object类型的,要进行相应的类型轮换
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
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
                Connection.Dispose();
            }

        }
        /// <summary>
        /// 执行存储方法返回多个表
        /// </summary>
        /// <param name="storedName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataSet MoreExecuteStorage(string storedName, MySqlParameter[] param)
        {
            DataSet dt = new DataSet();
            try
            {
                //MySQL调用存储过程时数据库名字必须要小写            

                using (MySqlCommand cmd = new MySqlCommand(storedName, Connection))
                {
                    cmd.CommandTimeout = outtime;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedName;
                    //注意输出参数要设置大小,否则size默认为0,
                    cmd.Parameters.AddRange(param);
                    //执行           
                    //得到输出参数的值,把赋值给name,注意,这里得到的是object类型的,要进行相应的类型轮换
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
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
                Connection.Dispose();
            }
        }
        /// <summary>
        /// 返回一个值
        /// </summary>
        /// <param name="storedName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public string StringExecuteStorage(string storedName, MySqlParameter[] param)
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = null;
            try
            {
                //MySQL调用存储过程时数据库名字必须要小写                            
                using (cmd = new MySqlCommand(storedName, Connection))
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
                Connection.Dispose();
            }
        }
    }
}
