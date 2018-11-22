using BLL;
using DAL;
using GDataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDataBS
{
    public partial class TestMySQL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Class1 class1 = new Class1();
            //int Count = class1.GetRows();
            //DataTable dt = new DataTable();
            //int RowCount = 0;
            //class1.GetList(ref dt,ref RowCount,0,10,"");
            //GDataBase.MyGT gt = new GDataBase.MyGT();
            //gt.WriteFile("gjaskdfj");
            //gt.WriteFile("你好啊", "C:\\yy.txt");
            //gt.WriteFile("(｡･∀･)ﾉﾞ嗨","C:\\yut.txt","ttyt");
            CreateQRCode();
        }
        private void CreateQRCode()
        {
            //string a =string.Empty;
            //string bpath = string.Empty;
            //float af = (float)1.0;
            //bpath=MyStatesGTL.CreateQRCode("http://www.baidu.com", "E:\\MyProject\\MyDataBase\\GDataBS\\Images\\", ref a);
            //MyStatesGTL.DrawImage(bpath, "E:\\MyProject\\MyDataBase\\GDataBS\\Images\\log.png", af, ImagePosition.Center, "E:\\", DateTime.Now.ToString("yyyymmddhhmmss"));
            //Images.ImageUrl ="/images/"+a;

            //http://m.lepin168.com/Shanghu/BeiTuiguang/78DD3568-F2C2-4F83-B658-D943D230CA91
            Bitmap bmp = MyStatesGTL.CreateQRCodeWithLogo("http://www.baidu.com", Get_img("http://img.lepin168.com/upload/file/20170216/6362285766793600009713878.gif"));
            string path = DateTime.Now.ToString("yyyymmddhhmmss") + ".jpg";
            System.Drawing.Image imgPhoto = new System.Drawing.Bitmap(bmp);
            imgPhoto.Save("E:\\MyProject\\MyDataBase\\GDataBS\\Images\\" + path);
            imgPhoto.Dispose();
            //System.Drawing.Image imgPhotodes = new System.Drawing.Bitmap("E:\\MyProject\\MyDataBase\\GDataBS\\Images\\log.png");
            //imgPhotodes.Dispose();
            Images.ImageUrl = "/Images/" + path;
          //Graphics grWatermark = Graphics.FromImage(bmp);
          //bmp.Save("E:\\MyProject\\MyDataBase\\GDataBS\\Images\\" + DateTime.Now.ToString("yyyymmddhhmmss")+".jpg");
          //bmp.Dispose();
        }
        public Bitmap Get_img(string Image)
        {
            Bitmap img = null;
            HttpWebRequest req;
            HttpWebResponse res = null;           
            try
            {
                System.Uri httpUrl = new System.Uri(Image);
                req = (HttpWebRequest)(WebRequest.Create(httpUrl));
                req.Timeout = 180000; //设置超时值10秒
                //req.UserAgent = "XXXXX";
                //req.Accept = "XXXXXX";
                MemoryStream ms = new MemoryStream();
                req.Method = "GET";
                res = (HttpWebResponse)(req.GetResponse());
                img = new Bitmap(res.GetResponseStream());
            }

            catch (Exception ex)
            {
                string aa = ex.Message;
            }
            finally
            {
                res.Close();
            }
            return img;
        }
    }
}