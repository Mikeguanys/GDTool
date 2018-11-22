using GDataBase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GDataBS
{
    public partial class ServerTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GT_GoodsDT dt = new GDataBS.GT_GoodsDT();
            var Goods = new GT_GoodsDT();// { }.OrderByDesc();
            //Action 相当于定义好的委托
            Action<string> BookAction = new Action<string>(Book);
            BookAction("小明吗");
        }
        public void Book(string BookName)
        {
            Response.Write(string.Format("我是买书的是:{0}", BookName));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Func 有返回值的委托
            Func<string, string> RetBook = new Func<string, string>(FuncBook);
            Response.Write(RetBook("aaa"));
            Func<string> funcValue = delegate
            {
                return "我是即将传递的值3";
            };
            DisPlayValue(funcValue);
        }
        public string FuncBook(string BookName)
        {
            return BookName;
        }
        private void DisPlayValue(Func<string> func)
        {
            string RetFunc = func();
            Response.Write(string.Format(@"我在测试一下传过来值：{0}", RetFunc));
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            GT_GoodsDT dt = new GDataBS.GT_GoodsDT();
            var r = new GT_GoodsDT().GTSearchCondition("");


            string sdf = dt?.GoodsName;
            List<GT_GoodsDT> listdt = new List<GT_GoodsDT>();
            DateTime df = Convert.ToDateTime("2018-06-15").AddDays(1);
            listdt.Where(w => w.GoodsName == "hg");
            //string rs = "抵消";
            //var r = new GT_GoodsDT().GTMListByParameter();
            //var rd = r.Where(w => w.GoodsName.Contains(rs)).ToList();
            //var Goods = new GT_GoodsDT().OrderByDesc(s => s.CreateTime >= df && s.CreateTime <= df);
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            //var r = new GT_Pro_GetTicketList() { States = States.jinyong, GTNULL = "" }.GTInfo(s=>s.GoodId);
            var r = new GT_GoodsDT().GTInfo(s => s.GoodsName == null);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string ghgh = CeShi();
            var t = new GDataBS.GT_Pro_GetTicketList().GTInfo(w => w.GTNULL == ghgh);
        }
        public string CeShi()
        {
            return "我是返回数";
        }
    }
}