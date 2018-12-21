using GDAttributes;
using System;

namespace GDCreateTool.Model
{
    public class DBLogin
    {
        [GDColoum(QueryType = QueryType.Average, IsKey = true, Name = "Id", Length = 11)]
        public Int64? Id { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        [GDColoum(QueryType = QueryType.Average, Name = "BaseName", Length = 40)]
        public string BaseName { get; set; }
        /// <summary>
        /// 数据库Id
        /// </summary>
        [GDColoum(QueryType = QueryType.Average, Name = "Ip", Length = 20)]
        public string Ip { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        [GDColoum(QueryType = QueryType.Average, Name = "Port", Length = 11)]
        public string Port { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        [GDColoum(QueryType = QueryType.Average, Name = "DataName", Length = 50)]
        public string DataName { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [GDColoum(QueryType = QueryType.Average, Name = "UserName", Length = 16)]
        public string UserName { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        [GDColoum(QueryType = QueryType.Average, Name = "PassWord", Length = 16)]
        public string PassWord { get; set; }
        /// <summary>
        /// 是否连接
        /// </summary>
        [GDColoum(QueryType = QueryType.Average, Name = "IsRead", Length = 1)]
        public Int64? IsRead { get; set; }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        [GDColoum(QueryType = QueryType.Average, Name = "ConnectStr", Length = 1)]
        public string ConnectStr { get; set; }
    }
}
