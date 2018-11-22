using GDataBase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDataBS.demo
{
    public partial class TemQRCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap bmp= MyStatesGTL.CreateTempQRCode("http://www.baidu.com");                        
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Jpeg);
            ms.WriteTo(Response.OutputStream);
            ms.Dispose();
        }
    }
}