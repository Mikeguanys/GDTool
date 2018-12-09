namespace GDCreateTool.Model.Global
{
    public static class DBLogin
    {

        public static int Id { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public static int BaseName { get; set; }
        /// <summary>
        /// 数据库Id
        /// </summary>
        public static int Ip { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public static int Port { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public static int DataName { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public static int UserName { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public static int PassWord { get; set; }
        /// <summary>
        /// 是否连接
        /// </summary>
        public static int IsRead { get; set; }
    }
}
