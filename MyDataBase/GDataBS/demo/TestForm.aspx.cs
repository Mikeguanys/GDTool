using GDataBS.demo.com;
using System;

namespace GDataBS.demo
{
    public partial class TestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RiZhiHelp help = new RiZhiHelp("RiZhiOnlineStr");
            //            System.Data.DataTable dt= help.bs.GetDataTable("select * from caidandb");
            //ComHelper chelps = new ComHelper();
            //System.Data.DataTable dt = help.GetDataTable("select * from caidandb");            
            //DataTable dt = help.bs.GetDataTable("select * from MenDianLiuLiangDB");
        }
    }
}