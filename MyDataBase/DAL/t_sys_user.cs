using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class t_sys_user
    {
        public int GetRowCounts()
        {
            //StackTrace st = new StackTrace(true);
            //StackFrame sf = st.GetFrame(0);
            //string ddd = sf.GetFileName();
            //return Convert.ToInt32(GetSingle("count(1)",""));              
            return 0;
        }

        public void GetList(ref System.Data.DataTable DataSour, ref int RowCount, int ThisPage, int PageSize, string Condition)
        {
            //StackTrace st = new StackTrace(true);
            //StackFrame sf = st.GetFrame(0);
            //string ddd = sf.GetFileName();
            //this.PagingList(ref DataSour, ref RowCount, ThisPage, PageSize, Condition,"");
        }

        public void _GetList(ref DataTable dt, ref int RowCount, int ThisPage, int PageSize, string Condition, string desc)
        {
            int PageCount = PageSize * (ThisPage - 1);
            string sql1 = string.Format(@"select top {0} * FROM {1} WHERE id NOT IN (SELECT top {2} id from {1} ORDER BY id) {3} ORDER BY id {4};", PageSize, "caidandb", PageCount, Condition, desc);

            string sql2 = string.Format(@"select count(1) FROM {0} where 1=1 {1} ", "caidandb", Condition);

            // GetPagingData(ref dt, ref RowCount, sql1 + sql2);
        }
        public string TestAddRetrun(string idname, string outName, string filename, string valuestr, string tablename, SqlParameter[] cmdParms)
        {
            //return this.OutAddAnyColum(idname, outName, filename, valuestr, tablename, cmdParms);
            return "";
        }

        public void Test()
        {
            //MySQLDBHeper db = new MySQLDBHeper();
            ////MySqlDataReader dr = db.BsGetDataReader("select * from dbl_register LIMIT 0,3");
            //TRR mode = db.GTSearch<TRR>("select * from dbl_advertisementimages LIMIT 0,1;");
            //MySQLDBHeper db1 =new MySQLDBHeper("junyin") ;
            //DataTable dt = db1.BsGetDataTable("select * from sig_users");
            //DataTable dt21 = db1.BsGetDataTable("select * from jy_group");
            //SQLiteDBHeper SQLitedb = new SQLiteDBHeper("constr");
            //DataTable dt = SQLitedb.BsGetDataTable("SELECT * FROM DataBaseList;");
            //DataTable dt1 = SQLitedb.BsGetDataTable("SELECT * FROM DataBaseList;");
        }
    }
    public class TRR
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string LinkURL { get; set; }
        public string Remark { get; set; }
        public int CreateUid { get; set; }
        public string CreateDate { get; set; }
        public int UpdateUid { get; set; }
        public string UpdateDate { get; set; }
    }
}
