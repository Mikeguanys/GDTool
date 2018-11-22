using GDateBase2v.GDTools;
using System;
using System.Configuration;

namespace GDateBase2v
{
    public class SQLConnection
    {

        /// <summary>
        /// 连接过期时间
        /// </summary>
        protected int OutTime { get; set; } = 30;
        /// <summary>
        /// 默认连接
        /// </summary>
        protected string DefConnection { get; set; } = ConfigurationManager.ConnectionStrings["GDataBase"].ToString();
        /// <summary>
        /// 连接名称
        /// </summary>
        protected string ConnectionStr(string Connection)
        {
            return ConfigurationManager.ConnectionStrings[Connection].ToString();
        }
        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="ErrorMessage"></param>
        public void ReadError(string ErrorMessage)
        {
            $"[时间({DateTime.Now.ToString()})=>异常:{ErrorMessage}]\r\n".WriteFile();
        }
    }
}
