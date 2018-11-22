using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Class1
    {
        t_sys_user user = new t_sys_user();
        public int GetRows()
        {            
            return user.GetRowCounts();
        }

        public void GetList(ref System.Data.DataTable DataSour, ref int RowCount, int ThisPage, int PageSize, string Condition)
        {
            user.GetList(ref DataSour, ref RowCount, ThisPage, PageSize, Condition);   
        }
        /// <summary>
        /// 获取分页数据列表
        /// </summary>
        public void GetList2(ref System.Data.DataTable DataSour, ref int RowCount, int ThisPage, int PageSize, string Condition,string desc)
        {
            user._GetList(ref DataSour,ref RowCount, ThisPage, PageSize, Condition, desc);
        }

        public string Exected(string idname,string outName, string filename, string valuestr, string tablename, SqlParameter[] cmdParms)
        {
           return user.TestAddRetrun(idname,outName, filename, valuestr, tablename, cmdParms);
        }
        public void Testbll()
        {
            t_sys_user tr = new t_sys_user();
            tr.Test();
        }
    }
}
