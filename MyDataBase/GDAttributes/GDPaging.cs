using System.Collections.Generic;

namespace GDAttributes
{
    /// <summary>
    /// 分页对象
    /// </summary>
    public class GDPaging<T>
    {
        /// <summary>
        /// 返回对象
        /// </summary>
        public List<T> GDModel { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int Count { get; set; }
    }
}
