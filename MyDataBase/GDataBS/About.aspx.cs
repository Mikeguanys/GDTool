using GDAttributes;
using System;
using System.Web.UI;

namespace GDataBS
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CommonBLL bll = new GDataBS.CommonBLL();
            //bll.Tet();
            bll.Tbset();

        }
    }

    public class ModelTe
    {
        //[GDColoum(IsAdd = false, IsAscBy = false, IsDescBy = false, IsKey = true, IsUpdate = false, Name = "Id", Length = 100)]
        //public int Id { get; set; }
        //[GDColoum(IsAdd = true, IsUpdate = true)]
        //public string Name { get; set; }
        //[GDColoum(IsAdd = true, IsUpdate = true)]
        //public int Age { get; set; }
        //[GDColoum(IsAdd = true)]
        //public string Rember { get; set; }
    }
}