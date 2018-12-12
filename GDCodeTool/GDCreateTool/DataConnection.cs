using System;
using System.Windows.Forms;
using InsideComm;
using GDCreateTool.Comm.Enum;
using GDCreateTool.Model;
using GDateBase2v.SQLite;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SQLite;

namespace GDCreateTool
{
    public partial class DataConnection : Form
    {
        public static List<DBLogin> ListModel = new List<DBLogin>();
        private string ConnectionStr = null;
        public DataConnection()
        {
            InitializeComponent();
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {

            this.Enabled = false;
            Connection();
            this.Enabled = true;

        }

        private void btnConnection_Click(object sender, EventArgs e)
        {

            this.Enabled = false;
            if (Connection(false))
            {
                new MainWindow().ShowDialog();
            }
            this.Enabled = true;

        }

        private bool VerData()
        {
            if (string.IsNullOrEmpty(txtDataBaseName.Text))
            {
                MessageBox.Show("数据库名不能为空。");
                return false;
            }
            else if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("用户名不能为空。");
                return false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("密码不能为空。");
                return false;
            }
            else if (string.IsNullOrEmpty(SelDataType.Text))
            {
                MessageBox.Show("数据库类型不能为空。");
                return false;
            }
            else if (string.IsNullOrEmpty(SelIp.Text))
            {
                MessageBox.Show("服务器地址不能为空。");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void DataConnection_Load(object sender, EventArgs e)
        {
            try
            {
                ListModel = new DBLogin().GDList(null);
                if (ListModel != null)
                {
                    var db = SysTool.EnumToList<EDType>();
                    SelDataType.SelectedIndexChanged -= new EventHandler(SelDataType_SelectedIndexChanged);
                    SelDataType.DataSource = db;
                    var IsReadModel = ListModel.Where(w => w.IsRead == 1);
                    if (IsReadModel.Count()==0)
                    {
                        var rs = ListModel.First();
                        BindData(rs);
                        SelDataType.SelectedIndex = 0;
                        BindIp(rs.BaseName, rs.Ip);
                    }
                    else
                    {
                        var ReadFirst = IsReadModel.First();
                        BindData(ReadFirst);
                        SelDataType.Text = ReadFirst.BaseName;
                        BindIp(ReadFirst.BaseName, ReadFirst.Ip);
                    }
                    SelDataType.SelectedIndexChanged += new EventHandler(SelDataType_SelectedIndexChanged);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误：" + ex.Message);
            }
        }
        private void BindData(DBLogin Model)
        {
            txtDataBaseName.Text = Model.DataName;
            txtUserName.Text = Model.UserName;
            txtPassword.Text = Model.PassWord;
            txtPort.Text = Model.Port;
            ckbRember.Checked = (Model.IsRead == 1);
        }
        //绑定IP
        private void BindIp(string BaseName, string Ip)
        {
            if (ListModel != null)
            {
                SelIp.SelectedIndexChanged -= new EventHandler(SelIp_SelectedIndexChanged);
                SelIp.DataSource = ListModel.Where(w => w.BaseName == BaseName).Select(s => new { s.Id, s.Ip }).ToList();
                SelIp.DisplayMember = "Ip";
                SelIp.ValueMember = "Id";
                SelIp.Text = Ip;
                SelIp.SelectedIndexChanged += new EventHandler(SelIp_SelectedIndexChanged);
            }
        }
        private void ClareBind()
        {
            txtDataBaseName.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtPort.Text = "";
            ckbRember.Checked = false;
        }
        private void SelDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string DataType = SelDataType.Text;
            var r = ListModel.Where(w => w.BaseName == DataType).ToList();
            if (r.Count > 0)
            {
                var model = r.First();
                BindData(model);
                BindIp(DataType, model.Ip);
            }
            else
            {
                SelIp.DataSource = null;
                ClareBind();
            }
        }

        private void SelIp_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(SelIp.SelectedValue.ToString());
            var r = ListModel.Where(w => w.Id == Id).First();
            BindData(r);
        }

        private bool Connection(bool IsTest = true)
        {
            if (!VerData())
            {
                return false;
            }
            bool r = false;
            try
            {
                if (SelDataType.Text == EDType.SQLServer.ToString())
                {
                    ConnectionStr = $"Data Source = {SelIp.Text + (string.IsNullOrEmpty(txtPort.Text) ? "" : (",") + txtPort.Text)};Initial Catalog = {txtDataBaseName.Text};User Id = {txtUserName.Text};Password = {txtPassword.Text};";
                    using (SqlConnection conn = new SqlConnection(ConnectionStr))
                    {
                        conn.Open();
                        if (conn.State == ConnectionState.Open)
                        {
                            r = true;
                        }
                    }
                }
                else if (SelDataType.Text == EDType.MySQL.ToString())
                {
                    ConnectionStr = $"Server={SelIp.Text}:{txtPort.Text};Database={txtDataBaseName.Text};Uid={txtUserName.Text};pwd={txtPassword.Text};Pooling=true;MAX Pool Size=512;Min Pool Size=0;Connection Lifetime=80000;Character Set=utf8mb4;";
                    using (MySqlConnection conn = new MySqlConnection(ConnectionStr))
                    {
                        conn.Open();
                        if (conn.State == ConnectionState.Open)
                        {
                            r = true;
                        }
                    }
                }
                else if (SelDataType.Text == EDType.SQLite.ToString())
                {
                    SQLiteConnection Connection = new SQLiteConnection();
                }
                else if (SelDataType.Text == EDType.Redis.ToString())
                {

                }
                //判断是否为测试连接
                if (!IsTest)
                {
                    UpdateConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败。" + ex.Message);
                return false;
            }
            if (r)
            {
                MessageBox.Show("测试连接成功。");
            }
            else
            {
                MessageBox.Show("连接失败，请检查各项是否正确。");
            }
            return r;
        }
        /// <summary>
        /// 修改记录连接
        /// </summary>
        /// <returns></returns>
        private bool UpdateConnection()
        {
            if (ckbRember.Checked)
            {
                new DBLogin() { IsRead = 0 }.GDUpdate();
            }
            string DataBaseType = SelDataType.Text;
            string Ip = SelIp.Text;
            string DataName = txtDataBaseName.Text;
            string UserName = txtUserName.Text;
            string Port = txtPort.Text;
            int IsRead = (ckbRember.Checked ? 1 : 0);
            int Id = Convert.ToInt32(SelIp.SelectedValue.ToString() == "" ? "0" : SelIp.SelectedValue.ToString());
            int c = new DBLogin().GDList(w => w.BaseName == DataBaseType && w.Ip == Ip && w.Port == Port && w.DataName == DataName && w.UserName == UserName).Count();
            DBLogin dbModel = new DBLogin()
            {
                BaseName = DataBaseType,
                Ip = Ip,
                Port = txtPort.Text,
                DataName = DataName,
                IsRead = IsRead,
                PassWord = txtPassword.Text,
                UserName = txtUserName.Text
            };
            if (c > 0)
            {
                return dbModel.GDUpdate(w => w.Id == Id);
            }
            else
            {
                return dbModel.GDAdd();
            }
        }
    }
}
