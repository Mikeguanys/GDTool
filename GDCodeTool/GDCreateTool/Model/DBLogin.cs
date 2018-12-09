namespace GDCreateTool.Model
{
    public class DBLogin
    {
        public int Id { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public int BaseName { get; set; }
        /// <summary>
        /// 数据库Id
        /// </summary>
        public int Ip { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public int DataName { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public int UserName { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public int PassWord { get; set; }
        /// <summary>
        /// 是否连接
        /// </summary>
        public int IsRead { get; set; }
    }
}
