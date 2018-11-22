using GDataBase;
using GDAttributes;

namespace GDataBS
{
    public class CommonBLL : MySQLDBHeper
    {
        public void Tbset()
        {
            MySQLDBHeper db = new MySQLDBHeper("junyin133");
            table1 tb1 = new GDataBS.table1()
            {
                //Id = 9,
                //Nums = "5"
            };
            //tb1.Add();
            //db.Add(tb1);
            //int r = db.ReturnAddId(tb1);
            //db.Delete(tb1);
            //string[] = { };
            //db.DeleteByConditon(tb1,);
        }
        public string Tet()
        {
            //ModelTe te = new GDataBS.ModelTe();
            //te.Id = 4;
            //te.Age = 1;
            //te.Name = "23";
            //te.Rember = "jgjh";
            //string[] r = { "Age", "Name", "Rember", "Id" };
            //DeleteByConditon(te, r);
            //Update(te);
            //Update(te, " and Age='' and Name=''");
            //Add(te);
            //AddByParameter(te);
            //List<ModelTe> list = new List<GDataBS.ModelTe>();
            //list.Add(te);
            //list.Add(te);
            //ListAdd(list);

            return "";
        }
    }
    public class table1
    {
        //[GDColoum(IsDescBy = true, IsKey = true)]
        //public int Id { get; set; }
        //[GDColoum(IsAdd = true, IsUpdate = true, Length = 50)]
        //public string Nums { get; set; }
    }
}