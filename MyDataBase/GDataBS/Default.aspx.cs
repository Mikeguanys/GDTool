using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDataBS
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Class1 bll = new Class1();
                //DataTable dt=new DataTable ();
                //int rowcount=0;
                //bll.GetList2(ref dt, ref rowcount, 15, 1, "", "desc");
                string r=string.Empty;
                SqlParameter[] parameter={
                                         new SqlParameter("@ShuXingKey",SqlDbType.NVarChar,500),
                                         new SqlParameter("@ShuXingZhi",SqlDbType.NVarChar,500),
                                         new SqlParameter("@ShangPinKey",SqlDbType.NVarChar,500),
                                         new SqlParameter("@ShuXingZhuangTai",SqlDbType.Int),
                                         new SqlParameter("@KeyID",SqlDbType.NVarChar,500),
                                         };
                parameter[0].Value = "0";
                parameter[1].Value = "0";
                parameter[2].Value = "0";
                parameter[3].Value = 0;
                parameter[4].Direction = ParameterDirection.Output;
                string i = bll.Exected("Id","KeyID", "ShuXingKey,ShuXingZhi,ShangPinKey,ShuXingZhuangTai", "@ShuXingKey,@ShuXingZhi,@ShangPinKey,@ShuXingZhuangTai", "ShangPinShuXingDB", parameter);
            }
        }
    }
}