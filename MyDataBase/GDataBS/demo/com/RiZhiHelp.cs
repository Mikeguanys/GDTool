using GDataBase;

namespace GDataBS.demo.com
{
    public class RiZhiHelp : GDataBase.SQLServerDBHeper
    {
        public SQLServerBS bs;
        public RiZhiHelp()
        {

        }
        public RiZhiHelp(string con)
        {
            //bs = new SQLServerBS(con);
        }
    }
}