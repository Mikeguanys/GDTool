using GDAttributes;
using System;

namespace GDataBS
{
    public class GT_Pro_GetTicketList
    {
        [GDColoum(QueryType = QueryType.Average, Name = "UserId", Length = 100)]
        public int? UserId { get; set; }
        [GDColoum(QueryType = QueryType.Average, Name = "GoodId", Length = 100)]
        public int? GoodId { get; set; }
        [GDColoum(QueryType = QueryType.Average, Name = "States", Length = 100)]
        public States? States { get; set; }
        [GDColoum(QueryType = QueryType.Average, Name = "GTNULL", Length = 100)]
        public string GTNULL { get; set; }
        [GDColoum(QueryType = QueryType.Average, Name = "GTNULL", Length = 100)]
        public DateTime DateTimes { get; set; }

    }
    public enum States
    {
        qiyong,
        jinyong
    }
}