using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class testpro
    {
        public void testproS()
        {
            SqlParameter[] parm ={
                                new SqlParameter("@OrderNo",SqlDbType.VarChar,200),
                                new SqlParameter("@OrderStates",SqlDbType.VarChar,200),
                                new SqlParameter("@OperType",SqlDbType.VarChar,200),
                                new SqlParameter("@BillOperType",SqlDbType.VarChar,200),
                                new SqlParameter("@BillType",SqlDbType.VarChar,200),
                                new SqlParameter("@before",SqlDbType.VarChar,200),
                                new SqlParameter("@after",SqlDbType.VarChar,200),
                                };
            parm[0].Value = "010071609211729039";
            parm[1].Value = 1;
            parm[2].Value = 1;
            parm[3].Value = 1;
            parm[4].Value = 1;
            parm[5].Value = 1;
            parm[6].Value = 1;

            // string a = this.StringExecuteStorage("OrderOperatingDB", parm);
            //return "";
        }
    }
}
