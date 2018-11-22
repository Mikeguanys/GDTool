using System.Data;

namespace BLL
{
    public class TestMysSql
    {
        public DataTable GetList()
        {
            DAL.TestMysql dal = new DAL.TestMysql();
            return dal._GetList();
        }

        public void TestWrite(string txt)
        {
            DAL.TestMysql dal = new DAL.TestMysql();
            //dal.WriteFile(txt);
        }
    }
}
