using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDCreateTool.Comm
{
    public class FormComm
    {
        public FormComm(Form from)
        {
            from.StartPosition = FormStartPosition.CenterScreen;
            from.MaximizeBox = false;
            from.MinimizeBox = false;
            from.FormBorderStyle = FormBorderStyle.FixedDialog;
            from.Icon  = new System.Drawing.Icon("Images\\favicon-20180908113717507.ico");
        }        
    }
}
