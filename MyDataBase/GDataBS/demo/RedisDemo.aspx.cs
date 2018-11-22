using GDataBS.demo.com;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDataBS.demo
{
    public partial class RedisDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ComHelper hel = new ComHelper();
            //using (var redis = hel.RedisDB())
            //{
            //    DataTable dt = new DataTable();
            //    redis.Set<DataTable>("OrderNo", dt);

            //    int r= redis.Get<int>("OrderNo");
            //}
        }
    }
}