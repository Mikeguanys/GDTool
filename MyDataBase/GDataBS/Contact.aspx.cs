using GDataBase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDataBS
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //MyGT gt = new MyGT();
            //string a= gt.ToMD5_32("123456");
            string jsondata = "[{\"Chicun\": \"6寸\",\"Chengzhong\": \"1磅\",\"Jiage\":0.01,\"TiJi\": \"13CMx13CM\",\"CanJu\":8},{\"Chicun\": \"8寸\",\"Chengzhong\": \"2磅\",\"Jiage\": 0.02,\"TiJi\": \"15CMx15CM\",\"CanJu\":9},{\"Chicun\": \"10寸\",\"Chengzhong\": \"3磅\",\"Jiage\":0.03,\"TiJi\": \"17CMx17CM\",\"CanJu\": 10},{\"Chicun\": \"12寸\",\"Chengzhong\": \"4磅\",\"Jiage\": 0.04,\"TiJi\": \"19CMx19CM\",\"CanJu\":11},{\"Chicun\": \"14寸\",\"Chengzhong\": \"5磅\",\"Jiage\": 0.05,\"TiJi\": \"21CMx21CM\",\"CanJu\":12}]";

            List<NewModel> model = jsondata.JsonToListModel<NewModel>();
            
        }
    }
    public class NewModel
    {
        public string Chicun { get; set; }
        public string Chengzhong { get; set; }
        public string Jiage { get; set; }
        public string TiJi { get; set; }
        public int CanJu { get; set; }
    }
}