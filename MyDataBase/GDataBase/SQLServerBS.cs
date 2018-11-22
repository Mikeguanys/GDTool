using System;
using System.Data;
using System.Data.SqlClient;

namespace GDataBase
{
    /// <summary>
    /// SQLServer数据
    /// </summary>
    public abstract class SQLServerBS : MyGT
    {
        #region 数据库连接属性
        private string connectionstring;
        /// <summary> 
        /// SqlConnection对象 
        /// </summary>         
        private SqlConnection conn;
        private int outtime = 30;
        /// <summary>
        /// 方法重构
        /// </summary>
        public SQLServerBS()
        {
            connectionstring = System.Configuration.ConfigurationManager.AppSettings["connectionstring"];
            conn = new SqlConnection(connectionstring);
        }
        /// <summary>
        /// 方法重构
        /// </summary>
        /// <param name="connstring"></param>
        public SQLServerBS(string connstring)
        {
            connectionstring = System.Configuration.ConfigurationManager.AppSettings[connstring];
            conn = new SqlConnection(connectionstring);
        }

        /// <summary> 
        /// SqlCommand对象
        /// </summary> 
        protected SqlCommand comm;
        #endregion

        #region 内部函数
        /// <summary> 
        /// 打开数据库连接 
        /// </summary> 
        private void ConnectionOpen()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Close();
                comm = new SqlCommand();
                conn.ConnectionString = connectionstring;
                comm.Connection = conn;
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                }
            }
        }

        /// <summary> 
        /// 关闭数据库连接 
        /// </summary> 
        private void ConnectionClose()
        {
            conn.Close();
            conn.Dispose();
            comm.Dispose();
        }

        #endregion
        /// <summary>
        /// 查询是否存在记录
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public bool BsExecuteScalar(string sqlString)
        {
            try
            {
                ConnectionOpen();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlString;
                return comm.ExecuteScalar() == null ? false : Convert.ToInt32(comm.ExecuteScalar()) > 0;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return false;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 查询是否存在记录
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public bool BsExecuteScalar(string sqlString, SqlParameter[] parms)
        {
            try
            {
                ConnectionOpen();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlString;
                if (parms != null)
                {
                    foreach (SqlParameter item in parms)
                    {
                        comm.Parameters.Add(item);
                    }
                }
                object r = comm.ExecuteScalar();
                comm.Parameters.Clear();
                return r == null ? false : Convert.ToInt32(r) > 0;

            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return false;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 查询第一行第一列数据
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public object GetSingle(string sqlString)
        {
            try
            {
                ConnectionOpen();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlString;
                return comm.ExecuteScalar();
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 查询第一行第一列数据
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public object GetSingle(string sqlString, SqlParameter[] parms)
        {
            try
            {
                ConnectionOpen();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlString;
                if (parms != null)
                {
                    foreach (SqlParameter item in parms)
                    {
                        comm.Parameters.Add(item);
                    }
                }
                object jo = comm.ExecuteScalar();
                comm.Parameters.Clear();
                return jo;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 新增并返回自增主键ID
        /// </summary>
        /// <returns></returns>
        public int BsAddGetId(string sqlstring)
        {
            try
            {
                ConnectionOpen();
                using (comm = new SqlCommand(sqlstring, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        comm.CommandText = "select @@IDENTITY as newids";
                        return Convert.ToInt32(comm.ExecuteScalar());
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
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
        /// <param name="sqlstring"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public int BsAddGetId(string sqlstring, SqlParameter[] parms)
        {
            try
            {
                ConnectionOpen();
                using (comm = new SqlCommand(sqlstring, conn))
                {
                    comm.Parameters.AddRange(parms);
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        comm.CommandText = "select @@IDENTITY as newids";
                        return Convert.ToInt32(comm.ExecuteScalar());
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return 0;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary> 
        /// 执行增删改
        /// </summary> 
        /// <param name="SqlString">要执行的SQL语句</param> 
        public bool BsExecuteSQL(string SqlString)
        {
            try
            {
                ConnectionOpen();
                comm.CommandType = CommandType.Text;
                comm.CommandText = SqlString;
                return comm.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return false;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="SqlString"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public bool BsExecuteSQL(string SqlString, SqlParameter[] parms)
        {
            try
            {
                ConnectionOpen();
                comm.CommandType = CommandType.Text;
                comm.CommandText = SqlString;
                if (parms != null)
                {
                    foreach (SqlParameter item in parms)
                    {
                        comm.Parameters.Add(item);
                    }
                }
                bool r = comm.ExecuteNonQuery() > 0;
                comm.Parameters.Clear();
                return r;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return false;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 查询一条数据
        /// </summary>
        /// <param name="SqlString"></param>
        /// <returns></returns>
        public DataRow BsRows(string SqlString)
        {
            try
            {
                ConnectionOpen();
                comm.CommandType = CommandType.Text;
                comm.CommandText = SqlString;
                SqlDataReader dr = comm.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
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
                ConnectionClose();
            }
        }
        /// <summary>
        /// 查询一条数据
        /// </summary>
        /// <param name="SqlString"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public DataRow BsRows(string SqlString, SqlParameter[] parms)
        {
            try
            {
                ConnectionOpen();
                comm.CommandType = CommandType.Text;
                comm.CommandText = SqlString;
                if (parms != null)
                {
                    foreach (SqlParameter item in parms)
                    {
                        comm.Parameters.Add(item);
                    }
                }
                SqlDataReader dr = comm.ExecuteReader();
                comm.Parameters.Clear();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
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
                ConnectionClose();
            }
        }
        /// <summary>
        /// 返回DataTable对象
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable BsDataTable(string sql)
        {
            try
            {
                ConnectionOpen();
                SqlDataAdapter rs = new SqlDataAdapter(sql, connectionstring);
                DataTable ds = new DataTable();
                rs.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 返回DataTable对象
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable BsDataTable(string sql, SqlParameter[] parms)
        {
            try
            {
                ConnectionOpen();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sql;
                if (parms != null)
                {
                    foreach (SqlParameter item in parms)
                    {
                        comm.Parameters.Add(item);
                    }
                }
                DataTable ds = new DataTable();
                using (SqlDataAdapter sda = new SqlDataAdapter(comm))
                {
                    sda.Fill(ds);
                }
                comm.Parameters.Clear();
                return ds;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 返回DataTable对象
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet BsDataSet(string sql)
        {
            try
            {
                ConnectionOpen();
                SqlDataAdapter rs = new SqlDataAdapter(sql, connectionstring);
                DataSet ds = new DataSet();
                rs.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 返回DataTable对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public DataSet BsDataSet(string sql, string[] tablename)
        {
            try
            {
                ConnectionOpen();
                SqlDataAdapter rs = new SqlDataAdapter(sql, connectionstring);
                for (int i = 0; i < tablename.Length; i++)
                {
                    rs.TableMappings.Add($"Table" + (i == 0 ? "" : $"{i}"), tablename[i]);
                }
                DataSet ds = new DataSet();
                rs.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 返回DataSet对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public DataSet BsDataSet(string sql, SqlParameter[] parms)
        {
            try
            {
                ConnectionOpen();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sql;
                if (parms != null)
                {
                    foreach (SqlParameter item in parms)
                    {
                        comm.Parameters.Add(item);
                    }
                }
                DataSet ds = new DataSet();
                using (SqlDataAdapter sda = new SqlDataAdapter(comm))
                {
                    sda.Fill(ds);
                }
                comm.Parameters.Clear();
                return ds;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 返回DataSet对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public DataSet BsDataSet(string sql, string[] tablename, SqlParameter[] parms)
        {
            try
            {
                ConnectionOpen();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sql;
                if (parms != null)
                {
                    foreach (SqlParameter item in parms)
                    {
                        comm.Parameters.Add(item);
                    }
                }
                DataSet ds = new DataSet();
                using (SqlDataAdapter sda = new SqlDataAdapter(comm))
                {
                    for (int i = 0; i < tablename.Length; i++)
                    {
                        sda.TableMappings.Add($"Table" + (i == 0 ? "" : $"{i}"), tablename[i]);
                    }
                    sda.Fill(ds);
                }
                comm.Parameters.Clear();
                return ds;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 返回DataView对象
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataView DataView(string sql)
        {
            try
            {
                DataTable ds = new DataTable();
                ds = BsDataTable(sql);
                DataView dv = new DataView(ds);
                return dv;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 返回DataView对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        public DataView DataView(string sql, SqlParameter[] parm)
        {
            try
            {
                DataTable ds = new DataTable();
                ds = BsDataTable(sql, parm);
                DataView dv = new DataView(ds);
                return dv;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }
        /// <summary>
        /// 返回dataReader对象
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlDataReader BsDataReader(string sql)
        {
            try
            {
                ConnectionOpen();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return null;
            }
            finally
            {
                ConnectionClose();
            }
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public bool Adapter(string sql, DataSet ds)
        {

            SqlDataAdapter Adapter = new SqlDataAdapter();
            SqlCommand cmd = null;
            try
            {
                ConnectionOpen();
                cmd = new SqlCommand(sql, conn);
                string tablename = ds.Tables[0].TableName;
                Adapter.SelectCommand = cmd;
                SqlCommandBuilder build = new SqlCommandBuilder(Adapter);
                Adapter.Fill(ds, tablename);
                int returns = Adapter.Update(ds, tablename);
                return returns > 0;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return false;
            }
            finally
            {
                Adapter.Dispose();
                cmd.Dispose();
                conn.Dispose();
            }
        }
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public bool UpdataAdapter(string sql, DataSet ds)
        {
            DataSet set = new DataSet();
            SqlDataAdapter Adapter = null;
            SqlCommand cmd = null;
            ConnectionOpen();
            set = ds;
            ds.Clear();
            try
            {
                string tablename = ds.Tables[0].TableName.ToString();
                cmd = new SqlCommand(sql, conn);
                Adapter = new SqlDataAdapter();
                SqlCommandBuilder build = new SqlCommandBuilder(Adapter);
                Adapter.SelectCommand = cmd;
                Adapter.UpdateCommand = build.GetUpdateCommand();
                Adapter.Fill(ds, tablename);
                Adapter.FillSchema(ds, SchemaType.Source, tablename);
                int returns = Adapter.Update(set, tablename);
                ds.AcceptChanges();
                return returns > 0;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
                return false;
            }
            finally
            {
                Adapter.Dispose();
                cmd.Dispose();
                conn.Dispose();
            }
        }
        /// <summary>
        /// 事物执行多条SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool BsMoreExecute(string sql)
        {
            ConnectionOpen();
            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                comm = new SqlCommand(sql);
                bool Ruslt = comm.ExecuteNonQuery() > 0;
                transaction.Commit();
                return Ruslt;

            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")"); transaction.Rollback();
                return false;
            }
            finally
            {
                transaction.Dispose();
                ConnectionClose();
            }
        }
        /// <summary>
        /// 事物执行多条SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        public bool BsMoreExecute(string sql, SqlParameter[] parm)
        {
            ConnectionOpen();
            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                comm.CommandType = CommandType.Text;
                comm.CommandText = sql;
                comm.Parameters.AddRange(parm);
                bool Ruslt = comm.ExecuteNonQuery() > 0;
                transaction.Commit();
                comm.Parameters.Clear();
                return Ruslt;
            }
            catch (Exception ex)
            {
                WriteFile("--时间：" + DateTime.Now.ToString() + "(出现异常:" + ex.Message + ")");
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
        /// 执行存储方法返回一个表
        /// </summary>
        /// <param name="storedName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable ExecuteStorage(string storedName, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            try
            {
                //MySQL调用存储过程时数据库名字必须要小写            
                ConnectionOpen();
                using (SqlCommand cmd = new SqlCommand(storedName, conn))
                {
                    cmd.CommandTimeout = outtime;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedName;
                    //注意输出参数要设置大小,否则size默认为0,
                    cmd.Parameters.AddRange(param);
                    //执行           
                    //得到输出参数的值,把赋值给name,注意,这里得到的是object类型的,要进行相应的类型轮换
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    comm.Parameters.Clear();
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
                ConnectionClose();
            }

        }
        /// <summary>
        /// 执行存储方法返回多个表
        /// </summary>
        /// <param name="storedName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataSet MoreExecuteStorage(string storedName, SqlParameter[] param)
        {
            DataSet dt = new DataSet();
            try
            {
                //MySQL调用存储过程时数据库名字必须要小写            
                ConnectionOpen();
                using (SqlCommand cmd = new SqlCommand(storedName, conn))
                {
                    cmd.CommandTimeout = outtime;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedName;
                    //注意输出参数要设置大小,否则size默认为0,
                    cmd.Parameters.AddRange(param);
                    //执行           
                    //得到输出参数的值,把赋值给name,注意,这里得到的是object类型的,要进行相应的类型轮换
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cmd.Parameters.Clear();
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
                ConnectionClose();
            }

        }
        /// <summary>
        /// 返回一个值
        /// </summary>
        /// <param name="storedName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public string StringExecuteStorage(string storedName, SqlParameter[] param)
        {
            ConnectionOpen();
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                //MySQL调用存储过程时数据库名字必须要小写                            
                using (cmd = new SqlCommand(storedName, conn))
                {
                    cmd.CommandTimeout = outtime;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedName;
                    //注意输出参数要设置大小,否则size默认为0,
                    cmd.Parameters.AddRange(param);
                    //执行     
                    string r = Convert.ToString(cmd.ExecuteScalar());
                    cmd.Parameters.Clear();
                    return r;
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
                ConnectionClose();
            }

        }
    }
}
