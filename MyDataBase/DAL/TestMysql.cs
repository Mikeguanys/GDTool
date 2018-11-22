using System.Data;

namespace DAL
{
    public class TestMysql
    {
        public DataTable _GetList()
        {
            return new DataTable();
            //return GetDataTable("select * from UserAdminData");
        }
    }
}
