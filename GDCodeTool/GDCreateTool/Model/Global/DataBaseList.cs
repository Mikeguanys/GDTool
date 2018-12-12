using GDAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDCreateTool.Model.Global
{
    public class DataBaseList
    {
        [GDColoum(QueryType = QueryType.Average, IsKey = true, Name = "DBTypeName", Length = 4)]
        public string DBTypeName { get; set; }
    }
}
