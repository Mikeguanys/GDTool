using GDateBase2v.GDTools;
using System;
using System.Linq.Expressions;

namespace GDUnitTest
{
    public class CMoth
    {
        public void GDOrderBy<T, TKey>(T t, Expression<Func<T, TKey>> keySelector)
        {
            var sf = keySelector.DealExpress();
        }
        public void GDOrderBy1<T, TKey>(T t, Expression<Func<T, TKey>> keySelector)
        {
            var sf = keySelector.DealExpress();
        }
    }
}
