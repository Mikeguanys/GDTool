using GDAttributes;
using System;

namespace GDataBS
{
    public class GT_GoodsDT
    {
        ///<summary>
        /// 
        /// </summary>
        [GDColoum(IsKey = true, Name = "Id", Length = 4, QueryType = QueryType.Average)]
        public int? Id { get; set; } = 100;
        ///<summary>
        /// 
        /// </summary>
        [GDColoum(Name = "GoodsName", Length = 400, QueryType = QueryType.IsFuzzy)]
        public string GoodsName { get; set; }
        ///<summary>
        /// 
        /// </summary>
        [GDColoum(Name = "Images", Length = 1000, QueryType = QueryType.Average)]
        public string Images { get; set; }
        ///<summary>
        /// 
        /// </summary>
        [GDColoum(Name = "Price", Length = 9, QueryType = QueryType.IsBetween)]
        public decimal? Price { get; set; }
        ///<summary>
        /// 
        /// </summary>
        [GDColoum(Name = "Integral", Length = 4, QueryType = QueryType.Average)]
        public int? Integral { get; set; }
        ///<summary>
        /// 
        /// </summary>
        [GDColoum(Name = "Nums", Length = 4)]
        public int? Nums { get; set; }
        ///<summary>
        /// 
        /// </summary>
        [GDColoum(Name = "Category", Length = 4, QueryType = QueryType.Average)]
        public int? Category { get; set; }
        ///<summary>
        /// 
        /// </summary>
        [GDColoum(Name = "GoodsType", Length = 4, QueryType = QueryType.Average)]
        public int? GoodsType { get; set; }
        ///<summary>
        /// 
        /// </summary>
        [GDColoum(Name = "Discount", Length = 10, QueryType = QueryType.Average)]
        public string Discount { get; set; }
        ///<summary>
        /// 
        /// </summary>
        [GDColoum(Name = "States", Length = 4, QueryType = QueryType.Average)]
        public int? States { get; set; }
        ///<summary>
        /// 
        /// </summary>
        [GDColoum(Name = "Dsctions", Length = 1000, QueryType = QueryType.Average)]
        public string Dsctions { get; set; }
        ///<summary>
        /// 创建时间
        /// </summary>
        [GDColoum(Name = "CreateTime", QueryType = QueryType.IsBetween)]
        public DateTime? CreateTime { get; set; }
        ///<summary>
        /// 
        /// </summary>
        [GDColoum(Name = "Weight", Length = 4, QueryType = QueryType.Average)]
        public int? Weight { get; set; }
        ///<summary>
        /// 
        /// </summary>
        [GDColoum(Name = "IsShelves", Length = 4, QueryType = QueryType.Average)]
        public int? IsShelves { get; set; }
        ///<summary>
        /// 限购数量
        /// </summary>
        [GDColoum(Name = "LimitBuy", Length = 4, QueryType = QueryType.Average)]
        public int? LimitBuy { get; set; }
        ///<summary>
        /// 是否用于拍卖上架
        /// </summary>
        [GDColoum(Name = "IsAuction", Length = 4, QueryType = QueryType.Average)]
        public int? IsAuction { get; set; }
        ///<summary>
        /// 是否可以用于积分兑换
        /// </summary>
        [GDColoum(Name = "IsExchange", Length = 4, QueryType = QueryType.Average)]
        public int? IsExchange { get; set; }
        ///<summary>
        /// 是否可以邮寄
        /// </summary>
        [GDColoum(Name = "IsMailing", Length = 4, QueryType = QueryType.Average)]
        public int? IsMailing { get; set; }
        ///<summary>
        /// 
        /// </summary>
        [GDColoum(Name = "IsVCode", Length = 4, QueryType = QueryType.Average)]
        public int? IsVCode { get; set; }
    }
}