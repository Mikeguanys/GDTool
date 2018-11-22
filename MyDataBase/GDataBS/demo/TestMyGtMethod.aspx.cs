using BLL;
using GDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDataBS.demo
{
    public partial class TestMyGtMethod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                           
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Click(object sender, EventArgs e)
        {
            TestWx testback=new TestWx ();
            string a = testback.WxBack();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnToMD5_Click(object sender, EventArgs e)
        {
            MyGT gt = new MyGT();
            string IsJM = gt.ToMD5_16(txttxt.Text);
            string IsJM1 = gt.ToMD5_32(txttxt.Text);
            string IsBase64 = gt.ToBase64(txttxt.Text);
            string Dec = gt.DecBase64("Z2F1bnlz");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            testpro bll = new testpro();
            bll.testproS();
        }
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            string ImageName = string.Empty;
            string a = MyStatesGTL.CreateQRCode("http://www.baidu.com", "C:", ref ImageName);
            Img.ImageUrl = a;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //MyStatesGTL.CreateTempQRCode("http://www.baidu.com");
        }
    }
}