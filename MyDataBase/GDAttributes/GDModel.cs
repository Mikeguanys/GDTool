namespace GDAttributes
{
    public class GDModel
    {
        /// <summary>
        /// 连接基类
        /// </summary>
        public sealed class MergerModel
        {
            /// <summary>
            /// SQL语句
            /// </summary>
            public string SQLStr { get; set; }
            /// <summary>
            /// 实体名称
            /// </summary>
            public string EntityName { get; set; }
            /// <summary>
            /// 实体对象
            /// </summary>
            public object Entity { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public sealed class SQLModel
        {
            /// <summary>
            /// 字段
            /// </summary>
            public string Field { get; set; }
            /// <summary>
            /// 值
            /// </summary>
            public object Value { get; set; }
            /// <summary>
            /// 以String的形式储存值
            /// </summary>
            public string ValueStr { get; set; }
            /// <summary>
            /// 参数
            /// </summary>
            public object Parameter { get; set; }
            /// <summary>
            /// 参数名称 
            /// </summary>
            public string ParameterName { get; set; }
            /// <summary>
            /// 是否主键
            /// </summary>
            public bool IsKey { get; set; } = false;
            /// <summary>
            /// 表示是否为自增
            /// </summary>
            public bool IsIncrease { get; set; }
        }
    }
}
