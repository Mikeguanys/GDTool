namespace GDateBase2v.Enums
{
    public class SQLEnum
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public enum DataBaseType
        {
            SqlServer,
            MySql,
            Sqlite
        }
        /// <summary>
        /// 排序类型
        /// </summary>
        public enum SortType
        {
            /// <summary>
            /// 降序
            /// </summary>
            Desc,
            /// <summary>
            /// 升序
            /// </summary>
            Asc
        }
        /// <summary>
        /// 操作类型增,删,改
        /// </summary>
        public enum OperationType
        {
            /// <summary>
            /// 新增
            /// </summary>
            Add,
            /// <summary>
            /// 删除
            /// </summary>
            Del,
            /// <summary>
            /// 修改
            /// </summary>
            Update
        }
    }
}
