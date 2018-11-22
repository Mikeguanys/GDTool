using System;

namespace GDAttributes
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class GDColoum : Attribute
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否为主建
        /// </summary>
        public bool IsKey { get; set; }
        /// <summary>
        /// 表示是否自动增长
        /// </summary>
        public bool IsIncrease { get; set; }
        /// <summary>
        /// 字符长度
        /// </summary>
        public int Length { get; set; }
        
        /// <summary>
        /// 默认查询类型
        /// </summary>
        public QueryType QueryType { get; set; }
    }
    /// <summary>
    /// 查询类型
    /// </summary>
    public enum QueryType
    {
        /// <summary>
        /// 普通查询
        /// </summary>
        Average,
        /// <summary>
        /// 模糊查询
        /// </summary>
        IsFuzzy,
        /// <summary>
        /// 范围查询列：大于等于300 and 小于等于500 适用于时间和数字类型
        /// </summary>
        IsBetween
    }
}
