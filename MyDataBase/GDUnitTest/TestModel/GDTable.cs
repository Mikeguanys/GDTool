using GDAttributes;
using System;

namespace GDUnitTest.TestModel
{
    public class GDTable
    {
        [GDColoum(IsKey = true, IsIncrease = true)]
        public int? Id { get; set; }
        [GDColoum(IsKey = false)]
        public int? Nums { get; set; }
        [GDColoum(IsKey = false)]
        public decimal? Money { get; set; }
        [GDColoum(IsKey = false)]
        public float? Float { get; set; }
        [GDColoum(IsKey = false)]
        public string Name { get; set; }
        [GDColoum(IsKey = false)]
        public States? State { get; set; }
        [GDColoum(IsKey = false)]
        public bool? Sex { get; set; }
        [GDColoum(IsKey = false)]
        public DateTime? DateTime { get; set; }
        [GDColoum(IsKey = false)]
        public string Rember { get; set; }
        [GDColoum(IsKey = false)]
        public enum States
        {
            禁用,
            启用
        }
    }

}
